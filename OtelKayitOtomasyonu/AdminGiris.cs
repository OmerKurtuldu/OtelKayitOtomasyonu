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
    public partial class AdminGiris : Form
    {
        public AdminGiris()
        {
            InitializeComponent();
        }
        
        private void KullaniciTxt_TextChanged(object sender, EventArgs e)
        {
 
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (KullaniciTxt.Text.ToString() == "admin" && SifreTxt.Text.ToString() == "1234")
            {
                AnaFrm skip = new AnaFrm();
                this.Hide();
                skip.Show();
            }
            else
            {
                MessageBox.Show("Hatalı bilgi girdiniz lütfen tekrar deneyin!!", "HATALI BİLGİ", MessageBoxButtons.OKCancel);
                KullaniciTxt.Clear();
                SifreTxt.Clear();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //checkBox işaretli ise
            if (sfreGstr.Checked)
            {
                //karakteri göster.
                SifreTxt.PasswordChar = '\0';
                

            }
            //değilse karakterlerin yerine * koy.
            else
            {
                SifreTxt.PasswordChar = '*';
                

            }
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                btnLogin.Enabled = true;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            sözleşme sözleşme = new sözleşme();
            sözleşme.Show();
        }

        private void SifreTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            var durum = MessageBox.Show("Uygulamayı kapatmak istiyor musunuz ?", "Çıkış yapılıyor...", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (durum == DialogResult.OK)
            {
                Application.Exit();
            }

        }
    }
}
