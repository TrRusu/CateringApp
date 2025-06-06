using Business.Interfaces;
using CateringApp.Attributes;
using DTO;
using Microsoft.AspNetCore.Mvc;
using CateringApp.Attributes;
using DTO.Viewmodels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CateringApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKey]
    public class SessionController : ControllerBase
    {
        ISessionBusiness _sessionBusiness;
        public SessionController(ISessionBusiness sessionBusiness)
        {
            _sessionBusiness = sessionBusiness;
        }

        [HttpPost]
        [Route("start")]
        public SessionViewModel createSession(int tableId) { 
            return _sessionBusiness.createSession(tableId);
        }

        [HttpPost]
        [Route("add-order")]
        public void AddOrderToSession(int orderId, int sessionId)
        {
            _sessionBusiness.AddOrderToSession(orderId, sessionId);
        }

        [HttpPut]
        [Route("close")]
        public void CloseSession(int sessionId)
        {
            _sessionBusiness.CloseSession(sessionId);
        }


        [HttpGet]
        [Route("get")]
        public Session? GetCurrentSession(int Id) {
            return _sessionBusiness.getCurrentSession(Id);
        }

        [HttpGet]
        [Route("orders")]
        public List<Order> GetOrdersForSession(int sessionID)
        {
            return _sessionBusiness.GetOrdersForSession(sessionID);
        }
    }
}
