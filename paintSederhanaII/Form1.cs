using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Note: Tidak boleh menggunakan ++, += di dalam class

namespace paintSederhanaII
{
    public partial class paintSederhana : Form
    {

        private void btnRefresh2_Click(object sender, EventArgs e) { Refresh(); }
        public paintSederhana()
        {
            InitializeComponent();
            txtN.Enabled = false;
            txtDx.Enabled = false;
            txtDy.Enabled = false;
            txtSkala.Enabled = false;
            txtSudut.Enabled = false;
            txtY.Enabled = false;
            txtSx.Enabled = false;
            txtSy.Enabled = false;

        }
        private void drawPanel_Paint(object sender, PaintEventArgs e)
        {
            g = drawPanel.CreateGraphics();
            g.DrawLine(new Pen(Color.Black), 172, 0, 172, 297);
            g.DrawLine(new Pen(Color.Black), 0, 148, 345, 148);
        }
        
        //==============================================================================================
        //==============================================================================================
        Graphics g;
        DDA dda_ = new DDA();
        PersamaanGaris pg_ = new PersamaanGaris();
        Bresenham br_ = new Bresenham();
        Lingkaran l_ = new Lingkaran();
        Elips e_ = new Elips();
        Bintang bi_ = new Bintang();
        Segi sg_ = new Segi();
        Kurva kv_ = new Kurva();
        AAliasing aa_ = new AAliasing();
        colorfill_class cf_ = new colorfill_class();

        private int Ket = 0, KetWarna = 0;
        private int number = 5;
        private float sudut = 0;
        private bool StartDraw = false;
        private string trans = "default";

        private float pembulatan(float x)
        {
            if(x-0.50 < System.Math.Floor(x))
                return (float)Math.Floor(x);
            else
                return (float)Math.Ceiling(x);
        }


        private void btnDDA_Click(object sender, EventArgs e)
        {
            txtN.Enabled = false;
            Ket = 0;
            btnDDA.BackColor = Color.Orange;
            btnBresmenham.BackColor = Color.Transparent;
            btnCircle.BackColor = Color.Transparent;
            btnEllipse.BackColor = Color.Transparent;
            btnEquality.BackColor = Color.Transparent;
            btnBintang.BackColor = Color.Transparent;
        }

        private void btnEquality_Click(object sender, EventArgs e)
        {
            Ket = 1;
            btnDDA.BackColor = Color.Transparent;
            btnBresmenham.BackColor = Color.Transparent;
            btnCircle.BackColor = Color.Transparent;
            btnEllipse.BackColor = Color.Transparent;
            btnEquality.BackColor = Color.Orange;
            btnBintang.BackColor = Color.Transparent;
            btnSegi.BackColor = Color.Transparent;
            btnKurva.BackColor = Color.Transparent;
            btnAA.BackColor = Color.Transparent;
        }

        private void btnBresmenham_Click(object sender, EventArgs e)
        {
            txtN.Enabled = false;
            Ket = 2;
            btnDDA.BackColor = Color.Transparent;
            btnBresmenham.BackColor = Color.Orange;
            btnCircle.BackColor = Color.Transparent;
            btnEllipse.BackColor = Color.Transparent;
            btnEquality.BackColor = Color.Transparent;
            btnBintang.BackColor = Color.Transparent;
            btnSegi.BackColor = Color.Transparent;
            btnKurva.BackColor = Color.Transparent;
            btnAA.BackColor = Color.Transparent;
        }

        private void btnCircle_Click(object sender, EventArgs e)
        {
            txtN.Enabled = false;
            Ket = 3;
            btnDDA.BackColor = Color.Transparent;
            btnBresmenham.BackColor = Color.Transparent;
            btnCircle.BackColor = Color.Orange;
            btnEllipse.BackColor = Color.Transparent;
            btnEquality.BackColor = Color.Transparent;
            btnBintang.BackColor = Color.Transparent;
            btnSegi.BackColor = Color.Transparent;
            btnKurva.BackColor = Color.Transparent;
            btnAA.BackColor = Color.Transparent;
        }

