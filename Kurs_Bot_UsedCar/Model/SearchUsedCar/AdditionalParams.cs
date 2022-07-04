using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kurs_Api_UsedCar.Model.SearchUsedCar
{
    public class AdditionalParams
    {
        public int lang_id { get; set; }
        public int page { get; set; }
        public int view_type_id { get; set; }
        public string target { get; set; }
        public string section { get; set; }
        public string catalog_name { get; set; }
        public bool elastica { get; set; }
        public bool nodejs { get; set; }
    }
}
