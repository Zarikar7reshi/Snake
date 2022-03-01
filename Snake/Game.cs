using System;
using static System.Console;
using static Snake.Window;
using System.Threading;

namespace Snake
{
    class Game
    {
        static int count = 0;
        static double baseCount;
        public static int punteggio = 0;

        static Apple mela = new Apple();
        static Snake snake = new Snake(30, 20);
        static Menu menu = new Menu();
        static void Main(string[] args)
        {
            Save.CreaFile();
            WindowWidth = 100;                                      //> di 50
            WindowHeight = 40;                                      //> di 20
            baseCount = 0.5 * WindowWidth;
            SetWindowSize(dx, down);
            Clear();
            CursorVisible = false;
            Title = "Snake";

            Letter.VisualizzaScritta();
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

        private static void Reset()
        {
            if (Save.IsNuovoRecord())
            {
                SetCursorPosition(20, 1);
                Write("*NUOVO RECORD*");
            }
            Save.Salva();
            VisualizzaPunteggio();
            Thread.Sleep(1000);

            snake = new Snake(30, 20);
            punteggio = 0;

            Clear();
            menu.Cornice();
            SetCursorPosition(50, 1);
            Write("Punteggio: 0");
        }
    }
}
