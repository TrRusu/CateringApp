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
    public class DBTable
    {
        public void CreateTable(int nrOfSeats)
        {
            using (MySqlConnection connection = DBConnection.GetConnection())
            {
                string sql = "INSERT INTO `Tables` (`NumberOfSeats`) VALUES (@nrOfSeats);";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("nrOfSeats", nrOfSeats);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<Table> GetAllTables()
        {
            using (MySqlConnection connection = DBConnection.GetConnection())
            {
                Table table = null;
                List<Table> listOfTables = new List<Table>();
                string sql = "SELECT * FROM Tables";
                MySqlCommand command = new MySqlCommand(sql, connection);
                connection.Open();
                MySqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    int ID = dataReader.GetInt32("ID");
                    int nrOfSeats = dataReader.GetInt32("NumberOfSeats");
          
                }
                return listOfTables;
            }
        }

        public List<Table> GetTablesWithSeats(int numberOfSeats)
        {
            using (MySqlConnection connection = DBConnection.GetConnection())
            {
                Table table = null;
                List<Table> listOfTables = new List<Table>();
                string sql = "SELECT * FROM Tables WHERE NumberOfSeats=@nrOfSeats";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("nrOfSeats", numberOfSeats);
                connection.Open();
                MySqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    int ID = dataReader.GetInt32("ID");
                }
                return listOfTables;
            }
        }

        public void RemoveItem(int tableid)
        {
            using (MySqlConnection connection = DBConnection.GetConnection())
            {
                string sql = "REMOVE FROM Tables WHERE Id=@id";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("id", tableid);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
