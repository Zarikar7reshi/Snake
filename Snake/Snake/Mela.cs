using System;
using static System.Console;
namespace Snake
{
    public class Mela                                                                           //start Mela
    {
        static Random rnd = new Random();
        public int x;
        public int y;
        public bool visible;

        public Mela()
        {
            visible = false;
        }

        public static void VisualizzaMela(Snake snake, Mela mela, ref int count)
        {
            if (mela.visible && count > 0)
            {
                BackgroundColor = ConsoleColor.Red;
                count--;
                SetCursorPosition(mela.x, mela.y);
                Write("  ");
            }
            else if (!Snake.IsSnakeOver(snake, mela))
            {
                mela.visible = true;
            }
            else
            {
                count = 30;
            }
        }

        public static void Muovi(Mela mela)
        {
            mela.x = rnd.Next(0, WindowWidth - 1);
            mela.y = rnd.Next(0, WindowHeight - 1);
        }
        public static void CancellaMela(Mela mela)
        {
            BackgroundColor = ConsoleColor.DarkBlue;
            SetCursorPosition(mela.x, mela.y);
            Write("  ");
        }

        public static bool IsMelaMangiataBy(Snake snake, Mela mela)
        {
            if (snake.xSnake[0] == mela.x && snake.ySnake[0] == mela.y)
            {
                return true;
            }
            return false;
        }
    }                                                                                        //end Mela
}
