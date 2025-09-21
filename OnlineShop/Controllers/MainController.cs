using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.Controllers
{
    public class MainController : Controller
    {
        public IActionResult MainPage()
        {
            return View();
        }
    }
}
