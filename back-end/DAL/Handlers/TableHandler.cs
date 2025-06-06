using DAL.Data;
using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Handlers
{
    public class TableHandler : ITableHandler
    {
        private readonly DataContext _dataContext;
        private readonly ITableHandler _tableHandler;

        public TableHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<Table> getAll()
        {
            return _dataContext.Tables.ToList();
        }

        public IEnumerable<Table> GetTablesByNumberOfSeats(int numberOfSeats)
        {
            using (_dataContext)
            {
                return _dataContext.Tables.Where(x => x.amount_seats == numberOfSeats).ToList();
            }
        }

        public void UpdateTable(TableStatus status, int tableId) {
            Table t = _dataContext.Tables.First(x => x.Id == tableId);
            t.Status = status;
            _dataContext.SaveChanges();
        }
    }
}
