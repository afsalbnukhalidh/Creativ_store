using Microsoft.AspNetCore.Mvc.Rendering;

namespace CreativeStore.Models.ViewModel
{
    public class CategoryRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? Image { get; set; }
        public string? Status { get; set; }
	}
}
