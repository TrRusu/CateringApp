using DAL.Data;
using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DTO.Viewmodels;

namespace DAL.Handlers
{
    public class SessionHandler : ISessionHandler
    {
        private readonly DataContext _dataContext;
        
        public SessionHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public SessionViewModel CreateSession(int tableId)
        {
            Session s = new Session() {
                TableId = tableId,
                Status = Status.Busy, 
                Paid = false
            };
            
            _dataContext.Sessions.Add(s);
            _dataContext.SaveChanges();

            return new SessionViewModel()
            {
                id = s.Id,
                paid = s.Paid,
                status = s.Status,
                table_id = s.TableId
            };
        }

        public void CloseSession(int sessionId) {
            Session s = _dataContext.Sessions.First(x => x.Id == sessionId);
            s.Paid = true;
            _dataContext.SaveChanges();
        }

        public void AddOrderToSession(int orderId, int sessionId)
        {
            Order o = _dataContext.Orders.First(p => p.ID == orderId);
            
            if (o == null) return;
            
            Session s = _dataContext.Sessions.First(s => s.Id == sessionId);
            s.Orders.Add(o);
            
            _dataContext.Sessions.Update(s);
            _dataContext.SaveChanges();
        }

        public Session? getCurrentSession(int id)
        {
            return _dataContext.Sessions.Find(id);
        }

        public void AddItem(int tableId, int orderId)
        {

        }
        
        public List<int> GetOrderForSession(int sessionID)
        {
            return new List<int>();
        }
    }
}
