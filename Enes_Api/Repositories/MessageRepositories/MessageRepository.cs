using Dapper;
using Enes_Api.Dtos.CategoryDtos;
using Enes_Api.Dtos.MessageDtos;
using Enes_Api.Models.DapperContext;

namespace Enes_Api.Repositories.MessageRepositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly Context _context;

        public MessageRepository(Context context)
        {
            _context = context;
        }
        public async Task<List<ResultInBoxMessageDto>> GetInBoxLast3MessageListByReceiver(int id)
        {
            string query = "Select Top(3) * From Message Where Receiver=@receiverID order by MessageID Desc";
            var parameters = new DynamicParameters();
            parameters.Add("@receiverID", id);
            using (var connection = _context.CreaConnection())
            {
                var values = await connection.QueryAsync<ResultInBoxMessageDto>(query, parameters);
                return values.ToList();
            }
        }
    }
}
