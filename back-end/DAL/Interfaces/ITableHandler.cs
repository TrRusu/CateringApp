using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ITableHandler
    {
        public void UpdateTable(TableStatus status, int tableId);
        IEnumerable<Table> GetTablesByNumberOfSeats(int numberOfSeats);
        IEnumerable<Table> getAll();
    }
}
