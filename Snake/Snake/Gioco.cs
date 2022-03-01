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

        static void Main(string[] args)
        {
            BackgroundColor = ConsoleColor.DarkBlue;
            Clear();
            CursorVisible = false;
            SetWindowSize(100, 40);
            Title = "Snake";
            while (true)
            {
                Thread.Sleep(80);                               //stoppa

                Mela.CancellaMela(mela);                        //cancella
                Snake.Cancella(snake);

                Snake.GetDirezione(snake);                                              //gestisce input

                if (Mela.IsMelaMangiataBy(snake, mela))         //aggiorna
                {
                    Mela.Muovi(mela);
                    count = 30;
                    Snake.Allunga(snake);
                }
                if (count == 0)
                {
                    Mela.Muovi(mela);
                }
                Snake.Muovi(snake);
                Snake.IsOutOfBounds(snake);
                if (Snake.IsCannibale(snake))
                {
                    Thread.Sleep(500);
                    snake = new Snake(30, 20);
                    Clear();
                }

                Mela.VisualizzaMela(snake, mela, ref count);    //visualizza
                Snake.Visualizza(snake);
            }
        }

    }
}
