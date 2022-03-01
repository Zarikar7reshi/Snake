using System;
using System.Collections.Generic;
using static System.Console;
namespace Snake
{
    public class Snake                                                                              //start Snake
    {
        public List<int> xSnake = new List<int>();
        public List<int> ySnake = new List<int>();
        private Direzione direzione;
        private int lunghezzaIniziale = 5;

        public Snake(int x, int y)                                                      //costruttore
        {
            y--;
            for (int i = 0; i < lunghezzaIniziale; i++)
            {
                ySnake.Add(++y);
                xSnake.Add(x);
            }
        }

        public static void GestisciInput(Snake snake)
        {
            GetDirezione(snake);                                              //gestisce input
        }

        public static void GetDirezione(Snake snake)                                                //metodi input
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

        public static void Cancella(Snake snake)                                                   //cancella
        {
            BackgroundColor = ConsoleColor.DarkBlue;
            int dim = snake.ySnake.Count;
            SetCursorPosition(snake.xSnake[dim - 1], snake.ySnake[dim - 1]);
            Write("  ");
        }

        public static void Muovi(Snake snake)                                                       //muovi
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
        public static void IsOutOfBounds(Snake snake)                                          //fa riapparire dall'altra parte
        {
            if (snake.xSnake[0] > WindowWidth)
            {
                snake.xSnake[0] = 0;
            }
            if (snake.xSnake[0] < 0)
            {
                snake.xSnake[0] = WindowWidth;
            }
            if (snake.ySnake[0] > WindowHeight)
            {
                snake.ySnake[0] = 0;
            }
            if (snake.ySnake[0] < 0)
            {
                snake.ySnake[0] = WindowHeight;
            }
        }

        

        internal static void Allunga(Snake snake)                                                   //quando mangia la mela si allunga di 1
        {
            int xCoda = snake.xSnake[snake.xSnake.Count - 1];
            int yCoda = snake.xSnake[snake.ySnake.Count - 1];
            snake.xSnake.Add(xCoda);
            snake.ySnake.Add(yCoda);
        }

        internal static bool IsSnakeOver(Snake snake, Mela mela)                                            //se è sulla mela
        {
            for (int i = 0; i < snake.xSnake.Count; i++)
            {
                if (mela.x == snake.xSnake[i] && mela.y == snake.ySnake[i])
                {
                    return true;
                }
            }
            return false;
        }
        internal static bool IsCannibale(Snake snake)                                                   //respawn se si mangia da solo
        {
            for (int i = 0; i < snake.xSnake.Count; i++)
            {
                for (int j = 0; j < snake.xSnake.Count; j++)
                {
                    if (snake.xSnake[i] == snake.xSnake[j] &&
                        snake.ySnake[i] == snake.ySnake[j] &&
                        i != j)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static void Visualizza(Snake snake)                                                  //visualizza
        {
            BackgroundColor = ConsoleColor.Green;
            for (int i = 0; i < snake.xSnake.Count; i++)
            {
                SetCursorPosition(snake.xSnake[i], snake.ySnake[i]);
                Write("  ");
            }
            BackgroundColor = ConsoleColor.DarkBlue;
        }
    }                                                                                           //end Snake
}
