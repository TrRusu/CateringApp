using CateringApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Viewmodels
{
    public class CategoryViewModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<Item> items { get; set; }
    }
}
