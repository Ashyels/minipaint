using System;
using System.Drawing;

namespace paintSederhanaII
{
    class Bintang
    {
        public Point start, end;
        public float xTemp = 0, yTemp = 0;
        public float dx =0, dy = 0;

        public void perhitungan(Graphics g, int n)
        {
            // Make room for the points.
            dx = Math.Abs(end.X - start.X);
            dy = Math.Abs(end.Y - start.Y);

        double theta = -Math.PI / 2;
        double dtheta = 4 * Math.PI / n;

        double rx = dx;
            double ry = dy;
            double cx = start.X;
            double cy = start.Y;
            xTemp = (float)(cx + rx * Math.Cos(theta));
            yTemp = (float)(cy + ry * Math.Sin(theta));

            for (int i = 0; i <= n; i++)
            {
                g.DrawLine(new Pen(Color.Black), xTemp, yTemp, (float)(cx + rx * Math.Cos(theta)), (float)(cy + ry * Math.Sin(theta)));
                xTemp = (float)(cx + rx * Math.Cos(theta));
                yTemp = (float)(cy + ry * Math.Sin(theta));
                theta += dtheta;
            }
        }
    }
}
