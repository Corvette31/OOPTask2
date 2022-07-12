using System;

namespace OOPTask2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int posotionX = 10;
            int posotionY = 10;
            Player player = new Player('@', posotionX, posotionY);
            Renderer renderer = new Renderer();

            renderer.DrawPlayer(player);
        }
    }

    class Player
    {
        public char Symbol { get; private set; }
        public int PositionX { get; private set; }
        public int PositionY { get; private set; }

        public Player(char symbol, int positionX, int positionY)
        {
            Symbol = symbol;
            PositionX = positionX;
            PositionY = positionY;
        }

    }

    class Renderer
    {
        public void DrawPlayer(Player player)
        {
            if (CheckPosition(player.PositionX, player.PositionY) == false)
            {
                return;
            }

            var currentConsolePositinon = Console.GetCursorPosition();

            Console.SetCursorPosition(player.PositionX, player.PositionY);
            Console.WriteLine(player.Symbol);
            Console.SetCursorPosition(currentConsolePositinon.Left, currentConsolePositinon.Top);
        }

        private bool CheckPosition(int positionX, int positionY)
        {
            int maxPositionX = Console.BufferWidth;
            int maxPositionY = Console.BufferHeight;

            if ((positionX >= 0 && positionX <= maxPositionX) && (positionY >= 0 && positionY <= maxPositionY))
            {
                return true;
            }

            Console.WriteLine("Не возможно задать игроку такие координаты");
            return false;
        }
    }

}
