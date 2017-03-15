using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.InteropServices;

namespace paintSederhanaII
{
    class colorfill_class
    {
        Color bounColor = Color.Black;
        Brush aBrush = (Brush)Brushes.Black;

        [DllImport("user32.dll")]
        static extern IntPtr GetDC(IntPtr hwnd);

        [DllImport("user32.dll")]
        static extern Int32 ReleaseDC(IntPtr hwnd, IntPtr hdc);

        [DllImport("gdi32.dll")]
        static extern uint GetPixel(IntPtr hdc, int nXPos, int nYPos);

        static public System.Drawing.Color GetPixelColor(int x, int y)
        {
            IntPtr hdc = GetDC(IntPtr.Zero);
            uint pixel = GetPixel(hdc, x, y);
            ReleaseDC(IntPtr.Zero, hdc);
            Color color = Color.FromArgb((int)(pixel & 0x000000FF), (int)(pixel & 0x0000FF00) >> 8, (int)(pixel & 0x00FF0000) >> 16);
            return color;
        }

        public void Coloring(Graphics g, int x, int y, Color fillColor, Color oldColor)
        {
            if (x < 345 && x > 0 && y < 297 && y > 0)
            {
                if (fillColor == Color.Blue)
                    aBrush = (Brush)Brushes.Blue;
                else if (fillColor == Color.Black)
                    aBrush = (Brush)Brushes.Black;

                Color currcol = GetPixelColor(x, y);

                if (currcol.ToArgb().Equals(oldColor.ToArgb()) == true &&
                    currcol.ToArgb().Equals(bounColor.ToArgb()) == false &&
                    currcol.ToArgb().Equals(fillColor.ToArgb()) == false)
                {
                    /*
                                if (currcol == oldColor && 
                                    x < 345 && 
                                    y < 297 && 
                                    currcol != bounColor &&
                                    currcol != fillColor)
                                {
                    */
                    g.FillRectangle(aBrush, x, y, 1, 1);
                    Coloring(g, x + 1, y, fillColor, oldColor);
                    Coloring(g, x - 1, y, fillColor, oldColor);
                    Coloring(g, x, y + 1, fillColor, oldColor);
                    Coloring(g, x, y - 1, fillColor, oldColor);
                }
            }
        }

        public Color init(Graphics g, int x, int y, Color fillColor)
        {
            Color oldColor = GetPixelColor(x, y);
            Coloring(g, x, y, fillColor, oldColor);
            return oldColor;
        }
    }
}
