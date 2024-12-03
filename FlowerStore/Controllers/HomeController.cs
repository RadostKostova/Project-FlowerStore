using FlowerStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FlowerStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult AboutUs()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult ContactUs()
        {
            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

            if (statusCode == 400)
            {
                return View("Error400");  //BadRequest
            }
            else if (statusCode == 401)
            {
                return View("Error401");  //Unauthorized
            }
            else if (statusCode == 404)
            {
                return View("Error404");  //Not found
            }
            else if (statusCode == 500)
            {
                return View("Error500");  //Internal Server Error (custom)
            }

            return View("Error");
        }
    }
}
