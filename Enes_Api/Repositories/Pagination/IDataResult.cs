namespace Enes_Api.Repositories.Pagination
{
    public interface IDataResult<out T> : IResult
    {
        T Data { get; }
        int TotalRecords { get; }
    }
}
