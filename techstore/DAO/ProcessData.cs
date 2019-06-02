using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace techstore.DAO
{
    public class ProcessData
    {
        public static string path = "SERVER=db4free.net; PORT=3306; DATABASE=techmart; UID=techmart; PWD=techmart;oldguids=true";
        public static MySqlConnection conn = new MySqlConnection(path);

        public static DataTable Query(string query)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);

            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;
        }
        public static int Exec(string cmd)
        {
            conn.Open();
            MySqlCommand command = new MySqlCommand(cmd, conn);
            command.ExecuteNonQuery();
            conn.Close();
            return 0;
        }
    }
}
