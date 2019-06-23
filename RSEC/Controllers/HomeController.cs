using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RSEC.Models;
using RSEC.Services;
using log4net;
using log4net.Config;
using System.IO;

namespace RSEC.Controllers
{
    public class HomeController : Controller
    {
        //private static log4net.ILog Log { get; set; }
        //ILog log = log4net.LogManager.GetLogger(typeof(HomeController));
        //log4net.Config.XmlConfigurator(ConfigFile = 
        //        "MyStandardLog4Net.config", Watch = true)//log4net.Config.XmlConfigurator Configure(new FileInfo(Server.MapPath("~/log4net.txt")));


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
            try { ViewBag.TotalEnergy = await _raportsService.GetTotalEnergy(); }
            catch (Exception e) { Logs.sendLog(e); }
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
