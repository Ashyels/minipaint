using System;
using System.Drawing;

namespace paintSederhanaII
{
    class Bresenham
    {
        public Point start, end;
        public float xTemp = 0, yTemp = 0;
        public float x = 0, y = 0;
        public float dx = 0, dy = 0;
        public float addX = 0, addY = 0;
        public float dx2 = 0, dy2 = 0;
        public float p = 0;
        public void initVariable()
        {
            dx = Math.Abs(end.X - start.X);
            dy = Math.Abs(end.Y - start.Y);

            if(end.X - start.X != 0)
            {
                addX = (end.X-start.X) / dx;
            }
            if(end.Y - start.Y != 0)
            {
                addY = (end.Y-start.Y) / dy;
            }

            dx2 = 2 * dx;
            dy2 = 2 * dy;
        }

        public void perhitungan(Graphics g)
        {
            initVariable();
            x = start.X;
            y = start.Y;
            xTemp = x;
            yTemp = y;

            if (dx > dy)
            {
                p = dy2 - dx;
                for (int i = 0; i < dx; i++)
                {
                    x += addX;
                    g.DrawLine(new Pen(Color.Black), xTemp, yTemp, x, y);
                    xTemp = x;
                    if (p > 0)
                    {
                        y += addY;
                        p += dy2 - dx2;
                        yTemp = y;
                    }
                    else
                    {
                        p += dy2;
                    }
                }
            }
            else if (dx <= dy)
            {
                p = dx2 - dy;
                for (int i = 0; i < dy; i++)
                {
                    y += addY;
                    g.DrawLine(new Pen(Color.Black), xTemp, yTemp, x, y);
                    yTemp = y;
                    xTemp = x;
                    if (p > 0)
                    {
                        x += addX;
                        p += dx2 - dy2;
                    }
                    else
                    {
                        p += dx2;
                    }
                }
            }
        }
    }
}
