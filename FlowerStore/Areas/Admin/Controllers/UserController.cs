using FlowerStore.Core.Contracts;
using FlowerStore.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace FlowerStore.Areas.Admin.Controllers
{
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
            return View(users);
        }
    }
}
