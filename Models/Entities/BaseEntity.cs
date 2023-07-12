namespace New_folder.Models.Entities
{
    public class BaseEntity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public bool IsDeleted { get; set; }
        public string DeletedBy { get; set; }
    }
}
