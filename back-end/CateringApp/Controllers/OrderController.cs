using Business;
using Business.Interfaces;
using DTO;
using DTO.Viewmodels;
using Microsoft.AspNetCore.Mvc;

namespace CateringApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderManager _orderManager;
        public OrderController(IOrderManager _orderManager)
        {
            this._orderManager = _orderManager;
        }
        
        [HttpPost]
        [Route("add-item")]
        public void AddItemToOrder(int orderID, int itemID) {
            _orderManager.AddItemToOrder(orderID, itemID);
        }

        [HttpPost]
        [Route("update-orderitem-status")]
        public void UpdateOrderItemStatus(int orderID, int itemID, int status)
        {
            _orderManager.UpdateOrderItem(orderID, itemID, status);
        }

        [HttpGet]
        [Route("get-orderitemlist-today")]
        public List<Order> GetOrderItemListForToday()
        {
            DateTime date = DateTime.Now;
            return _orderManager.GetOrderItemListByDay(date.Date);
        }

        [HttpPost]
        [Route("delete-item")]
        public void DeleteItemFromOrder(int orderID, int itemID) {
            _orderManager.DeleteItemFromOrder(orderID, itemID);
        }

        [HttpPost]
        [Route("create")]
        public OrderViewModel CreateOrder(int sessionID, List<ItemModel> items)
        {
            return _orderManager.CreateOrder(sessionID, items);
        }

        [HttpGet]
        [Route("get-order")]
        public Order GetOrderById(string orderCode)
        {
            return _orderManager.GetOrderByCode(orderCode);
        }
    }
}
