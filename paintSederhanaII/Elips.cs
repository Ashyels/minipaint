using System;
using System.Drawing;

namespace paintSederhanaII
{
    class Elips
    {
        public Point start, end;
        public double p1 = 0, p2 = 0;
        public double rx = 0; // Jari-jari mayor
        public double ry = 0; // Jari-jari minor
        public double x = 0, y = 0;
        public double k = 0;
        public double xTemp = 0, yTemp = 0;

        public void perhitungan(Graphics g)
        {
            rx = Math.Abs(end.X -start.X);
            ry = Math.Abs(end.Y - start.Y);

            x = 0;
            y = ry;

            xTemp = x;
            yTemp = y;

            p1 = Math.Pow(ry, 2) - Math.Pow(rx, 2) * ry + (1 / 4) * Math.Pow(rx, 2);
            while (2*Math.Pow(ry,2)*x < 2*Math.Pow(rx, 2)*y)
            {
                if (p1 < 0)
                {
                    x++;
                    p1 += 2 * Math.Pow(ry, 2) * x + Math.Pow(ry, 2);
                }
                else
                {
                    p1 += 2 * (Math.Pow(ry, 2) * x + Math.Pow(ry, 2)) - 2 * (Math.Pow(rx, 2) * y - Math.Pow(rx, 2)) + Math.Pow(ry, 2);
                    x++;
                    y--;
                }
                g.DrawLine(new Pen(Color.Black), (float)(start.X + xTemp), (float)(start.Y + yTemp), (float)(start.X + x), (float)(start.Y + y));
                g.DrawLine(new Pen(Color.Black), (float)(start.X + (-1) * xTemp), (float)(start.Y + yTemp), (float)(start.X + (-1) * x), (float)(start.Y + y));
                g.DrawLine(new Pen(Color.Black), (float)(start.X + xTemp), (float)(start.Y + (-1) * yTemp), (float)(start.X + x), (float)(start.Y + (-1) * y));
                g.DrawLine(new Pen(Color.Black), (float)(start.X + (-1) * xTemp), (float)(start.Y + (-1) * yTemp), (float)(start.X + (-1) * x), (float)(start.Y + (-1) * y));

/*
                g.DrawLine(new Pen(Color.Black), (float)(start.X + yTemp), (float)(start.Y + xTemp), (float)(start.X + y), (float)(start.Y + x));
                g.DrawLine(new Pen(Color.Black), (float)(start.X + (-1) * yTemp), (float)(start.Y + xTemp), (float)(start.X + (-1) * y), (float)(start.Y + x));
                g.DrawLine(new Pen(Color.Black), (float)(start.X + yTemp), (float)(start.Y + (-1) * xTemp), (float)(start.X + y), (float)(start.Y + (-1) * x));
                g.DrawLine(new Pen(Color.Black), (float)(start.X + (-1) * yTemp), (float)(start.Y + (-1) * xTemp), (float)(start.X + (-1) * y), (float)(start.Y + (-1) * x));
*/                xTemp = x;
                yTemp = y;
            }
            p2 = Math.Pow(ry, 2) * Math.Pow(x + (1 / 2), 2) + Math.Pow(rx, 2) * Math.Pow(y - 1, 2) - Math.Pow(rx, 2) * Math.Pow(ry, 2);
            while(y> 0)
            {
                if(p2 > 0)
                {
                    y--;
                    p2 += (-1) * 2 * Math.Pow(rx, 2) * y + Math.Pow(rx, 2);
                }
                else
                {
                    x++;
                    y--;
                    p2 += 2 * Math.Pow(ry, 2) * x - 2 * Math.Pow(rx, 2) * y + Math.Pow(rx, 2);
                }
                g.DrawLine(new Pen(Color.Black), (float)(start.X + xTemp)       , (float)(start.Y + yTemp)          , (float)(start.X + x)          , (float)(start.Y + y));
                g.DrawLine(new Pen(Color.Black), (float)(start.X + (-1) * xTemp), (float)(start.Y + yTemp)          , (float)(start.X + (-1) * x)   , (float)(start.Y + y));
                g.DrawLine(new Pen(Color.Black), (float)(start.X + xTemp)       , (float)(start.Y + (-1) * yTemp)   , (float)(start.X + x)          , (float)(start.Y + (-1) * y));
                g.DrawLine(new Pen(Color.Black), (float)(start.X + (-1) * xTemp), (float)(start.Y + (-1) * yTemp)   , (float)(start.X + (-1) * x)   , (float)(start.Y + (-1) * y));
/*
                g.DrawLine(new Pen(Color.Black), (float)(start.X + yTemp)       , (float)(start.Y + xTemp)          , (float)(start.X + y)          , (float)(start.Y + x));
                g.DrawLine(new Pen(Color.Black), (float)(start.X + (-1) * yTemp), (float)(start.Y + xTemp)          , (float)(start.X + (-1) * y)   , (float)(start.Y + x));
                g.DrawLine(new Pen(Color.Black), (float)(start.X + yTemp)       , (float)(start.Y + (-1) * xTemp)   , (float)(start.X + y)          , (float)(start.Y + (-1) * x));
                g.DrawLine(new Pen(Color.Black), (float)(start.X + (-1) * yTemp), (float)(start.Y + (-1) * xTemp)   , (float)(start.X + (-1) * y)   , (float)(start.Y + (-1) * x));
*/                xTemp = x;
                yTemp = y;
            }
        }
    }
}