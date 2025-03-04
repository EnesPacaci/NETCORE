namespace Enes_Api.Repositories.Pagination
{
    public interface IPaginationUriService
    {
        public Uri GetPageUri(PaginationQuery paginationQuery);
    }
}
