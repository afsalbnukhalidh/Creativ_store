using Microsoft.AspNetCore.Mvc;

namespace CreativeStore.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
