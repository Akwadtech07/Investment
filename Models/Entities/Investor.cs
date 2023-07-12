namespace New_folder.Models.Entities
{
    public class Investor : BaseEntity
    {
        public string UserId { get; set; }
        public User User { get; set; }

    }
}
