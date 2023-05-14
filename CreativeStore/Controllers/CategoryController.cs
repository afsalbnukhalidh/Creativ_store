using Microsoft.AspNetCore.Mvc;

namespace CreativeStore.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
