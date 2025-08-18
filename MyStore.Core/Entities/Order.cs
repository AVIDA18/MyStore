namespace MyStore.Core.Entities
{
    public class Order
    {
        public int Id { get; set; }

        //One to many with user
        public int UserId { get; set; }
        public User User { get; set; }

        //Many to many with product
        public ICollection<Product> Products { get; set; } = new List<Product>();

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}