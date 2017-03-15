using System;
using System.Drawing;

namespace paintSederhanaII
{
    class Kurva
    {
        public Point start, end;
        public float xTemp = 0, yTemp = 0;
        public float y = 0;
        public float x = 0;
        public float xBay = 0;

        public float fungsi(float x)
        {
            float y = (float)(0.05 * Math.Pow(x, 3));
            return y;
        }
        public void perhitungan(Graphics g, int n)
        {
            // Make room for the points.
            /*            xTemp = x;
                        yTemp = y;
                        for(x = 0; x<340; x++)
                        {
                            if(x < 170)
                            {
                                xBay = 170 - x;
                                y = fungsi(xBay);
                                g.DrawLine(new Pen(Color.Black), xTemp, yTemp, x, 120-y);
                                xTemp = x;
                                yTemp = y;
                            }
                            else if (x >= 170)
                            {
                                xBay = Math.Abs(170 - x);
                                y = fungsi(xBay);
                                g.DrawLine(new Pen(Color.Black), xTemp, yTemp, x, 120-y);
                                xTemp = x;
                                yTemp = y;
                            }
                        }
                        */
/*            Point[] ptarray = new Point[3];
            ptarray[0] = new Point(250, 250);
            ptarray[1] = new Point(300, 300);
            ptarray[2] = new Point(350, 400);

            Pen pengraph = new Pen(Color.Green, 0.75F);
            g.DrawCurve(pengraph, ptarray);
            */
            Point[] ptarray2 = new Point[3];
            ptarray2[0] = new Point(100, 100);
            ptarray2[1] = new Point(200, 150);
            ptarray2[2] = new Point(250, 250);

            Pen pengraph2 = new Pen(Color.Black, 1.25F);
            g.DrawCurve(pengraph2, ptarray2);

        }       
    }
}
