using New_folder.Models.Entities;

namespace New_folder.Repositories.Interfaces
{
    public interface IChatRepository : IBaseRepository<Chat>
    {
        Task<List<Chat>> GetAllChatFromSender(string recieverId, string senderId);
        Task<List<Chat>> GetAllUnSeenChatAsync(string recieverId);
        Task<List<Chat>> GetAllUnSeenChatAsync(string senderId, string recieverId);
    }
}
