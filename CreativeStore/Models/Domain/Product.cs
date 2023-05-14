namespace CreativeStore.Models.Domain
{
    public class Product
    {
        public Guid id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
        public int Stock { get; set; }
        public string? Image { get; set; }
        public string Status { get; set; }
        public Category? Category { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
