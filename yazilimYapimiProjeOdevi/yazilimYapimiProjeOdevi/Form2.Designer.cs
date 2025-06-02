namespace yazilimYapimiProjeOdevi
{
    partial class settingsPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.wordCount = new System.Windows.Forms.Label();
            this.wordCountTxtBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // wordCount
            // 
            this.wordCount.AutoSize = true;
            this.wordCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.wordCount.Location = new System.Drawing.Point(114, 114);
            this.wordCount.Name = "wordCount";
            this.wordCount.Size = new System.Drawing.Size(130, 25);
            this.wordCount.TabIndex = 0;
            this.wordCount.Text = "Kelime Sayısı";
            // 
            // wordCountTxtBox
            // 
            this.wordCountTxtBox.Location = new System.Drawing.Point(278, 118);
            this.wordCountTxtBox.Name = "wordCountTxtBox";
            this.wordCountTxtBox.Size = new System.Drawing.Size(100, 22);
            this.wordCountTxtBox.TabIndex = 1;
            this.wordCountTxtBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.Location = new System.Drawing.Point(184, 178);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 46);
            this.button1.TabIndex = 2;
            this.button1.Text = "Çıkış Yap";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(430, 100);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // settingsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 296);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.wordCountTxtBox);
            this.Controls.Add(this.wordCount);
            this.Name = "settingsPage";
            this.Text = "ayarlarSayfası";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label wordCount;
        private System.Windows.Forms.TextBox wordCountTxtBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}