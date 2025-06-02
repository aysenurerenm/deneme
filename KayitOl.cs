using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace YazilimYapimiProjeOdevi
{
    public partial class KayitOl : Form
    {
        SqlConnection conn=new SqlConnection("Data Source=DESKTOP-06DR47K\\SQLEXPRESS;Initial Catalog=yazilimYapimiProje;Integrated Security=True;");

       

        public KayitOl()
        {
            InitializeComponent();
        }

        private void btnKayıt_Click(object sender, EventArgs e)
        {
            string ad=textBoxAd.Text;
            string soyad=textBoxSoyad.Text;
            string email=textBoxEmail.Text;
            string şifre=textBoxSifre.Text;

            string hashedŞifre =SecurityHelper.ComputeSha256Hash(şifre);

            if (ad == "" || soyad == "" || email == "" || şifre == "") {
                MessageBox.Show("Lütfen tüm alanları doldurunuz");
                return;
            }

            if (şifre.Length < 6) {
                MessageBox.Show("Şifre en az 6 karakter uzunluğunda olmalıdır.");
                return;
            }
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO users(name,surname,email,password) values(@ad,@soyad,@email,@şifre)", conn);
            cmd.Parameters.AddWithValue("@ad", ad);
            cmd.Parameters.AddWithValue("@soyad", soyad);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@şifre", hashedŞifre);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Kayıt başarıyla tamamlandı!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
            conn.Close();
        }
    }
}
