using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ComputationalGraph
{
	public partial class prepoznavanjeSlova : Form
	{
		private OpenFileDialog ofd = new OpenFileDialog();
		
		public prepoznavanjeSlova()
		{
			InitializeComponent();
			this.CenterToScreen();
		}


		private void buttonObuci_Click_1(object sender, EventArgs e)
		{
			Program.obuciMrezu(); 
			MessageBox.Show("Мрежа је обучена.", "Порука");

		}

		private void button2_Click(object sender, EventArgs e)
		{
			DialogResult d = ofd.ShowDialog();
			string fname ="";
			if (d == DialogResult.OK)
			{
				fname = ofd.FileName;
				Image img = new Bitmap(fname);
				img = new Bitmap(img, new Size(pictureBox1.Width, pictureBox1.Height));
				pictureBox1.BackgroundImage = img;

			}
			if (fname != "")
			{
				double rezultat = Program.testirajMrezuZaDatiFajl(fname);
				if (rezultat == 0)
				{
					MessageBox.Show("То је слово Б.", "Рјешење");
				}
				else if (rezultat == 1)
				{
					MessageBox.Show("То је слово A.", "Рјешење");
				}
			}
			else
			{
				MessageBox.Show("Морате изабрати фајл са сликом.", "Порука");
			}
		}

		private void prepoznavanjeSlova_Load(object sender, EventArgs e)
		{

		}

		private void prepoznavanjeSlova_FormClosing(object sender, FormClosingEventArgs e)
		{
			DialogResult d = MessageBox.Show("Да ли сигурно желите да изађете?", "Излаз", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (d.Equals(DialogResult.Yes))
			{
				Application.ExitThread();//da ne bi morali 2x pritisnuti yes 
			}
			else if (d.Equals(DialogResult.No))
			{
				e.Cancel = true;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{//prikazivanje procenta tacnosti
			double procenat_tacnosti = Program.testirajMrezu();
			MessageBox.Show("Проценат тачности је "+procenat_tacnosti+" %.", "Тачност");
		}
		
	}
	
}
