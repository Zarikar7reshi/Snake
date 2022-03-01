using static System.Console;
namespace Snake
{
    class Finestra
    {
        internal static readonly int sx;
        internal static readonly int up;
        internal static readonly int dx;
        internal static readonly int down;

        internal static readonly int offsetX = WindowWidth/10;
        internal static readonly int offsetY = offsetX/2;

        internal static readonly int offsx;
        internal static readonly int offdx;
        internal static readonly int offup;
        internal static readonly int offdown;
        static Finestra()
        {
            sx = 0;
            up = 0;
            dx = WindowWidth - 1;
            down = WindowHeight - 1;
            offsx = sx + offsetX;
            offdx = dx - offsetX;
            offup = up + offsetY;
            offdown = down - offsetY;
        }
    }
}
