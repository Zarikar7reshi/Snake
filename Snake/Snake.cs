using System;
using System.Collections.Generic;
using static Snake.Window;
using static System.Console;
namespace Snake
{
    internal class Snake                                                                              //start Snake
    {
        public List<int> xSnake = new List<int>();
        public List<int> ySnake = new List<int>();
        private Direction direzione;
        public int lunghezzaIniziale = 3;

        public Snake() { }
        public Snake(int x, int y)                                                      //costruttore
        {
            y--;
            for (int i = 0; i < lunghezzaIniziale; i++)
            {
                ySnake.Add(++y);
                xSnake.Add(x);
            }
        }

        internal void GetDirezione()                                                //metodi input
        {
            direzione = InputGiocatore();
        }

        internal void IsOutOfBounds()                                          //fa riapparire dall'altra parte
        {
            if (xSnake[0] > offdx)
            {
                xSnake[0] = offsx;
            }
            if (xSnake[0] < offsx)
            {
                xSnake[0] = offdx - 1;
            }
            if (ySnake[0] > offdown - 1)
            {
                ySnake[0] = offup;
            }
            if (ySnake[0] < offup)
            {
                ySnake[0] = offdown - 1;
            }
        }


        internal void Allunga()                                                   //quando mangia la mela si allunga di 1
        {
            int xCoda = xSnake[xSnake.Count - 1];
            int yCoda = xSnake[ySnake.Count - 1];
            xSnake.Add(xCoda);
            ySnake.Add(yCoda);
        }

        internal bool IsOver(Apple mela)                                            //se è sulla mela
        {
            for (int i = 0; i < xSnake.Count; i++)
            {
                if ((mela.x == xSnake[i] ||
                    mela.x + 1 == xSnake[i]) &&
                    mela.y == ySnake[i])
                {
                    return true;
                }
            }
            return false;
        }
        internal bool IsCannibale()                                                   //respawn se si mangia da solo
        {
            for (int i = 0; i < xSnake.Count; i++)
            {
                for (int j = 0; j < ySnake.Count; j++)
                {
                    if (xSnake[i] == xSnake[j] &&
                        ySnake[i] == ySnake[j] &&
                        i != j)
                    {
                        return true;
                    }
                }
            }
            return false;
        }


        public virtual void Visualizza()                                              //visualizza
        {
            for (int i = 0; i < xSnake.Count; i++)
            {
                SetCursorPosition(xSnake[i], ySnake[i]);
                Write("  ");
            }

        }

        public virtual void Cancella()                                                   //cancella
        {
            int dim = ySnake.Count;
            SetCursorPosition(xSnake[dim - 1], ySnake[dim - 1]);
            Write("  ");
        }

        public virtual void Muovi()                                                       //muovi
        {
            for (int i = xSnake.Count - 1; i > 0; i--)
            {
                xSnake[i] = xSnake[i - 1];
                ySnake[i] = ySnake[i - 1];
            }
            switch (direzione)
            {
                case Direction.UP:
                    if (xSnake[0] % 2 == 1)
                    {
                        xSnake[0]--;
                    }
                    ySnake[0]--;
                    break;
                case Direction.DOWN:
                    if (xSnake[0] % 2 == 1)
                    {
                        xSnake[0]--;
                    }
                    ySnake[0]++;
                    break;
                case Direction.RIGHT:
                    xSnake[0] += 2;
                    break;
                case Direction.LEFT:
                    xSnake[0] -= 2;
                    break;
            }
        }

        private Direction InputGiocatore()
        {
            if (KeyAvailable)
            {
                ConsoleKeyInfo tasto = ReadKey(true);
                switch (tasto.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (direzione != Direction.DOWN)
                        {
                            return Direction.UP;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (direzione != Direction.UP)
                        {
                            return Direction.DOWN;
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (direzione != Direction.RIGHT)
                        {
                            return Direction.LEFT;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (direzione != Direction.LEFT)
                        {
                            return Direction.RIGHT;
                        }
                        break;
                    case ConsoleKey.W:
                        if (direzione != Direction.DOWN)
                        {
                            return Direction.UP;
                        }
                        break;
                    case ConsoleKey.S:
                        if (direzione != Direction.UP)
                        {
                            return Direction.DOWN;
                        }
                        break;
                    case ConsoleKey.A:
                        if (direzione != Direction.RIGHT)
                        {
                            return Direction.LEFT;
                        }
                        break;
                    case ConsoleKey.D:
                        if (direzione != Direction.LEFT)
                        {
                            return Direction.RIGHT;
                        }
                        break;
                }
            }
            return direzione;
        }
    }                                                                                           //end Snake
}
