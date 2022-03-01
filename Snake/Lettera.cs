using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using static System.Console;
using static System.Math;

namespace Snake
{
    class Lettera
    {
        int origineX;
        int origineY;
        static Lettera lettera = new Lettera();

        public static void VisualizzaScritta()
        {
            lettera.VisualizzaS();
            lettera.VisualizzaN();
            lettera.VisualizzaA();
            lettera.VisualizzaK();
            lettera.VisualizzaE();
        }

        private void VisualizzaS()
        {
            origineX = 25;
            origineY = 5;
            TrattoOrizzontale(origineY, origineX + 6, origineX);
            TrattoVerticale(origineX, origineY, origineY += 2);
            TrattoOrizzontale(origineY, origineX, origineX + 6);
            TrattoVerticale(origineX + 6, origineY, origineY += 2);
            TrattoOrizzontale(origineY, origineX + 6, origineX - 1);
            origineX += 10;
        }
        private void VisualizzaN()
        {
            origineY = 5;
            TrattoVerticale(origineX, origineY + 4, origineY - 1);
            TrattoDiagonale(origineX, origineY, origineX + 5, origineY + 5);
            TrattoVerticale(origineX + 6, origineY + 4, origineY - 1);
            origineX += 5;
        }
        private void VisualizzaA()
        {
            origineY = 5;
            TrattoDiagonale(origineX + 10, origineY, origineX + 15, origineY + 5);
            TrattoDiagonale(origineX + 5, origineY + 4, origineX + 10, origineY - 1);
            TrattoOrizzontale(origineY + 2, origineX + 7, origineX + 12);
            origineX += 20;
        }
        private void VisualizzaK()
        {
            origineY = 5;
            TrattoVerticale(origineX, origineY, origineY + 5);
            TrattoDiagonale(origineX, origineY + 2, origineX + 5, origineY - 1);
            TrattoDiagonale(origineX, origineY + 2, origineX + 5, origineY + 5);
            origineX += 7;
        }
        private void VisualizzaE()
        {
            origineY = 5;
            TrattoOrizzontale(origineY, origineX + 5, origineX);
            TrattoVerticale(origineX, origineY, origineY + 5);
            TrattoOrizzontale(origineY + 2, origineX, origineX + 6);
            TrattoOrizzontale(origineY + 4, origineX, origineX + 6);
        }

        private void TrattoVerticale(int x, int startY, int endY)
        {
            BackgroundColor = ConsoleColor.Green;
            if (endY > startY)
            {
                for (int i = startY; i < endY; i++)
                {
                    SetCursorPosition(x, i);
                    Write(" ");
                    Thread.Sleep(10);
                }
            }
            else
            {
                for (int i = startY; i > endY; i--)
                {
                    SetCursorPosition(x, i);
                    Write(" ");
                    Thread.Sleep(10);
                }
            }
            BackgroundColor = ConsoleColor.Black;
        }
        private void TrattoOrizzontale(int y, int startX, int endX)
        {
            BackgroundColor = ConsoleColor.Green;
            if (endX > startX)
            {
                for (int i = startX; i < endX; i++)
                {
                    SetCursorPosition(i, y);
                    Write(" ");
                    Thread.Sleep(10);
                }
            }
            else
            {
                for (int i = startX; i > endX; i--)
                {
                    SetCursorPosition(i, y);
                    Write(" ");
                    Thread.Sleep(10);
                }
            }
            BackgroundColor = ConsoleColor.Black;
        }
        private void TrattoDiagonale(int startX, int startY, int endX, int endY)
        {
            int distanzaX = Abs(endX - startX);
            int distanzaY = Abs(endY - startY);
            double rapporto;
            BackgroundColor = ConsoleColor.Green;
            if (startX < endX && startY < endY)
            {
                if (distanzaX < distanzaY)
                {
                    rapporto = distanzaY / distanzaX;
                    for (double x = startX, y = startY; x < endX && y < endY; y++, x += rapporto)
                    {
                        SetCursorPosition((int)Round(x), (int)Round(y));
                        Write("  ");
                        Thread.Sleep(10);
                    }
                }
                else
                {
                    rapporto = distanzaX / distanzaY;
                    for (double x = startX, y = startY; x < endX && y < endY; x++, y += rapporto)
                    {
                        SetCursorPosition((int)Round(x), (int)Round(y));
                        Write("  ");
                        Thread.Sleep(10);
                    }
                }
            }
            else if (startX > endX && startY < endY)
            {
                if (distanzaX < distanzaY)
                {
                    rapporto = distanzaY / distanzaX;
                    for (double x = startX, y = startY; x > endX && y < endY; y++, x -= rapporto)
                    {
                        SetCursorPosition((int)Round(x), (int)Round(y));
                        Write("  ");
                        Thread.Sleep(10);
                    }
                }
                else
                {
                    rapporto = distanzaX / distanzaY;
                    for (double x = startX, y = startY; x > endX && y < endY; x--, y += rapporto)
                    {
                        SetCursorPosition((int)Round(x), (int)Round(y));
                        Write("  ");
                        Thread.Sleep(10);
                    }
                }
            }
            else if (startX < endX && startY > endY)
            {
                if (distanzaX < distanzaY)
                {
                    rapporto = distanzaY / distanzaX;
                    for (double x = startX, y = startY; x < endX && y > endY; y--, x += rapporto)
                    {
                        SetCursorPosition((int)Round(x), (int)Round(y));
                        Write("  ");
                        Thread.Sleep(10);
                    }
                }
                else
                {
                    rapporto = distanzaX / distanzaY;
                    for (double x = startX, y = startY; x < endX && y > endY; x++, y -= rapporto)
                    {
                        SetCursorPosition((int)Round(x), (int)Round(y));
                        Write("  ");
                        Thread.Sleep(10);
                    }
                }
            }
            else if (startX > endX && startY > endY)
            {
                if (distanzaX < distanzaY)
                {
                    rapporto = distanzaY / distanzaX;
                    for (double x = startX, y = startY; x > endX && y > endY; y--, x -= rapporto)
                    {
                        SetCursorPosition((int)Round(x), (int)Round(y));
                        Write("  ");
                        Thread.Sleep(10);
                    }
                }
                else
                {
                    rapporto = distanzaX / distanzaY;
                    for (double x = startX, y = startY; x > endX && y > endY; x--, y -= rapporto)
                    {
                        SetCursorPosition((int)Round(x), (int)Round(y));
                        Write("  ");
                        Thread.Sleep(10);
                    }
                }
            }
            BackgroundColor = ConsoleColor.Black;
        }
    }
}
