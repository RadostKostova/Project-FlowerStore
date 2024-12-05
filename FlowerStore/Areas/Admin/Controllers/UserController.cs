using FlowerStore.Core.Contracts;
using FlowerStore.Core.ViewModels.Admin;
using FlowerStore.Extensions;
using FlowerStore.Infrastructure.Data.Models.Roles;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static FlowerStore.Core.Constants.AdminConstants;

namespace FlowerStore.Areas.Admin.Controllers
{
    /// <summary>
    /// Manages operations related to Users
    /// </summary>

    public class UserController : AdminBaseController
    {
        private readonly IAdminService adminService;
        private readonly UserManager<ApplicationUser> userManager;

        public UserController(IAdminService _adminService,
            UserManager<ApplicationUser> _userManager)
        {
            adminService = _adminService;
            userManager = _userManager;
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

        //Display confirmation view for making user an admin
        [HttpGet]
        public async Task<IActionResult> MakeAdministrator(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest();
            }

            var user = await adminService.GetUserByIdAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

            if (await userManager.IsInRoleAsync(user, AdminRole))
            {                
                return RedirectToAction("All"); //already admin
            }

            var model = new AdminAddViewModel
            {
                UserId = user.Id,
                Username = user.UserName,
                Email = user.Email
            };

            return View(model);
        }

        //Add new admin
        [HttpPost]
        public async Task<IActionResult> MakeAdministrator(AdminAddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = await adminService.GetUserByIdAsync(model.UserId);

            if (user == null || user.Email != model.Email || user.UserName != model.Username) 
            {
                return BadRequest();
            }

            if (await userManager.IsInRoleAsync(user, AdminRole))
            {
                return RedirectToAction("All");  //already admin
            }

            var result = await userManager.AddToRoleAsync(user, AdminRole);            
            return RedirectToAction("All");
        }

        //Remove Admin TODO
    }
}
