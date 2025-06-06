using CateringApp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Order
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int SessionId { get; set; }
        public DateTime OrderMoment { get; set; }
        public Session Session { get; set; }
        public ICollection<ItemOrder>? ItemOrders { get; set; }
    }
}
