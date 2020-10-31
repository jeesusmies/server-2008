using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace server2008.server.tcp.User
{
    class UserClient
    {
        TcpClient _clientSocket;
        private readonly Random _random = new Random();

        public UserClient(TcpClient clientSocket) {
            _clientSocket = clientSocket;
        }

        public void startClient() {
            Thread userThread = new Thread(doSomeStuffIdk);
            userThread.Start();
        }

        // change method name to something else.,.
        public void doSomeStuffIdk() {
            byte[] bytesFrom = new byte[1024];
            byte[] bytesFromT = new byte[1024];
            string dataFromClient;
            string[] dataFromClientFormatted;
            byte[] sendBytes;

            try {
                NetworkStream networkStream = _clientSocket.GetStream();
                PacketHandler packetHandler = new PacketHandler();
                networkStream.Read(bytesFrom, 0, 1024);
                dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);
                dataFromClientFormatted = dataFromClient.Split(new string[] { "\n" }, StringSplitOptions.None);

                // gotta make logging in better lmap
                if (dataFromClientFormatted[0] == "lol\r" || dataFromClientFormatted[0] == "asdf\r" || dataFromClientFormatted[0] == "jeesusmies\r") {

                    sendBytes = packetHandler.LoginPacket(1);
                    networkStream.Write(sendBytes, 0, sendBytes.Length);

                    sendBytes = packetHandler.UserStatsPacket(1436534);
                    networkStream.Write(sendBytes, 0, sendBytes.Length);

                    while (networkStream.Read(bytesFrom, 0, 1024) > 0) {
                        Thread.Sleep(1000);
                        networkStream.Read(bytesFrom, 0, 1024);

                        if (bytesFrom != bytesFromT) {
                            // user stats still confusing, packet id is random and i don't get what i should to
                            // gotta do research!
                            byte[] packetID = { bytesFrom[0], bytesFrom[1] };
                            using (MemoryStream ms = new MemoryStream(packetID)) {
                                using (BinaryReader reader = new BinaryReader(ms)) {
                                    Debug.WriteLine(reader.ReadUInt16());
                                    //Console.WriteLine("[PACKET ID: {0} {1}" + "] " + System.Text.Encoding.ASCII.GetString(new ArraySegment<byte>(bytesFrom, 7, bytesFrom.Length - 100)), bytesFrom[0].ToString("x2"), bytesFrom[1].ToString("x2"));
                                    // user stat packet should be 3 but isn't? either i am stupid or osu client is high as fuck
                                    if (reader.ReadUInt16() == 3) {
                                        Debug.WriteLine("Ayo");
                                        // sendBytes = packetHandler.UserStatsPacket(_random.Next(32132124));
                                        networkStream.Write(sendBytes, 0, sendBytes.Length);
                                    }
                                }
                            }
                        }
                        
                        //networkStream.Read(bytesFromT, 0, 1024);
                        
                    }
                } else {
                    sendBytes = packetHandler.LoginPacket(-1);
                    Debug.WriteLine(dataFromClientFormatted[0]);
                    networkStream.Write(sendBytes, 0, sendBytes.Length);
                }
                

            } catch (Exception ex) {
                Debug.WriteLine(ex);
            }
        }
    }
}