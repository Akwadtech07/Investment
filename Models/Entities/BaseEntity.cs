namespace New_folder.Models.Entities
{
    public abstract class BaseEntity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public string DeletedBy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
