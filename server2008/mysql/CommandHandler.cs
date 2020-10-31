using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace server_2007.mysql
{
    class CommandHandler
    {
        // Todo... gsdfgdsf
        public static void Query(SqlInit init, string sql)
        {
            MySqlConnection Connection = new MySqlConnection(init.ConnectionString());
            MySqlCommand Command = Connection.CreateCommand();
            Command.CommandText = sql;

            try {
                Connection.Open();
            } catch (Exception e) {
                throw e;
            }
        }
    }
}
