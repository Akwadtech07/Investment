using New_folder.Models.Dtos;

namespace New_folder.Services.Interfaces
{
    public interface IChatService
    {
        Task<Result<ChatDto>> CreateChat(CreateChatRequestModel model, int id, int recieverid);
        Task<Result<List<ChatDto>>> Get(int senderId, int recieverId);
        Task<Result<IEnumerable<ChatDto>>> GetAll(int recieverId);
        Task<Result<UserDto>> Get(int contactId);
    }
}
