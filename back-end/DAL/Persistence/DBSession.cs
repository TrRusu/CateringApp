using DTO;
using MySqlConnector;
using OmegaAdminPanel.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Persistence
{
    public class DBSession
    {
        public void CreateSession(int tableid, int orderid)
        {
            using (MySqlConnection connection = DBConnection.GetConnection())
            {
                string sql = "INSERT INTO `Sessions` (`TableID`, `OrderID`, `Paid`, `Status`) VALUES (@tableid, @orderid, false, null);";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("tableid", tableid);
                command.Parameters.AddWithValue("orderid", orderid);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public Session GetSession(int id)
        {
            using (MySqlConnection connection = DBConnection.GetConnection())
            {
                Session session = null;
                string sql = "SELECT * FROM Session where Id=@id";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("id", id);
                connection.Open();
                MySqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    int tableid = dataReader.GetInt32("TableID");
                    int orderid = dataReader.GetInt32("OrderID");
                    bool paid = dataReader.GetBoolean("Paid");
                    string status = dataReader.GetString("Status");
                    Enum.TryParse(status, out Status _status);
                }
                return session;
            }
        }

        public List<int> GetOrderBySessionID(int sessionID)
        {
            using (MySqlConnection connection = DBConnection.GetConnection())
            {
                Session session = null;
                List<int> listOfOrderID = new List<int>();
                string sql = "SELECT * FROM Session Tables WHERE Id=@sessionID";
                MySqlCommand command = new MySqlCommand(sql, connection);
                connection.Open();
                MySqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    int orderid = dataReader.GetInt32("OrderID");
                    listOfOrderID.Add(orderid);
                }
                return listOfOrderID;
            }
        }


    }
}
