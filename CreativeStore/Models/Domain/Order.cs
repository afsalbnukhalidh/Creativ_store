namespace CreativeStore.Models.Domain
{
    public class Order
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }
        public string Status { get; set; }

       
    }
}
