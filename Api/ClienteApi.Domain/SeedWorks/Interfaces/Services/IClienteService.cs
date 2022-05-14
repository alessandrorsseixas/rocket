using ClienteApi.Domain.Entities;
using ClienteApi.Domain.SeedWorks.Classes;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace ClienteApi.Domain.SeedWorks.Interfaces.Services
{
    public interface IClienteService: IDisposable
    {
        Task Add(Cliente Cliente);
        Task<IEnumerable<Cliente>> Get(Expression<Func<Cliente, bool>> predicate);
        Task<Cliente> GetByCode(Guid code);
        Task<Cliente> GetById(int id);
        Task<List<Cliente>> GetAll();
        Task<PagedModel<Cliente>> GetAll(Expression<Func<Cliente, bool>> predicate, int page, int size, string sort, bool orderByAsc, CancellationToken cancellationToken);
        Task Update(Cliente Cliente);
        Task<bool> Exist(Cliente Cliente);
        Task Delete(Cliente Cliente);
        int GetId(Guid code);
    }
}
