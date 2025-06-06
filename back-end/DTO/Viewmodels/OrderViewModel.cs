using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Viewmodels
{
    public class OrderViewModel
    {
        public int id { get; set; }
        public string code { get; set; }
        public DateTime moment { get; set; }
        public int total_price { get; set; }
        public Status current_status { get; set; }
        public List<ItemModel> items { get; set; }
    }
}
