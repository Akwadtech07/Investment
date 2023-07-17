namespace New_folder.Models.Entities
{
    public class Address : BaseEntity
    {
        public string Nationality { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string HomeAddress { get; set; }
        public string ZipCode { get; set; }
        public ICollection<User> Users { get; set; } = new HashSet<User>();

    }
}
