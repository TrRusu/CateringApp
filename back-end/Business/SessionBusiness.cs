using Business.Interfaces;
using DAL.Handlers;
using DAL.Interfaces;
using DTO;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Viewmodels;

namespace Business
{
    public class SessionBusiness : ISessionBusiness
    {
        private readonly ISessionHandler _sessionHandler;
        private readonly IOrderHandler _orderHandler;
        private readonly ITableHandler _tableHandler;

        public SessionBusiness(ISessionHandler sessionHandler, IOrderHandler orderHandler, ITableHandler tableHandler)
        {
            _sessionHandler = sessionHandler;
            _orderHandler = orderHandler;
            _tableHandler = tableHandler;
        }

        public void AddOrderToSession(int orderId, int sessionId) {}

        public SessionViewModel createSession(int tableId)
        {
            _tableHandler.UpdateTable(TableStatus.Busy, tableId);
            return _sessionHandler.CreateSession(tableId);
        }
        public Session? getCurrentSession(int id)
        {
            return _sessionHandler.getCurrentSession(id);
        }

        public List<Order> GetOrdersForSession(int sessionID)
        {
            return _orderHandler.getAllOrderInSession(sessionID);
        }

        public void CloseSession(int sessionId) {
            int tableId = getCurrentSession(sessionId).TableId;
            _tableHandler.UpdateTable(TableStatus.Available, tableId);
            _sessionHandler.CloseSession(sessionId);
        }
    }
}
