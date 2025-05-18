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

        // Šī metode tiek izsaukta, kad forma ielādējas
        private void Form1_Load(object sender, EventArgs e)
        {
            // Šeit vari ievietot kodu, kas jāizpilda formu ielādējot, ja nepieciešams
            // Piemēram: MessageBox.Show("Forma ielādēta!");
        }

        // Kopīga funkcija grafika zīmēšanai
        private void ZimetGrafiku(Func<double, double> funkcija, Color krasas)
        {
            double merogs = 30; // mērogs pikseļos
            int xc = pictureBox1.Width / 2; // x ass centrs
            int yc = pictureBox1.Height / 2; // y ass centrs
            int xe, ye;
            double x, y;
            double solis = 0.005;

            Graphics G = pictureBox1.CreateGraphics();
            G.Clear(Color.White); // notīra iepriekšējo grafiku

            // Asu zīmēšana
            Pen asis = new Pen(Color.Silver);
            G.DrawLine(asis, 10, yc, 2 * xc - 10, yc); // x ass
            G.DrawLine(asis, xc, 10, xc, 2 * yc - 10); // y ass

            // Funkcijas zīmēšana
            Pen pildspalva = new Pen(krasas);
            x = -Math.PI;

            while (x < Math.PI)
            {
                try
                {
                    y = funkcija(x);
                    xe = (int)(xc + merogs * x);
                    ye = (int)(yc - merogs * y);
                    G.DrawEllipse(pildspalva, xe, ye, 1, 1);
                }
                catch
                {
                    // Ja funkcija šajā punktā nav definēta (piem., 1/sin(x) pie x=0), ignorē
                }

                x += solis;
            }
        }

        // 1. poga — zīmē y = 1 / sin(x)
        private void button1_Click(object sender, EventArgs e)
        {
            ZimetGrafiku(x => 1 / Math.Sin(x), Color.Black);
        }

        // 2. poga — zīmē y = sin(x) + cos(x)
        private void button2_Click(object sender, EventArgs e)
        {
            ZimetGrafiku(x => Math.Sin(x) + Math.Cos(x), Color.Blue);
        }
    }
}