using ClienteApi.Domain.Entities;
using ClienteApi.Domain.SeedWorks.Classes;
using ClienteApi.Domain.SeedWorks.Interfaces.Repositories;
using ClienteApi.Domain.SeedWorks.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClientApi.Service.Service
{
    public class ClienteService : IClienteService
    {
        public readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository ClienteRepository)
        {
            _clienteRepository = ClienteRepository;
        }
        public async Task Add(Cliente cliente)
        {
            try
            {
                await _clienteRepository.Add(cliente);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Delete(Cliente cliente)
        {
            try
            {
                await _clienteRepository.Delete(cliente);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {
            try
            {
                _clienteRepository.Dispose();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Exist(Cliente cliente)
        {
            try
            {
                return await _clienteRepository.Exist(cliente);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Cliente>> Get
            (
                Expression<Func<Cliente, bool>> predicate
            )
        {
            try
            {
                return await _clienteRepository.Get(predicate);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<PagedModel<Cliente>> GetAll
            (
                Expression<Func<Cliente, bool>> predicate,
                int page,
                int size,
                string sort,
                bool orderByAsc,
                CancellationToken cancellationToken
            )
        {
            try
            {
                return await _clienteRepository.GetAll(predicate, page, size, sort, orderByAsc, cancellationToken);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Cliente>> GetAll()
        {
            try
            {
                return await _clienteRepository.GetAllAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<Cliente> GetByCode(Guid code)
        {
            try
            {
                return await _clienteRepository.GetByCode(code);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Cliente> GetById(int id)
        {
            try
            {
                return await _clienteRepository.GetById(id);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetId(Guid code)
        {
            try
            {
                return _clienteRepository.GetId(code);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Update(Cliente cliente)
        {
            try
            {
                await _clienteRepository.Update(cliente);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
