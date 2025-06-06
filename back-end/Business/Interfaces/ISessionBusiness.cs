using DTO;
using DTO.Viewmodels;

namespace Business.Interfaces
{
    public interface ISessionBusiness
    {
        SessionViewModel createSession(int tableId);
        Session? getCurrentSession(int id);
        public void AddOrderToSession(int orderId, int sessionId);
        public List<Order> GetOrdersForSession(int sessionID);
        public void CloseSession(int sessionId);
    }
}