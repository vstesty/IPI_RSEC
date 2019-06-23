using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RSEC.Models;

using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using RSEC.Services;
using Microsoft.AspNetCore.Identity;

namespace RSEC.Controllers
{
    [Authorize]
    public class ChartController : Controller
    {
        //dependency injection
        private readonly IRaportsService _raportsService;
        private readonly UserManager<IdentityUser> _userManager;                
        public ChartController(IRaportsService raportsService, UserManager<IdentityUser> userManager)
        {
            _raportsService = raportsService;
            _userManager = userManager;
        }

        // Actions 

        public async Task<IActionResult> Index(string busNum, DateTime startDate, DateTime endDate)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
                return Challenge();

            try
            {
                // Get raports from database
                var raports = await _raportsService.GetSelectedRaportsAsync(busNum, startDate, endDate);

                // Check date range
                TimeSpan dateRange = endDate - startDate;

                //Prepare chart
                List<DataPoint> dataPoints = new List<DataPoint>();
                int counter = 1;

                // One day raport
                if (dateRange.Days == 0)
                {
                    foreach (Raport Data in raports)
                    {
                        dataPoints.Add(new DataPoint(counter, Data.EnergyConsumed, Data.BusNumber));
                        counter++;
                    }

                }

                // One month raport
                else if (dateRange.Days <= 31)
                {


                    Dictionary<string, double> timeDictionary = new Dictionary<string, double>();

                    foreach (Raport Data in raports)
                    {
                        if (timeDictionary.ContainsKey(Data.StartChargingTime.Date.ToString("dd/MM/yyyy")))
                        {

                            timeDictionary[Data.StartChargingTime.Date.ToString("dd/MM/yyyy")] += Data.EnergyConsumed;
                        }
                        else
                        {
                            timeDictionary.Add(Data.StartChargingTime.Date.ToString("dd/MM/yyyy"), Data.EnergyConsumed);
                        }

                    }

                    foreach (var data in timeDictionary)
                    {
                        dataPoints.Add(new DataPoint(counter, data.Value, data.Key));
                        counter++;
                    }

                }
                //one year raport
                else if (dateRange.Days > 31)
                {
                    Dictionary<string, double> timeDictionary = new Dictionary<string, double>();

                    foreach (Raport Data in raports)
                    {
                        if (timeDictionary.ContainsKey(Data.StartChargingTime.Year.ToString()))
                        {

                            timeDictionary[Data.StartChargingTime.Year.ToString()] += Data.EnergyConsumed;
                        }
                        else
                        {
                            timeDictionary.Add(Data.StartChargingTime.Year.ToString(), Data.EnergyConsumed);
                        }

                    }

                    foreach (var data in timeDictionary)
                    {
                        dataPoints.Add(new DataPoint(counter, data.Value, data.Key));
                        counter++;
                    }
                }

            
            

            // Serialize data for chart component
            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);
            }
            catch (Exception e) { Logs.sendLog(e); }

            return View();
        }            
                
    }
}
