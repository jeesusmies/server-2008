using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace server_2007.http.handlers
{
    class HttpHandlers
    {
        // gonna do this when i feel like it

        public HttpHandlers() { }
        /*
        public string getScores(MySqlCommand cmd) {
            string text = "";
            var users = new List<string>();

            string mapHash = HttpUtility.ParseQueryString(uri.Query).Get("c");

            var sql = new MySqlCommand(String.Format("SELECT * from osu_scores WHERE osuhash = '{0}' and pass = True ORDER BY score DESC;", mapHash), con);
            MySqlDataReader rdr = cmd.ExecuteReader();

            int c = 0;
            while (rdr.Read())
            {
                if (users.FirstOrDefault(x => x.Contains(rdr.GetString(3))) == null)
                {
                    text += String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|0|LNJAO|0\n", rdr.GetString(0), rdr.GetString(3), rdr.GetString(11), rdr.GetString(12), rdr.GetString(7), rdr.GetString(6), rdr.GetString(5), rdr.GetString(10), rdr.GetString(9), rdr.GetString(8), rdr.GetBoolean(13), rdr.GetString(15));
                    users.Add(rdr.GetString(3));
                }
                c++;
            }
            return text;
        }
        */
    }
}
