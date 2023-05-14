namespace CreativeStore.Models.Domain
{
    public class User
    {
        public Guid Id { get; set; } 
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Image { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
