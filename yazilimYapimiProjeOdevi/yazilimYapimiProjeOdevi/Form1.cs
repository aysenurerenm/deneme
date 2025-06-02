using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace yazilimYapimiProjeOdevi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public static int userID;
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-KJEJA5L;Initial Catalog=yazilimYapimiProjeOdevi;Integrated Security=True;Encrypt=False");
        private void btnGiris_Click(object sender, EventArgs e)
        {
           
            string email = textBox1.Text;
            conn.Open();

            SqlCommand cmd = new SqlCommand("select userID from users where email=@email", conn);
            cmd.Parameters.AddWithValue("@email", email);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    
                    userID = reader.GetInt32(0); 

                }
            }
            else
            {
                MessageBox.Show("E-posta adresine sahip kullanıcı bulunamadı.");
            }
            conn.Close();
            Form4 frm = new Form4();
            frm.Show();




        }

        private void linkKayıt_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            settingsPage sp = new settingsPage();
            sp.Show();
        }
    }
}
