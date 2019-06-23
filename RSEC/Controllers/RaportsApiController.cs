using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RSEC.Models;
using RSEC.Services;


namespace RSEC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaportsApiController : ControllerBase
    {
        //injecting dependencies
        private readonly IRaportsService _raportsService;
        public RaportsApiController(IRaportsService raportsService)
        {
            _raportsService = raportsService;
        }



        /// <summary>
        /// add raport to database by API SERVICE
        /// </summary>
        /// <param name="raportApi">raport to add</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AddRaport(Raport raportApi)
        {
            try
            {
                _raportsService.AddApiRaport(raportApi);               
            }
            catch (Exception e) { Logs.sendLog(e); }
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}