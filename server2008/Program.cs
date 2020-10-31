using server_2007.http;
using server_2007.mysql;
using System;

namespace server2008
{
    class Program
    {
        static void Main(string[] args)
        {
            // CODE IS VERY BAD !!!!!!!!!!!!!!!! DONOT READ IF U DON'T WANT BRAIN DAMAGE !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            // gonna rewrite soon cuz code is un organized and stuff
            HttpServer server = new HttpServer("http://127.0.0.1:80/", new SqlInit("", "", "", ""));
        }
    }
}
