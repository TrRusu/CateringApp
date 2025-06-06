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
    public class DBItem
    {
        DBIngredient dbIngredient = new DBIngredient();
        public Item GetItem(int itemid)
        {
            using (MySqlConnection connection = DBConnection.GetConnection())
            {
                Item item = null;
                string sql = "SELECT * FROM Items where ID=@itemid";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("itemid", itemid);
                connection.Open();
                MySqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    string name = dataReader.GetString("Name");
                    double price = dataReader.GetDouble("Price");
                    string type = dataReader.GetString("ItemType");
                    Enum.TryParse(type, out ItemType _type);
                    string description = dataReader.GetString("Description");
                    List<Ingredient> listOfIngredient = dbIngredient.GetIngredientsByItemID(itemid);
                   // item = new Item(itemid, name, price, _type, description, listOfIngredient);
                }
                return item;
            }
        }

        public List<Item> GetItemByCategory(string category)
        {
            using (MySqlConnection connection = DBConnection.GetConnection())
            {
                Item item = null;
                List<Item> listOfItems = new List<Item>();
                string sql = "SELECT * FROM Items where ItemType=@category";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("category", category);
                connection.Open();
                MySqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    int id = dataReader.GetInt32("ID");
                    string name = dataReader.GetString("Name");
                    double price = dataReader.GetDouble("Price");
                    Enum.TryParse(category, out ItemType _type);
                    string description = dataReader.GetString("Description");
                    List<Ingredient> listOfIngredient = dbIngredient.GetIngredientsByItemID(id);
                    //item = new Item(id, name, price, _type, description, listOfIngredient);
                    listOfItems.Add(item);
                }
                return listOfItems;
            }
        }

        public List<Item> GetAllItems()
        {
            using (MySqlConnection connection = DBConnection.GetConnection())
            {
                Item item = null;
                List<Item> listOfItems = new List<Item>();
                string sql = "SELECT * FROM Items";
                MySqlCommand command = new MySqlCommand(sql, connection);
                connection.Open();
                MySqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    int id = dataReader.GetInt32("ID");
                    string name = dataReader.GetString("Name");
                    double price = dataReader.GetDouble("Price");
                    string type = dataReader.GetString("ItemType");
                    Enum.TryParse(type, out ItemType _type);
                    string description = dataReader.GetString("Description");
                    List<Ingredient> listOfIngredient = dbIngredient.GetIngredientsByItemID(id);
                   // item = new Item(id, name, price, _type, description, listOfIngredient);
                    listOfItems.Add(item);
                }
                return listOfItems;
            }
        }

        public void ChangeStatus(int orderid, int itemid, string status)
        {
            using (MySqlConnection connection = DBConnection.GetConnection())
            {
                string sql = "UPDATE orderitem SET ItemStatus=@status WHERE ItemId=@itemid && OrderId=@orderid";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("status", status);
                command.Parameters.AddWithValue("itemid", itemid);
                command.Parameters.AddWithValue("orderid", orderid);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void AddItem(Item item)
        {
            using (MySqlConnection connection = DBConnection.GetConnection())
            {
                string sql = "INSERT INTO `Items` (`Name`, `Price`, `ItemType`, `Description`) VALUES (@name, @price, @type, @description);";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("name", item.Name);
                command.Parameters.AddWithValue("price", item.Price);
                command.Parameters.AddWithValue("type", item.itemType.ToString());
                command.Parameters.AddWithValue("description", item.Description);


                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void AddIngredientToItem(int itemid, int ingredientid)
        {
            using (MySqlConnection connection = DBConnection.GetConnection())
            {
                string sql = "INSERT INTO `ItemIngredients` (`ItemId`, `IngredientId`) VALUES (@itemid, @ingredientid);";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("itemid", itemid);
                command.Parameters.AddWithValue("ingredientid", ingredientid);


                connection.Open();
                command.ExecuteNonQuery();
            }
        }

    }
}
