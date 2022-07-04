using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kurs_Api_UsedCar.Model.SearchCarByID
{
    public class PhotoData
    {
        public List<int> all { get; set; }
        public int count { get; set; }
        public string seoLinkM { get; set; }
        public string seoLinkSX { get; set; }
        public string seoLinkB { get; set; }
        public string seoLinkF { get; set; }
    }
}
