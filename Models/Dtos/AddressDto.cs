using New_folder.Models.Entities;

namespace New_folder.Models.Dtos
{
    public class AddressDto : BaseEntity
    {
        public string Nationality { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string HomeAddress { get; set; }
        public string ZipCode { get; set; }
        public ICollection<User> Users { get; set; } = new HashSet<User>();
    }

    public class CreateAddressRequestModel
    {
        public string Nationality { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string HomeAddress { get; set; }
        public string ZipCode { get; set; }
        public ICollection<User> Users { get; set; } = new HashSet<User>();
    }
}
