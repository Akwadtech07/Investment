namespace New_folder.Models.Entities
{
    public class Broker : BaseEntity
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public string BrokerCode { get; set; }
        public ICollection<Investor> Investors { get; set; } = new HashSet<Investor>();

    }
}
