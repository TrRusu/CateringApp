using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Viewmodels
{
    public class TableViewmodel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TableStatus Status { get; set; }
        public int amount_seats { get; set; }
        public Session Session { get; set; }
    }
}
