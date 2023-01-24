using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtelKayitOtomasyonu
{
    public partial class AnaFrm : Form
    {
        public AnaFrm()
        {
            InitializeComponent();
        }

        private void XBtn_Click(object sender, EventArgs e)
        {
            var durum = MessageBox.Show("Uygulamayı kapatmak istiyor musunuz ?", "Çıkış yapılıyor...", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (durum == DialogResult.OK)
            {
                Application.Exit();
            }

        }

        private void OrtaBtn_Click(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;
            if (WindowState == FormWindowState.Maximized)
            {
                this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
                this.WindowState = FormWindowState.Maximized;
            }

        }

        private void TireBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }



        private void AdminGiris_Click(object sender, EventArgs e)
        {
            AdminGiris admnFr = new AdminGiris();
            admnFr.Show();
            this.Hide();
        }

        private void YeniMüsteri_Click(object sender, EventArgs e)
        {
            Form1 fr = new Form1();
            fr.Show();

        }

        private void OdalarBtn_Click(object sender, EventArgs e)
        {
            Odalar oda = new Odalar();
            oda.Show();
        }

        private void OtelKayitOto_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Musteriler fr = new Musteriler();
            fr.Show();
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminGiris adminGiris = new AdminGiris();
            adminGiris.Show();
        }
    }
}
