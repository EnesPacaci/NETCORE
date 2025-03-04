using Enes_Api.Dtos.CategoryDtos;

public class PagedResultCategoryDto
{
    public int ActivePage { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
    public int TotalPageCount { get; set; }
    public int CurrentCount { get; set; }
    public List<ResultCategoryDto> Categories { get; set; }

    public PagedResultCategoryDto()
    {
        Categories = new List<ResultCategoryDto>();
    }
}
