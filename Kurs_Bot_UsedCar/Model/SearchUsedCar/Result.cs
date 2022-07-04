using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kurs_Api_UsedCar.Model.SearchUsedCar
{
    public class Result
    {
        public SearchResult search_result { get; set; }
        public SearchResultCommon search_result_common { get; set; }
        public bool isCommonSearch { get; set; }
        public ActiveMarka active_marka { get; set; }
        public object active_model { get; set; }
        public object active_city { get; set; }
        public object active_state { get; set; }
        public object revies { get; set; }
        public Additional additional { get; set; }
    }
}
