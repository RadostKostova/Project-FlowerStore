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
    /// Manages operations related to Users. Attributes for Admin only authorization are included in AdminBaseController 
    /// so checking for the current user (if it is Admin) is redundant.
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
        public async Task<IActionResult> AddAdministrator(string userId)
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
        public async Task<IActionResult> AddAdministrator(AdminAddViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            var user = await adminService.GetUserByIdAsync(model.UserId);

            if (user == null)
            {
                return NotFound();
            }

            if (user.Id != model.UserId || user.Email != model.Email || user.UserName != model.Username)
            {
                return BadRequest();   //additional compare validations
            }

            if (await userManager.IsInRoleAsync(user, AdminRole))
            {
                return RedirectToAction("All");  //already admin
            }

            var result = await userManager.AddToRoleAsync(user, AdminRole);
            return RedirectToAction("All");
        }

        //Display confirmation view for removing user as an Admin 
        [HttpGet]
        public async Task<IActionResult> RemoveAdministrator(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return NotFound();
            }

            var user = await adminService.GetUserByIdAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

            if (!await userManager.IsInRoleAsync(user, AdminRole))
            {
                return RedirectToAction(nameof(All));   //not admin
            }

            var model = new AdminRemoveViewModel
            {
                UserId = user.Id,
                Username = user.UserName,
                Email = user.Email
            };

            return View(model);
        }

        //Removing an admin
        [HttpPost]
        public async Task<IActionResult> RemoveAdministrator(AdminRemoveViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            var user = await adminService.GetUserByIdAsync(model.UserId);

            if (user == null)
            {
                return NotFound();
            }

            if (user.Id != model.UserId || user.Email != model.Email || user.UserName != model.Username)
            {
                return BadRequest();    //additional compare validations
            }

            if (!await userManager.IsInRoleAsync(user, AdminRole))
            {
                return RedirectToAction(nameof(All));   //not an admin
            }

            var result = await userManager.RemoveFromRoleAsync(user, AdminRole);
            return RedirectToAction(nameof(All));
        }
    }
}
