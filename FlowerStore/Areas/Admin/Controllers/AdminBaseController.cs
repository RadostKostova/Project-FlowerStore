﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static FlowerStore.Core.Constants.AdminConstants;

namespace FlowerStore.Areas.Admin.Controllers
{
    /// <summary>
    /// Base Controller for Admin Area
    /// </summary>
    
    [Area(AdminAreaName)]
    [Authorize(Roles = AdminRole)]
    public class AdminBaseController : Controller
    {
        
    }
}