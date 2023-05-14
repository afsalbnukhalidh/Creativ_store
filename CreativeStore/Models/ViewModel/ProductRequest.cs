using Microsoft.AspNetCore.Mvc.Rendering;

namespace CreativeStore.Models.ViewModel
{
    public class ProductRequest
    {
		public ProductRequest()
		{
			Categories = new List<SelectListItem>();
		}

		public Guid id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
        public int Stock { get; set; }
        public string? Image { get; set; }
        public string? Status { get; set; }
        public Guid CategoryId { get; set; }
        public List<SelectListItem> Categories { get; set; }
    }
}
