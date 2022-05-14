using AutoMapper;
using ClienteApi.Domain.Entities;
using ClienteApi.Domain.SeedWorks.Classes;
using ClienteApi.Domain.SeedWorks.Interfaces;
using ClienteApi.Domain.SeedWorks.Interfaces.Services;
using ClienteApi.Valitation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ClientWebApi.Controller.v1
{
    [Route("v{version:apiVersion}/clientes")]
    [ApiController]
    public class ClientesController : MainController
    {

        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;
        private INotificator _notificator;
        public static IWebHostEnvironment _environment;
        private readonly IUrlHelper _urlHelper;
        private readonly ILogger _logger;


        public ClientesController(IClienteService clienteService,
                                          IWebHostEnvironment environment,
                                          IMapper mapper,
                                          INotificator notificator,
                                          IUrlHelper urlHelper)
                                         
           : base(notificator, urlHelper)
        {
            _clienteService = clienteService;
            _environment = environment;
            _mapper = mapper;
            _notificator = notificator;
            _urlHelper = urlHelper;
        }


        [HttpGet("list-clientes")]
        //[EnableQuery()]
        public async Task<IActionResult> GetAll([FromQuery] UrlQueryParameters urlQueryParameters,
                                    CancellationToken cancellationToken)
        {

            try
            {
                TimeSpan processingTime;
                var stopwatch = new Stopwatch();
                stopwatch.Start();

                var _clientes = await _clienteService.GetAll
                                         (
                                             x => x.Id > 0,
                                             urlQueryParameters.Page,
                                             urlQueryParameters.Size,
                                             urlQueryParameters.Sort,
                                             urlQueryParameters.Order,
                                             cancellationToken
                                         );

                var _clientesViewModel = _mapper.Map<List<ClienteViewModel>>(_clientes.Items);

                if (!_clientesViewModel.Any())
                {
                    stopwatch.Stop();
                    processingTime = stopwatch.Elapsed;
                    return await CustomResponse(404, processingTime);
                }


                stopwatch.Stop();
                processingTime = stopwatch.Elapsed;



                return await CustomResponse(200,
                                     processingTime,
                                     _clientesViewModel,
                                     null,
                                     _clientes.CurrentPage,
                                     _clientes.TotalItems,
                                     _clientes.TotalPages);
            }
            catch (Exception ex)
            {
                return await CustomResponse(500, new TimeSpan(), ex.Message);

            }


        }



        [HttpGet("{id:guid}", Name = "get-cliente-by-code")]
        public async Task<IActionResult> GetByCode(Guid id)
        {


            try
            {
                TimeSpan processingTime;
                var stopwatch = new Stopwatch();
                stopwatch.Start();

                var _cliente = await _clienteService.Get(x => x.Code == id);
                if (_cliente == null || _cliente.Count() == 0)
                {
                    stopwatch.Stop();
                    processingTime = stopwatch.Elapsed;
                    return await CustomResponse(404, processingTime);

                }

                stopwatch.Stop();
                processingTime = stopwatch.Elapsed;


                var _clienteModel = _mapper.Map<ClienteViewModel>(_cliente.SingleOrDefault());

                return await CustomResponse(200, processingTime, _clienteModel, null);
            }
            catch (Exception ex)
            {
                return await CustomResponse(500, new TimeSpan(), ex.Message);

            }

        }


        [HttpPost("add-cliente")]
        public async Task<IActionResult> Add([FromBody] ClienteViewModel clienteViewModel)
        {

            try
            {
                TimeSpan processingTime;
                var stopwatch = new Stopwatch();
                stopwatch.Start();

                var _cliente = _mapper.Map<Cliente>(clienteViewModel);

                _cliente.SetNotificator(_notificator);

                if (await _clienteService.Exist(_cliente))
                {
                    stopwatch.Stop();
                    processingTime = stopwatch.Elapsed;
                    return await CustomResponse(422, processingTime, clienteViewModel);

                }

                if (!_cliente.IsValideObject(new ClienteValidation(), _cliente))
                {
                    stopwatch.Stop();
                    processingTime = stopwatch.Elapsed;
                    return await CustomResponse(422, processingTime, clienteViewModel, _cliente.GetNotifications());

                }


                stopwatch.Stop();
                processingTime = stopwatch.Elapsed;

                _cliente.Code = _cliente.Code == Guid.Empty ? Guid.NewGuid() : _cliente.Code;
           
                await _clienteService.Add(_cliente);
                return await CustomResponse(201, processingTime, _mapper.Map<ClienteViewModel>(_cliente));

            }
            catch (Exception ex)
            {
                return await CustomResponse(500, new TimeSpan(), ex.Message);

            }
        }


        [HttpPut("update-cliente")]
        public async Task<IActionResult> Update([FromBody] ClienteViewModel clienteViewModel)
        {
            try
            {
                TimeSpan processingTime;
                var stopwatch = new Stopwatch();
                stopwatch.Start();

                var _cliente = _mapper.Map<Cliente>(clienteViewModel);



                _cliente.Id = _clienteService.GetId(_cliente.Code);


                if (!await _clienteService.Exist(_cliente))
                {
                    stopwatch.Stop();
                    processingTime = stopwatch.Elapsed;

                    return await CustomResponse(409, processingTime, clienteViewModel);
                }

                if (!_cliente.IsValideObject(new ClienteValidation(), _cliente))
                {
                    stopwatch.Stop();
                    processingTime = stopwatch.Elapsed;
                    return await CustomResponse(409, processingTime, clienteViewModel, _cliente.GetNotifications());

                }

                await _clienteService.Update(_cliente);
                stopwatch.Stop();
                processingTime = stopwatch.Elapsed;


                return await CustomResponse(200, processingTime);
            }
            catch (Exception ex)
            {
                return await CustomResponse(500, new TimeSpan(), ex.Message);

            }
        }



        [HttpDelete("{id:guid}", Name = "delete-cliente")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                TimeSpan processingTime;
                var stopwatch = new Stopwatch();
                stopwatch.Start();

                var _cliente = await _clienteService.GetByCode(id);

                if (_cliente == null)
                {
                    stopwatch.Stop();
                    processingTime = stopwatch.Elapsed;

                    return await CustomResponse(409, processingTime, id);
                }


                await _clienteService.Delete(_cliente);
                stopwatch.Stop();
                processingTime = stopwatch.Elapsed;

                return await CustomResponse(200, processingTime);
            }
            catch (Exception ex)
            {
                return await CustomResponse(500, new TimeSpan(), ex.Message);

            }
        }


    }
}
