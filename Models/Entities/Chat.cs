namespace New_folder.Models.Entities
{
    public class Chat : BaseEntity
    {
        public string Message { get; set; }
        public bool Seen { get; set; }
        public string PostedTime { get; set; }
        public string SenderId { get; set; }
        public User Sender { get; set; }
        public string RecieverId { get; set; }
    }
}
