namespace yazilimYapimiProjeOdevi
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGiris = new System.Windows.Forms.Button();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblSifre = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.linksifreunuttum = new System.Windows.Forms.LinkLabel();
            this.linkKayıt = new System.Windows.Forms.LinkLabel();
            this.lblhesapyok = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnGiris
            // 
            this.btnGiris.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnGiris.ForeColor = System.Drawing.Color.DarkRed;
            this.btnGiris.Location = new System.Drawing.Point(259, 220);
            this.btnGiris.Name = "btnGiris";
            this.btnGiris.Size = new System.Drawing.Size(206, 47);
            this.btnGiris.TabIndex = 0;
            this.btnGiris.Text = "GİRİŞ YAP";
            this.btnGiris.UseVisualStyleBackColor = false;
            this.btnGiris.Click += new System.EventHandler(this.btnGiris_Click);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.ForeColor = System.Drawing.Color.DarkRed;
            this.lblEmail.Location = new System.Drawing.Point(151, 78);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(46, 16);
            this.lblEmail.TabIndex = 1;
            this.lblEmail.Text = "EMAİL";
            this.lblEmail.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblSifre
            // 
            this.lblSifre.AutoSize = true;
            this.lblSifre.ForeColor = System.Drawing.Color.DarkRed;
            this.lblSifre.Location = new System.Drawing.Point(151, 139);
            this.lblSifre.Name = "lblSifre";
            this.lblSifre.Size = new System.Drawing.Size(46, 16);
            this.lblSifre.TabIndex = 2;
            this.lblSifre.Text = "ŞİFRE";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.LavenderBlush;
            this.textBox1.Location = new System.Drawing.Point(270, 72);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(175, 22);
            this.textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.LavenderBlush;
            this.textBox2.Location = new System.Drawing.Point(270, 133);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(175, 22);
            this.textBox2.TabIndex = 4;
            // 
            // linksifreunuttum
            // 
            this.linksifreunuttum.AutoSize = true;
            this.linksifreunuttum.LinkColor = System.Drawing.Color.DarkRed;
            this.linksifreunuttum.Location = new System.Drawing.Point(377, 177);
            this.linksifreunuttum.Name = "linksifreunuttum";
            this.linksifreunuttum.Size = new System.Drawing.Size(99, 16);
            this.linksifreunuttum.TabIndex = 5;
            this.linksifreunuttum.TabStop = true;
            this.linksifreunuttum.Text = "Şifremi Unuttum";
            this.linksifreunuttum.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // linkKayıt
            // 
            this.linkKayıt.AutoSize = true;
            this.linkKayıt.LinkColor = System.Drawing.Color.DarkRed;
            this.linkKayıt.Location = new System.Drawing.Point(413, 293);
            this.linkKayıt.Name = "linkKayıt";
            this.linkKayıt.Size = new System.Drawing.Size(52, 16);
            this.linkKayıt.TabIndex = 6;
            this.linkKayıt.TabStop = true;
            this.linkKayıt.Text = "Kayıt Ol";
            this.linkKayıt.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkKayıt_LinkClicked);
            // 
            // lblhesapyok
            // 
            this.lblhesapyok.AutoSize = true;
            this.lblhesapyok.ForeColor = System.Drawing.Color.Crimson;
            this.lblhesapyok.Location = new System.Drawing.Point(256, 293);
            this.lblhesapyok.Name = "lblhesapyok";
            this.lblhesapyok.Size = new System.Drawing.Size(120, 16);
            this.lblhesapyok.TabIndex = 7;
            this.lblhesapyok.Text = "Hesabınız yok mu?";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Pink;
            this.ClientSize = new System.Drawing.Size(669, 381);
            this.Controls.Add(this.lblhesapyok);
            this.Controls.Add(this.linkKayıt);
            this.Controls.Add(this.linksifreunuttum);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblSifre);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.btnGiris);
            this.ForeColor = System.Drawing.Color.DarkRed;
            this.Name = "Form1";
            this.Text = "GİRİŞ SAYFASI";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGiris;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblSifre;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.LinkLabel linksifreunuttum;
        private System.Windows.Forms.LinkLabel linkKayıt;
        private System.Windows.Forms.Label lblhesapyok;
    }
}

