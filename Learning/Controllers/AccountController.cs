using Microsoft.AspNetCore.Mvc;

namespace Learning.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
