namespace MyStore.Core.Entities
{
    public class Cart
    {
        public int Id { get; set; }

        //one to one or one to many with user
        public int UserId { get; set; }
        public User User { get; set; }

        //Many to many with Product
        public ICollection<Product> Products{ get; set; } = new List<Product>();
    }
}