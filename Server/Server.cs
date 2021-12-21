using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace Server
{
    //Processing data
    class ProcessingData
    {
        SaveData save = new SaveData();

        public List<TcpClient> clientList = new List<TcpClient>();

        public void addClients(TcpClient client)
        {
            clientList.Add(client);
        }

        //Take message from client
        public void GetMessage(TcpClient tcpClient)
        {
            Console.WriteLine("Client is Connected.");
            StreamReader reader = new StreamReader(tcpClient.GetStream());

            //Every incoming message will be read and recorded
            while (true)
            {
                string message = reader.ReadLine();
                Broadcast(message, tcpClient);

                string chat = message;
                Console.WriteLine(chat);

                save.writeMessage(chat);
            }
        }

        //Save data into txt file
        class SaveData
        {
            private List<string> saveMessages = new List<string>();
            public void writeMessage(string chat)
            {
                saveMessages.Add(chat);
                File.WriteAllLines("C:/Pens/Semester 5/Pemrograman Jaringan Komputer/TCP Replication/TCP-Replication/ChatHistory.txt", saveMessages);
            }
        }

        //Broadcast message
        public void Broadcast(string message, TcpClient excludeClient)
        {
            foreach (TcpClient client in clientList)
            {

                StreamWriter sWriter = new StreamWriter(client.GetStream());

                if (client != excludeClient)
                {
                    sWriter.WriteLine(message);
                }

                sWriter.Flush();
            }
        }
    }

    class Program
    {
        public static TcpListener tcpListener;

        static void Main(string[] args)
        {
            ProcessingData dataClient = new ProcessingData();

            tcpListener = new TcpListener(IPAddress.Any, 6000);
            tcpListener.Start();
            Console.WriteLine("Server is Created.");

            while (true)
            {

                TcpClient tcpClient = tcpListener.AcceptTcpClient();
                dataClient.addClients(tcpClient);

                Thread startListen = new Thread(() => dataClient.GetMessage(tcpClient));
                startListen.Start();
            }
        }
    }
}