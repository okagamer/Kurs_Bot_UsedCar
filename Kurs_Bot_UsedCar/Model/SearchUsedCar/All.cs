using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kurs_Api_UsedCar.Model.SearchUsedCar
{
    public class All
    {
        public List<int> marka_id { get; set; }
        public int searchType { get; set; }
        public string target { get; set; }
        public string @event { get; set; }
        public int lang_id { get; set; }
        public int page { get; set; }
        public object limit_page { get; set; }
        public int countpage { get; set; }
        public int last_id { get; set; }
        public int saledParam { get; set; }
        public List<object> model_id { get; set; }
        public List<object> mm_marka_filtr { get; set; }
        public List<object> mm_model_filtr { get; set; }
        public bool useOrigAutoTable { get; set; }
        public bool withoutStatus { get; set; }
        public bool with_photo { get; set; }
        public bool with_video { get; set; }
        public int under_credit { get; set; }
        public int confiscated_car { get; set; }
        public List<object> exchange_filter { get; set; }
        public bool old_only { get; set; }
        public List<object> auto_options { get; set; }
        public int user_id { get; set; }
        public int person_id { get; set; }
        public bool with_discount { get; set; }
        public string auto_id_str { get; set; }
        public int black_user_id { get; set; }
        public int order_by { get; set; }
        public bool is_online { get; set; }
        public bool withoutCache { get; set; }
        public bool with_last_id { get; set; }
        public int top { get; set; }
        public int currency { get; set; }
        public int currency_id { get; set; }
        public List<object> currencies_arr { get; set; }
        public int power_name { get; set; }
        public int powerFrom { get; set; }
        public int powerTo { get; set; }
        public List<object> hide_black_list { get; set; }
        public int custom { get; set; }
        public bool abroad { get; set; }
        public int damage { get; set; }
        public int star_auto { get; set; }
        public int price_ot { get; set; }
        public int price_do { get; set; }
        public List<object> s_yers { get; set; }
        public List<object> po_yers { get; set; }
        public int year { get; set; }
        public int auto_ids_search_position { get; set; }
        public int print_qs { get; set; }
        public int is_hot { get; set; }
        public int deletedAutoSearch { get; set; }
        public int can_be_checked { get; set; }
        public List<object> excludeMM { get; set; }
        public Verified verified { get; set; }
        public int auctionPossible { get; set; }
    }
}
