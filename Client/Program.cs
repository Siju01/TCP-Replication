using System;
using System.Net.Sockets;
using System.IO;
using System.Threading;


namespace Client
{
    class Program
    {
        //Check incoming message
        public class CheckM
        {

            public void Check(TcpClient tcpClient)
            {
                StreamReader streamReader = new StreamReader(tcpClient.GetStream());

                while (true)
                {
                    try
                    {
                        string message = streamReader.ReadLine();
                        Console.WriteLine(message);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        break;
                    }
                }
            }
        }

        //Record incoming message
        static void Main(string[] args)
        {
            CheckM read = new CheckM();
            string ip = "127.0.0.1";
            int port = 6000;
            string inputClient;

            try
            {
                TcpClient tcpClient = new TcpClient(ip, port);
                Console.WriteLine("Connect to The Server.");
                Console.WriteLine("1.Login\n2.Play\n");
                
                Console.Write("Choose Number : ");
                inputClient = Console.ReadLine();

                Thread thread = new Thread(() => read.Check(tcpClient));
                thread.Start();

                StreamWriter streamWriter = new StreamWriter(tcpClient.GetStream());
                string word = Console.ReadLine();

                string username = Console.ReadLine();
                string pass = Console.ReadLine();
                string room = Console.ReadLine();
                string input = Console.ReadLine();

                switch (inputClient)
                {
                    
                    case "1":
                        Console.Write("Name     : ");
                        streamWriter.WriteLine(username + " : " + input);
                        streamWriter.Flush();

                        Console.Write("Password : ");
                        streamWriter.WriteLine(pass + " : " + input);
                        streamWriter.Flush();

                        break;

                    case "2":
                        Console.Write("Input Room Name : ");
                        streamWriter.WriteLine(room + " : " + input);
                        streamWriter.Flush();

                        break;
             
                    default:
                        Console.WriteLine("Number Not Detected");
                        break;


                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();

        }
    }
}