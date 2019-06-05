using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargerEmulator
{
    class Raport
    {
        public Guid Id { get; set; }
        public DateTime StartChargingTime { get; set; }
        public string BusNumber { get; set; }
        public double EnergyConsumed { get; set; } //[kWh]
        public uint ChargingTime { get; set; } //[s]
        public string ChargingPower { get; set; }
    }
}
