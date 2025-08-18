namespace MyStore.Core.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        //Many to many with users
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}