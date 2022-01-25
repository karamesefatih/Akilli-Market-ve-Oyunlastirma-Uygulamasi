
namespace Fatih_Karameşe_BitirmeTezi_1
{
    partial class fAddProduct
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lkullanıcı = new System.Windows.Forms.Label();
            this.BUTONID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbGoster = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbUrunAra = new System.Windows.Forms.TextBox();
            this.gridUrun = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridUrun)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lkullanıcı);
            this.splitContainer1.Panel1.Controls.Add(this.BUTONID);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.cbGoster);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.tbUrunAra);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gridUrun);
            this.splitContainer1.Size = new System.Drawing.Size(1108, 634);
            this.splitContainer1.SplitterDistance = 151;
            this.splitContainer1.TabIndex = 0;
            // 
            // lkullanıcı
            // 
            this.lkullanıcı.AutoSize = true;
            this.lkullanıcı.Location = new System.Drawing.Point(548, 20);
            this.lkullanıcı.Name = "lkullanıcı";
            this.lkullanıcı.Size = new System.Drawing.Size(32, 17);
            this.lkullanıcı.TabIndex = 10;
            this.lkullanıcı.Text = "654";
            this.lkullanıcı.Visible = false;
            // 
            // BUTONID
            // 
            this.BUTONID.AutoSize = true;
            this.BUTONID.Location = new System.Drawing.Point(436, 20);
            this.BUTONID.Name = "BUTONID";
            this.BUTONID.Size = new System.Drawing.Size(68, 17);
            this.BUTONID.TabIndex = 9;
            this.BUTONID.Text = "Buton NO";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(303, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Buton Numarası:";
            // 
            // cbGoster
            // 
            this.cbGoster.AutoSize = true;
            this.cbGoster.Location = new System.Drawing.Point(278, 54);
            this.cbGoster.Name = "cbGoster";
            this.cbGoster.Size = new System.Drawing.Size(126, 21);
            this.cbGoster.TabIndex = 7;
            this.cbGoster.Text = "Tümünü Göster";
            this.cbGoster.UseVisualStyleBackColor = true;
            this.cbGoster.CheckedChanged += new System.EventHandler(this.cbGoster_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "Ara";
            // 
            // tbUrunAra
            // 
            this.tbUrunAra.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbUrunAra.Location = new System.Drawing.Point(21, 48);
            this.tbUrunAra.Name = "tbUrunAra";
            this.tbUrunAra.Size = new System.Drawing.Size(227, 28);
            this.tbUrunAra.TabIndex = 5;
            this.tbUrunAra.TextChanged += new System.EventHandler(this.tbUrunAra_TextChanged);
            // 
            // gridUrun
            // 
            this.gridUrun.AllowUserToAddRows = false;
            this.gridUrun.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridUrun.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.gridUrun.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gridUrun.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridUrun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridUrun.EnableHeadersVisualStyles = false;
            this.gridUrun.Location = new System.Drawing.Point(0, 0);
            this.gridUrun.Name = "gridUrun";
            this.gridUrun.RowHeadersVisible = false;
            this.gridUrun.RowHeadersWidth = 51;
            this.gridUrun.RowTemplate.Height = 24;
            this.gridUrun.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridUrun.Size = new System.Drawing.Size(1108, 479);
            this.gridUrun.TabIndex = 2;
            this.gridUrun.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridUrun_CellContentDoubleClick);
            // 
            // fAddProduct
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 634);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Name = "fAddProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ÜRÜN EKLEME";
            this.Load += new System.EventHandler(this.UrunEkle_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridUrun)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView gridUrun;
        private System.Windows.Forms.CheckBox cbGoster;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbUrunAra;
        public System.Windows.Forms.Label BUTONID;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lkullanıcı;
    }
}