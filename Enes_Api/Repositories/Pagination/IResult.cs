namespace Enes_Api.Repositories.Pagination
{
    public interface IResult
    {
        int StatusCode { get; }
        string Message { get; }
    }
}
