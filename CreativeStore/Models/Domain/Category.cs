namespace CreativeStore.Models.Domain
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? Image { get; set; }
        public string Status { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
