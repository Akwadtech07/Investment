using New_folder.Models.Dtos;

namespace New_folder.Services.Interfaces
{
    public interface IChatService
    {
        Task<Result<ChatDto>> CreateChat(CreateChatRequestModel model, string id, string recieverid);
        Task<Result<List<ChatDto>>> Get(string senderId, string recieverId);
        Task<Result<IEnumerable<ChatDto>>> GetAll(string recieverId);
        Task<Result<UserDto>> Get(string contactId);
    }
}
