using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using RSEC.Models;


namespace RSEC.Services
{
    public interface IRaportsService
    {
        /// <summary>
        /// returns the total energy consumeded by the charger to show on main page
        /// </summary>
        /// <returns>total energy consumeded by the charger</returns>
        Task<double> GetTotalEnergy();

        /// <summary>
        /// Retrieves all database reports
        /// </summary>
        /// <returns>all raports from database</returns>
        Task<IEnumerable<Raport>> GetAllRaportsAsync();

        /// <summary>
        /// Retrives selected raports form database
        /// </summary>
        /// <param name="busNum"> bus number</param>
        /// <param name="startDate">time to start charging</param>
        /// <param name="endDate">time to finish charging</param>
        /// <returns>raports</returns>
        Task<Raport[]> GetSelectedRaportsAsync(string busNum, DateTime startDate, DateTime endDate);

        /// <summary>
        /// add raports to database by http page
        /// </summary>
        /// <param name="newRaport">rapoort to add</param>
        /// <returns>returns the confirmation operation was successful</returns>
        Task<bool> AddRaportAsync(Raport newRaport);

        /// <summary>
        /// preparation of a list of buses for the drop-down menu in the filter window
        /// </summary>
        /// <returns>list of buses</returns>
        Task<List<SelectListItem>> GetBusListAsync();

        //API SERVICES:
        /// <summary>
        /// add raports to database by API SERVICE
        /// </summary>
        /// <param name="newRaport">raport to add</param>
        void AddApiRaport(Raport newRaport);        
    }
}
