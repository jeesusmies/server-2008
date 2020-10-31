using System;
using System.Collections.Generic;
using System.Text;

namespace server_2007.mysql
{
    class SqlInit
    {
        private string _server;
        private string _userid;
        private string _password;
        private string _database;

        public SqlInit(string server, string userid, string password, string database) {
            _server = server;
            _userid = userid;
            _password = password;
            _database = database;
        }

        public string ConnectionString() {
            return String.Format("server={0};userid={1};password={2};database={3}", this._server, this._userid, this._password, this._database);
        }
    }
}
