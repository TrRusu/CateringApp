using CateringApp;
using DAL.Handlers;
using DTO;
using DTO.Viewmodels;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class OrderManager : IOrderManager
    {
        List<Order> listOfOrder;

        private readonly IOrderHandler _orderHandler;
        public OrderManager()
        {
            this.listOfOrder = new List<Order>();
        }

        public OrderViewModel CreateOrder(int sessionID, List<ItemModel> items)
        {
            int orderId = _orderHandler.CreateOrder(sessionID);
            _orderHandler.AddItemsToOrder(orderId, items);
            
            Order o = _orderHandler.GetOrderByID(orderId);
            
            return new OrderViewModel()
            {
                id = orderId,
                code = o.Name,
                moment = o.OrderMoment,
                items = items
            };
        }
        public OrderManager(IOrderHandler _orderHandler)
        {
            this._orderHandler = _orderHandler;
        }

        public OrderManager(List<Order> listOfOrder)
        {
            this.listOfOrder = listOfOrder;
        }

        public void AddItemToOrder(int orderID, int itemID) {
            _orderHandler.AddItemToOrder(orderID, itemID);
        }
        public void DeleteItemFromOrder(int orderID, int itemID) { 
            _orderHandler.DeleteItemFromOrder(orderID, itemID);
        }

        public double CalculateTotalPrice(int orderID)
        {
            return 0;
        }

        public List<Item> GetTheDisheshKitchen(int orderID)
        {
            List<Item> items = new List<Item>();
            return items;
        }

        public Order GetOrderByID(int orderID)
        {
            return _orderHandler.GetOrderByID(orderID);
        }
        
        public Order GetOrderByCode(string orderCode)
        {
            return _orderHandler.GetOrderByCode(orderCode);
        }

        public void UpdateOrderItem(int orderID, int itemID, int status)
        {
            _orderHandler.UpdateOrderItem(orderID, itemID, status);
        }

        public List<Order> GetOrderItemListByDay(DateTime date)
        {
            return _orderHandler.GetOrderItemListByDay(date);
        }
    }
}
