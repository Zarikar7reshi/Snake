using System;
using static System.Console;
using static Snake.Finestra;
using System.Threading;
namespace Snake
{
    class Gioco
    {
        static int count = 0;
        static double baseCount;
        static int punteggio = 0;

        static Mela mela = new Mela();
        static Snake snake = new Snake(30, 20);
        static Menu menu = new Menu(0, 0);
        static void Main(string[] args)
        {
            WindowWidth = 100;                                      //> di 50
            WindowHeight = 40;                                      //> di 20
            baseCount = 0.5 * WindowWidth;
            SetWindowSize(dx, down);
            //SetBufferSize(WindowWidth, WindowHeight);
            Clear();
            CursorVisible = false;
            Title = "Snake";
            
            Lettera.VisualizzaScritta();
            menu.Messaggio();
            ReadKey(false);
            Clear();

            menu.Cornice();
            SetCursorPosition(50, 1);
            Write("Punteggio: 0");
            while (true)
            {
                Thread.Sleep(80);                               //stoppa

                Cancella();

                GestisciInput();

                Aggiorna();

                Visualizza();
            }
        }

        static void Cancella()
        {
            BackgroundColor = ConsoleColor.Black;
            mela.CancellaMela();                        //cancella
            snake.Cancella();
            SetCursorPosition(61, 1);
            Write("       ");
        }

        static void GestisciInput()
        {
            snake.GetDirezione();                                              //gestisce input
        }

        static void Aggiorna()
        {
            if (snake.IsOver(mela))        //aggiorna
            {
                mela.Muovi();
                count = (int)Math.Round(baseCount);
                snake.Allunga();
                punteggio++;
            }
            snake.Allunga();
            if (count == 0)
            {
                mela.Muovi();
                count = (int)Math.Round(baseCount * 2);
            }

            snake.Muovi();
            snake.IsOutOfBounds();

            if (snake.IsCannibale())
            {
                Reset();
            }
        }

        static void Visualizza()
        {
            BackgroundColor = ConsoleColor.DarkRed;
            mela.VisualizzaMela(ref count);    //visualizza
            BackgroundColor = ConsoleColor.Green;
            snake.Visualizza();
            BackgroundColor = ConsoleColor.Black;
            VisualizzaPunteggio();
        }

        private static void VisualizzaPunteggio()
        {
            SetCursorPosition(61, 1);
            Write(punteggio);
        }

        static void Reset()
        {
            Thread.Sleep(500);
            snake = new Snake(30, 20);
            Clear();
            menu.Cornice();
            SetCursorPosition(50, 1);
            Write("Punteggio: 0");
            punteggio = 0;
        }
    }
}
