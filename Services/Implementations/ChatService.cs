using New_folder.Models.Dtos;
using New_folder.Models.Entities;
using New_folder.Repositories.Interfaces;
using New_folder.Services.Interfaces;

namespace New_folder.Services.Implementations
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository _chatRepository;
        private readonly IUserRepository _userRepository;


        public ChatService(IChatRepository chatRepository, IUserRepository userRepository)
        {
            _chatRepository = chatRepository;
            _userRepository = userRepository;

        }

        public async Task<Result<ChatDto>> CreateChat(CreateChatRequestModel model, string id, string recieverId)
        {
            var sender = await _userRepository.GetUserAsync(id);
            var reciever = await _userRepository.GetUserAsync(recieverId);
            if (sender == null || reciever == null)
            {
                return new Result<ChatDto>
                {
                    Message = "Not found",
                    Success = false,
                };
            }
            var chat = new Chat
            {
                Message = model.Message,
                CreatedDate = DateTime.UtcNow,
                PostedTime = DateTime.Now.ToLongDateString(),
                SenderId = id,
                RecieverId = recieverId,

            };
            await _chatRepository.CreateAsync(chat);
            _chatRepository.SaveChangesAsync();
            return new Result<ChatDto>
            {
                Message = " Message successfully sent",
                Success = true,
            };

        }

        public async Task<Result<UserDto>> GetUserAsync(string contactId)
        {
            var contact = await _userRepository.GetUserAsync(contactId);
            if (contact == null)
            {
                return new Result<UserDto>
                {
                    Message = "Contact not found",
                    Success = false,

                };
            }
            return new Result<UserDto>
            {
                Data = new UserDto
                {
                    Image = contact.Image,
                    FirstName = contact.FirstName,
                },
                Message = "Contact fetched succesfuly",
                Success = true
            };




        }

        public async Task<Result<List<ChatDto>>> GetUserAsync(string senderId, string recieverid)
        {
            var sender = await _userRepository.GetUserAsync(senderId);
            var reciever = await _userRepository.GetUserAsync(recieverid);
            if (sender == null || reciever == null)
            {
                return new Result<List<ChatDto>>
                {
                    Message = "Somthing went wrong",
                    Success = false,
                };
            }
            var chats = await _chatRepository.GetAllChatFromSender(reciever.Id, sender.Id);
            if (chats.Count == 0)
            {
                return new Result<List<ChatDto>>
                {
                    Success = true,
                    Data = new List<ChatDto>
                    {
                        new ChatDto
                        {
                            ReceiverImage = reciever.Image,
                            ContactName = reciever.FirstName + " " + reciever.LastName,
                        }
                    }
                };
            }
            return new Result<List<ChatDto>>
            {
                Message = "Chats retrieved successfully",
                Success = true,
                Data = chats.Select(x => new ChatDto
                {
                    SendeId = sender.Id,
                    Message = x.Message,
                    PostedTime = x.CreatedDate.ToShortTimeString(),
                    Seen = x.Seen,
                    SenderImage = sender.Image,
                    ReceiverImage = reciever.Image,
                    ContactName = reciever.FirstName + " " + reciever.LastName,

                }).ToList()

            };

        }

        public async Task<Result<IEnumerable<ChatDto>>> GetAll(string recieverId)
        {
            var reciever = await _userRepository.GetUserAsync(recieverId);
            if (reciever == null)
            {
                return new Result<IEnumerable<ChatDto>>
                {
                    Message = "Somthing went wrong",
                    Success = false,
                };
            }
            var unseen = await _chatRepository.GetAllUnSeenChatAsync(reciever.Id);
            return new Result<IEnumerable<ChatDto>>
            {
                Message = "Succesful",
                Success = true,
                Data = unseen.Select(x => new ChatDto
                {
                    SendeId = x.Sender.Id,
                }).ToList()
            };
        }

        public Task<Result<List<ChatDto>>> Get(string senderId, string recieverId)
        {
            throw new NotImplementedException();
        }

        public Task<Result<UserDto>> Get(string contactId)
        {
            throw new NotImplementedException();
        }
    }
}
