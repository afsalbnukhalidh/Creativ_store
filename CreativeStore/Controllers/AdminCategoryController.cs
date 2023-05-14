using CreativeStore.Data;
using CreativeStore.Models.Domain;
using CreativeStore.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CreativeStore.Controllers
{
    public class AdminCategoryController : Controller
    {
		private readonly CreativeDbContext creativeDbContext;

		public AdminCategoryController(CreativeDbContext creativeDbContext)
        {
			this.creativeDbContext = creativeDbContext;
		}
        [HttpGet]
        public IActionResult Index()
        {
			IEnumerable<Category> CategoryList = creativeDbContext.Categories.Where(c => c.Status == "A");

			return View(CategoryList);
		}
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ActionName("Add")]
        public IActionResult Add(CategoryRequest categoryrequest)
        {
            if(ModelState.IsValid)
            {
                var category = new Category
                {
                    Name = categoryrequest.Name,
                    Description = categoryrequest.Description,
                    Image = categoryrequest.Image,
                    Status = "A"
                };
                creativeDbContext.Categories.Add(category);
                creativeDbContext.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        //[HttpGet]
        // GET: Categories/Edit/{id}
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            // Retrieve the category from the database
            var category = await creativeDbContext.Categories.FindAsync(id);

            if (category == null)
            {
                // If the category is not found, return a 404 Not Found response
                return NotFound();
            }

            // Map the category to a CategoryDto
            var categoryDto = new CategoryRequest
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                Image = category.Image
            };

            // Pass the CategoryDto to the view for editing
            return View(categoryDto);
        }


        // POST: Categories/Edit/{id}
        [HttpPost]
        public async Task<IActionResult> Edit(CategoryRequest categoryDto)
        {
            if (!ModelState.IsValid)
            {
                return View(categoryDto);
            }

            // Retrieve the category from the database
            var category = await creativeDbContext.Categories.FindAsync(categoryDto.Id);

            if (category == null)
            {
                // If the category is not found, return a 404 Not Found response
                return NotFound();
            }

            // Update the category properties from the CategoryDto
            category.Name = categoryDto.Name;
            category.Description = categoryDto.Description;
            category.Image = categoryDto.Image;

            // Save the changes to the database
            await creativeDbContext.SaveChangesAsync();

            // Redirect to the category index page
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            // Retrieve the category from the database
            var category = await creativeDbContext.Categories.FindAsync(id);

            if (category == null)
            {
                // If the category is not found, return a 404 Not Found response
                return NotFound();
            }

            // Map the category to a CategoryDto
            var categoryDto = new CategoryRequest
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                Image = category.Image,
                Status = category.Status
            };

            // Pass the CategoryDto to the view for editing
            return View(categoryDto);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteItem(Guid id)
        {
            // Retrieve the category from the database with status "A"
            var category = await creativeDbContext.Categories.FirstOrDefaultAsync(c => c.Id == id && c.Status == "A");

            if (category == null)
            {
                // If the category is not found, return a 404 Not Found response
                return NotFound();
            }

            // Update the status of the category to "D"
            category.Status = "D";

            // Save the changes to the database
            await creativeDbContext.SaveChangesAsync();

            // Redirect to the category index page
            return RedirectToAction(nameof(Index));
        }
    }
}
