using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kurs_Api_UsedCar.Model.SearchCarByID
{
    public class AutoInfoBar
    {
        public bool custom { get; set; }
        public bool abroad { get; set; }
        public bool onRepairParts { get; set; }
        public bool damage { get; set; }
        public bool underCredit { get; set; }
        public bool confiscatedCar { get; set; }
    }
}
