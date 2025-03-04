namespace Enes_Api.Repositories.Pagination
{
    public interface IPaginationQuery
    {
        int PageNumber { get; set; }
        int PageSize { get; set; }
    }
}
