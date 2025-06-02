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
using YazilimYapimiProjeOdevi;

namespace yazilimYapimiProjeOdevi
{
    public partial class Ayarlar : Form
    {
        public Ayarlar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-KJEJA5L;Initial Catalog=yazilimYapimiProjeOdevi;Integrated Security=True;Encrypt=False");

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            


        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int newWordCount = Convert.ToInt32(wordCountTxtBox.Text);
                if (newWordCount <= 0 || newWordCount > 100000)
                {
                    throw new Exception("Kelime Sayısı Pozitif ve 100000'den küçük olmalıdır");


                }
                conn.Open();
                SqlCommand cmd = new SqlCommand("update settings set setWordCount=@newWordCount where userID=@userID", conn);
                cmd.Parameters.AddWithValue("@newWordCount", newWordCount);
                cmd.Parameters.AddWithValue("@userID", Form1.userID);
                cmd.ExecuteNonQuery();
                conn.Close();

            }
            catch (FormatException)
            {
                MessageBox.Show("Lütfen sadece sayı girin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            catch (Exception ex)
            {
                
            }

        }
    }
}
