using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Seguros.Util
{
    public class DAL

    {
        private static string server = "localhost";
        private static string database = "seguros";
        private static string user = "root";
        private static string password = "loide";
        private string connectionString = $"Server={server};Database={database};Uid={user};Pwd={password}";
        private MySqlConnection connection;

        public DAL()
        {
            connection = new MySqlConnection(connectionString);
            connection.Open();
        }
        // Execute os Selects
        public DataTable RetDataTable(string sql)
        {
            DataTable datatable = new DataTable();
            MySqlCommand comand = new MySqlCommand(sql, connection);
            MySqlDataAdapter da = new MySqlDataAdapter(comand);
            da.Fill(datatable);
            connection.Close();
            return datatable;

        }
        //Executa os INSERTS,UPDATE, DELETES
        public void ExecutarComandoSQL(string sql)
        {
            MySqlCommand comand = new MySqlCommand(sql, connection);
            comand.ExecuteNonQuery();
            connection.Close();
        }
    }
}
