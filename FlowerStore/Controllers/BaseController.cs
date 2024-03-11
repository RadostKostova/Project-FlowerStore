using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlowerStore.Controllers
{
    /// <summary>
    /// Used as Base for all controllers.
    /// </summary>

    [Authorize]
    public class BaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
