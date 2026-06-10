using Microsoft.AspNetCore.Mvc;

namespace MoviesRental.WebApi.Controllers
{
    public class DirectorsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
