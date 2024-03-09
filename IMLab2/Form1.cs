using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMLab2
{
	public partial class Form1 : Form
	{
		double stft, stsd, maxH;
		const double k = 0.02;
		int x = 0;
		Random rnd = new Random();
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (timer1.Enabled)
			{
				timer1.Stop();
			}
			else
			{
				chart1.ChartAreas[0].AxisX.Maximum = 2;

				chart1.Series[0].Points.Clear();
				chart1.Series[1].Points.Clear();
				stft = (double)First.Value;
				stsd = (double)Second.Value;
				if (stft > stsd)
				{
					
					maxH = stft;
				}
				else
				{
					
					maxH = stsd;
				}
				chart1.ChartAreas[0].AxisY.Maximum = maxH + 5;
		
				timer1.Start();
				chart1.Series[0].Points.AddXY(0, stft);
				chart1.Series[0].Points.AddXY(0, stsd);
				x = 0;
			}

			

		}

		private void timer1_Tick(object sender, EventArgs e)
		{

			x++;
			stft = stft * (1 + k * (rnd.NextDouble() - 0.5));
			if (stft>maxH) maxH = stft;
			stsd = stsd * (1 + k * (rnd.NextDouble() - 0.5));
			if (stsd > maxH) maxH = stsd;

			chart1.ChartAreas[0].AxisY.Maximum = maxH + 5;
			chart1.ChartAreas[0].AxisX.Maximum++;
			
			chart1.Series[0].Points.AddXY(x, stft);
			chart1.Series[1].Points.AddXY(x, stsd);

		}

		private void numericUpDown1_ValueChanged(object sender, EventArgs e)
		{

		}
	}
}
