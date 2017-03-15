using System;
using System.Drawing;

namespace paintSederhanaII
{
    class PersamaanGaris
    {
        public Point start, end;
        public float dx = 0;
        public float dy = 0;
        public float m = 0;
        public float xTemp = 0;
        public float yTemp = 0;
        public float x = 0;
        public float y = 0;
        public float b = 0;
        public float add = 0;

        public void initB()
        {
            dx = end.X - start.X;
            dy = end.Y - start.Y;
            if (Math.Abs(dy)/Math.Abs(dx) != 0)
                m = dy / dx;
            b = start.Y - m * start.X;
        }

        public void perhitungan(Graphics g)
        {
            initB();
            x = start.X;
            y = start.Y;
            xTemp = x;
            yTemp = y;
            if (Math.Abs(dx) > Math.Abs(dy))
            {
                add = dx / Math.Abs(dx);
                for (int i = 0; i< Math.Abs(dx); i++)
                {
                    x += add;
                    y = m * x + b;
                    g.DrawLine(new Pen(Color.Black), xTemp, yTemp, x, y);
                    xTemp = x;
                    yTemp = y;
                }
            }
            else if (Math.Abs(dy) <= Math.Abs(dy))
            {
                add = dy / Math.Abs(dy);
                for (int i = 0; i < Math.Abs(dy); i++)
                {
                    y += add;
                    if(dx != 0)
                        x = (y - b)/ m;
                    g.DrawLine(new Pen(Color.Black), xTemp, yTemp, x, y);
                    if (dx != 0)
                        xTemp = x;
                    yTemp = y;
                }
            }
        }
    }
}
