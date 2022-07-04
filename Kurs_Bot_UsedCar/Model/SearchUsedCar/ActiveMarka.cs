using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kurs_Api_UsedCar.Model.SearchUsedCar
{
    public class ActiveMarka
    {
        public int lang_id { get; set; }
        public int marka_id { get; set; }
        public string name { get; set; }
        public string set_cat { get; set; }
        public int main_category { get; set; }
        public int active { get; set; }
        public int country_id { get; set; }
        public string eng { get; set; }
        public int count { get; set; }
        public int fit { get; set; }
    }
}
