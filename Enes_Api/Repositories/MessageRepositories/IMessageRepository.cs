using Enes_Api.Dtos.MessageDtos;

namespace Enes_Api.Repositories.MessageRepositories
{
    public interface IMessageRepository
    {
        Task<List<ResultInBoxMessageDto>> GetInBoxLast3MessageListByReceiver(int id);
    }
}
