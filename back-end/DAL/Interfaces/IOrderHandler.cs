using CateringApp;
using DTO;
using DTO.Viewmodels;

namespace DAL.Handlers
{
    public interface IOrderHandler
    {
        public List<Order> getAllOrderInSession(int sessionId);
        Order OneOrder(int id);
        public void AddItemToOrder(int orderID, int itemID);
        public void DeleteItemFromOrder(int orderID, int itemID);
        public int CreateOrder(int sessionID);
        public Order GetTheDisheshKitchen(int orderID);
        public Order GetOrderByCode(string orderCode);
        public Order GetOrderByID(int oderID);
        public int getOrderId(int sessionID);
        public void AddItemsToOrder(int orderId, List<ItemModel> items);
        public void UpdateOrderItem(int orderID, int itemID, int status);
        public List<Order> GetOrderItemListByDay(DateTime date);


    }
}