using New_folder.Models.Entities;

namespace New_folder.Models.Dtos
{
    public class BrokerDto : BaseEntity
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public string BrokerCode { get; set; }
        public ICollection<Investor> Investors { get; set; } = new HashSet<Investor>();
    }

    public class CreateBrokerRequestModel : CreateUserRequestModel
    {
        public string BrokerCode { get; set; }
    }
}
