using ClienteApi.Domain.Entities;
using ClienteApi.Domain.SeedWorks.Classes;
using ClienteApi.Domain.SeedWorks.Interfaces.Repositories;
using ClienteApi.Respotirory.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace ClienteApi.Respotirory.Repositories.General
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<PagedModel<Cliente>> GetAll
               (Expression<Func<Cliente, bool>> predicate,
                   int page,
                   int size,
                   string sort,
                   bool orderbyAsc,
                   CancellationToken cancellationToken
               )
        {
            var data = await base.GetAll(predicate, page, size, cancellationToken);
            var items = (List<Cliente>)data.Items;

            switch (sort.ToLower())
            {
                case "nome":
                    data.Items = orderbyAsc
                        ? data.Items.OrderBy(x => x.Nome).ToList()
                        : data.Items.OrderByDescending(x => x.Nome).ToList();
                    break;

                case "porte":
                    data.Items = orderbyAsc
                        ? data.Items.OrderBy(x => x.Porte).ToList()
                        : data.Items.OrderByDescending(x => x.Porte).ToList();
                    break;
            }
            return data;

        }


    }
}
