using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSEC.Models
{
    public class RaportsViewModel
    {
        //View for Raports page
        public Raport[] Raports { get; set; }
        public List<SelectListItem> BusList { get; set; }        
    }
}
