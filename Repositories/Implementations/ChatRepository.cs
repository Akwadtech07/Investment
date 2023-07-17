using Microsoft.EntityFrameworkCore;
using New_folder.Data;
using New_folder.Models.Entities;
using New_folder.Repositories.Interfaces;

namespace New_folder.Repositories.Implementations
{
    public class ChatRepository : BaseRepository<Chat>, IChatRepository
    {
        public ChatRepository(ApplicationContext context) { _context = context; }
        public async Task<List<Chat>> GetAllChatFromSender(string recieverId, string senderId)
        {
            var chat = await _context.Chats.Where(x => x.RecieverId == recieverId && x.SenderId == senderId || x.RecieverId == senderId && x.SenderId == recieverId).ToListAsync();
            return chat;
        }

        public async Task<List<Chat>> GetAllUnSeenChatAsync(string recieverId)
        {
            var chat = await _context.Chats.Where(x => x.RecieverId == recieverId).ToListAsync();
            return chat;
        }

        public async Task<List<Chat>> GetAllUnSeenChatAsync(string senderId, string recieverId)
        {
            var chat = await _context.Chats.Where(x => x.RecieverId == recieverId && x.SenderId == senderId).ToListAsync();
            return chat;
        }
    }
}
