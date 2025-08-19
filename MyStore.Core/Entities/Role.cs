namespace MyStore.Core.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        //Many to many with users
        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}