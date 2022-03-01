using System;
using static System.Console;
using System.Threading;
namespace Snake
{
    class Gioco
    {
        static Mela mela = new Mela();
        static int count = 0;
        static Snake snake = new Snake(30, 20);
        static Menu menu = new Menu(0, 0);
        static void Main(string[] args)
        {
            WindowWidth = 100;
            WindowHeight = 40;
            Finestra window = new Finestra();
            //window.down = WindowHeight - 1;
            //window.dx = WindowWidth - 1;
            //window.sx = 0;
            //window.up = 0;

            SetWindowSize(window.dx, window.down);
            BackgroundColor = ConsoleColor.DarkBlue;
            Clear();
            CursorVisible = false;
            Title = "Snake";

            menu.Inizializza();

            ReadKey(true);

            Clear();
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
            mela.CancellaMela();                        //cancella
            snake.Cancella();
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
                count = 30;
                snake.Allunga();
            }
            else
            {
                mela.visible = true;
            }
            if (count == 0)
            {
                mela.Muovi();
                count = 60;
            }

            snake.Muovi();
            snake.IsOutOfBounds();

           

            if (snake.IsCannibale())
            {
                Thread.Sleep(500);
                snake = new Snake(30, 20);
                Clear();
            }
        }

        static void Visualizza()
        {
            BackgroundColor = ConsoleColor.Red;
            mela.VisualizzaMela(ref count);    //visualizza
            BackgroundColor = ConsoleColor.Green;
            snake.Visualizza();
            BackgroundColor = ConsoleColor.DarkBlue;
        }
    }
}
