using System;

namespace OOPTask2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int posotionX = 10;
            int posotionY = 10;
            Player player = new Player('@');
            Renderer renderer = new Renderer();

            renderer.DrawPlayer(player, posotionX, posotionY);
        }
    }

    class Player
    {
        public char PlayerSymbol { get; private set; }
        public int PlayerPositionX { get; private set; }
        public int PlayerPositionY { get; private set; }

        public Player(char playerSymbol)
        {
            PlayerSymbol = playerSymbol;
            PlayerPositionX = 0;
            PlayerPositionY = 0;
        }

        public void SetPlayerPosition(int positionX, int positionY)
        {
            PlayerPositionX = positionX;
            PlayerPositionY = positionY;
        }
    }

    class Renderer
    {
        public Renderer() { }

        public void DrawPlayer(Player player, int positionX, int positionY)
        {
            if (PositionIsCorrect(positionX, positionY) == false)
            {
                return;
            }

            var currentConsolePositinon = Console.GetCursorPosition();

            player.SetPlayerPosition(positionX, positionY);
            Console.SetCursorPosition(player.PlayerPositionX, player.PlayerPositionY);
            Console.WriteLine(player.PlayerSymbol);
            Console.SetCursorPosition(currentConsolePositinon.Left, currentConsolePositinon.Top);
        }

        private bool PositionIsCorrect(int positionX, int positionY)
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
