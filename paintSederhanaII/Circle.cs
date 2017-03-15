using System;
using System.Drawing;

namespace paintSederhanaII
{
    class Circle
    {
        public Point start, end;
        public int r = 0;
        public float x = 0, y = 0;
        public float xTemp = 0, yTemp = 0;
        public float p = 0;

        public void initRadius()
        {
            r = (int)Math.Sqrt(Math.Pow(end.X - start.X, 2) + Math.Pow(end.Y - start.Y, 2));
        }

        public void perhitungan(Graphics g)
        {
            y = r;
            x = 0;
            p = (float)((5 / 4) - r);
            xTemp = x;
            yTemp = y;

            while (x < y)
            {
                x = x + 1;
                if (p < 0)
                {
                    p = p + (2 * x + 1);
                }
                else
                {
                    y = y - 1;
                    p = p + (2 * (x - y) + 1);
                }
            }
            g.DrawRectangle(new Pen(Color.Black), 100, 100, 100, 200);
        }
    }
}