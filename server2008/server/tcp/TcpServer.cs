using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using server2008.server.tcp.User;

namespace server2008.server.tcp
{
    class TcpServer
    {
        string _ip;
        int _port;

        public TcpServer(string ip, int port) {
            _ip = ip;
            _port = port;
        }
        public void TcpConnectionListener() {
            IPAddress addr = IPAddress.Parse(_ip);
            TcpListener serverSocket = new TcpListener(IPAddress.Parse("127.0.0.1"), _port);

            serverSocket.Start();
            Console.WriteLine("[TcpServer] Server up!");

            while (true) {
                Console.WriteLine("[TcpServer] Server up!");
                try {
                    TcpClient clientSocket = serverSocket.AcceptTcpClient();
                    Console.WriteLine("[TcpServer] Client connected!");
                    UserClient client = new UserClient(clientSocket);
                    client.startClient();
                } catch (Exception ex) {
                    Console.WriteLine(ex);
                }
            }
        }
    }
}
