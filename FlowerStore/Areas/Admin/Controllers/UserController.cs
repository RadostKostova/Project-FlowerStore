using FlowerStore.Core.Contracts;
using FlowerStore.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace FlowerStore.Areas.Admin.Controllers
{
    /// <summary>
    /// Manages operations related to Users
    /// </summary>

    public class UserController : AdminBaseController
    {

        private readonly IAdminService adminService;

        public UserController(IAdminService _adminService)
        {
            adminService = _adminService;
        }

        //Get all users
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var users = await adminService.GetAllUsersAsync();

            ViewBag.CurrentUserId = User.GetUserId();
            return View(users);
        }

        //Get details of a user
        [HttpGet]
        public async Task<IActionResult> Details(string userId)
        {
            var userDetails = await adminService.GetUserDetailsAsync(userId);

            if (userDetails == null)
            {
                return NotFound();
            }

            ViewBag.CurrentUserId = User.GetUserId();
            return View(userDetails);
        }

        
    }
}
