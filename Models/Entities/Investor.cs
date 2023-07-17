using New_folder.Models.Enums;

namespace New_folder.Models.Entities
{
    public class Investor : BaseEntity
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public string IdentityImage { get; set; } 
        public IdentityType IdentityType { get; set; }
        public string BrokerId { get; set; }
        public InvestmentType Broker { get; set; }
        public ICollection<Investment> Investments { get; set; } = new HashSet<Investment>();

    }
}
