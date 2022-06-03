using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
using System.Threading;

namespace Kripto_Analiz_BMX
{
    public partial class Bitcoin : Form
    {

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

            return (sondeger * 0.05345345345) + sondeger;
        }
        public static double Direnc2(double sondeger)
        {

            return (sondeger * 0.097567567567567) + sondeger;
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

                MessageBox.Show(xml.ToString());
            }

        }
        //BİTCOİN
        private static double btcLastPrice()
        {


            WebClient wb = new WebClient();
            string btc = wb.DownloadString("https://api.binance.com/api/v3/ticker/24hr?symbol=BTCUSDT");

            int pos1 = btc.IndexOf("lastPrice", 0);
            int pos2 = btc.IndexOf(":", pos1);
            int pos3 = btc.IndexOf(",", pos2);

            return Convert.ToDouble(btc.Substring(pos2 + 2, pos3 - pos2 - 4));
        }
        private static double btcMaxPrice()
        {


            WebClient wb = new WebClient();
            string btc = wb.DownloadString("https://api.binance.com/api/v3/ticker/24hr?symbol=BTCUSDT");

            int pos1 = btc.IndexOf("highPrice", 0);
            int pos2 = btc.IndexOf(":", pos1);
            int pos3 = btc.IndexOf(",", pos2);

            return Convert.ToDouble(btc.Substring(pos2 + 2, pos3 - pos2 - 4));
        }

        private static double btcMinPrice()
        {


            WebClient wb = new WebClient();
            string btc = wb.DownloadString("https://api.binance.com/api/v3/ticker/24hr?symbol=BTCUSDT");

            int pos1 = btc.IndexOf("lowPrice", 0);
            int pos2 = btc.IndexOf(":", pos1);
            int pos3 = btc.IndexOf(",", pos2);

            return Convert.ToDouble(btc.Substring(pos2 + 2, pos3 - pos2 - 4));
        }

        private static double btc24Change()
        {


            WebClient wb = new WebClient();
            string btc = wb.DownloadString("https://api.binance.com/api/v3/ticker/24hr?symbol=BTCUSDT");

            int pos1 = btc.IndexOf("priceChange", 0);
            int pos2 = btc.IndexOf(":", pos1);
            int pos3 = btc.IndexOf(",", pos2);

            return Convert.ToDouble(btc.Substring(pos2 + 2, pos3 - pos2 - 4));
        }


        private static double btc24Average()
        {


            WebClient wb = new WebClient();
            string btc = wb.DownloadString("https://api.binance.com/api/v3/ticker/24hr?symbol=BTCUSDT");

            int pos1 = btc.IndexOf("weightedAvgPrice", 0);
            int pos2 = btc.IndexOf(":", pos1);
            int pos3 = btc.IndexOf(",", pos2);

            return Convert.ToDouble(btc.Substring(pos2 + 2, pos3 - pos2 - 4));
        }



        // Bitcoin bitiş
        public Bitcoin()
        {
            InitializeComponent();
        }

        private void Bitcoin_Load(object sender, EventArgs e)
        {
            
            timer2.Interval = 5000;
            timer2.Start();
            timer3.Start();
            DovizGoster();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private async void timer2_Tick(object sender, EventArgs e)
        {
            loading ld = new loading();
            ld.Hide();

            label26.Text = DateTime.Now.ToShortTimeString();
            label27.Text = DateTime.Now.ToLongDateString();
           label4.Text = String.Format("{0:00,000}", (btcLastPrice() / 10000)); // son değer
        
            label5.Text = String.Format("{0:00,000}", (btcMaxPrice() / 10000)); // max değer
         
            label18.Text = String.Format("{0:00,000}", (btcMinPrice() / 10000)); // min değer 
  
            label19.Text = String.Format("{0:00,000}", (btc24Change() / 10000)); // 24 saat değişim
    
            label20.Text = String.Format("{0:00,000}", (btc24Average() / 10000)); // 24 saatlik ortalama

            double btcavarage = btc24Average();
      
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
     


            if (btc24Change() < 0)
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

        private void timer4_Tick(object sender, EventArgs e)
        {

        }
    }
    }

    

