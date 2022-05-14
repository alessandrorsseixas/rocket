using ClienteApi.Domain.Entities;
using ClienteApi.Domain.SeedWorks.Classes;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClienteApi.Domain.SeedWorks.Interfaces.Repositories
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Task<PagedModel<Cliente>> GetAll(Expression<Func<Cliente, bool>> predicate,
                                                     int page,
                                                     int size,
                                                     string sort,
                                                     bool orderByAsc,
                                                     CancellationToken cancellationToken);
    }
}
