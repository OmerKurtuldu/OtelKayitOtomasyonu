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
using System.Configuration;


namespace OtelKayitOtomasyonu
{
    public partial class Form1 : Form
    {
        int odaNo;
        List<string> dolu_odalar_list;
        public Form1()
        {
            InitializeComponent();

            Musait_odalar_cagir();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=.;Initial Catalog=KayitDatabases;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            var durum = MessageBox.Show("Uygulamayı kapatmak istiyor musunuz ?", "Çıkış yapılıyor...", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (durum == DialogResult.OK)
            {
                Application.Exit();
            }

        }


        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();

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

        private void TelefonTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void TcNoTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void MailTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 32)
            {
                e.Handled = true;
            }
        }

        private void CikisDt_ValueChanged()
        {
            int Total;
            DateTime lessDate = Convert.ToDateTime(GirisDT.Text);
            DateTime largeDate = Convert.ToDateTime(CikisDt.Text);
            TimeSpan result = largeDate - lessDate;

            label15.Text = result.TotalDays.ToString();

            Total = Convert.ToInt32(label15.Text) * 150;
            UcretTxt.Text = Total.ToString();


        }

        private void BtnOdaDolu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Dolu odaları gösterir ");
        }

        private void BtnOdaBos_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Boş odaları gösterir ");
        }

        private void BtnOda101_Click(object sender, EventArgs e)
        {

            OdaNotxt.Text = "101";
        }

        private void BtnOda102_Click(object sender, EventArgs e)
        {
            OdaNotxt.Text = "102";
        }

        private void BtnOda103_Click(object sender, EventArgs e)
        {
            OdaNotxt.Text = "103";
        }

        private void BtnOda104_Click(object sender, EventArgs e)
        {
            OdaNotxt.Text = "104";
        }

        private void BtnOda105_Click(object sender, EventArgs e)
        {
            OdaNotxt.Text = "105";
        }

        private void BtnOda106_Click(object sender, EventArgs e)
        {
            OdaNotxt.Text = "106";
        }

        private void BtnOda107_Click(object sender, EventArgs e)
        {
            OdaNotxt.Text = "107";
        }

        private void BtnOda108_Click(object sender, EventArgs e)
        {
            OdaNotxt.Text = "108";
        }

        private void BtnOda109_Click(object sender, EventArgs e)
        {
            OdaNotxt.Text = "109";
        }
        private void Odayı_doldur(int odaNo)
        {
            switch (odaNo)
            {
                case 101:
                    BtnOda101.BackColor = Color.Red;
                    BtnOda101.Enabled = false;
                    break;

                case 102:
                    BtnOda102.BackColor = Color.Red;
                    BtnOda102.Enabled = false;
                    break;

                case 103:
                    BtnOda103.BackColor = Color.Red;
                    BtnOda103.Enabled = false;
                    break;

                case 104:
                    BtnOda104.BackColor = Color.Red;
                    BtnOda104.Enabled = false;
                    break;

                case 105:
                    BtnOda105.BackColor = Color.Red;
                    BtnOda105.Enabled = false;
                    break;

                case 106:
                    BtnOda106.BackColor = Color.Red;
                    BtnOda106.Enabled = false;
                    break;

                case 107:
                    BtnOda107.BackColor = Color.Red;
                    BtnOda107.Enabled = false;
                    break;

                case 108:
                    BtnOda108.BackColor = Color.Red;
                    BtnOda108.Enabled = false;
                    break;

                case 109:
                    BtnOda109.BackColor = Color.Red;
                    BtnOda109.Enabled = false;
                    break;
            }


        }
        private void Musteri_kayıt()
        {
            baglanti.Open();

            SqlCommand komut = new SqlCommand();
            //SqlCommand komut = new SqlCommand("insert into MusteriBilgileri (Adi,Soyadi,DogumTarihi,Cinsiyet,Telefon,Mail,TC) values('" + AdTxt.Text.ToString() + "','" + SoyadTxt.Text + "','" + dgmtrhDT.Value.ToString("yyyy-MM-dd") + "','" + comboBox1.Text + "','"  + TelefonTxt.Text  + "','" + MailTxt.Text + "','" + TcNoTxt.Text + "')", baglanti);
            SqlDataAdapter adapter = new SqlDataAdapter();

            string sorgu = "INSERT INTO MusteriBilgileri (Adi,Soyadi,DogumTarihi,Cinsiyet,Telefon,Mail,TC) VALUES(@tAdi,@tSoyadi,@tDogumTarihi,@tCinsiyet,@tTelefon,@tMail,@tTC)";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@tAdi", AdTxt.Text.ToString());
            komut.Parameters.AddWithValue("@tSoyadi", SoyadTxt.Text);
            komut.Parameters.AddWithValue("@tDogumTarihi", dgmtrhDT.Value.ToString("yyyy - MM - dd"));
            komut.Parameters.AddWithValue("@tCinsiyet", comboBox1.Text);
            komut.Parameters.AddWithValue("@tTelefon", TelefonTxt.Text);
            komut.Parameters.AddWithValue("@tMail", MailTxt.Text);
            komut.Parameters.AddWithValue("@tTC", TcNoTxt.Text);

            komut.ExecuteNonQuery();

            SqlCommand komut3 = new SqlCommand("select * from MusteriBilgileri ", baglanti);
            SqlDataReader oku = komut3.ExecuteReader();
            int id = 0;
            while (oku.Read())
            {
                id = Convert.ToInt32(oku["MusteriID"].ToString());

            }

            oku.Close();



            SqlCommand komut2 = new SqlCommand();
            komut2 = new SqlCommand(sorgu, baglanti);
            string sorgu2 = "insert into OdaBilgileri (OdaNo,Ucret,GirisTarihi,CikisTarihi,MusteriID) VALUES(@tOdaNo,@tUcret,@tGirisTarihi,@tCikisTarihi,@tMusteriID)";
            komut2 = new SqlCommand(sorgu2, baglanti);
            komut2.Parameters.AddWithValue("@tOdaNo", OdaNotxt.Text);
            komut2.Parameters.AddWithValue("@tUcret", UcretTxt.Text);
            komut2.Parameters.AddWithValue("@tGirisTarihi", GirisDT.Value.ToString("yyyy-MM-dd"));
            komut2.Parameters.AddWithValue("@tCikisTarihi", CikisDt.Value.ToString("yyyy-MM-dd"));

            komut2.Parameters.AddWithValue("@tMusteriID", id);

            komut2.ExecuteNonQuery();

            baglanti.Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {

            long TCKN = 0;
            try
            {
                TCKN = long.Parse(TcNoTxt.Text);


            }
            catch (Exception)
            {

                MessageBox.Show("T.C. Kimlik No Kısmı Boş Olamaz!");
                return;
            }
            string Name, Surname;
            Name = AdTxt.Text;
            Surname = SoyadTxt.Text;
            int yearOfBirth = dgmtrhDT.Value.Year;
            if (Name == "" || Surname == "")
            {
                MessageBox.Show("Ad Soyad Kısımları Boş Olamaz!");
                return;
            }
            if (2023 - yearOfBirth < 18)
            {
                MessageBox.Show("Müşteri 18 Yaşından Büyük Olmadlıdır!");
                return;
            }
            KimlikBilgileri.KPSPublicSoapClient KimlikKontrol = new KimlikBilgileri.KPSPublicSoapClient();
            KimlikKontrol.TCKimlikNoDogrula(TCKN, Name, Surname, yearOfBirth);

            bool state = KimlikKontrol.TCKimlikNoDogrula(TCKN, Name, Surname, yearOfBirth);

            if (state == true)
            {
                MessageBox.Show("Kayıt Başarılı...", "Geçerli Durum", MessageBoxButtons.OK, MessageBoxIcon.Information);
                odaNo = Convert.ToInt32(OdaNotxt.Text);
                Odayı_doldur(odaNo);
                Musteri_kayıt();

            }
            else
            {
                MessageBox.Show("Girilen Kimlik Bilgiler Hatalı....  Lütfen Tekrar Girin", "Geçersiz Durum", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }






        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (kblEtChck.Checked)
            {
                BtnKaydet.Enabled = true;
            }
        }

        private void label16_Click(object sender, EventArgs e)
        {
            sözleşme sözleşme = new sözleşme();
            sözleşme.Show();
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            this.Hide();
            AnaFrm anaFrm = new AnaFrm();
            anaFrm.Show();
        }

        private void Musait_odalar(object sender, EventArgs e)
        {
            Musait_odalar_cagir();
            CikisDt_ValueChanged();

        }

        private void Dolu_odalar_goster()
        {

            for (int i = 101; i < 110; i++)
            {
                if (dolu_odalar_list.Contains(i.ToString()))
                {
                    Odayı_doldur(i);
                }
                else
                {
                    Odayı_bosalt(i);
                }
            }
            dolu_odalar_list.Clear();

        }

        private void Odayı_bosalt(int odaNo)
        {
            switch (odaNo)
            {
                case 101:
                    BtnOda101.BackColor = SystemColors.Info;
                    BtnOda101.Enabled = true;
                    break;

                case 102:
                    BtnOda102.BackColor = SystemColors.Info;
                    BtnOda102.Enabled = true;
                    break;

                case 103:
                    BtnOda103.BackColor = SystemColors.Info;
                    BtnOda103.Enabled = true;
                    break;

                case 104:
                    BtnOda104.BackColor = SystemColors.Info;
                    BtnOda104.Enabled = true;
                    break;

                case 105:
                    BtnOda105.BackColor = SystemColors.Info;
                    BtnOda105.Enabled = true;
                    break;

                case 106:
                    BtnOda106.BackColor = SystemColors.Info;
                    BtnOda106.Enabled = true;
                    break;

                case 107:
                    BtnOda107.BackColor = SystemColors.Info;
                    BtnOda107.Enabled = true;
                    break;

                case 108:
                    BtnOda108.BackColor = SystemColors.Info;
                    BtnOda108.Enabled = true;
                    break;

                case 109:
                    BtnOda109.BackColor = SystemColors.Info;
                    BtnOda109.Enabled = true;
                    break;
            }
        }

        private void Musait_odalar_cagir()
        {

            baglanti.Open();
            string sorgu = "SELECT OdaNo FROM OdaBilgileri WHERE(GirisTarihi BETWEEN @girist AND @cikist) OR(CikisTarihi BETWEEN @girist AND @cikist) GROUP BY OdaNo";

            dolu_odalar_list = new List<string>();
            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@girist", GirisDT.Value.ToString("yyyy-MM-dd"));
            komut.Parameters.AddWithValue("@cikist", CikisDt.Value.ToString("yyyy-MM-dd"));
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                dolu_odalar_list.Add(oku["OdaNo"].ToString());

            }
            Dolu_odalar_goster();
            oku.Close();
            baglanti.Close();
        }
    }
}

