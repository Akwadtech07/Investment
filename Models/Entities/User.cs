using New_folder.Models.Enums;

namespace New_folder.Models.Entities
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string Image { get; set; }
        public string AddressId { get; set; }
        public string RoleId { get; set; }
        public Investor Investor { get; set; }
        public InvestmentType Broker { get; set; }
        

    }
}
