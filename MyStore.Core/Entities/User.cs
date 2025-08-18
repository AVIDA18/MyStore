namespace MyStore.Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string PasswordHashed { get; set; } = string.Empty;

        //One to many with Order
        public ICollection<Order> Orders { get; set; } = new List<Order>();

        //Many to many with Roles
        public ICollection<Role> Roles { get; set; } = new List<Role>();

        //one to one or one to many with cart
        public ICollection<Cart> Carts{ get; set; } = new List<Cart>();
    }
}