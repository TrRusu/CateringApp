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
    public class CategoryHandler : ICategoryHandler
    {
        private readonly DataContext _dataContext;

        public CategoryHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<Category> getAll()
        {
            return _dataContext.Categories.ToList();
        }
    }
}
