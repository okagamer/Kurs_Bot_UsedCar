using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kurs_Api_UsedCar.Model.SearchUsedCar
{
    public class Cleaned
    {
        public List<int> marka_id { get; set; }
        public int searchType { get; set; }
        public string target { get; set; }
        public string @event { get; set; }
        public int lang_id { get; set; }
        public int countpage { get; set; }
        public List<object> model_id { get; set; }
        public List<object> mm_marka_filtr { get; set; }
        public List<object> mm_model_filtr { get; set; }
        public List<object> exchange_filter { get; set; }
        public List<object> auto_options { get; set; }
        public int currency { get; set; }
        public List<object> currencies_arr { get; set; }
        public List<object> hide_black_list { get; set; }
        public List<object> s_yers { get; set; }
        public List<object> po_yers { get; set; }
        public List<object> excludeMM { get; set; }
        public Verified verified { get; set; }
    }
}
