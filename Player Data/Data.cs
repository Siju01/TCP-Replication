using System;

namespace PlayerData
{
    public class Player
    {
        public int xPos;
        public int yPos;

        public Player() { }
        public Player(int _xPos, int _yPos)
        {
            xPos = _xPos;
            yPos = _yPos;

            Console.WriteLine($"Player Spawned on : {xPos} y: {yPos}");
        }

        public void Move(int _x, int _y)
        {
            xPos += _x;
            yPos += _y;

            Console.WriteLine($"Player Current Position: {xPos} and y: {yPos}");
        }

        public void Attack()
        {
            Console.WriteLine($"Player Is Attacking");
        }
    }
}