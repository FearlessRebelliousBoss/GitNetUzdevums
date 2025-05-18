using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication_15
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Poga 1 — y = 1 / sin(x)
        private void button1_Click(object sender, EventArgs e)
        {
            ZimetGrafiku(x => 1 / Math.Sin(x), Color.Black);
        }

        // Poga 2 — y = x * x
        private void button2_Click(object sender, EventArgs e)
        {
            ZimetGrafiku(x => x * x, Color.Blue);
        }

        // Poga 3 — y = x (taisne)
        private void button3_Click(object sender, EventArgs e)
        {
            ZimetGrafiku(x => x, Color.Red);
        }

        // Kopīga grafika zīmēšanas funkcija
        private void ZimetGrafiku(Func<double, double> funkcija, Color krasas)
        {
            double m = 30;
            int xc = pictureBox1.Width / 2;
            int yc = pictureBox1.Height / 2;
            int xe, ye;
            double x, y;
            double step = 0.005;

            Graphics G = pictureBox1.CreateGraphics();
            G.Clear(Color.White);

            Pen asis = new Pen(Color.Silver);
            G.DrawLine(asis, 10, yc, 2 * xc - 10, yc); // x ass
            G.DrawLine(asis, xc, 10, xc, 2 * yc - 10); // y ass

            Pen pildspalva = new Pen(krasas);
            x = -Math.PI;

            while (x < Math.PI)
            {
                try
                {
                    y = funkcija(x);
                    xe = (int)(xc + m * x);
                    ye = (int)(yc - m * y);
                    G.DrawEllipse(pildspalva, xe, ye, 1, 1);
                }
                catch { }
                x += step;
            }
        }
    }
}