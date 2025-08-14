using SportReserve_Shared.Models.Pagination;

namespace SportReserve_Shared.Interfaces
{
    public interface IPaginatedRepository<T> where T : class
    {
        Task<T?> Get(int id);
        Task<List<T>> Get(PaginationDto dto);
        Task Add(T entity);
        Task Remove(T entity);
    }
}
