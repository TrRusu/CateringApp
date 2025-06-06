using CateringApp;
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
    public class DBIngredient
    {
        public void AddNewIngredient(Ingredient i)
        {
            using (MySqlConnection connection = DBConnection.GetConnection())
            {
                string sql = "INSERT INTO `Ingredients` (`Name`, `Amount`, `Price`) VALUES (@name, @amount, @price);";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("name", i.Name);
                command.Parameters.AddWithValue("amount", i.Amount);
                command.Parameters.AddWithValue("price", i.Price);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<Ingredient> GetIngredientsByItemID(int itemID)
        {
            using (MySqlConnection connection = DBConnection.GetConnection())
            {
                string sql = "SELECT * FROM ItemIngredients where ItemId=@itemid";
                List<Ingredient> listOfIngredient = new List<Ingredient>();
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("itemid", itemID);
                connection.Open();
                MySqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    int id = dataReader.GetInt32("IngredientId");
                    listOfIngredient.Add(GetIngredient(id));
                }

                return listOfIngredient;
            }
        }

        public Ingredient GetIngredient(int ingredientID)
        {
            using (MySqlConnection connection = DBConnection.GetConnection())
            {
                string sql = "SELECT * FROM Ingredients where ID=@ingredientID";
                Ingredient i = null;
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("ingredientID", ingredientID);
                connection.Open();
                MySqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    int id = dataReader.GetInt32("ID");
                    string name = dataReader.GetString("Name");
                    int amount = dataReader.GetInt32("Amount");
                    double price = dataReader.GetDouble("Price");
                   // i = new Ingredient(id, name, amount, price);
                }

                return i;
            }
        }



        public void DeleteIngredient(int ingredientID)
        {
            using (MySqlConnection connection = DBConnection.GetConnection())
            {
                string sql = "DELETE FROM Ingredients WHERE ID=@ingredientID";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("ingredientID", ingredientID);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<Ingredient> GetAllIngredients()
        {
            using (MySqlConnection connection = DBConnection.GetConnection())
            {
                Ingredient i = null;
                List<Ingredient> listOfIngredients = new List<Ingredient>();
                string sql = "SELECT * FROM Ingredients";
                MySqlCommand command = new MySqlCommand(sql, connection);
                connection.Open();
                MySqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    int id = dataReader.GetInt32("ID");
                    string name = dataReader.GetString("Name");
                    int amount = dataReader.GetInt32("Amount");
                    double price = dataReader.GetDouble("Price");
                    //i = new Ingredient(id, name, amount, price);
                    listOfIngredients.Add(i);
                }
                return listOfIngredients;
            }
        }
    }
}
