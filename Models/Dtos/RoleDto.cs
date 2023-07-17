using New_folder.Models.Entities;

namespace New_folder.Models.Dtos
{
    public class RoleDto : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<User> Users { get; set; } = new HashSet<User>();
    }

    public class CreateRoleRequestModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<User> Users { get; set; } = new HashSet<User>();
    }
}
