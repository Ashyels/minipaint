using System;
using System.Drawing;

namespace paintSederhanaII
{
    class DDA
    {
        public Point start, end;
        public float step = 0, step1 = 0;

        private float dx = 0;
        private float dy = 0;

        private float x = 0, x1 = 0, xbay = 0, x1bay = 0;
        private float y = 0, y1 = 0, ybay = 0, y1bay = 0;
        private float xTemp = 0, xTemp1 = 0, xbayTemp = 0, x1bayTemp = 0;
        private float yTemp = 0, yTemp1 = 0, ybayTemp = 0, y1bayTemp = 0;

        private float addX = 0;
        private float addY = 0;

        public void initStep()
        {
            dx = end.X - start.X;
            dy = end.Y - start.Y;

            if (Math.Abs(dx) > Math.Abs(dy))
                step = Math.Abs(dx);
            else if (Math.Abs(dx) <= Math.Abs(dy))
                step = Math.Abs(dy);

            addX = dx/ step;
            addY = dy/ step;
        }

        public void perhitungan(Graphics g, string trans, float sudut, int ketWarna, float dx_, float dy_, float k, float Sx, float Sy)
        {

                initStep();
                x = start.X;
                y = start.Y;
                xTemp = start.X;
                yTemp = start.Y;

                x += addX;
                y += addY;
                xTemp = x;
                yTemp = y;
                if (ketWarna == 1)
                    g.DrawLine(new Pen(Color.Blue), xTemp, yTemp, x, y);
                else if (ketWarna == 2)
                    g.DrawLine(new Pen(Color.Black), xTemp, yTemp, x, y);

                x1 = (float)((Math.Cos(Convert.ToDouble(sudut)) * x) - (Math.Sin(Convert.ToDouble(sudut)) * y));
                y1 = (float)((Math.Sin(Convert.ToDouble(sudut)) * x) + (Math.Cos(Convert.ToDouble(sudut)) * y));
                xTemp1 = x1;
                yTemp1 = y1;

                for (int i = 0; i < step; i++)
                {
                    x += addX;
                    y += addY;
                    x1 = (float)((Math.Cos(Convert.ToDouble(sudut)) * x) - (Math.Sin(Convert.ToDouble(sudut)) * y));
                    y1 = (float)((Math.Sin(Convert.ToDouble(sudut)) * x) + (Math.Cos(Convert.ToDouble(sudut)) * y));

                    if (ketWarna == 1)
                        g.DrawLine(new Pen(Color.Blue), xTemp, yTemp, x, y);
                    else if (ketWarna == 2)
                        g.DrawLine(new Pen(Color.Black), xTemp, yTemp, x, y);

                    xTemp = x;
                    yTemp = y;
                    xTemp1 = x1;
                    yTemp1 = y1;
                }

            //--------

            if (trans == "rotasi")
            {
                xbay = start.X - 172;
                ybay = start.Y - 148;
                xbayTemp = start.X - 172;
                ybayTemp = start.Y - 148;

                xbay += addX;
                ybay += addY;
                xbayTemp = xbay;
                ybayTemp = ybay;

                x1bay = (float)((Math.Cos(Convert.ToDouble(sudut)) * xbay) - (Math.Sin(Convert.ToDouble(sudut)) * ybay));
                y1bay = (float)((Math.Sin(Convert.ToDouble(sudut)) * xbay) + (Math.Cos(Convert.ToDouble(sudut)) * ybay));
                x1bayTemp = x1bay;
                y1bayTemp = y1bay;

                if (ketWarna == 1)
                    g.DrawLine(new Pen(Color.Blue), x1bayTemp + 172, y1bayTemp + 148, x1bay + 172, y1bay + 148);
                else if (ketWarna == 2)
                    g.DrawLine(new Pen(Color.Black), x1bayTemp + 172, y1bayTemp + 148, x1bay + 172, y1bay + 148);

                for (int i = 0; i < step; i++)
                {
                    xbay += addX;
                    ybay += addY;
                    x1bay = (float)((Math.Cos(Convert.ToDouble(sudut)) * xbay) - (Math.Sin(Convert.ToDouble(sudut)) * ybay));
                    y1bay = (float)((Math.Sin(Convert.ToDouble(sudut)) * xbay) + (Math.Cos(Convert.ToDouble(sudut)) * ybay));
                    if (ketWarna == 1)
                        g.DrawLine(new Pen(Color.Blue), x1bayTemp + 172, y1bayTemp + 148, x1bay + 172, y1bay + 148);
                    else if (ketWarna == 2)
                        g.DrawLine(new Pen(Color.Black), x1bayTemp + 172, y1bayTemp + 148, x1bay + 172, y1bay + 148);

                    xbayTemp = xbay;
                    ybayTemp = ybay;
                    x1bayTemp = x1bay;
                    y1bayTemp = y1bay;
                }
            }

            //-------------------

            if (trans == "translasi")
            {
                xbay = start.X - 172;
                ybay = start.Y - 148;
                xbayTemp = start.X - 172;
                ybayTemp = start.Y - 148;

                xbay += addX;
                ybay += addY;
                xbayTemp = xbay;
                ybayTemp = ybay;

                x1bay = (float)((1 * xbay) + (0 * ybay) + dx_);
                y1bay = (float)((0 * xbay) + (1 * ybay) - dy_);
                x1bayTemp = x1bay;
                y1bayTemp = y1bay;

                if (ketWarna == 1)
                {
                    g.DrawLine(new Pen(Color.Blue), x1bayTemp + 172, y1bayTemp + 148, x1bay + 172, y1bay + 148);
//                    g.DrawRectangle(new Pen(Color.Blue), x1bayTemp + 172, y1bayTemp + 148,1,1);
                }
                else if (ketWarna == 2)
                    g.DrawLine(new Pen(Color.Black), x1bayTemp + 172, y1bayTemp + 148, x1bay + 172, y1bay + 148);
                for (int i = 0; i < step; i++)
                {
                    xbay += addX;
                    ybay += addY;
                    x1bay = (float)((1 * xbay) + (0 * ybay) + dx_);
                    y1bay = (float)((0 * xbay) + (1 * ybay) - dy_);
                    if (ketWarna == 1)
                        g.DrawLine(new Pen(Color.Blue), x1bayTemp + 172, y1bayTemp + 148, x1bay + 172, y1bay + 148);
                    else if (ketWarna == 2)
                        g.DrawLine(new Pen(Color.Black), x1bayTemp + 172, y1bayTemp + 148, x1bay + 172, y1bay + 148);

                    xbayTemp = xbay;
                    ybayTemp = ybay;
                    x1bayTemp = x1bay;
                    y1bayTemp = y1bay;
                }
            }


            else if (trans == "refleksi")
            {
                xbay = start.X - 172;
                ybay = start.Y - 148;
                xbayTemp = start.X - 172;
                ybayTemp = start.Y - 148;

                xbay += addX;
                ybay += addY;
                xbayTemp = xbay;
                ybayTemp = ybay;

                x1bay = (float)((0 * xbay) + (-1 * ybay));
                y1bay = (float)((-1 * xbay) + (0 * ybay));
                x1bayTemp = x1bay;
                y1bayTemp = y1bay;

                if (ketWarna == 1)
                    g.DrawLine(new Pen(Color.Blue), x1bayTemp + 172, y1bayTemp + 148, x1bay + 172, y1bay + 148);
                else if (ketWarna == 2)
                    g.DrawLine(new Pen(Color.Black), x1bayTemp + 172, y1bayTemp + 148, x1bay + 172, y1bay + 148);

                for (int i = 0; i < step; i++)
                {
                    xbay += addX;
                    ybay += addY;
                    x1bay = (float)((0 * xbay) + (-1 * ybay));
                    y1bay = (float)((-1 * xbay) + (0 * ybay));
                    if (ketWarna == 1)
                        g.DrawLine(new Pen(Color.Blue), x1bayTemp + 172, y1bayTemp + 148, x1bay + 172, y1bay + 148);
                    else if (ketWarna == 2)
                        g.DrawLine(new Pen(Color.Black), x1bayTemp + 172, y1bayTemp + 148, x1bay + 172, y1bay + 148);

                    xbayTemp = xbay;
                    ybayTemp = ybay;
                    x1bayTemp = x1bay;
                    y1bayTemp = y1bay;
                }
            }

            else if (trans == "dilatasi")
            {
                xbay = start.X - 172;
                ybay = start.Y - 148;
                xbayTemp = start.X - 172;
                ybayTemp = start.Y - 148;

                xbay += addX;
                ybay += addY;
                xbayTemp = xbay;
                ybayTemp = ybay;

                x1bay = (float)((k * xbay) + (0 * ybay));
                y1bay = (float)((0 * xbay) + (k * ybay));
                x1bayTemp = x1bay;
                y1bayTemp = y1bay;

                if (ketWarna == 1)
                    g.DrawLine(new Pen(Color.Blue), x1bayTemp + 172, y1bayTemp + 148, x1bay + 172, y1bay + 148);
                else if (ketWarna == 2)
                    g.DrawLine(new Pen(Color.Black), x1bayTemp + 172, y1bayTemp + 148, x1bay + 172, y1bay + 148);

                for (int i = 0; i < step; i++)
                {
                    xbay += addX;
                    ybay += addY;
                    x1bay = (float)((k * xbay) + (0 * ybay));
                    y1bay = (float)((0 * xbay) + (k * ybay));
                    if (ketWarna == 1)
                        g.DrawLine(new Pen(Color.Blue), x1bayTemp + 172, y1bayTemp + 148, x1bay + 172, y1bay + 148);
                    else if (ketWarna == 2)
                        g.DrawLine(new Pen(Color.Black), x1bayTemp + 172, y1bayTemp + 148, x1bay + 172, y1bay + 148);

                    xbayTemp = xbay;
                    ybayTemp = ybay;
                    x1bayTemp = x1bay;
                    y1bayTemp = y1bay;
                }
            }

            //--------

            if (trans == "shearing")
            {
                xbay = start.X - 172;
                ybay = start.Y - 148;
                xbayTemp = start.X - 172;
                ybayTemp = start.Y - 148;

                xbay += addX;
                ybay += addY;
                xbayTemp = xbay;
                ybayTemp = ybay;

                x1bay = (float)(xbay + (Sx * ybay));
                y1bay = (float)((Sy * xbay) + ybay);
                x1bayTemp = x1bay;
                y1bayTemp = y1bay;

                if (ketWarna == 1)
                    g.DrawLine(new Pen(Color.Blue), x1bayTemp + 172, y1bayTemp + 148, x1bay + 172, y1bay + 148);
                else if (ketWarna == 2)
                    g.DrawLine(new Pen(Color.Black), x1bayTemp + 172, y1bayTemp + 148, x1bay + 172, y1bay + 148);

                for (int i = 0; i < step; i++)
                {
                    xbay += addX;
                    ybay += addY;
                    x1bay = (float)(xbay + (Sx * ybay));
                    y1bay = (float)((Sy * xbay) + ybay);
                    if (ketWarna == 1)
                        g.DrawLine(new Pen(Color.Blue), x1bayTemp + 172, y1bayTemp + 148, x1bay + 172, y1bay + 148);
                    else if (ketWarna == 2)
                        g.DrawLine(new Pen(Color.Black), x1bayTemp + 172, y1bayTemp + 148, x1bay + 172, y1bay + 148);

                    xbayTemp = xbay;
                    ybayTemp = ybay;
                    x1bayTemp = x1bay;
                    y1bayTemp = y1bay;
                }
            }
        }
    }
}
