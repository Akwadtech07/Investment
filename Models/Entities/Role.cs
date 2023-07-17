namespace New_folder.Models.Entities
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<User> Users { get; set; } = new HashSet<User>();
    }
}
