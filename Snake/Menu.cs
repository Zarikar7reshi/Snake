using System;
using System.Threading;
using static System.Console;
using static Snake.Window;
namespace Snake
{
    class Menu : Snake
    {
        public void Messaggio()
        {
            string mess = "Premi un tasto per iniziare";
            int xMess = (int)Math.Round((double)(dx - 1 - mess.Length) / 2);
            while (!KeyAvailable)
            {
                SetCursorPosition(xMess, 30);
                ForegroundColor = ConsoleColor.Red;
                Write(mess);
                Thread.Sleep(500);
                SetCursorPosition(xMess, 30);
                ForegroundColor = ConsoleColor.White;
                Write(mess);
                Thread.Sleep(500);
            }
        }
        public void Cornice()
        {
            BackgroundColor = ConsoleColor.DarkMagenta;
            Riga(offup - 1);
            Colonne();
            Riga(offdown);
            BackgroundColor = ConsoleColor.Black;
        }

        public void Colonne()
        {
            for (int colonna = offup - 1; colonna <= offdown; colonna++)
            {
                SetCursorPosition(offsx - 2, colonna);
                Write("  ");
                SetCursorPosition(offdx + 1, colonna);
                Write("  ");
            }
        }

        private void Riga(int riga)
        {
            SetCursorPosition(offsx, riga);
            for (int i = 0; i <= offdx - offsx; i++)
            {
                Write(" ");
            }
        }
    }
}
