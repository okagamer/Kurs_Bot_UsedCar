using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kurs_Api_UsedCar.Model.SearchCarByID
{
    public class AutoData
    {
        public bool active { get; set; }
        public bool vat { get; set; }
        public string description { get; set; }
        public int year { get; set; }
        public int autoId { get; set; }
        public string race { get; set; }
        public string fuelName { get; set; }
        public string gearboxName { get; set; }
        public int driveId { get; set; }
        public string driveName { get; set; }
        public bool isSold { get; set; }
        public string mainCurrency { get; set; }
        public string categoryNameEng { get; set; }
        public string subCategoryNameEng { get; set; }
        public int custom { get; set; }
    }

}
