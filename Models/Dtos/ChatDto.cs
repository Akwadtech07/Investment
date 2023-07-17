using New_folder.Models.Entities;

namespace New_folder.Models.Dtos
{
    public class ChatDto : BaseEntity
    {
       
        public string Message { get; set; }
        public bool Seen { get; set; }
        public string PostedTime { get; set; }
        public string SendeId { get; set; }
        public User Sender { get; set; }
        public string RecieverId { get; set; }
        public string ReceiverImage { get; set; }
        public string SenderImage { get; set; }
        public string ContactName { get; set; }
    }
    public class UserChatDto
    {

    }
    public class CreateChatRequestModel
    {
        public string Message { get; set; }
    }

}
