using AjaxControlToolkit.HtmlEditor.ToolbarButtons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fatih_Karameşe_BitirmeTezi_1
{
    class nesnelerim
    {
    }
    class lSandart : Label
    {
        public lSandart()
        {

            this.ForeColor = System.Drawing.Color.Black;
            this.Text = "lStandart";
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "lStandart";
        }
        class bSandart : Button
        {
            public bSandart()
            {

                this.ImeMode = System.Windows.Forms.ImeMode.On;
                this.Location = new System.Drawing.Point(1, 1);
                this.Margin = new System.Windows.Forms.Padding(1);
                this.Name = "btnNakit";
                this.Size = new System.Drawing.Size(101, 104);
                this.TabIndex = 0;
                this.Text = "NAKİT(F5)";

            }
        }
        class tStandart : TextBox
        {
            public tStandart()
            {
                this.Font = new System.Drawing.Font("Times New Roman", 10.8F);
                this.Location = new System.Drawing.Point(9, 58);
                this.Name = "tbMiktar";
                this.Size = new System.Drawing.Size(59, 28);
                this.TabIndex = 0;
                this.Text = "1";
            }
        }
  class tnumeric:TextBox
        {
            public tnumeric()
            {
                this.Size = new System.Drawing.Size(115, 26);
                this.BackColor = System.Drawing.Color.White;
                this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
                this.Name = "tNumeric";
            }
        }

    }
    class tnumeric : TextBox
    {
        public tnumeric()
        {
            this.Size = new System.Drawing.Size(115, 26);
            this.BackColor = System.Drawing.Color.White;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Name = "tNumeric";
            this.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Click += tNumeric_Click;
            this.KeyPress += tNumeric_Keypress;
        }
        private void tNumeric_Keypress(object sender,KeyPressEventArgs e)
        {
            if(char.IsDigit(e.KeyChar)==false && e.KeyChar != (char)08)
            {
                e.Handled = true;
            }
        }
        private void tNumeric_Click(object sender,EventArgs e)
        {
            this.SelectAll();
        }

    }
   
    }
