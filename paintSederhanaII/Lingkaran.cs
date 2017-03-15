using System;
using System.Drawing;


namespace paintSederhanaII
{
    class Lingkaran
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
            initRadius();
            y = r;
            x = 0;
            p = (float)((5 / 4) - r);
            xTemp = x;
            yTemp = y;

            while (x <= y)
            {
                x++;
                g.DrawLine(new Pen(Color.Black), start.X + xTemp, start.Y + yTemp, start.X + x, start.Y + y);
                g.DrawLine(new Pen(Color.Black), start.X + (-1) * xTemp, start.Y + yTemp, start.X + (-1) * x, start.Y + y);
                g.DrawLine(new Pen(Color.Black), start.X + xTemp, start.Y + (-1) * yTemp, start.X + x, start.Y + (-1) * y);
                g.DrawLine(new Pen(Color.Black), start.X + (-1) * xTemp, start.Y + (-1) * yTemp, start.X + (-1) * x, start.Y + (-1) * y);

                g.DrawLine(new Pen(Color.Black), start.X + yTemp, start.Y + xTemp, start.X + y, start.Y + x);
                g.DrawLine(new Pen(Color.Black), start.X + (-1) * yTemp, start.Y + xTemp, start.X + (-1) * y, start.Y + x);
                g.DrawLine(new Pen(Color.Black), start.X + yTemp, start.Y + (-1) * xTemp, start.X + y, start.Y + (-1) * x);
                g.DrawLine(new Pen(Color.Black), start.X + (-1) * yTemp, start.Y + (-1) * xTemp, start.X + (-1) * y, start.Y + (-1) * x);
                xTemp = x;
                yTemp = y;

                if (p < 0)
                {
                    p += 2 * xTemp + 2 + 1;
                }
                else
                {
                    y--;
                    p += 2 * xTemp + 2 + 1 - 2 * y - 2;
                }
            }
        }
    }
}
