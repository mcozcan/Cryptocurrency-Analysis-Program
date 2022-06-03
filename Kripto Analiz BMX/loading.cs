using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Kripto_Analiz_BMX
{
    public partial class loading : Form
    {

        int saat = 0;
        int dakika = 0;
        int saniye = 5;
        public loading()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
          
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            saniye = saniye - 1;


            if (saniye == 00)
            {
                this.Close();
            }
        }

        private void loading_Load(object sender, EventArgs e)
        {

          
          
            timer1.Enabled = true;
            timer1.Interval = 1000;





        }
    }
}
