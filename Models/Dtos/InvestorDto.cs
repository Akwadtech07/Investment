using New_folder.Models.Entities;
using New_folder.Models.Enums;

namespace New_folder.Models.Dtos
{
    public class InvestorDto : BaseEntity
    {
        public string UserId { get; set; }
        public UserDto User { get; set; }
        public string IdentityImage { get; set; }
        public IdentityType IdentityType { get; set; }
        public string BrokerId { get; set; }
        public InvestmentType Broker { get; set; }
        public ICollection<Investment> Investments { get; set; } = new HashSet<Investment>();
    }

    public class CreateInvestorRequestModel
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public IFormFile IdentityImage { get; set; }
        public IdentityType IdentityType { get; set; }
        public string BrokerId { get; set; }
        public InvestmentType Broker { get; set; }
        public AddressDto Address { get; set; }
        public ICollection<Investment> Investments { get; set; } = new HashSet<Investment>();
    }
}
