using Abp.Domain.Entities;
using System.Linq.Expressions;

namespace Enes_Api.Repositories.Pagination
{
    public interface IServiceBase<T, in TKey>
            where T : class, IEntity, new() where TKey : IEquatable<TKey>
    {
        Task<IResult> GetAllAsync(Expression<Func<T, bool>> predicate = null, PaginationQuery paginationQuery = null);
        Task<IResult> GetByIdAsync(TKey id);
    }
}
