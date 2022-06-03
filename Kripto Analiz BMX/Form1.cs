using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Diagnostics;

namespace Kripto_Analiz_BMX
{
    public partial class Form1 : Form
    {
        
        SoundPlayer player = new SoundPlayer();
        public Form1()
        {
            InitializeComponent();
        }
        loading ld = new loading();
        private void button1_Click(object sender, EventArgs e)
        {

            Ethereum eth = new Ethereum();
            eth.Show();
            ld.Show();
            this.Hide();


        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            BNB bnb = new BNB();
            bnb.Show();
            ld.Show();
            this.Hide();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            ADA ada = new ADA();
            ada.Show();
            ld.Show();
            this.Hide();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            Solana sol = new Solana();
            sol.Show();
            ld.Show();
            this.Hide();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Xrp xrp = new Xrp();
            xrp.Show();
            ld.Show();
            this.Hide();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            LUNA luna = new LUNA();
            luna.Show();
            ld.Show();
            this.Hide();
        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            AVAX avax = new AVAX();
            avax.Show();
            ld.Show();
            this.Hide();
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            DOGE doge = new DOGE();
            doge.Show();
            ld.Show();
            this.Hide();
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            DOT dot = new DOT();
            dot.Show();
            ld.Show();
            this.Hide();
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            SHIB shib = new SHIB();
            shib.Show();
            ld.Show();
            this.Hide();
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            MATIC matic = new MATIC();
            matic.Show();
            ld.Show();
            this.Hide();
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            Litecoin ltc = new Litecoin();
            ltc.Show();
            ld.Show();
            this.Hide();
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            ATOM atom = new ATOM();
            atom.Show();
            ld.Show();
            this.Hide();
        }

        private void button22_Click_1(object sender, EventArgs e)
        {
            LINK link = new LINK();
            link.Show();
            ld.Show();
            this.Hide();
        }

        private void button21_Click_1(object sender, EventArgs e)
        {
            Uniswap uni = new Uniswap();
            uni.Show();
            ld.Show();
            this.Hide();
        }

        private void button20_Click_1(object sender, EventArgs e)
        {
            BitcoinCash bch = new BitcoinCash();
            bch.Show();
            ld.Show();
            this.Hide();
        }

        private void button18_Click_1(object sender, EventArgs e)
        {
            Mana mana = new Mana();
            mana.Show();
            ld.Show();
            this.Hide();    
        }

        private void button17_Click_1(object sender, EventArgs e)
        {
            Sandbox sand = new Sandbox();
            sand.Show();
            ld.Show();
            this.Hide();
        }

        private void button19_Click_1(object sender, EventArgs e)
        {
            NEO neo = new NEO();
            neo.Show();
            ld.Show();
            this.Hide();         
        }

        private void button16_Click_1(object sender, EventArgs e)
        {
            ICP icp = new ICP();
            icp.Show();
            ld.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            timer1.Start();
            label26.Text = DateTime.Now.ToShortTimeString();
            label27.Text = DateTime.Now.ToLongDateString();
            int i = Class1.kontrol;

            if (i == 0)
            {
                var psi = new ProcessStartInfo
                {
                    FileName = "https://linktr.ee/mcozcan",
                    UseShellExecute = true,
                };
                Process.Start(psi);
                Class1.kontrol++;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Bitcoin btc = new Bitcoin();
           
            btc.Show();
            ld.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            player.Stop();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            player.Play();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button25_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start("www.websitemizblablabla.com");
            
         
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void button26_Click(object sender, EventArgs e)
        {
            var psi = new ProcessStartInfo
            {
                FileName = "https://linktr.ee/mcozcan",
                UseShellExecute = true,
            };
            Process.Start(psi);
        }

        private void button25_Click_1(object sender, EventArgs e)
        {
            var psi = new ProcessStartInfo
            {
                FileName = "https://linktr.ee/mcozcan",
                UseShellExecute = true,
            };
            Process.Start(psi);
        }

        private void button26_Click_1(object sender, EventArgs e)
        {
            var psi = new ProcessStartInfo
            {
                FileName = "https://linktr.ee/mcozcan",
                UseShellExecute = true,
            };
            Process.Start(psi);
        }

        private void button27_Click(object sender, EventArgs e)
        {
            var psi = new ProcessStartInfo
            {
                FileName = "https://www.linkedin.com/in/mcozcan/",
                UseShellExecute = true,
            };
            Process.Start(psi);
        
        }

        private void button28_Click(object sender, EventArgs e)
        {
            var psi = new ProcessStartInfo
            {
                FileName = "https://open.spotify.com/artist/2OPc2EYBb7rbX60AL3rHHR?si=ItIKFlfTRh-8J4coHzE-Pw",
                UseShellExecute = true,
            };
            Process.Start(psi);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
           
        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
      
            var psi = new ProcessStartInfo
            {
                FileName = "https://linktr.ee/mcozcan",
                UseShellExecute = true,
            };
            Process.Start(psi);
        }
    }
}
