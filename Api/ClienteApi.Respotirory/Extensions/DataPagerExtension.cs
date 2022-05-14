using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ClienteApi.Domain.SeedWorks.Classes;
using Microsoft.EntityFrameworkCore;

namespace ClienteApi.Respotirory.Extensions
{
    public static class DataPagerExtension
    {
        public static async Task<PagedModel<TModel>> PaginateAsync<TModel>(
            this IQueryable<TModel> query,
            int page,
            int limit,
            CancellationToken cancellationToken)
            where TModel : class
        {

            var paged = new PagedModel<TModel>();

          

            var totalItemsCountTask = await query.CountAsync(cancellationToken);
            //var totalItemsCountTask = query.CountAsync(cancellationToken);
            
            if(page == 0){

                paged.CurrentPage = page;
                paged.Items = await query
                              .ToListAsync(cancellationToken);
                paged.PageSize = paged.Items.Count();
                paged.TotalItems = totalItemsCountTask;
                paged.TotalPages = (int)Math.Ceiling(paged.TotalItems / (double)limit);

            }else{
                 var startRow = (page - 1) * limit;
                page = (page < 0) ? 1 : page;

                paged.CurrentPage = page;
                paged.PageSize = limit;
                paged.Items = await query
                        .Skip(startRow)
                        .Take(limit)
                        .OrderBy(x => x)
                        .ToListAsync(cancellationToken);

                paged.TotalItems = totalItemsCountTask;
                paged.TotalPages = (int)Math.Ceiling(paged.TotalItems / (double)limit);

            }
           


            return paged;
        }
    }


}