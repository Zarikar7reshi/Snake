using System;
using static System.Console;
using static Snake.Finestra;
namespace Snake
{
    class Mela                                                                           //start Mela
    {
        static Random rnd = new Random();
        public int x;
        public int y;

        public void VisualizzaMela(ref int count)
        {
            if (count > 0)
            {
                SetCursorPosition(x, y);
                Write("  ");
                count--;
            }
        }

        public void Muovi()
        {
            x = rnd.Next(offsx, offdx);
            if (x % 2 == 1)
            {
                x--;
            }
            y = rnd.Next(offup, offdown);
        }
        public void CancellaMela()
        {
            SetCursorPosition(x, y);
            Write("  ");
        }
    }                                                                                        //end Mela
}
