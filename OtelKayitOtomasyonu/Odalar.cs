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
    public partial class Odalar : Form
    {
        public Odalar()
        {
            InitializeComponent();
        }

        private void TireBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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

        private void XBtn_Click(object sender, EventArgs e)
        {
            var durum = MessageBox.Show("Uygulamayı kapatmak istiyor musunuz ?", "Çıkış yapılıyor...", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (durum == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            this.Hide();
            AnaFrm anaFrm = new AnaFrm();
            anaFrm.Show();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
