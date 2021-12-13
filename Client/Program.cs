using PlayerData;
using System;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "CLIENT";

            string ip = "127.0.0.1";
            int port = 26750;

            Client client = new Client(ip, port);
            client.SpawnPlayer();

            while (true)
            {
                Console.WriteLine($"1: To Move\n2: To Attack");
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        Console.Write("Enter move X-Coordinate: ");
                        int x = int.Parse(Console.ReadLine());
                        Console.Write("Enter move Y-Coordinate: ");
                        int y = int.Parse(Console.ReadLine());
                        client.PlayerMovement(x, y);
                        break;
                    case 2:
                        client.PlayerAttack();
                        break;
                    default:
                        break;
                }

            }

            Console.ReadKey();
        }
    }
}