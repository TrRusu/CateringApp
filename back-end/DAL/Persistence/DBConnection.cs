using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaAdminPanel.Persistence
{
    public class DBConnection
    {
        public static MySqlConnection GetConnection()
        {
            MySqlConnection conn =
               new MySqlConnection("server=<ip>; port=<port>; database=catering-dev; user=diversiteam; password=<password>; Persist Security Info=False; Connect Timeout=300");
            return conn;
        }
    }
}
