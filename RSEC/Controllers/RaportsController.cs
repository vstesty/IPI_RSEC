using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RSEC.Models;
using RSEC.Services;

namespace RSEC.Controllers
{
    [Authorize]
    public class RaportsController : Controller
    {
        //dependency injection
        private readonly IRaportsService _raportsService;
        private readonly UserManager<IdentityUser> _userManager;
        public RaportsController(IRaportsService raportsService, UserManager<IdentityUser> userManager)
        {
            _raportsService = raportsService;
            _userManager = userManager;
        }
        
        // Actions          
        public async Task<IActionResult> Index(string busNum, DateTime startDate, DateTime endDate, string documentType)
        {            
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
                return Challenge();
            RaportsViewModel model = null;
            try
            {
                // Get raports from database
                var raports = await _raportsService.GetSelectedRaportsAsync(busNum, startDate, endDate);

                // Get bus list from database
                List<SelectListItem> busList = new List<SelectListItem>();
                busList = await _raportsService.GetBusListAsync();

                // Put data into a model 
                model = new RaportsViewModel() { Raports = raports, BusList = busList };
            }
            catch (Exception e) { Logs.sendLog(e); }
            //Render view using the model
            if (model != null)
                return View(model);
            else
                return BadRequest("Could not find raport.");
        }

        
        [ValidateAntiForgeryToken] public async Task<IActionResult> AddRaport(Raport newRaport)
        {
            if (!ModelState.IsValid)
            { return RedirectToAction("Index"); }
            var successful = await _raportsService.AddRaportAsync(newRaport);
            if (!successful)
            { return BadRequest("Could not add raport."); }
            return RedirectToAction("Index");
        }

        
    }
}