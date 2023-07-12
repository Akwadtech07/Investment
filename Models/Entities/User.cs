namespace New_folder.Models.Entities
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public  ICollection<UserRole> UserRoles { get; set; } = new HashSet<UserRole>();
        public Investor Investor { get; set; }
        

    }
}
