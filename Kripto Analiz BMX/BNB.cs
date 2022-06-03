
using System;
using System.Xml;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;
using System.Media;
using System.Diagnostics;
using System.Windows.Forms;

namespace Kripto_Analiz_BMX
{
    public partial class BNB : Form
    {

        //BNB
        private static double bnbLastPrice()
        {


            WebClient wb = new WebClient();
            string btc = wb.DownloadString("https://api.binance.com/api/v3/ticker/24hr?symbol=BNBUSDT");

            int pos1 = btc.IndexOf("lastPrice", 0);
            int pos2 = btc.IndexOf(":", pos1);
            int pos3 = btc.IndexOf(",", pos2);

            return Convert.ToDouble(btc.Substring(pos2 + 2, pos3 - pos2 - 4));
        }
        private static double bnbMaxPrice()
        {


            WebClient wb = new WebClient();
            string btc = wb.DownloadString("https://api.binance.com/api/v3/ticker/24hr?symbol=BNBUSDT");

            int pos1 = btc.IndexOf("highPrice", 0);
            int pos2 = btc.IndexOf(":", pos1);
            int pos3 = btc.IndexOf(",", pos2);

            return Convert.ToDouble(btc.Substring(pos2 + 2, pos3 - pos2 - 4));
        }

        private static double bnbMinPrice()
        {


            WebClient wb = new WebClient();
            string btc = wb.DownloadString("https://api.binance.com/api/v3/ticker/24hr?symbol=BNBUSDT");

            int pos1 = btc.IndexOf("lowPrice", 0);
            int pos2 = btc.IndexOf(":", pos1);
            int pos3 = btc.IndexOf(",", pos2);

            return Convert.ToDouble(btc.Substring(pos2 + 2, pos3 - pos2 - 4));
        }

        private static double bnb24Change()
        {


            WebClient wb = new WebClient();
            string btc = wb.DownloadString("https://api.binance.com/api/v3/ticker/24hr?symbol=BNBUSDT");

            int pos1 = btc.IndexOf("priceChange", 0);
            int pos2 = btc.IndexOf(":", pos1);
            int pos3 = btc.IndexOf(",", pos2);

            return Convert.ToDouble(btc.Substring(pos2 + 2, pos3 - pos2 - 4));
        }


        private static double bnb24Average()
        {


            WebClient wb = new WebClient();
            string btc = wb.DownloadString("https://api.binance.com/api/v3/ticker/24hr?symbol=BNBUSDT");

            int pos1 = btc.IndexOf("weightedAvgPrice", 0);
            int pos2 = btc.IndexOf(":", pos1);
            int pos3 = btc.IndexOf(",", pos2);

            return Convert.ToDouble(btc.Substring(pos2 + 2, pos3 - pos2 - 4));
        }



        // bnb bitiş

        // matematiksel fonksiyonlar

        SoundPlayer player = new SoundPlayer();
        public static double Destek1(double sondeger)
        {

            return sondeger * 0.9534534534576;
        }

        public static double Destek2(double sondeger)
        {

            return sondeger * 0.91345345345;
        }

        public static double Direnc1(double sondeger)
        {

            return sondeger * 0.05345345345 + sondeger;
        }
        public static double Direnc2(double sondeger)
        {

            return sondeger * 0.097567567567567 + sondeger;
        }

        public void DovizGoster()
        {
            try
            {

                XmlDocument xmlVerisi = new XmlDocument();
                xmlVerisi.Load("http://www.tcmb.gov.tr/kurlar/today.xml");

                decimal dolar = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "USD")).InnerText.Replace('.', ','));
                decimal euro = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "EUR")).InnerText.Replace('.', ','));
                decimal sterlin = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "GBP")).InnerText.Replace('.', ','));

                label1.Text = dolar.ToString();
                label2.Text = euro.ToString();
                label3.Text = sterlin.ToString();
            }
            catch (XmlException xml)
            {
                timer1.Stop();
                MessageBox.Show(xml.ToString());
            }

        }



        public BNB()
        {
            InitializeComponent();
        }

        private void BNB_Load(object sender, EventArgs e)
        {
            timer2.Interval = 5000;
            timer2.Start();
            DovizGoster();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label26.Text = DateTime.Now.ToShortTimeString();
            label27.Text = DateTime.Now.ToLongDateString();
  
            label4.Text = String.Format("{0:00,000}", (bnbLastPrice() / 10000)); // son değer
            label5.Text = String.Format("{0:00,000}", (bnbMaxPrice() / 10000)); // max değer
            label18.Text = String.Format("{0:00,000}", (bnbMinPrice() / 10000)); // min değer 
            label19.Text = String.Format("{0:00,000}", (bnb24Change() / 10000)); // 24 saat değişim
            label20.Text = String.Format("{0:00,000}", (bnb24Average() / 10000)); // 24 saatlik ortalama
            double btcavarage = bnb24Average();

            double destek1 = Destek1(btcavarage) / 10000000;
            destek1 = Math.Round(destek1, 2);
            label21.Text = Convert.ToString(destek1);


            double destek2 = Destek2(btcavarage) / 10000000;
            destek2 = Math.Round(destek2, 2);
            label22.Text = Convert.ToString(destek2);


            double direnc1 = Direnc1(btcavarage) / 10000000;
            direnc1 = Math.Round(direnc1, 2);
            label23.Text = Convert.ToString(direnc1);


            double direnc2 = Direnc2(btcavarage) / 10000000;
            direnc2 = Math.Round(direnc2, 2);
            label24.Text = Convert.ToString(direnc2);

         

            if (bnb24Change() < 0)
            {

                label25.Text = "SAT ve DÜŞÜŞÜ BEKLE Şu seviyeden alabilirsin YTD :) ---> :" + destek2;
            }

            else
            {
                label25.Text = "AL ve BEKLET Akıllı adamsın iyi kazanırsın sen :) YTD";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void timer3_Tick(object sender, EventArgs e)
        {

        }
    }
}
