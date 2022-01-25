
namespace Fatih_Karameşe_BitirmeTezi_1
{
    partial class fInOut
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
            this.lGelirGider = new Fatih_Karameşe_BitirmeTezi_1.lSandart();
            this.tNakit = new Fatih_Karameşe_BitirmeTezi_1.tnumeric();
            this.cÖdemeTürü = new System.Windows.Forms.ComboBox();
            this.lSandart2 = new Fatih_Karameşe_BitirmeTezi_1.lSandart();
            this.lSandart3 = new Fatih_Karameşe_BitirmeTezi_1.lSandart();
            this.Nakit = new Fatih_Karameşe_BitirmeTezi_1.lSandart();
            this.tAçıklama = new Fatih_Karameşe_BitirmeTezi_1.lSandart();
            this.tKart = new Fatih_Karameşe_BitirmeTezi_1.tnumeric();
            this.dbitis = new System.Windows.Forms.DateTimePicker();
            this.lSandart4 = new Fatih_Karameşe_BitirmeTezi_1.lSandart();
            this.bKaydet = new System.Windows.Forms.Button();
            this.tAciklama = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lGelirGider
            // 
            this.lGelirGider.AutoSize = true;
            this.lGelirGider.Font = new System.Drawing.Font("Segoe UI Light", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lGelirGider.ForeColor = System.Drawing.Color.Black;
            this.lGelirGider.Location = new System.Drawing.Point(12, 9);
            this.lGelirGider.Name = "lGelirGider";
            this.lGelirGider.Size = new System.Drawing.Size(123, 32);
            this.lGelirGider.TabIndex = 0;
            this.lGelirGider.Text = "Gelir-Gider";
            // 
            // tNakit
            // 
            this.tNakit.BackColor = System.Drawing.Color.White;
            this.tNakit.Enabled = false;
            this.tNakit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tNakit.Location = new System.Drawing.Point(54, 173);
            this.tNakit.Name = "tNakit";
            this.tNakit.Size = new System.Drawing.Size(164, 30);
            this.tNakit.TabIndex = 1;
            this.tNakit.Text = "0";
            this.tNakit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cÖdemeTürü
            // 
            this.cÖdemeTürü.Font = new System.Drawing.Font("Segoe UI Light", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cÖdemeTürü.FormattingEnabled = true;
            this.cÖdemeTürü.Items.AddRange(new object[] {
            "NAKİT",
            "KART",
            "NAKİT-KART"});
            this.cÖdemeTürü.Location = new System.Drawing.Point(56, 93);
            this.cÖdemeTürü.Name = "cÖdemeTürü";
            this.cÖdemeTürü.Size = new System.Drawing.Size(164, 33);
            this.cÖdemeTürü.TabIndex = 2;
            this.cÖdemeTürü.SelectedIndexChanged += new System.EventHandler(this.cÖdemeTürü_SelectedIndexChanged);
            // 
            // lSandart2
            // 
            this.lSandart2.AutoSize = true;
            this.lSandart2.Font = new System.Drawing.Font("Segoe UI Light", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lSandart2.ForeColor = System.Drawing.Color.Black;
            this.lSandart2.Location = new System.Drawing.Point(51, 58);
            this.lSandart2.Name = "lSandart2";
            this.lSandart2.Size = new System.Drawing.Size(140, 32);
            this.lSandart2.TabIndex = 3;
            this.lSandart2.Text = "Ödeme Türü";
            // 
            // lSandart3
            // 
            this.lSandart3.AutoSize = true;
            this.lSandart3.Font = new System.Drawing.Font("Segoe UI Light", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lSandart3.ForeColor = System.Drawing.Color.Black;
            this.lSandart3.Location = new System.Drawing.Point(260, 138);
            this.lSandart3.Name = "lSandart3";
            this.lSandart3.Size = new System.Drawing.Size(56, 32);
            this.lSandart3.TabIndex = 4;
            this.lSandart3.Text = "Kart";
            // 
            // Nakit
            // 
            this.Nakit.AutoSize = true;
            this.Nakit.Font = new System.Drawing.Font("Segoe UI Light", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Nakit.ForeColor = System.Drawing.Color.Black;
            this.Nakit.Location = new System.Drawing.Point(50, 138);
            this.Nakit.Name = "Nakit";
            this.Nakit.Size = new System.Drawing.Size(67, 32);
            this.Nakit.TabIndex = 5;
            this.Nakit.Text = "Nakit";
            // 
            // tAçıklama
            // 
            this.tAçıklama.AutoSize = true;
            this.tAçıklama.Font = new System.Drawing.Font("Segoe UI Light", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tAçıklama.ForeColor = System.Drawing.Color.Black;
            this.tAçıklama.Location = new System.Drawing.Point(48, 233);
            this.tAçıklama.Name = "tAçıklama";
            this.tAçıklama.Size = new System.Drawing.Size(106, 32);
            this.tAçıklama.TabIndex = 6;
            this.tAçıklama.Text = "Açıklama";
            // 
            // tKart
            // 
            this.tKart.BackColor = System.Drawing.Color.White;
            this.tKart.Enabled = false;
            this.tKart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tKart.Location = new System.Drawing.Point(266, 173);
            this.tKart.Name = "tKart";
            this.tKart.Size = new System.Drawing.Size(164, 30);
            this.tKart.TabIndex = 7;
            this.tKart.Text = "0";
            this.tKart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dbitis
            // 
            this.dbitis.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dbitis.Location = new System.Drawing.Point(57, 539);
            this.dbitis.Name = "dbitis";
            this.dbitis.Size = new System.Drawing.Size(373, 32);
            this.dbitis.TabIndex = 12;
            // 
            // lSandart4
            // 
            this.lSandart4.AutoSize = true;
            this.lSandart4.Font = new System.Drawing.Font("Segoe UI Light", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lSandart4.ForeColor = System.Drawing.Color.Black;
            this.lSandart4.Location = new System.Drawing.Point(48, 504);
            this.lSandart4.Name = "lSandart4";
            this.lSandart4.Size = new System.Drawing.Size(61, 32);
            this.lSandart4.TabIndex = 13;
            this.lSandart4.Text = "Tarih";
            // 
            // bKaydet
            // 
            this.bKaydet.BackColor = System.Drawing.Color.LimeGreen;
            this.bKaydet.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bKaydet.Font = new System.Drawing.Font("Segoe UI Light", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.bKaydet.Image = global::Fatih_Karameşe_BitirmeTezi_1.Properties.Resources.save_file_option;
            this.bKaydet.Location = new System.Drawing.Point(54, 606);
            this.bKaydet.Name = "bKaydet";
            this.bKaydet.Size = new System.Drawing.Size(376, 75);
            this.bKaydet.TabIndex = 14;
            this.bKaydet.UseVisualStyleBackColor = false;
            this.bKaydet.Click += new System.EventHandler(this.bKaydet_Click);
            // 
            // tAciklama
            // 
            this.tAciklama.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tAciklama.Location = new System.Drawing.Point(54, 269);
            this.tAciklama.Multiline = true;
            this.tAciklama.Name = "tAciklama";
            this.tAciklama.Size = new System.Drawing.Size(376, 232);
            this.tAciklama.TabIndex = 15;
            this.tAciklama.TextChanged += new System.EventHandler(this.tAciklama_TextChanged);
            // 
            // fInOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(478, 765);
            this.Controls.Add(this.tAciklama);
            this.Controls.Add(this.bKaydet);
            this.Controls.Add(this.lSandart4);
            this.Controls.Add(this.dbitis);
            this.Controls.Add(this.tKart);
            this.Controls.Add(this.tAçıklama);
            this.Controls.Add(this.Nakit);
            this.Controls.Add(this.lSandart3);
            this.Controls.Add(this.lSandart2);
            this.Controls.Add(this.cÖdemeTürü);
            this.Controls.Add(this.tNakit);
            this.Controls.Add(this.lGelirGider);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "fInOut";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gelir-Gider";
            this.Load += new System.EventHandler(this.fInOut_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private lSandart lGelirGider;
        private tnumeric tNakit;
        private System.Windows.Forms.ComboBox cÖdemeTürü;
        private lSandart lSandart2;
        private lSandart lSandart3;
        private lSandart Nakit;
        private lSandart tAçıklama;
        private tnumeric tKart;
        private System.Windows.Forms.DateTimePicker dbitis;
        private lSandart lSandart4;
        private System.Windows.Forms.Button bKaydet;
        private System.Windows.Forms.TextBox tAciklama;
    }
}