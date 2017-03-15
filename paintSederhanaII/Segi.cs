using System;
using System.Drawing;

namespace paintSederhanaII
{
    class Segi
    {
        public Point start, end;
        public float xTemp = 0, yTemp = 0;
        private float xTemp1 = 0, yTemp1 = 0;
        public float dx = 0, dy = 0;
        private float x1 = 0, y1 = 0;

        public void perhitungan(Graphics g, int n, string trans, float sudut)
        {
            if(trans == "rotasi")
            {
                // Make room for the points.
                dx = Math.Abs(end.X - start.X);
                dy = Math.Abs(end.Y - start.Y);

                double alpha = 2 * Math.PI / n;
                double beta = (-Math.PI / 2) + (Math.PI / n);

                double rx = dx; // jari-jari x
                double ry = dy; // jari-jari y

                double cx = start.X; // x1
                double cy = start.Y; // y1

                xTemp = (float)(cx + rx * Math.Cos(beta));
                yTemp = (float)(cy + ry * Math.Sin(beta));


                for (int i = 1; i <= n; i++)
                {
                    x1 = (float)((Math.Cos(Convert.ToDouble(sudut)) * cx + rx * Math.Cos((i * alpha) + beta)) - (Math.Sin(Convert.ToDouble(sudut)) * cy + ry * Math.Sin((i * alpha) + beta)));
                    y1 = (float)((Math.Sin(Convert.ToDouble(sudut)) * cx + rx * Math.Cos((i * alpha) + beta)) + (Math.Cos(Convert.ToDouble(sudut)) * cy + ry * Math.Sin((i * alpha) + beta)));
                    g.DrawLine(new Pen(Color.Black), xTemp, yTemp, (float)(cx + rx * Math.Cos((i * alpha) + beta)), (float)(cy + ry * Math.Sin((i * alpha) + beta)));
                    g.DrawLine(new Pen(Color.Blue), xTemp1, yTemp1, x1, y1);
                    xTemp1 = x1;
                    yTemp1 = y1;
                    xTemp = (float)(cx + rx * Math.Cos((i * alpha) + beta));
                    yTemp = (float)(cy + ry * Math.Sin((i * alpha) + beta));
                }
            }
            else
            {
                // Make room for the points.
                dx = Math.Abs(end.X - start.X);
                dy = Math.Abs(end.Y - start.Y);

                double alpha = 2 * Math.PI / n;
                double beta = (-Math.PI / 2) + (Math.PI / n);

                double rx = dx; // jari-jari x
                double ry = dy; // jari-jari y

                double cx = start.X; // x1
                double cy = start.Y; // y1

                xTemp = (float)(cx + rx * Math.Cos(beta));
                yTemp = (float)(cy + ry * Math.Sin(beta));

                for (int i = 1; i <= n; i++)
                {
//                    g.DrawRectangle(new Pen(Color.Blue), (float)(cx + rx * Math.Cos((i * alpha) + beta)), (float)(cy + ry * Math.Sin((i * alpha) + beta)), 1, 1);
                    g.DrawLine(new Pen(Color.Black), xTemp, yTemp, (float)(cx + rx * Math.Cos((i * alpha) + beta)), (float)(cy + ry * Math.Sin((i * alpha) + beta)));
                    xTemp = (float)(cx + rx * Math.Cos((i * alpha) + beta));
                    yTemp = (float)(cy + ry * Math.Sin((i * alpha) + beta));
                }
            }
        }
    }
}
