using Dapper;
using Enes_Api.Models.DapperContext;

namespace Enes_Api.Repositories.EstateAgentRepositories.DashboardRepositories.StatisticRepositories
{
    public class StatiscticRepository : IStatisticRepository
    {
        private readonly Context _context;

        public StatiscticRepository(Context context)
        {
            _context = context;
        }
        public int AllProductCount()
        {
            string query = "Select Count(*) From Product";
            using (var connection = _context.CreaConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public int ProductCountByEmployeeId(int id)
        {
            string query = "Select Count(*) From Product where EmployeeID=@employeeID";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeID", id);
            using (var connection = _context.CreaConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query,parameters);
                return values;
            }
        }

        public int ProductCountByStatusFalse(int id)
        {
            string query = "Select Count(*) From Product where EmployeeID=@employeeID And ProductStatus=0";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeID", id);
            using (var connection = _context.CreaConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query, parameters);
                return values;
            }
        }

        public int ProductCountByStatusTrue(int id)
        {
            string query = "Select Count(*) From Product where EmployeeID=@employeeID And ProductStatus=1";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeID", id);
            using (var connection = _context.CreaConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query, parameters);
                return values;
            }
        }
    }
}
