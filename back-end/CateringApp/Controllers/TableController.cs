using Business.Interfaces;
using DTO;
using DTO.Viewmodels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CateringApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly ITableManager _manager;

        public TableController(ITableManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        [Route("all")]
        public IEnumerable<Table> getAll() {
            return _manager.getAll();
        }
    }
}
