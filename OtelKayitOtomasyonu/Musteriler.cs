using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace OtelKayitOtomasyonu
{
    public partial class Musteriler : Form
    {
        public Musteriler()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=.;Initial Catalog=KayitDatabases;Integrated Security=True");

        private void MusteriGoster()
        {
            listView1.Items.Clear();

            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT MusteriBilgileri.*, OdaBilgileri.* FROM dbo.MusteriBilgileri INNER JOIN OdaBilgileri ON MusteriBilgileri.MusteriID = OdaBilgileri.MusteriID", baglanti);
           
            SqlDataReader oku = komut.ExecuteReader();


            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["MusteriId"].ToString();
                ekle.SubItems.Add(oku["Adi"].ToString());
                ekle.SubItems.Add(oku["Soyadi"].ToString());
                ekle.SubItems.Add(oku["DogumTarihi"].ToString());
                ekle.SubItems.Add(oku["Cinsiyet"].ToString());
                ekle.SubItems.Add(oku["Telefon"].ToString());
                ekle.SubItems.Add(oku["Mail"].ToString());
                ekle.SubItems.Add(oku["TC"].ToString());
                ekle.SubItems.Add(oku["OdaNo"].ToString());
                ekle.SubItems.Add(oku["Ucret"].ToString());
                ekle.SubItems.Add(oku["GirisTarihi"].ToString());
                ekle.SubItems.Add(oku["CikisTarihi"].ToString());
                listView1.Items.Add(ekle);
            }
            baglanti.Close();


        }





        private void TireBtn_Click(object sender, EventArgs e)
        {
            this.Hide();

        }

        private void OtelKayitOto_Click(object sender, EventArgs e)
        {

        }

        private void btnMstriGstr_Click(object sender, EventArgs e)
        {
            MusteriGoster();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void OrtaBtn_Click(object sender, EventArgs e)
        {
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

        private void OdadakiMusterileriGoster(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            int odano = Convert.ToInt32(textBoxOdaNo.Text);
            if (odano<101 || odano > 109)
            {
                MessageBox.Show("Böyle Bir Oda Bulunmamaktadır!");
                return;
            }

            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT MusteriBilgileri.*, OdaBilgileri.* FROM dbo.MusteriBilgileri INNER JOIN OdaBilgileri ON MusteriBilgileri.MusteriID = OdaBilgileri.MusteriID WHERE OdaNo = @odano", baglanti);
            komut.Parameters.AddWithValue("@odano", textBoxOdaNo.Text);
            SqlDataReader oku = komut.ExecuteReader();


            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["MusteriId"].ToString();
                ekle.SubItems.Add(oku["Adi"].ToString());
                ekle.SubItems.Add(oku["Soyadi"].ToString());
                ekle.SubItems.Add(oku["DogumTarihi"].ToString());
                ekle.SubItems.Add(oku["Cinsiyet"].ToString());
                ekle.SubItems.Add(oku["Telefon"].ToString());
                ekle.SubItems.Add(oku["Mail"].ToString());
                ekle.SubItems.Add(oku["TC"].ToString());
                ekle.SubItems.Add(oku["OdaNo"].ToString());
                ekle.SubItems.Add(oku["Ucret"].ToString());
                ekle.SubItems.Add(oku["GirisTarihi"].ToString());
                ekle.SubItems.Add(oku["CikisTarihi"].ToString());
                listView1.Items.Add(ekle);
            }
            baglanti.Close();

        }
    }
}


