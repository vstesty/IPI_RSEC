using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using RSEC.Data;
using RSEC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;



namespace RSEC.Services
{
    public class RaportsService : IRaportsService
    {
        private readonly ApplicationDbContext _context;
        public RaportsService(ApplicationDbContext context)
        { _context = context; }

        /// <summary>
        /// returns the total energy consumeded by the charger to show on main page
        /// </summary>
        /// <returns>total energy consumeded by the charger</returns>
        public async Task<double> GetTotalEnergy()
        {
            
            double resoult = 0;
            var raports = await _context.Raports.ToListAsync();
            foreach (Raport raport in raports)
            {
                resoult += raport.EnergyConsumed;
            }
            return resoult;
        }

        /// <summary>
        /// Retrieves all database reports
        /// </summary>
        /// <returns>all raports from database</returns>
        public async Task<IEnumerable<Raport>> GetAllRaportsAsync()
        {            
            var raports = await _context.Raports.ToListAsync();
            return raports;
        }

        /// <summary>
        /// Retrives selected raports form database
        /// </summary>
        /// <param name="busNum"> bus number</param>
        /// <param name="startDate">time to start charging</param>
        /// <param name="endDate">time to finish charging</param>
        /// <returns>raports</returns>
        public async Task<Raport[]> GetSelectedRaportsAsync(string busNum, DateTime startDate, DateTime endDate)
        {            
            IEnumerable<Raport>raports = await _context.Raports.ToListAsync(); 

            // BusNumber filter
            if (!string.IsNullOrEmpty(busNum) && !busNum.Contains("All"))
            {
                raports = raports.Where(s => s.BusNumber.Equals(busNum));
            }
            // Data filtring -start
            if (!string.IsNullOrEmpty(startDate.ToString()))
            {
                raports = raports.Where(s => s.StartChargingTime.Date.CompareTo(startDate) >= 0);
            }
            // Data filtring -end
            if (!string.IsNullOrEmpty(endDate.ToString()))
            //if (endDate != null )
            {                  
                 raports = raports.Where(s => s.StartChargingTime.Date.CompareTo(endDate) <= 0);
            }


            return raports.ToArray();
        }

        /// <summary>
        /// add raports to database by http page
        /// </summary>
        /// <param name="newRaport">rapoort to add</param>
        /// <returns>returns the confirmation operation was successful</returns>
        public async Task<bool> AddRaportAsync(Raport newRaport)
        {
            if(string.IsNullOrEmpty(newRaport.BusNumber)|| string.IsNullOrEmpty(newRaport.ChargingPower)) return false;
            newRaport.Id = Guid.NewGuid();            
            newRaport.StartChargingTime = DateTime.Now;
            _context.Raports.Add(newRaport);            
            var saveResult = await _context.SaveChangesAsync();            
            return saveResult == 1;
        }

        /// <summary>
        /// preparation of a list of buses for the drop-down menu in the filter window
        /// </summary>
        /// <returns>list of buses</returns>
        public async Task<List<SelectListItem>> GetBusListAsync()
        {
            var items = await _context.Raports.ToArrayAsync();
            List<SelectListItem> busList = new List<SelectListItem>();

            foreach (Raport item in items)
            { busList.Add(new SelectListItem { Text = item.BusNumber, Value = item.BusNumber }); }
            busList.Insert(0, new SelectListItem { Text = "All", Value = null });          
                                                                                                                                                       
            return busList;
        }

        //API SERVICES:
        /// <summary>
        /// add raports to database by API SERVICE
        /// </summary>
        /// <param name="newRaport">raport to add</param>
        public void AddApiRaport(Raport newRaport)
        {            
            _context.Raports.Add(newRaport);
            var saveResult = _context.SaveChangesAsync();            
        }

    }
}
