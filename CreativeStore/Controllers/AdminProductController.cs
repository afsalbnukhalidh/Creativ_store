using CreativeStore.Data;
using CreativeStore.Models.Domain;
using CreativeStore.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CreativeStore.Controllers
{
    public class AdminProductController : Controller
    {
		private readonly CreativeDbContext creativeDbContext;

		public AdminProductController(CreativeDbContext creativeDbContext)
        {
			this.creativeDbContext = creativeDbContext;
		}
        [HttpGet]
		public async Task<IActionResult> AdminProductIndex()
		{
			var productList = await creativeDbContext.Products.Include(p => p .Category).ToListAsync();

			return View(productList);
		}
		[HttpGet]
		public async Task<IActionResult> Create()
		{
			var categories = await creativeDbContext.Categories.ToListAsync();
			var viewModel = new ProductRequest
			{
				Categories = categories.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList()
			};
			return View(viewModel);
		}
		[HttpPost]
		public async Task<IActionResult> Create(ProductRequest productRequest)
		{
			if(!ModelState.IsValid)
			{
				var categories = await creativeDbContext.Categories.ToListAsync();
				productRequest.Categories = categories.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();
				return View(productRequest);
			}
			var selectedCategoryId = productRequest.CategoryId;
			var category = await creativeDbContext.Categories.FindAsync(selectedCategoryId);

			var products = new Product
			{
				Name = productRequest.Name,
				Category = category,
				Description = productRequest.Description,
				Stock = productRequest.Stock,
				Image = productRequest.Image,
				Status = "A"
			};
			creativeDbContext.Products.Add(products);
			await creativeDbContext.SaveChangesAsync();
			return RedirectToAction(nameof(AdminProductIndex));
		}
		//in login controller have full code of this section

	}
}
