using Learning.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Learning.Controllers
{
    public class HomeController : Controller
    {
     

        public IActionResult Index()
        {
            return View();
        }

       

      
    }
}