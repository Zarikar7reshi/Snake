using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Threading;
namespace Snake
{
    class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            BackgroundColor = ConsoleColor.DarkBlue;
            Clear();
            CursorVisible = false;
            WindowWidth = 100;
            WindowHeight = 40;
            Mela mela = new Mela();
            Snake snake = new Snake();
            while (true)
            {
                Thread.Sleep(1000);
                Mela.CancellaMela(mela);
                Snake.Cancella(snake);
                Snake.GetDirezione(snake);
                Mela.Muovi(mela);
                Snake.Muovi(snake);
                Mela.VisualizzaMela(mela);
                Snake.Visualizza(snake);
            }
        }
    }


    public class Mela
    {
        static Random rnd = new Random();
        public int x;
        public int y;
        public int xPrima;
        public int yPrima;
        public bool visible;

        public Mela()
        {
            visible = false;
        }

        public static void VisualizzaMela(Mela mela)
        {
            if (mela.visible)
            {
                SetCursorPosition(mela.x, mela.y);
                BackgroundColor = ConsoleColor.Red;
                Write("  ");
            }
            else
            {
                mela.visible = true;
            }
        }
        public static void Muovi(Mela mela)
        {
            mela.xPrima = mela.x;
            mela.yPrima = mela.y;
            mela.x = rnd.Next(0, WindowWidth - 1);
            mela.y = rnd.Next(0, WindowHeight - 1);
        }
        public static void CancellaMela(Mela mela)
        {
            SetCursorPosition(mela.xPrima, mela.yPrima);
            BackgroundColor = ConsoleColor.DarkBlue;
            Write("  ");
        }

        public bool IsMelaMangiata(Mela mela, Snake snake)
        {
            if (snake.xSnake[0] == mela.x && snake.ySnake[0] == mela.y)
            {
                return true;
            }
            return false;
        }
    }


    public class Snake
    {
        public List<int> xSnake = new List<int>();
        public List<int> ySnake = new List<int>();
        private Direzione direzione;

        public Snake()
        {
            ySnake.Add(20);
            xSnake.Add(20);
        }
        public static void GetDirezione(Snake snake)
        {
            snake.direzione = InputGiocatore(snake);
        }
        private static Direzione InputGiocatore(Snake snake)
        {
            if (KeyAvailable)
            {
                ConsoleKeyInfo tasto = ReadKey();
                switch (tasto.Key)
                {
                    case ConsoleKey.UpArrow:
                        return Direzione.UP;
                    case ConsoleKey.DownArrow:
                        return Direzione.DOWN;
                    case ConsoleKey.LeftArrow:
                        return Direzione.LEFT;
                    case ConsoleKey.RightArrow:
                        return Direzione.RIGHT;
                }
            }
            return snake.direzione;
        }

        public static void Cancella(Snake snake)
        {
            int dim = snake.ySnake.Count;
            SetCursorPosition(snake.xSnake[dim - 1], snake.ySnake[dim - 1]);
            BackgroundColor = ConsoleColor.DarkBlue;
            Write("  ");
        }

        public static void Muovi(Snake snake)
        {
            for (int i = snake.xSnake.Count - 1; i > 0; i--)
            {
                snake.xSnake[i] = snake.xSnake[i - 1];
                snake.ySnake[i] = snake.ySnake[i - 1];
            }
            switch (snake.direzione)
            {
                case Direzione.UP:
                    snake.ySnake[0]--;
                    break;
                case Direzione.DOWN:
                    snake.ySnake[0]++;
                    break;
                case Direzione.RIGHT:
                    snake.xSnake[0] += 2;
                    break;
                case Direzione.LEFT:
                    snake.xSnake[0] -= 2;
                    break;
            }

        }
        
        public static void Visualizza(Snake snake)
        {
            BackgroundColor = ConsoleColor.Green;
            for (int i = 0; i < snake.xSnake.Count; i++)
            {
                SetCursorPosition(snake.xSnake[i], snake.ySnake[i]);
                Write("  ");
            }
            BackgroundColor = ConsoleColor.DarkBlue;
        }
    }


    public enum Direzione
    {
        UP,
        DOWN,
        RIGHT,
        LEFT
    }
}
