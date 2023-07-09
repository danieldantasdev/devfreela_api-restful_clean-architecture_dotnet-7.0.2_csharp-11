using DevFreela.Core.Dtos.Paginations;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Extensions;

public static class MethodsExtension
{
    public static async Task<PaginationResultDto<T>> GetPaged<T>(this IQueryable<T> queryable, int page, int pageSize)
        where T : class
    {
        var result = new PaginationResultDto<T>
        {
            Page = page,
            PageSize = pageSize,
            ItemsCount = await queryable.CountAsync()
        };

        var pageCount = (double)result.ItemsCount / pageSize;
        result.TotalPages = (int)Math.Ceiling(pageCount);

        var skip = (page - 1) * pageSize;
        result.Data = await queryable.Skip(skip).Take(pageSize).ToListAsync();

        return result;
    }
}