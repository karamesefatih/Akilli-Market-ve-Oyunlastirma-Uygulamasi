
namespace Fatih_Karameşe_BitirmeTezi_1
{
    partial class fShowDetails
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
            this.lislemno = new Fatih_Karameşe_BitirmeTezi_1.lSandart();
            this.gridSatışList = new System.Windows.Forms.DataGridView();
            this.KdvTutari = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AlisFiyati = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Urungrup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Birim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSatışList)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel1.Controls.Add(this.lislemno);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gridSatışList);
            this.splitContainer1.Size = new System.Drawing.Size(836, 549);
            this.splitContainer1.SplitterDistance = 161;
            this.splitContainer1.TabIndex = 0;
            // 
            // lislemno
            // 
            this.lislemno.AutoSize = true;
            this.lislemno.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lislemno.ForeColor = System.Drawing.Color.Black;
            this.lislemno.Location = new System.Drawing.Point(12, 31);
            this.lislemno.Name = "lislemno";
            this.lislemno.Size = new System.Drawing.Size(78, 22);
            this.lislemno.TabIndex = 0;
            this.lislemno.Text = "lislemno";
            // 
            // gridSatışList
            // 
            this.gridSatışList.AllowUserToAddRows = false;
            this.gridSatışList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridSatışList.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.gridSatışList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gridSatışList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSatışList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.KdvTutari,
            this.AlisFiyati,
            this.Urungrup,
            this.Birim});
            this.gridSatışList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSatışList.EnableHeadersVisualStyles = false;
            this.gridSatışList.Location = new System.Drawing.Point(0, 0);
            this.gridSatışList.Name = "gridSatışList";
            this.gridSatışList.RowHeadersVisible = false;
            this.gridSatışList.RowHeadersWidth = 51;
            this.gridSatışList.RowTemplate.Height = 24;
            this.gridSatışList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridSatışList.Size = new System.Drawing.Size(836, 384);
            this.gridSatışList.TabIndex = 3;
            // 
            // KdvTutari
            // 
            this.KdvTutari.HeaderText = "Kdv Tutarı";
            this.KdvTutari.MinimumWidth = 6;
            this.KdvTutari.Name = "KdvTutari";
            this.KdvTutari.Visible = false;
            // 
            // AlisFiyati
            // 
            this.AlisFiyati.HeaderText = "Alış Fiyatı";
            this.AlisFiyati.MinimumWidth = 6;
            this.AlisFiyati.Name = "AlisFiyati";
            this.AlisFiyati.Visible = false;
            // 
            // Urungrup
            // 
            this.Urungrup.HeaderText = "Urungrup";
            this.Urungrup.MinimumWidth = 6;
            this.Urungrup.Name = "Urungrup";
            this.Urungrup.Visible = false;
            // 
            // Birim
            // 
            this.Birim.HeaderText = "Birim";
            this.Birim.MinimumWidth = 6;
            this.Birim.Name = "Birim";
            this.Birim.Visible = false;
            // 
            // fShowDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 549);
            this.Controls.Add(this.splitContainer1);
            this.Name = "fShowDetails";
            this.Text = "Detay Gösterme";
            this.Load += new System.EventHandler(this.fShowDetails_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSatışList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private lSandart lislemno;
        private System.Windows.Forms.DataGridView gridSatışList;
        private System.Windows.Forms.DataGridViewTextBoxColumn KdvTutari;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlisFiyati;
        private System.Windows.Forms.DataGridViewTextBoxColumn Urungrup;
        private System.Windows.Forms.DataGridViewTextBoxColumn Birim;
    }
}