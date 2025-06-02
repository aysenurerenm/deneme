using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yazilimYapimiProjeOdevi
{
    public partial class Form4 : Form
    {
        List<int> choiceWordIdList = new List<int>();
        public Form4()
        {
            InitializeComponent();
        }


        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-KJEJA5L;Initial Catalog=yazilimYapimiProjeOdevi;Integrated Security=True;Encrypt=False");
        private void Form4_Load(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand wordCohiceDateCmd = new SqlCommand("Select wordsID from words where wordsID in (Select wordsID from wordsStation where Convert(Date,answerdTime)=Convert(Date,GetDate()) and isLearned=@false) order by newID()",connection);
            wordCohiceDateCmd.Parameters.AddWithValue("@false", 0);
            SqlDataReader wordChoiceDateRdr = wordCohiceDateCmd.ExecuteReader();
            while (wordChoiceDateRdr.Read())
            {
                choiceWordIdList.Add(wordChoiceDateRdr.GetInt32(0));
            }
            wordChoiceDateRdr.Close();

            string idListString = choiceWordIdList.Count > 0 ? string.Join(",", choiceWordIdList) : "0";
            int settedWordCount = 2;

            //SqlCommand wordChoiceCmd = new SqlCommand("Select top @settedWordCount wordID from words where wordsID not in ({{idListString}}) order by newID()", connection);
            //wordChoiceCmd.Parameters.AddWithValue("@settedWordCount", p2);//değiştireceğimm

            string query = $@"SELECT TOP {settedWordCount} w.wordsID FROM words w WHERE NOT EXISTS (SELECT 1 FROM wordsStation ws WHERE ws.wordsID = w.wordsID AND ws.userID = @userID) AND w.userID = @userID ORDER BY NEWID()";


            SqlCommand wordChoiceCmd = new SqlCommand(query, connection);
            wordChoiceCmd.Parameters.AddWithValue("@userID", Form1.userID);
            SqlDataReader wordChoiceRdr = wordChoiceCmd.ExecuteReader();
            while (wordChoiceRdr.Read())
            {
                choiceWordIdList.Add(wordChoiceRdr.GetInt32(0));
            }
            wordChoiceRdr.Close();
            
            LoadNextQuestion();

        }


        int currentIndex=0;
        int currentWordID;
        string trueAnswer = "";
        string question = "";
        Boolean islearned;
        public static int sendCorrectCount;
        public static int senWrongCount;
        private void LoadNextQuestion()
        {
            if (currentIndex >= choiceWordIdList.Count)
            {
                sendCorrectCount = dailyCorrectCount;
                senWrongCount = dailyWrongCount;
                MessageBox.Show("Tüm Sorular Tamamlandı. Yarın Tekrar Gel ve Kendini Test Et!"+ sendCorrectCount);
                this.Close();
                return;
            }

            currentWordID = choiceWordIdList[currentIndex];
            if (connection.State == ConnectionState.Closed)
                connection.Open();

            SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM wordsStation WHERE wordsID = @wordsID AND userID = @userID", connection);
            checkCmd.Parameters.AddWithValue("@wordsID", currentWordID);
            checkCmd.Parameters.AddWithValue("@userID", Form1.userID);

            int count = (int)checkCmd.ExecuteScalar();

            if (count == 0) // kayıt yoksa
            {
                SqlCommand insertCmd = new SqlCommand("INSERT INTO wordsStation (wordsID, answerdTime, userID) VALUES (@wordsID, @answerdTime, @userID)", connection);
                insertCmd.Parameters.AddWithValue("@wordsID", currentWordID);
                insertCmd.Parameters.AddWithValue("@answerdTime", DateTime.Now.AddDays(1));
                insertCmd.Parameters.AddWithValue("@userID", Form1.userID);

                insertCmd.ExecuteNonQuery(); // veritabanına ekle
            }

            SqlCommand isLearnedCmd =new  SqlCommand("Select isLearned from wordsStation where wordsID=@id and userID=@userID",connection);
            isLearnedCmd.Parameters.AddWithValue("@id", currentWordID);
            isLearnedCmd.Parameters.AddWithValue("@userID", Form1.userID);
            SqlDataReader isLearnedRdr = isLearnedCmd.ExecuteReader();
            if (isLearnedRdr.Read())
            {
                if (isLearnedRdr.IsDBNull(0))
                {
                    islearned = false;
                }
                else
                    islearned = isLearnedRdr.GetBoolean(0);

            }
            isLearnedRdr.Close();
            if (islearned == true)
            {

                currentIndex++;
                LoadNextQuestion();
                return;

            }
            else
            {
                currentIndex++;
            }
            SqlCommand questionAnswerCmd = new SqlCommand("Select turkishWord,englishWord from words where wordsID=@currentWordID",connection);
            questionAnswerCmd.Parameters.AddWithValue("@currentWordID", currentWordID);
            SqlDataReader questionAnswerRdr =questionAnswerCmd. ExecuteReader();
            if (questionAnswerRdr.Read())
            {
                trueAnswer = questionAnswerRdr["englishWord"].ToString();
                question = questionAnswerRdr["turkishWord"].ToString();
            }
            questionAnswerRdr.Close();

            List<string> wrongAnswerList = new List<string> ();
            SqlCommand wrongAnswerCmd = new SqlCommand("Select Top 3 englishWord from words where wordsId!=@currentWordID", connection);
            wrongAnswerCmd.Parameters.AddWithValue("@currentWordID", currentWordID);
            SqlDataReader wrongAnswerRdr = wrongAnswerCmd.ExecuteReader();
            while (wrongAnswerRdr.Read())
            {
                wrongAnswerList.Add(wrongAnswerRdr.GetString(0));
            }
            wrongAnswerRdr.Close();

            List<string> wordBtn = new List<string> { trueAnswer};
            wordBtn.AddRange(wrongAnswerList);
            Random rng = new Random();
            wordBtn = wordBtn.OrderBy(a => rng.Next()).ToList();

            textBox1.Text = question;

            button1.Text = wordBtn[0];
            button2.Text = wordBtn[1];
            button3.Text = wordBtn[2];
            button4.Text = wordBtn[3];

            // Renkleri sıfırla
            button1.BackColor = SystemColors.Control;
            button2.BackColor = SystemColors.Control;
            button3.BackColor = SystemColors.Control;
            button4.BackColor = SystemColors.Control;





        }
        int wordCorrectCount;
        int dailyCorrectCount=0;
        int dailyWrongCount = 0;
        private void HandleAnswer(Button selectedButton)
        {
            
            if (trueAnswer == selectedButton.Text)
            {

                selectedButton.BackColor = Color.Green;
                dailyCorrectCount++;
             /////////
                SqlCommand updateCorrectCountCmd = new SqlCommand("UPDATE wordsStation SET correctCount = correctCount + 1 WHERE wordsID = @id", connection);
                updateCorrectCountCmd.Parameters.AddWithValue("@id", currentWordID);
                updateCorrectCountCmd.ExecuteNonQuery();
                SqlCommand wordDateSetCmd = new SqlCommand("Select correctCount from wordsStation where wordsID=@id",connection);
                wordDateSetCmd.Parameters.AddWithValue("@id", currentWordID);
                SqlDataReader wordDateSetRdr =wordDateSetCmd.ExecuteReader();
                if (wordDateSetRdr.Read())
                {
                    if (wordDateSetRdr.IsDBNull(0))
                        wordCorrectCount = 0;
                    else
                        wordCorrectCount = wordDateSetRdr.GetByte(0);

                }
               
                wordDateSetRdr.Close();
                switch (wordCorrectCount)
                {
                    case 1:
                        UpdateQuestionDate(1);
                        break;
                    case 2:
                        UpdateQuestionDate(7);
                        break;
                    case 3:
                        UpdateQuestionDate(30);
                        break;
                    case 4:
                        UpdateQuestionDate(90);
                        break;
                    case 5:
                        UpdateQuestionDate(180);
                        break;
                    case 6:
                        UpdateQuestionDate(360);
                        break;
                    case 7:
                        SqlCommand updateisLearnedCmd = new SqlCommand("Update wordsStation Set isLearned=@true where wordsId=@id and userID=@userID",connection);
                        updateisLearnedCmd.Parameters.AddWithValue("@id", currentWordID);
                        updateisLearnedCmd.Parameters.AddWithValue("@userID", Form1.userID);
                        updateisLearnedCmd.Parameters.AddWithValue("@true", true);
                        updateisLearnedCmd.ExecuteNonQuery();
                        break;



                }
            }
            else
            {
                dailyWrongCount++;
                selectedButton.BackColor = Color.Red;
                SqlCommand ifWrongAnswerCmd = new SqlCommand("delete wordsStation where userId=@userID and wordsID=@wordsID",connection);
                ifWrongAnswerCmd.Parameters.AddWithValue("@userID",Form1.userID);
                ifWrongAnswerCmd.Parameters.AddWithValue("@wordsID",currentWordID);
                ifWrongAnswerCmd.ExecuteNonQuery();


            }

            Task.Delay(1000).ContinueWith(_ => this.Invoke(new Action(() =>
            {
                selectedButton.BackColor = SystemColors.Control; // eski rengine döndür
                LoadNextQuestion();
            })));
        }
        private void button1_Click(object sender, EventArgs e) => HandleAnswer(button1);
        private void button2_Click(object sender, EventArgs e) => HandleAnswer(button2);
        private void button3_Click(object sender, EventArgs e) => HandleAnswer(button3);
        private void button4_Click(object sender, EventArgs e) => HandleAnswer(button4);


        public void UpdateQuestionDate(int day)
        {
            SqlCommand updateQuestionTimeCmd = new SqlCommand("Update wordsStation set answerdTime=@time where userID=@userID and wordsID=@currentWordsID",connection);
            updateQuestionTimeCmd.Parameters.AddWithValue("@userID", Form1.userID);
            updateQuestionTimeCmd.Parameters.AddWithValue("@currentWordsID", currentWordID);
            updateQuestionTimeCmd.Parameters.AddWithValue("@time", DateTime.Now.AddDays(day));
            updateQuestionTimeCmd.ExecuteNonQuery();
        {

        }

    }
        
       


    }
    
}
