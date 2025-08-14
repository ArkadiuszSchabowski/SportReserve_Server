using SportReserve_Shared.Models.Pagination;

namespace SportReserve_Shared.Interfaces
{
    public interface IPaginatedGetService<T> where T : class
    {
        Task<T> Get(int id);
        Task<PaginationResult<T>> Get(PaginationDto dto);
    }
}
