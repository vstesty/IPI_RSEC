using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RSEC.Models;
using RSEC.Services;

namespace RSEC.Controllers
{
    public class HomeController : Controller
    {
        //dependency injection
        private readonly IRaportsService _raportsService;
        private readonly UserManager<IdentityUser> _userManager;
        public HomeController(IRaportsService raportsService, UserManager<IdentityUser> userManager)
        {
            _raportsService = raportsService;
            _userManager = userManager;
        }

        // Actions 


        /// <summary>
        /// Show total energy consumed on main page
        /// </summary>
        /// <returns>total energy consumed</returns>
        public async Task<IActionResult> Index()
        {
            ViewBag.TotalEnergy = await _raportsService.GetTotalEnergy();
            return View();
        }

        public IActionResult About()
        {            
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
