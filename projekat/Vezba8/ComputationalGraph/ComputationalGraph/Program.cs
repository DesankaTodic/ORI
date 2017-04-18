using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace ComputationalGraph
{
    class Program
    {
		//ako je a onda je izlaz 1, a b onda je 0
		static List<List<double>> ulazi = new List<List<double>>();//lista ulaza
		static List<List<double>> izlazi = new List<List<double>>();//lista ulaza

		static List<List<double>> ulaziTest = new List<List<double>>();//lista ulaza
		static List<List<double>> izlaziTest = new List<List<double>>();//lista ulaza

		public static List<double> greskeZeljenaDobijena = new List<double>();

		static NeuralNetwork network = null;

		 [STAThread]
		static void Main(string[] args)
        {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new prepoznavanjeSlova());
        }

		public static void obuciMrezu(){
			network = new NeuralNetwork();
			network.Add(new NeuralLayer(100, 100, "sigmoid")); 
			network.Add(new NeuralLayer(100, 1, "sigmoid"));

			ucitajObucavajuciSkup();
			network.fit(ulazi, izlazi, 0.1, 0.9, 10);
			List<string> lines = new List<string>();
			for (int d = 0; d < 200; d++)
			{
				lines.Add(greskeZeljenaDobijena[d].ToString());
			}

			System.IO.File.WriteAllLines(@"..\..\..\..\grad.txt", lines);
		
			//Console.WriteLine("Mreza obucena.");
		}
		public static double testirajMrezuZaDatiFajl(string fname)
		{
			double rezultat = -1;
			Console.WriteLine(fname);
			ucitajTestniSkupZaDatiFajl(fname);
			for (int k = 0; k < ulaziTest.Count; k++)
			{
				rezultat = network.predict(ulaziTest[k])[0];
				if (rezultat < 0.5)
				{
					rezultat = 0;
				}
				else
				{
					rezultat = 1;
				}
			}
			
			return rezultat;
		}
		public static void ucitajTestniSkupZaDatiFajl(string fname)
		{
			ulaziTest.Clear();
			List<double> crne3b = obradiSliku(fname);
			ulaziTest.Add(crne3b);
		}
		public static double testirajMrezu()
		{
			double brojTacnih = 0;
			double brojSvih = 0;
			double rezultat = -1;
			ucitajTestniSkup();
			for (int k = 0; k < ulaziTest.Count; k++)
			{
				rezultat = network.predict(ulaziTest[k])[0];
				if (rezultat < 0.5)
				{
					rezultat = 0;
				}
				else
				{
					rezultat = 1;
				}

				if (rezultat == izlaziTest[k][0])
				{
					brojTacnih++;
				}

				brojSvih++;
			}
			double procenat_tacnosti = (brojTacnih / brojSvih) * 100;
			Console.WriteLine("Procenat tacnosti: " + procenat_tacnosti + "%");
			//Console.ReadLine();
			return procenat_tacnosti;
		}
		public static void ucitajTestniSkup()
		{
			double jedan = 1;
			double nula = 0;
			ulaziTest.Clear();
			List<double> crne1 = obradiSliku(@"..\..\..\..\atest1.jpg");
			ulaziTest.Add(crne1);
			List<double> izlaz1 = new List<double>();
			izlaz1.Add(jedan);
			izlaziTest.Add(izlaz1);

			List<double> crne1b = obradiSliku(@"..\..\..\..\btest1.jpg");
			ulaziTest.Add(crne1b);
			List<double> izlaz1b = new List<double>();
			izlaz1b.Add(nula);
			izlaziTest.Add(izlaz1b);

			List<double> crne2b = obradiSliku(@"..\..\..\..\btest2.jpg");
			ulaziTest.Add(crne2b);
			List<double> izlaz2b = new List<double>();
			izlaz2b.Add(nula);
			izlaziTest.Add(izlaz2b);

			List<double> crne2 = obradiSliku(@"..\..\..\..\atest2.jpg");
			ulaziTest.Add(crne2);
			List<double> izlaz2 = new List<double>();
			izlaz2.Add(jedan);
			izlaziTest.Add(izlaz2);

			List<double> crne3 = obradiSliku(@"..\..\..\..\atest3.jpg");
			ulaziTest.Add(crne3);
			List<double> izlaz3 = new List<double>();
			izlaz3.Add(jedan);
			izlaziTest.Add(izlaz3);

			List<double> crne3b = obradiSliku(@"..\..\..\..\btest3.jpg");
				//List<double> crne3b = obradiSliku(fname);
			ulaziTest.Add(crne3b);
			List<double> izlaz3b = new List<double>();
			izlaz3b.Add(nula);
			izlaziTest.Add(izlaz3b);

			List<double> crne4 = obradiSliku(@"..\..\..\..\atest4.jpg");
			ulaziTest.Add(crne4);
			List<double> izlaz4 = new List<double>();
			izlaz4.Add(jedan);
			izlaziTest.Add(izlaz4);

			List<double> crne4b = obradiSliku(@"..\..\..\..\btest4.jpg");
			ulaziTest.Add(crne4b);
			List<double> izlaz4b = new List<double>();
			izlaz4b.Add(jedan);
			izlaziTest.Add(izlaz4b);

			List<double> crne5b = obradiSliku(@"..\..\..\..\btest5.jpg");
			//List<double> crne3b = obradiSliku(fname);
			ulaziTest.Add(crne5b);
			List<double> izlaz5b = new List<double>();
			izlaz5b.Add(nula);
			izlaziTest.Add(izlaz5b);

			List<double> crne5 = obradiSliku(@"..\..\..\..\atest5.jpg");
			ulaziTest.Add(crne5);
			List<double> izlaz5= new List<double>();
			izlaz5.Add(jedan);
			izlaziTest.Add(izlaz5);


		}

		public static void ucitajObucavajuciSkup()
		{

			double jedan = 1;
			double nula = 0;
			List<double> crne1 = obradiSliku(@"..\..\..\..\a.jpg");
			ulazi.Add(crne1);
			List<double> izlaz1 = new List<double>();
			izlaz1.Add(jedan);
			izlazi.Add(izlaz1);

			List<double> crne1b = obradiSliku(@"..\..\..\..\b1.jpg");
			ulazi.Add(crne1b);
			List<double> izlaz1b = new List<double>();
			izlaz1b.Add(nula);
			izlazi.Add(izlaz1b);

			List<double> crne2b = obradiSliku(@"..\..\..\..\b2.jpg");
			ulazi.Add(crne2b);
			List<double> izlaz2b = new List<double>();
			izlaz2b.Add(nula);
			izlazi.Add(izlaz2b);

			List<double> crne2 = obradiSliku(@"..\..\..\..\a2.jpg");
			ulazi.Add(crne2);
			List<double> izlaz2 = new List<double>();
			izlaz2.Add(jedan);
			izlazi.Add(izlaz2);

			List<double> crne3 = obradiSliku(@"..\..\..\..\a3.jpg");
			ulazi.Add(crne3);
			List<double> izlaz3 = new List<double>();
			izlaz3.Add(jedan);
			izlazi.Add(izlaz3);

			List<double> crne3b = obradiSliku(@"..\..\..\..\b3.jpg");
			ulazi.Add(crne3b);
			List<double> izlaz3b = new List<double>();
			izlaz3b.Add(nula);
			izlazi.Add(izlaz3b);

			List<double> crne4 = obradiSliku(@"..\..\..\..\a4.jpg");
			ulazi.Add(crne4);
			List<double> izlaz4 = new List<double>();
			izlaz4.Add(jedan);
			izlazi.Add(izlaz4);

			List<double> crne4b = obradiSliku(@"..\..\..\..\b4.jpg");
			ulazi.Add(crne4b);
			List<double> izlaz4b = new List<double>();
			izlaz4b.Add(nula);
			izlazi.Add(izlaz4b);

			List<double> crne5b = obradiSliku(@"..\..\..\..\b5.jpg");
			ulazi.Add(crne5b);
			List<double> izlaz5b = new List<double>();
			izlaz5b.Add(nula);
			izlazi.Add(izlaz5b);

			List<double> crne5 = obradiSliku(@"..\..\..\..\a5.jpg");
			ulazi.Add(crne5);
			List<double> izlaz5 = new List<double>();
			izlaz5.Add(jedan);
			izlazi.Add(izlaz5);

			List<double> crne6 = obradiSliku(@"..\..\..\..\a6.jpg");
			ulazi.Add(crne6);
			List<double> izlaz6 = new List<double>();
			izlaz6.Add(jedan);
			izlazi.Add(izlaz6);

			List<double> crne7 = obradiSliku(@"..\..\..\..\a7.jpg");
			ulazi.Add(crne7);
			List<double> izlaz7 = new List<double>();
			izlaz7.Add(jedan);
			izlazi.Add(izlaz7);

			List<double> crne6b = obradiSliku(@"..\..\..\..\b6.jpg");
			ulazi.Add(crne6b);
			List<double> izlaz6b = new List<double>();
			izlaz6b.Add(nula);
			izlazi.Add(izlaz6b);

			List<double> crne7b = obradiSliku(@"..\..\..\..\b7.jpg");
			ulazi.Add(crne7b);
			List<double> izlaz7b = new List<double>();
			izlaz7b.Add(nula);
			izlazi.Add(izlaz7b);

			List<double> crne8b = obradiSliku(@"..\..\..\..\b8.jpg");
			ulazi.Add(crne8b);
			List<double> izlaz8b = new List<double>();
			izlaz8b.Add(nula);
			izlazi.Add(izlaz8b);

			List<double> crne8 = obradiSliku(@"..\..\..\..\a8.jpg");
			ulazi.Add(crne8);
			List<double> izlaz8 = new List<double>();
			izlaz8.Add(jedan);
			izlazi.Add(izlaz8);

			List<double> crne9 = obradiSliku(@"..\..\..\..\a9.jpg");
			ulazi.Add(crne9);
			List<double> izlaz9 = new List<double>();
			izlaz9.Add(jedan);
			izlazi.Add(izlaz9);

			List<double> crne10 = obradiSliku(@"..\..\..\..\a10.jpg");
			ulazi.Add(crne10);
			List<double> izlaz10 = new List<double>();
			izlaz10.Add(jedan);
			izlazi.Add(izlaz10);

			List<double> crne9b = obradiSliku(@"..\..\..\..\b9.jpg");
			ulazi.Add(crne9b);
			List<double> izlaz9b = new List<double>();
			izlaz9b.Add(nula);
			izlazi.Add(izlaz9b);

			List<double> crne10b = obradiSliku(@"..\..\..\..\b10.jpg");
			ulazi.Add(crne10b);
			List<double> izlaz10b = new List<double>();
			izlaz10b.Add(nula);
			izlazi.Add(izlaz10b);

		}

		public static List<double> obradiSliku(String filename)
		{
			Bitmap bmp = new Bitmap(filename);
			List<double> crne = new List<double>();
			int h = bmp.Height;
			int w = bmp.Width;

			if (bmp != null)
				Console.WriteLine("Imam sliku h=" + h + " w=" + w);
			///matrica
			List<double> redovi0_10SveKolone = prebrojCrne(0, 10, bmp);
			crne.AddRange(redovi0_10SveKolone);
			List<double> redovi10_20SveKolone = prebrojCrne(10, 20, bmp);
			crne.AddRange(redovi10_20SveKolone);
			List<double> redovi20_30SveKolone = prebrojCrne(20, 30, bmp);
			crne.AddRange(redovi20_30SveKolone);
			List<double> redovi30_40SveKolone = prebrojCrne(30, 40, bmp);
			crne.AddRange(redovi30_40SveKolone);
			List<double> redovi40_50SveKolone = prebrojCrne(40, 50, bmp);
			crne.AddRange(redovi40_50SveKolone);
			List<double> redovi50_60SveKolone = prebrojCrne(50, 60, bmp);
			crne.AddRange(redovi50_60SveKolone);
			List<double> redovi60_70SveKolone = prebrojCrne(60, 70, bmp);
			crne.AddRange(redovi60_70SveKolone);
			List<double> redovi70_80SveKolone = prebrojCrne(70, 80, bmp);
			crne.AddRange(redovi70_80SveKolone);
			List<double> redovi80_90SveKolone = prebrojCrne(80, 90, bmp);
			crne.AddRange(redovi80_90SveKolone);
			List<double> redovi90_100SveKolone = prebrojCrne(90, 100, bmp);
			crne.AddRange(redovi90_100SveKolone);

			return crne;
		}
		public static List<double> prebrojCrne(int from, int to, Bitmap bmp)
		{
			List<double> crne10x10 = new List<double>();
			int broj_crnih_10x10 = 0;
			int broj_crnih_u_redu = 0;

			for (int d = from; d < to; d++)
			{
				broj_crnih_u_redu = prebrojCrnePoKolonama(d, 0, 10, bmp);
				broj_crnih_10x10 += broj_crnih_u_redu;
			}
			crne10x10.Add(broj_crnih_10x10);
			
			broj_crnih_10x10 = 0;
			for (int d = from; d < to; d++)
			{
				broj_crnih_u_redu = prebrojCrnePoKolonama(d, 10, 20, bmp);
				broj_crnih_10x10 += broj_crnih_u_redu;
			}
			crne10x10.Add(broj_crnih_10x10);
			
			broj_crnih_10x10 = 0;
			for (int d = from; d < to; d++)
			{
				broj_crnih_u_redu = prebrojCrnePoKolonama(d, 20, 30, bmp);
				broj_crnih_10x10 += broj_crnih_u_redu;
			}
			crne10x10.Add(broj_crnih_10x10);
			
			broj_crnih_10x10 = 0;
			for (int d = from; d < to; d++)
			{
				broj_crnih_u_redu = prebrojCrnePoKolonama(d, 30, 40, bmp);
				broj_crnih_10x10 += broj_crnih_u_redu;
			}
			crne10x10.Add(broj_crnih_10x10);
			
			broj_crnih_10x10 = 0;
			for (int d = from; d < to; d++)
			{
				broj_crnih_u_redu = prebrojCrnePoKolonama(d, 40, 50, bmp);
				broj_crnih_10x10 += broj_crnih_u_redu;
			}
			crne10x10.Add(broj_crnih_10x10);

			broj_crnih_10x10 = 0;
			for (int d = from; d < to; d++)
			{
				broj_crnih_u_redu = prebrojCrnePoKolonama(d, 50, 60, bmp);
				broj_crnih_10x10 += broj_crnih_u_redu;
			}
			crne10x10.Add(broj_crnih_10x10);

			broj_crnih_10x10 = 0;
			for (int d = from; d < to; d++)
			{
				broj_crnih_u_redu = prebrojCrnePoKolonama(d, 60, 70, bmp);
				broj_crnih_10x10 += broj_crnih_u_redu;
			}
			crne10x10.Add(broj_crnih_10x10);

			broj_crnih_10x10 = 0;
			for (int d = from; d < to; d++)
			{
				broj_crnih_u_redu = prebrojCrnePoKolonama(d, 70, 80, bmp);
				broj_crnih_10x10 += broj_crnih_u_redu;
			}
			crne10x10.Add(broj_crnih_10x10);

			broj_crnih_10x10 = 0;
			for (int d = from; d < to; d++)
			{

				broj_crnih_u_redu = prebrojCrnePoKolonama(d, 80, 90, bmp);
				broj_crnih_10x10 += broj_crnih_u_redu;
			}
			crne10x10.Add(broj_crnih_10x10);

			broj_crnih_10x10 = 0;
			for (int d = from; d < to; d++)
			{

				broj_crnih_u_redu = prebrojCrnePoKolonama(d, 90, 100, bmp);
				broj_crnih_10x10 += broj_crnih_u_redu;
			}
			crne10x10.Add(broj_crnih_10x10);
			return crne10x10;
		}
		public static int prebrojCrnePoKolonama(int d, int from, int to, Bitmap bmp)
		{
			int broj_crnih = 0;
			for (int t = from; t < to; t++)
			{
				Color pixelColor = bmp.GetPixel(d, t);
				if (pixelColor.R < 20 && pixelColor.G < 20 && pixelColor.B < 20)//da bi pokupi i one bliske crnim pikselima
					broj_crnih++;
			}

			return broj_crnih;
		}
    }
}
