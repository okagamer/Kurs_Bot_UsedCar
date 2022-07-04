using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kurs_Api_UsedCar.Model.SearchUsedCar
{
    public class SearchResultCommon
    {
        public List<Datum> data { get; set; }
        public int count { get; set; }
        public int last_id { get; set; }
    }
}
