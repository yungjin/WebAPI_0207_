using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Modules
{
    public class DataBase
    {
        private MySqlConnection conn = null;

        public DataBase()
        {
            GetConnection();
        }

        public void ConnectionClose()
        {
            conn.Close();
        }

        private bool GetConnection()
        {
            conn = new MySqlConnection();
            conn.ConnectionString
                = string.Format("server={0};user={1};password={2};database={3};port={4};", "192.168.3.154", "root", "1234", "gudi", "3306");
            try
            {
                conn.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public MySqlDataReader GetReader(string sql)
        {
            try
            {
                MySqlCommand comm = new MySqlCommand();
                comm.CommandText = sql;
                comm.Connection = conn;
                return comm.ExecuteReader();
            }
            catch
            {
                return null;
            }
        }

    }
}
