using Dapper;
using Enes_Api.Dtos.ServiceDtos;
using Enes_Api.Dtos.TestimonialDtos;
using Enes_Api.Models.DapperContext;

namespace Enes_Api.Repositories.TestimonialRepositories
{
    public class TestimonialRepository : ITestimonialRepository
    {
        private readonly Context _context;

        public TestimonialRepository(Context context)
        {
            _context = context;
        }
        public async Task<List<ResultTestimonialDto>> GetAllTestimonialAsync()
        {
            {
                string query = "Select * from Testimonial";
                using (var connection = _context.CreaConnection())
                {
                    var values = await connection.QueryAsync<ResultTestimonialDto>(query);
                    return values.ToList();
                }
            }
        }
    }
}
