﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RSEC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace RSEC.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class ManageUsersController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        public ManageUsersController(UserManager<IdentityUser> userManager)
        { _userManager = userManager; }

        /// <summary>
        /// Show Users in Manage User Window
        /// </summary>
        /// <returns>list of Users</returns>
        public async Task<IActionResult> Index()
        {
            var admins = (await _userManager.GetUsersInRoleAsync("Administrator")).ToArray();
            var everyone = await _userManager.Users.ToArrayAsync();
            var model = new ManageUsersViewModel { Administrators = admins, Everyone = everyone };
            return View(model);
        }
    }
}
