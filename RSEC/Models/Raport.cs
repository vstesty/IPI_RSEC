using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;


namespace RSEC.Models
{
    //Rapor model 
    public class Raport
    {
        // ID for SQL database
        public Guid Id { get; set; }
        //time to start charging
        [Required] public DateTime StartChargingTime { get; set; }
        //Bus number
        public string BusNumber { get; set; }
        //energy consumeded by the charger
        [Required] public double EnergyConsumed { get; set; } //[kWh]
        //total charging time
        public uint ChargingTime { get; set; } //[s]
        //setting of battery charging power 
        public string ChargingPower { get; set; }
    }
}
