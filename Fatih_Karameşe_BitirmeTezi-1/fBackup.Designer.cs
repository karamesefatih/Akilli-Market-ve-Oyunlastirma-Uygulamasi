
namespace Fatih_Karameşe_BitirmeTezi_1
{
    partial class fBackup
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
            this.tYedekSeç = new System.Windows.Forms.TextBox();
            this.btnYedekSeç = new System.Windows.Forms.Button();
            this.btnYükle = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tYedekSeç
            // 
            this.tYedekSeç.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tYedekSeç.Location = new System.Drawing.Point(12, 24);
            this.tYedekSeç.Name = "tYedekSeç";
            this.tYedekSeç.Size = new System.Drawing.Size(492, 35);
            this.tYedekSeç.TabIndex = 0;
            // 
            // btnYedekSeç
            // 
            this.btnYedekSeç.BackColor = System.Drawing.Color.Crimson;
            this.btnYedekSeç.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnYedekSeç.ForeColor = System.Drawing.Color.White;
            this.btnYedekSeç.Location = new System.Drawing.Point(514, 18);
            this.btnYedekSeç.Name = "btnYedekSeç";
            this.btnYedekSeç.Size = new System.Drawing.Size(128, 51);
            this.btnYedekSeç.TabIndex = 1;
            this.btnYedekSeç.Text = "Yedek Seç";
            this.btnYedekSeç.UseVisualStyleBackColor = false;
            this.btnYedekSeç.Click += new System.EventHandler(this.btnYedekSeç_Click);
            // 
            // btnYükle
            // 
            this.btnYükle.BackColor = System.Drawing.Color.Crimson;
            this.btnYükle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnYükle.ForeColor = System.Drawing.Color.White;
            this.btnYükle.Location = new System.Drawing.Point(514, 75);
            this.btnYükle.Name = "btnYükle";
            this.btnYükle.Size = new System.Drawing.Size(128, 45);
            this.btnYükle.TabIndex = 2;
            this.btnYükle.Text = "YÜKLE";
            this.btnYükle.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(13, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(495, 65);
            this.label1.TabIndex = 3;
            this.label1.Text = "!!!Bu işlemi yaptığınız zaman mecut verileriniz silinecek Yerine yeni bilgilerini" +
    "z yüklenecektir";
            // 
            // fBackup
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 149);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnYükle);
            this.Controls.Add(this.btnYedekSeç);
            this.Controls.Add(this.tYedekSeç);
            this.Name = "fBackup";
            this.Text = "Yedekten Veri Yükleme";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tYedekSeç;
        private System.Windows.Forms.Button btnYedekSeç;
        private System.Windows.Forms.Button btnYükle;
        private System.Windows.Forms.Label label1;
    }
}