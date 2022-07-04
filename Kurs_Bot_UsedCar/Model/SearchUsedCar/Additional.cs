using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kurs_Api_UsedCar.Model.SearchUsedCar
{
    public class Additional
    {
        public List<object> user_auto_positions { get; set; }
        public SearchParams search_params { get; set; }
        public string query_string { get; set; }
    }
}
