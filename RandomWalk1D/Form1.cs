using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RandomWalk1D
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Refresh();

            int nsteps = int.Parse(textBox1.Text);
            int nwalks = int.Parse(textBox2.Text);

            //Declearing 1D Array
            float[] x2ave = new float[nsteps];
            float x, delx  = 3;  // x = dispalcement , delx = step size
            Random obj = new Random();
            double prob;

            //Strating the Walk
            for (int w = 0; w < nwalks; w++)
            {
                x = 0;
                for (int s = 0; s < nsteps; s++)
                {
                    prob = obj.NextDouble();
                    if (prob < 0.5)
                    {
                        x = x + delx;
                    }
                    else
                    {
                        x = x - delx;
                    }
                    x2ave[s] =x2ave[s] +  x * x;
                } // Ending of Single Walk
            } // Ending of All Walks

            Graphics gg = CreateGraphics();
            SolidBrush sb = new SolidBrush(Color.Red);
            SolidBrush sb1 = new SolidBrush(Color.Blue);

            // Computing the Mean Sqaure x
            for (int s = 0; s < nsteps; s++)
            {
                x2ave[s] = x2ave[s] / nwalks;
                // By this we will get averag displacement of every walkers

                gg.FillEllipse(sb, 100 + s * 10, 400 - x2ave[s], 4, 4);
                gg.FillEllipse(sb1, 100 + s * 10, 400 - (float)Math.Sqrt(x2ave[s]), 4, 4);

            }
        }
    }
}