        private void btnEllipse_Click(object sender, EventArgs e)
        {
            txtN.Enabled = false;
            Ket = 4;
            btnDDA.BackColor = Color.Transparent;
            btnBresmenham.BackColor = Color.Transparent;
            btnCircle.BackColor = Color.Transparent;
            btnEllipse.BackColor = Color.Orange;
            btnEquality.BackColor = Color.Transparent;
            btnBintang.BackColor = Color.Transparent;
            btnSegi.BackColor = Color.Transparent;
            btnKurva.BackColor = Color.Transparent;
            btnAA.BackColor = Color.Transparent;
        }

        private void btnBintang_Click(object sender, EventArgs e)
        {
            txtN.Enabled = true;
            Ket = 5;
            btnDDA.BackColor = Color.Transparent;
            btnBresmenham.BackColor = Color.Transparent;
            btnCircle.BackColor = Color.Transparent;
            btnEllipse.BackColor = Color.Transparent;
            btnEquality.BackColor = Color.Transparent;
            btnBintang.BackColor = Color.Orange;
            btnSegi.BackColor = Color.Transparent;
            btnKurva.BackColor = Color.Transparent;
            btnAA.BackColor = Color.Transparent;
        }

        private void btnSegi_Click(object sender, EventArgs e)
        {
            txtN.Enabled = true;
            Ket = 6;
            btnDDA.BackColor = Color.Transparent;
            btnBresmenham.BackColor = Color.Transparent;
            btnCircle.BackColor = Color.Transparent;
            btnEllipse.BackColor = Color.Transparent;
            btnEquality.BackColor = Color.Transparent;
            btnBintang.BackColor = Color.Transparent;
            btnSegi.BackColor = Color.Orange;
            btnKurva.BackColor = Color.Transparent;
            btnAA.BackColor = Color.Transparent;
        }

        private void btnKurva_Click(object sender, EventArgs e)
        {
            txtN.Enabled = false;
            Ket = 7;
            btnDDA.BackColor = Color.Transparent;
            btnBresmenham.BackColor = Color.Transparent;
            btnCircle.BackColor = Color.Transparent;
            btnEllipse.BackColor = Color.Transparent;
            btnEquality.BackColor = Color.Transparent;
            btnBintang.BackColor = Color.Transparent;
            btnSegi.BackColor = Color.Transparent;
            btnKurva.BackColor = Color.Orange;
            btnAA.BackColor = Color.Transparent;
        }

        private void btnAA_Click(object sender, EventArgs e)
        {
            txtN.Enabled = false;
            Ket = 8;
            btnDDA.BackColor = Color.Transparent;
            btnBresmenham.BackColor = Color.Transparent;
            btnCircle.BackColor = Color.Transparent;
            btnEllipse.BackColor = Color.Transparent;
            btnEquality.BackColor = Color.Transparent;
            btnBintang.BackColor = Color.Transparent;
            btnSegi.BackColor = Color.Transparent;
            btnKurva.BackColor = Color.Transparent;
            btnAA.BackColor = Color.Orange;
        }

        private void btnRotasi_Click(object sender, EventArgs e)
        {
            if (trans != "rotasi")
            {
                trans = "rotasi";
                btnRotasi.BackColor = Color.Orange;
                btnRefleksi.BackColor = Color.Transparent;
                btnTranslasi.BackColor = Color.Transparent;
                btnShearing.BackColor = Color.Transparent;
                btnDilatasi.BackColor = Color.Transparent;

                txtY.Enabled = false;
                txtDx.Enabled = false;
                txtDy.Enabled = false;
                txtSkala.Enabled = false;
                txtSudut.Enabled = true;
            }
            else
            {
                trans = "default";
                btnRotasi.BackColor = Color.Transparent;
                txtSudut.Enabled = false;
            }
        }
        
