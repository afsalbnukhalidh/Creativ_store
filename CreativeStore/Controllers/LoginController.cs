using CreativeStore.Models.Domain;
using CreativeStore.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;

namespace CreativeStore.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
//using CreativeStore.Models.Domain;
//using CreativeStore.Models.ViewModel;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace CreativeStore.Controllers
//{
//	public class ProductController : Controller
//	{
//		private readonly AppDbContext _context;

//		public ProductController(AppDbContext context)
//		{
//			_context = context;
//		}

//		public async Task<IActionResult> Index()
//		{
//			var products = await _context.Products.Include(p => p.Category).ToListAsync();
//			return View(products);
//		}

//		public async Task<IActionResult> Create()
//		{
//			var categories = await _context.Categories.ToListAsync();
//			var viewModel = new ProductRequest
//			{
//				Categories = categories.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList()
//			};
//			return View(viewModel);
//		}

//		[HttpPost]
//		[ValidateAntiForgeryToken]
//		public async Task<IActionResult> Create(ProductRequest request)
//		{
//			if (!ModelState.IsValid)
//			{
//				var categories = await _context.Categories.ToListAsync();
//				request.Categories = categories.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();
//				return View(request);
//			}

//			var product = new Product
//			{
//				id = Guid.NewGuid(),
//				Description = request.Description,
//				Stock = request.Stock,
//				Image = request.Image,
//				Status = request.Status,
//				Category = await _context.Categories.FindAsync(Guid.Parse(request.CategoryId))
//			};
//			_context.Add(product);
//			await _context.SaveChangesAsync();
//			return RedirectToAction(nameof(Index));
//		}

//		public async Task<IActionResult> Edit(Guid id)
//		{
//			var product = await _context.Products.FindAsync(id);
//			if (product == null)
//			{
//				return NotFound();
//			}

//			var categories = await _context.Categories.ToListAsync();
//			var viewModel = new ProductRequest
//			{
//				id = product.id,
//				Description = product.Description,
//				Stock = product.Stock,
//				Image = product.Image,
//				Status = product.Status,
//				CategoryId = product.Category.Id.ToString(),
//				Categories = categories.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList()
//			};
//			return View(viewModel);
//		}

//		[HttpPost]
//		[ValidateAntiForgeryToken]
//		public async Task<IActionResult> Edit(Guid id, ProductRequest request)
//		{
//			if (id != request.id)
//			{
//				return NotFound();
//			}

//			if (!ModelState.IsValid)
//			{
//				var categories = await _context.Categories.ToListAsync();
//				request.Categories = categories.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();
//				return View(request);
//			}

//			try
//			{
//				var product = await _context.Products.FindAsync(id);
//				product.Description = request.Description;
//				product.Stock = request.Stock;
//				product.Image = request.Image;
//				product.Status = request.Status;
//				product.Category = await _context.Categories.FindAsync(Guid.Parse(request.CategoryId));
//				_context.Update(product);
//				await _context.SaveChangesAsync();
//			}
//			catch (DbUpdateConcurrencyException)
//			{
//				if (!ProductExists(id))
//				{
//					return NotFound();
//				}
//				else
//				{
//					throw;
//				}
//			}

//			return RedirectToAction(nameof(Index));
//		}

//		public async Task<IActionResult> Delete(Guid id)
//		{
//			var product = await _context.Products.FindAsync(id);
//			if (product == null)
//			{
//				return NotFound();
//			}

//			return View(product);
//		}

//		[HttpPost, ActionName("Delete")]
//		[ValidateAntiForgeryToken]
//		public async Task<IActionResult> DeleteConfirmed(Guid id)
//		{
//			var product = await _context.Products.FindAsync(id);

//			if (product == null)
//			{
//				return NotFound();
//			}

//			_context.Products.Remove(product);
//			await _context.SaveChangesAsync();
//			return RedirectToAction(nameof(Index));
//		}

//		private bool ProductExists(Guid id)
//		{
//			return _context.Products.Any(e => e.id == id);
//		}
//	}
//}
