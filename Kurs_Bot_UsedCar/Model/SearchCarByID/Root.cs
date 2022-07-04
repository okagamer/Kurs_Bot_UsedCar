using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kurs_Api_UsedCar.Model.SearchCarByID
{
    public class Root
    {
        public string locationCityName { get; set; }
        public string addDate { get; set; }
        public string updateDate { get; set; }
        public UserPhoneData userPhoneData { get; set; }
        public int USD { get; set; }
        public int UAH { get; set; }
        public Color color { get; set; }
        public AutoData autoData { get; set; }
        public string markName { get; set; }
        public string modelName { get; set; }
        public PhotoData photoData { get; set; }
        public string linkToView { get; set; }
        public string title { get; set; }
        public StateData stateData { get; set; }
    }
}
