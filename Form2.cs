using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace yazilimyapimiprojem
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        string connectionString = "Data Source=BUSEC;Initial Catalog=yazilimYapimiProjeOdeviDeneme;Integrated Security=True;";
        private List<string> englishWords = new List<string>();

        // KELİMELERİ GETİRME BUTONU (Aynı kalabilir)
        private void btnGetWords_Click(object sender, EventArgs e)
        {
            listBoxWords.Items.Clear();
            englishWords.Clear();

            List<(string english, string turkish)> words = GetWordsFromDatabase(connectionString);

            foreach (var word in words)
            {
                listBoxWords.Items.Add($"{word.english} - {word.turkish}");
                englishWords.Add(word.english); // Sadece İngilizce kelimeleri sakla
            }
        }

        // VERİTABANINDAN KELİME ÇEKME METODU
        private List<(string english, string turkish)> GetWordsFromDatabase(string connectionString)
        {
            var wordList = new List<(string english, string turkish)>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT TOP 5 englishWord, turkishWord FROM Words";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            string english = reader.GetString(0);
                            string turkish = reader.GetString(1);
                            wordList.Add((english, turkish));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Veritabanı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return wordList;
        }

        // HİKAYE OLUŞTURMA BUTONU (Senin istediğin şekilde)
        private async void btnHikayeOlustur_Click(object sender, EventArgs e)
        {
            if (englishWords.Count == 0)
            {
                MessageBox.Show("Lütfen önce kelimeleri veritabanından çekin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OpenAIService aiService = new OpenAIService();
            try
            {
                string story = await aiService.GetStoryFromWordsAsync(englishWords);
                txtHikaye.Text = story;
            }
            catch (Exception ex)
            {
                MessageBox.Show("API Hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
