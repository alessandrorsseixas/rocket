using AutoMapper;
using ClienteApi.Domain.SeedWorks.Classes;
using ClienteApi.Domain.SeedWorks.Interfaces;
using CursoMauriciomoitinho.Domain.Mocks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientWebApi.Controller
{
    [Route("v{version:apiVersion}/main")]
    [ApiController]
    public class MainController : ControllerBase
    {
        //GET: 
        //Retorne 200(OK) para caso de sucesso V
        //Retorne 404 (NOT FOUND) se a entidade não for encontrada V
        //POST: 
        //Retorne 201 (CREATED) para caso um novo recurso seja criado com sucesso V
        //Retorne 400 (BAD REQUEST) caso a solicitação contenha dados inválidos
        //Retorne 422 (Unprocessable Entity) caso a solicitação caia em alguma regra de negócio 
        //PUT:
        //Retorne 200 (OK) se for atualizar um recurso existente
        //Retorne 400 (BAD REQUEST) caso a solicitação contenha dados inválidos
        //Considere utilizar 409 (CONFLICT) caso não consiga atualizar um recurso existente
        //DELETE:
        //Retorne 204 (No Content) para sucesso
        //Retorne 404 (NOT FOUND) se a entidade não for encontrada

        private readonly INotificator _notificator;
        protected ICollection<string> Errors = new List<string>();
        private List<Notification> notifications { get; set; }
        public Notification notification = new Notification();

        private readonly IUrlHelper _urlHelper;
        public MainController(
                             INotificator notificator,
                             IUrlHelper urlHelper
   )
        {
            _notificator = notificator;
            _urlHelper = urlHelper;


        }

        protected async System.Threading.Tasks.Task<ActionResult> CustomResponse([ActionResultStatusCode] int statusCode,
                                               TimeSpan processingTime,
                                               [ActionResultObjectValue] object data = null,
                                               object errors = null,
                                               int currentPage = 1,
                                               int totalItems = 1,
                                               int totalPages = 1)
        {
            notifications = NotificationMessageMock.GetListMocks();

            switch (statusCode)
            {
                case 200:

                    if (data != null)
                    {
                        notification = notifications.Where(x => x.CodeNumber == 1).SingleOrDefault();

                        return Ok(GetWebApiReturn(true,
                                                      statusCode,
                                                      processingTime,
                                                      data,
                                                      null,
                                                      notification.Message,
                                                      notification.Description,
                                                      notification.CodeNumber,
                                                      currentPage,
                                                      totalItems,
                                                      totalPages
                            ));

                    }
                    else
                    {
                        notification = notifications.Where(x => x.CodeNumber == 2).SingleOrDefault();
                        return Ok(GetWebApiReturn(true,
                                            statusCode,
                                            processingTime,
                                            data,
                                            null,
                                            notification.Message,
                                            notification.Description,
                                            notification.CodeNumber,
                                            currentPage,
                                            totalItems,
                                            totalPages
                             ));

                    }
                case 201:
                    notification = notifications.Where(x => x.CodeNumber == 201).SingleOrDefault();

                    return StatusCode(201, GetWebApiReturn(true,
                                                      statusCode,
                                                      processingTime,
                                                      data,
                                                      null,
                                                      notification.Message,
                                                      notification.Description,
                                                      notification.CodeNumber,
                                                      currentPage,
                                                      totalItems,
                                                      totalPages
                    ));

                case 204:
                    notification = notifications.Where(x => x.CodeNumber == 204).SingleOrDefault();
                    return StatusCode(204, GetWebApiReturn(false,
                                                      statusCode,
                                                      processingTime,
                                                      null,
                                                      null,
                                                      notification.Message,
                                                      notification.Description,
                                                      notification.CodeNumber,
                                                      currentPage,
                                                      totalItems,
                                                      totalPages
                    ));

                case 400:
                    if (errors != null)
                    {
                        notification = notifications.Where(x => x.CodeNumber == 409).SingleOrDefault();
                        return StatusCode(400, GetWebApiReturn(
                                            false,
                                            statusCode,
                                            processingTime,
                                            null,
                                            data,
                                            notification.Message,
                                            notification.Description,
                                            notification.CodeNumber,
                                            currentPage,
                                            totalItems,
                                            totalPages
                        ));

                    }
                    else
                    {
                        notification = notifications.Where(x => x.CodeNumber == 409).SingleOrDefault();
                        return StatusCode(400, GetWebApiReturn(false,
                                            statusCode,
                                            processingTime,
                                            null,
                                            null,
                                            notification.Message,
                                            notification.Description,
                                            notification.CodeNumber,
                                            currentPage,
                                            totalItems,
                                            totalPages
                        ));

                    }
                case 404:
                    notification = notifications.Where(x => x.CodeNumber == 4).SingleOrDefault();
                    return StatusCode(404, GetWebApiReturn(false,
                                            statusCode,
                                            processingTime,
                                            null,
                                            null,
                                            notification.Message,
                                            notification.Description,
                                            notification.CodeNumber,
                                            currentPage,
                                            totalItems,
                                            totalPages
                    ));


                case 409:
                    notification = notifications.Where(x => x.CodeNumber == 409).SingleOrDefault();
                    return StatusCode(statusCode, GetWebApiReturn(false,
                                            statusCode,
                                            processingTime,
                                            null,
                                            null,
                                            notification.Message,
                                            notification.Description,
                                            notification.CodeNumber,
                                            currentPage,
                                            totalItems,
                                            totalPages
                    ));
                case 422:
                    if (errors != null)
                    {
                        notification = notifications.Where(x => x.CodeNumber == 409).SingleOrDefault();
                        return StatusCode(statusCode, GetWebApiReturn(
                                            false,
                                            statusCode,
                                            processingTime,
                                            null,
                                            errors,
                                            notification.Message,
                                            notification.Description,
                                            notification.CodeNumber,
                                            currentPage,
                                            totalItems,
                                            totalPages
                        ));

                    }
                    else
                    {
                        notification = notifications.Where(x => x.CodeNumber == 409).SingleOrDefault();
                        return StatusCode(statusCode, GetWebApiReturn(false,
                                            statusCode,
                                            processingTime,
                                            null,
                                            null,
                                            notification.Message,
                                            notification.Description,
                                            notification.CodeNumber,
                                            currentPage,
                                            totalItems,
                                            totalPages
                        ));

                    }
                case 500:

                    notification = notifications.Where(x => x.CodeNumber == 500).SingleOrDefault();

                    return StatusCode(statusCode, GetWebApiReturn(false,
                                        statusCode,
                                        processingTime,
                                        null,
                                        data,
                                        notification.Message,
                                        notification.Description,
                                        notification.CodeNumber,
                                        currentPage,
                                        totalItems,
                                        totalPages
                    ));

                default:
                    return Ok();
            }
        }

        protected WebApiReturn GetWebApiReturn(bool transactionExecute,
                                                [ActionResultStatusCode] int statusCode,
                                                TimeSpan processingTime,
                                               [ActionResultObjectValue] object data = null,
                                               object errors = null,
                                               string notification = "",
                                               string notificationDescription = "",
                                               int notificationcode = 0,
                                               int currentPage = 1,
                                               int totalItems = 1,
                                               int totalPages = 1)
        {


            return new WebApiReturn
            {
                CurrentPage = data == null ? 0 : currentPage,
                RunBy = "system",
                ProcessorAt = DateTime.Now,
                Data = data,
                Errors = errors,
                Message = notification,
                Messagecode = notificationcode,
                MessageTitle = notificationDescription,
                ProcessingTime = processingTime.TotalSeconds,
                StatusCode = data == null ? 0 : statusCode,
                TransactionExecute = transactionExecute,
                TotalItems = data == null ? 0 : totalItems,
                TotalPages = data == null ? 0 : totalPages
            };
        }

        [HttpOptions]
        protected IActionResult AllowOperations()
        {

            Response.Headers.Add("ALLOW", "GET,POST,PUT,PATCH,OPTIONS");
            return Ok();
        }

    }
}
