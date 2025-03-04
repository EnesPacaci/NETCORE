using Enes_Api.Dtos.CategoryDtos;
using Enes_Api.Models.DapperContext;
using Dapper;

namespace Enes_Api.Repositories.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Context _context;

        public CategoryRepository(Context context)
        {
            _context = context;
        }
        public async void CreateCategory(CreateCatergoryDto catergoryDto)
        {
            string query = "insert into Category (CategoryName,CategoryStatus) values (@categoryName,@categoryStatus)";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryName", catergoryDto.CategoryName);
            parameters.Add("@categoryStatus", true);
            using (var connection = _context.CreaConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
        public async void DeleteCategory(int id)
        {
            string query = "Delete From Category Where CategoryID=@categoryID";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryID",id);
            using (var connection = _context.CreaConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            string query = "Select * from Category";
            using(var connection=_context.CreaConnection()) 
            {
                var values=await connection.QueryAsync<ResultCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDCategoryDto> GetCategory(int id)
        {
            string query = "Select * From Category Where CategoryID=@categoryID";
            var parameters =new DynamicParameters();
            parameters.Add("@CategoryID", id);
            using(var connection = _context.CreaConnection())
            {
                var values =await connection.QueryFirstOrDefaultAsync<GetByIDCategoryDto>(query, parameters);
                return values;
            }
        }

        public async void UpdateCategory(UpdateCategoryDto categoryDto)
        {
            string query = "Update Category Set CategoryName=@categoryName, CategoryStatus=@categoryStatus where CategoryID=@categoryID";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryName", categoryDto.CategoryName);
            parameters.Add("@categoryStatus",categoryDto.CategoryStatus);
            parameters.Add("@categoryID", categoryDto.CategoryID);
            using (var connection = _context.CreaConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<PagedResultCategoryDto> GetCategoriesPagedAsync(int pageNumber, int pageSize)
        {
            using (var connection = _context.CreaConnection())
            {
                string countQuery = "SELECT COUNT(*) FROM Category";
                int totalCount = await connection.ExecuteScalarAsync<int>(countQuery);

                string query = @"SELECT * FROM Category 
                         ORDER BY CategoryID 
                         OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

                var categories = await connection.QueryAsync<ResultCategoryDto>(
                    query,
                    new { Offset = (pageNumber - 1) * pageSize, PageSize = pageSize }
                );

                double pageCount = (double)((decimal)totalCount / Convert.ToDecimal(pageSize));

                var result = new PagedResultCategoryDto
                {
                    TotalCount = totalCount,
                    PageSize = pageSize,
                    ActivePage = pageNumber,
                    Categories = categories.ToList(),
                    CurrentCount = categories.Count(),
                    TotalPageCount = (int)Math.Ceiling(pageCount)
                };

                return result;
            }
        }

    }
}
