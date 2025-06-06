using CateringApp;
using DTO;
using MySqlConnector;
using OmegaAdminPanel.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CateringApp.Item;

namespace DAL.Persistence
{
    public class DBOrder
    {
        DBItem _dbItem = new DBItem(); 
        public void AddItemToOrder(int orderid, int itemid)
        {
            using (MySqlConnection connection = DBConnection.GetConnection())
            {
                string sql = "INSERT INTO `OrderItem` (`OrderId`, `ItemId`) VALUES (@orderid, @itemid);";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("itemid", itemid);
                command.Parameters.AddWithValue("orderid", orderid);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public Order GetOrder(int orderid)
        {
            using (MySqlConnection connection = DBConnection.GetConnection())
            {
                List<Item> listOfItems = new List<Item>(); 
                string sql = "SELECT * FROM OrderItem where OrderId=@id";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("id", orderid);
                connection.Open();
                MySqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    int itemid = dataReader.GetInt32("ItemId");
                    listOfItems.Add(_dbItem.GetItem(itemid));
                }
                Order order = new Order();
               return order;
            }
        }


        public void DeleteItemFromOrder(int orderid, int itemid)
        {
            using (MySqlConnection connection = DBConnection.GetConnection())
            {
                string sql = "DELETE FROM OrderItem WHERE OrderId=@orderid && ItemId=@itemid";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("itemid", itemid);
                command.Parameters.AddWithValue("orderid", orderid);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

    }
}
