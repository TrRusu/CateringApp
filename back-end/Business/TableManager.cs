using Business.Interfaces;
using DAL.Handlers;
using DAL.Interfaces;
using DTO;
using DTO.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class TableManager : ITableManager
    {
        private readonly ITableHandler _tableHandler;

        public TableManager(ITableHandler tableHandler)
        {
            _tableHandler = tableHandler;
        }

        public IEnumerable<Table> getAll() {
            return _tableHandler.getAll();
        }
    }
}
