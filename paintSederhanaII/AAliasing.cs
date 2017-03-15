using System;
using System.Drawing;

namespace paintSederhanaII
{
    class AAliasing
    {
        public Point start, end;
        public float xTemp = 0, yTemp = 0;
        public float x = 0, y = 0;

        public void fungsi()
        {
            y = (float)Math.Pow(x,2);
        }

        public void perhitungan(Graphics g, int n)
        {
            // Make room for the points.
            xTemp = x;
            yTemp = y;

            for (int i = 1; i <= 10; i++)
            {
                fungsi();
                g.DrawLine(new Pen(Color.Black), xTemp, yTemp, x, y);
                xTemp = x;
                yTemp = y;
            }
        }
    }
}
