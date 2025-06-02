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
using System.Drawing.Text;
using System.Diagnostics;

namespace yazilimYapimiProjeOdevi
{
    
    public partial class Form3 : Form
    {
        int currentWordID;
        public Form3()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-KJEJA5L;Initial Catalog=yazilimYapimiProjeOdevi;Integrated Security=True;Encrypt=False");
        string trueAnswer = "";
        private void Form3_Load(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select wordsID from words where wordsID in (select wordsID from wordsStation where  CONVERT(DATE, answerdTime) = CONVERT(DATE, GETDATE())) order by newID()",conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            List<int> wordsId = new List<int>();
            while (rdr.Read())
            {
                wordsId.Add(rdr.GetInt32(0));
            }
            rdr.Close();
            SqlCommand askWordCountCmd = new SqlCommand("Select count(*) from wordsStation where wordsID=@id");

            foreach (int id in wordsId)
            {
                currentWordID = id;
                SqlCommand wordCmd = new SqlCommand("Select englishWord,turkishWord from words where wordsID=@id", conn);
                wordCmd.Parameters.AddWithValue("@id", id);
                SqlDataReader rdr2 = wordCmd.ExecuteReader();
                if (rdr2.Read())
                {
                    trueAnswer = rdr2["englishWord"].ToString();
                    string questions = rdr2["turkishWord"].ToString();
                    textBox1.Text = questions;
                    rdr2.Close();
                    break;
                }


            }
            
            List<string> wrongWords = new List<string>();
            SqlCommand wrongCmd = new SqlCommand("Select Top 3 englishWord from words where englishWord != @trueAnswer order by newID() ",conn);
            wrongCmd.Parameters.AddWithValue("@trueAnswer", trueAnswer);
            SqlDataReader wrongRdr = wrongCmd.ExecuteReader();
            while (wrongRdr.Read())
            {
                wrongWords.Add(wrongRdr.GetString(0));  // Yanlış cevapları listeye ekle
            }
            wrongRdr.Close();
            List<string> answers = new List<string>();
            answers.Clear();
            answers.Add(trueAnswer);
            answers.AddRange(wrongWords);

            Random rng = new Random();
            answers = answers.OrderBy(a => rng.Next()).ToList(); // Shuffle
            

            // 4. Butonlara yerleştir
            button1.Text = answers[0];
            button2.Text = answers[1];
            button3.Text = answers[2];
            button4.Text = answers[3];




        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (trueAnswer == button1.Text)
            {
                button1.BackColor = Color.Green;
                SqlCommand updateCmd = new SqlCommand("UPDATE wordsStation SET correctCount = correctCount + 1 WHERE wordsID = @id", conn);
                updateCmd.Parameters.AddWithValue("@id", currentWordID);
                updateCmd.ExecuteNonQuery();
            }
            else
                button1.BackColor = Color.Red;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (trueAnswer == button2.Text)
            {
                button2.BackColor = Color.Green;
                SqlCommand updateCmd = new SqlCommand("UPDATE wordsStation SET correctCount = correctCount + 1 WHERE wordsID = @id", conn);
                updateCmd.Parameters.AddWithValue("@id", currentWordID);
                updateCmd.ExecuteNonQuery();
            }
            else
                button2.BackColor = Color.Red;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (trueAnswer == button3.Text)
            {
                button3.BackColor = Color.Green;
                SqlCommand updateCmd = new SqlCommand("UPDATE wordsStation SET correctCount = correctCount + 1 WHERE wordsID = @id", conn);
                updateCmd.Parameters.AddWithValue("@id", currentWordID);
                updateCmd.ExecuteNonQuery();
            }
            else
                button3.BackColor = Color.Red;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (trueAnswer == button4.Text)
            {
                button4.BackColor = Color.Green;
                SqlCommand updateCmd = new SqlCommand("UPDATE wordsStation SET correctCount = correctCount + 1 WHERE wordsID = @id", conn);
                updateCmd.Parameters.AddWithValue("@id", currentWordID);
                updateCmd.ExecuteNonQuery();
            }
            else
                button4.BackColor = Color.Red;
        }
    }
}