        private void btnRefleksi_Click(object sender, EventArgs e)
        {
            if (trans != "refleksi")
            {
                trans = "refleksi";
                btnRotasi.BackColor = Color.Transparent;
                btnRefleksi.BackColor = Color.Orange;
                btnTranslasi.BackColor = Color.Transparent;
                btnShearing.BackColor = Color.Transparent;
                btnDilatasi.BackColor = Color.Transparent;

                txtY.Enabled = true;
                txtDx.Enabled = false;
                txtDy.Enabled = false;
                txtSkala.Enabled = false;
                txtSudut.Enabled = false;
            }
            else
            {
                trans = "default";
                btnRefleksi.BackColor = Color.Transparent;
                txtY.Enabled = false;
            }
        }

        private void btnTranslasi_Click(object sender, EventArgs e)
        {
            if (trans != "translasi")
            {
                trans = "translasi";
                btnRotasi.BackColor = Color.Transparent;
                btnRefleksi.BackColor = Color.Transparent;
                btnTranslasi.BackColor = Color.Orange;
                btnDilatasi.BackColor = Color.Transparent;
                btnShearing.BackColor = Color.Transparent;

                txtY.Enabled = false;
                txtDx.Enabled = true;
                txtDy.Enabled = true;
                txtSkala.Enabled = false;
                txtSudut.Enabled = false;
            }
            else
            {
                trans = "default";
                btnTranslasi.BackColor = Color.Transparent;
                txtDx.Enabled = false;
                txtDy.Enabled = false;
            }
        }

        private void btnDilatasi_Click(object sender, EventArgs e)
        {
            if (trans != "dilatasi")
            {
                trans = "dilatasi";
                btnRotasi.BackColor = Color.Transparent;
                btnRefleksi.BackColor = Color.Transparent;
                btnTranslasi.BackColor = Color.Transparent;
                btnDilatasi.BackColor = Color.Orange;
                btnShearing.BackColor = Color.Transparent;

                txtY.Enabled = false;
                txtDx.Enabled = false;
                txtDy.Enabled = false;
                txtSkala.Enabled = true;
                txtSudut.Enabled = false;
            }
            else
            {
                trans = "default";
                btnDilatasi.BackColor = Color.Transparent;
                txtSkala.Enabled = false;
            }
        }
        private void btnShearing_Click(object sender, EventArgs e)
        {
            if (trans != "shearing")
            {
                trans = "shearing";
                btnRotasi.BackColor = Color.Transparent;
                btnShearing.BackColor = Color.Orange;
                btnRefleksi.BackColor = Color.Transparent;
                btnTranslasi.BackColor = Color.Transparent;
                btnDilatasi.BackColor = Color.Transparent;

                txtY.Enabled = false;
                txtDx.Enabled = false;
                txtDy.Enabled = false;
                txtSkala.Enabled = false;
                txtSudut.Enabled = false;
                txtSx.Enabled = true;
                txtSy.Enabled = true;
            }
            else
            {
                trans = "default";
                btnShearing.BackColor = Color.Transparent;
                txtSx.Enabled = false;
                txtSy.Enabled = false;
            }
        }

        private void btnColorFill_Click(object sender, EventArgs e)
        {

            if (Ket == 3 || Ket == 4 || Ket == 6)
            {
                btnColorFill.BackColor = Color.Orange;
                if (Ket == 6)
                {
                    if(KetWarna == 1)
                        color.BackColor = cf_.init(g, sg_.start.X, sg_.start.Y, Color.Blue);
                    else if (KetWarna == 2)
                        color.BackColor = cf_.init(g, sg_.start.X, sg_.start.Y, Color.Black);
                }
                else if (Ket == 3)
                {
                }
                else if (Ket == 4)
                {
                }

            }
            else
            {
            }
        }

        private void MouseUpClick(object sender, MouseEventArgs e)
        {
            StartDraw = false;
        }

