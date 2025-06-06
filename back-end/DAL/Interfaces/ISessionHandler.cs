using DTO;
using DTO.Viewmodels;

namespace DAL.Interfaces
{
    public interface ISessionHandler
    {
        void AddItem(int tableId, int orderId);
        SessionViewModel CreateSession(int tableId);
        public void AddOrderToSession(int orderid, int sessionid);
        public Session? getCurrentSession(int id);
        public List<int> GetOrderForSession(int sessionID);
        public void CloseSession(int sessionId);
    }
}