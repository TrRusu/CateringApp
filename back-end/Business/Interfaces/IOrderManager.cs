using CateringApp;
using DTO;
using DTO.Viewmodels;

namespace Business
{
    public interface IOrderManager
    {
        double CalculateTotalPrice(int orderID);
        //public OrderView OneOrder(int orderid);
        public void AddItemToOrder(int orderID, int itemID);
        public void DeleteItemFromOrder(int orderID, int itemID);
        public OrderViewModel CreateOrder(int sessionID, List<ItemModel> items);
        public List<Item> GetTheDisheshKitchen(int orderID);
        public Order GetOrderByID(int orderId);
        public Order GetOrderByCode(string orderCode);
        public void UpdateOrderItem(int orderID, int itemID, int status);
        public List<Order> GetOrderItemListByDay(DateTime date);
    }
}