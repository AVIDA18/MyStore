namespace MyStore.Core.Entities
{
    public class Cart
    {
        public int Id { get; set; }

        //one to one or one to many with user
        public int UserId { get; set; }
        public User User { get; set; }

        //Many to many with Product
        public ICollection<CartItem> CartItems{ get; set; } = new List<CartItem>();
    }
}