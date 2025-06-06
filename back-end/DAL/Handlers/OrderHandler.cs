using CateringApp;
using DAL.Data;
using DTO;
using DTO.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DAL.Handlers
{
    public class OrderHandler : IOrderHandler
    {
        List<Order> listOfOrders = new List<Order>();
        ItemHandler itemHandler;
        private readonly DataContext _dataContext;

        public OrderHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<Order> getAllOrderInSession(int sessionId) { 
            return _dataContext.Orders.Where(x => x.SessionId == sessionId).ToList();
        }

        public Order OneOrder(int id)
        {   
            Order o = null;
            return o;
        }

        public Order GetOrderByID(int orderId)
        {
            using (DataContext context = new DataContext())
            {
                return context.Orders
                    .Include(order => order.ItemOrders)
                        .ThenInclude(orderItem => orderItem.Item)
                    .First(x => x.ID == orderId);
            }
        }
        
        public Order GetOrderByCode(string orderCode)
        {
            using (DataContext context = new DataContext())
            {
                return context.Orders
                    .Include(order => order.ItemOrders)
                    .ThenInclude(orderItem => orderItem.Item)
                    .First(x => x.Name == orderCode);
            }
        }

        public int getOrderId(int sessionID)
        {
            using (DataContext context = new DataContext())
            {
                Order o = context.Orders.Where(x => x.SessionId == sessionID).ToList().OrderByDescending(t => t.OrderMoment).FirstOrDefault();
                return o.ID;
            }
        }

        public List<Order> GetOrderItemListByDay(DateTime date)
        {
            using (DataContext context = new DataContext())
            {
                List<Order> listOfNewOrders = _dataContext.Orders.Where(i => i.OrderMoment.Date == date)
                    .Include(order => order.ItemOrders)
                        .ThenInclude(orderItem => orderItem.Item).ToList();

                return listOfNewOrders;
            }
        }

        public int CreateOrder(int sessionID)
        {

            using (DataContext context = new DataContext())
            {
                Order o = new Order()
                {
                    SessionId = sessionID,
                    OrderMoment = DateTime.Now,
                    Name = Nanoid.Nanoid.Generate("QWERTYUIOPASDFGHJKLZXCVBNM", 6),
                };

                context.Orders.Add(o);
                context.SaveChanges();
            }
            return getOrderId(sessionID);
        }


        public void AddItemToOrder(int orderID, int itemID)
        {   

        }

        public void DeleteItemFromOrder(int orderID, int itemID)
        {

        }

        public Order GetTheDisheshKitchen(int orderID)
        {
            return listOfOrders.First(x => x.ID == orderID);
        }


        //ITEMORDER HANDLER STUFF
        public void AddItemsToOrder(int orderId, List<ItemModel> items)
        {
            var orderItems = new List<ItemOrder>();
            
            foreach (var item in items)
            {
                ItemOrder io = new ItemOrder()
                {
                    OrderId = orderId,
                    Status = CookStatus.Preparing,
                    ItemId = item.id,
                    Amount = item.amount
                };
                
                orderItems.Add(io);
            }
            
            _dataContext.ItemOrders.AddRange(orderItems);
            _dataContext.SaveChanges();
        }
        public void UpdateOrderItem(int orderID, int itemID, int status)
        {
            using (DataContext context = new DataContext())
            {
                
                List<ItemOrder> listOfOrders = _dataContext.ItemOrders.Where(i => i.Order.ID == orderID).ToList();
                ItemOrder myItemOrder = listOfOrders.Find(i => i.ItemId == itemID);
                myItemOrder.Status = (CookStatus)status;
                _dataContext.SaveChanges();
            }

        }
    }
}
