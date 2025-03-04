using Enes_Api.Dtos.CategoryDtos;

namespace Enes_Api.Repositories.CategoryRepository
{
    public interface ICategoryRepository
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();
        void CreateCategory(CreateCatergoryDto catergoryDto);
        void DeleteCategory(int id);
        void UpdateCategory(UpdateCategoryDto categoryDto);
        Task<GetByIDCategoryDto> GetCategory(int id);
        Task<PagedResultCategoryDto> GetCategoriesPagedAsync(int pageNumber, int pageSize);
    }
}