        private void MouseDownClick(object sender, MouseEventArgs e)
        {
            StartDraw = true;
            if (Ket == 0)
            {
                dda_.start = e.Location;
                txtX1.Text = dda_.start.X.ToString();
                txtY1.Text = dda_.start.Y.ToString();
            }

            if (Ket == 1)
            {
                pg_.start = e.Location;
                txtX1.Text = pg_.start.X.ToString();
                txtY1.Text = pg_.start.Y.ToString();
            }
            if (Ket == 2)
            {
                br_.start = e.Location;
                txtX1.Text = br_.start.X.ToString();
                txtY1.Text = br_.start.Y.ToString();
            }
            if (Ket == 3)
            {
                l_.start = e.Location;
                txtX1.Text = l_.start.X.ToString();
                txtY1.Text = l_.start.Y.ToString();
            }
            if (Ket == 4)
            {
                e_.start = e.Location;
                txtX1.Text = e_.start.X.ToString();
                txtY1.Text = e_.start.Y.ToString();
            }
            if (Ket == 5)
            {
                bi_.start = e.Location;
                txtX1.Text = bi_.start.X.ToString();
                txtY1.Text = bi_.start.Y.ToString();
            }
            if (Ket == 6)
            {
                sg_.start = e.Location;
                txtX1.Text = sg_.start.X.ToString();
                txtY1.Text = sg_.start.Y.ToString();
            }
            else if (Ket == 7)
            {
                StartDraw = false;
                kv_.perhitungan(g, number);
            }
            else if (Ket == 8)
            {
                aa_.start = e.Location;
                txtX1.Text = aa_.start.X.ToString();
                txtY1.Text = aa_.start.Y.ToString();
            }
        }

        private void MouseMoveClick(object sender, MouseEventArgs e)
        {
            if(StartDraw == true)
            {
                this.Refresh();
                if (Ket == 0)
                {
                    dda_.end = e.Location;
                    sudut = (float)(Math.PI / 2);
                    txtSudut.Text = sudut.ToString();
                    float dx = (float)Convert.ToDouble(txtDx.Text);
                    float dy = (float)Convert.ToDouble(txtDx.Text);
                    float k = (float)Convert.ToDouble(txtSkala.Text);
                    float Sx = (float)Convert.ToDouble(txtSx.Text);
                    float Sy = (float)Convert.ToDouble(txtSy.Text);
                    dda_.perhitungan(g, trans, sudut, KetWarna, dx, dy, k, Sx, Sy);
                }
                else if (Ket == 1)
                {
                    pg_.end = e.Location;
                    pg_.perhitungan(g);
                }
                else if (Ket == 2)
                {
                    br_.end = e.Location;
                    br_.perhitungan(g);
                }
                else if (Ket == 3)
                {
                    l_.end = e.Location;
                    l_.perhitungan(g);
                }
                else if (Ket == 4)
                {
                    e_.end = e.Location;
                    e_.perhitungan(g);
                }
                else if (Ket == 5)
                {
                    bi_.end = e.Location;
                    number = Convert.ToInt32(txtN.Text);
                    bi_.perhitungan(g, number);
                    txtN.Text = number.ToString();
                }
                else if (Ket == 6)
                {
                    sg_.end = e.Location;
                    sudut = (float)(Math.PI / 6);
                    txtSudut.Text = sudut.ToString();
                    number = Convert.ToInt32(txtN.Text);
                    sg_.perhitungan(g, number, trans, sudut);
                    txtN.Text = number.ToString();
                }
                else if (Ket == 8)
                {
                    aa_.end = e.Location;
                    aa_.perhitungan(g, number);
                    txtN.Text = number.ToString();
                }
            }
        }

        private void paintSederhana_Load(object sender, EventArgs e)
        {
        }

        private void btnBlue_Click(object sender, EventArgs e)
        {
            KetWarna = 1;
            btnBlue.BackColor = Color.Orange;
            btnBlack.BackColor = Color.Transparent;
        }

        private void btnBlack_Click(object sender, EventArgs e)
        {
            KetWarna = 2;
            btnBlue.BackColor = Color.Transparent;
            btnBlack.BackColor = Color.Orange;
        }
    }
}
