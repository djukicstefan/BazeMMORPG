
namespace Projekat2Deo_Verzija1.Forme
{
    partial class SegrtForma
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
            this.txtIme = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbRasa = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numBonusUSkirvanju = new System.Windows.Forms.NumericUpDown();
            this.btnDodaj = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numBonusUSkirvanju)).BeginInit();
            this.SuspendLayout();
            // 
            // txtIme
            // 
            this.txtIme.Location = new System.Drawing.Point(124, 25);
            this.txtIme.Name = "txtIme";
            this.txtIme.Size = new System.Drawing.Size(141, 20);
            this.txtIme.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ime:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(79, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Rasa:";
            // 
            // cmbRasa
            // 
            this.cmbRasa.FormattingEnabled = true;
            this.cmbRasa.Location = new System.Drawing.Point(124, 51);
            this.cmbRasa.Name = "cmbRasa";
            this.cmbRasa.Size = new System.Drawing.Size(141, 21);
            this.cmbRasa.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Bonus u skrivanju:";
            // 
            // numBonusUSkirvanju
            // 
            this.numBonusUSkirvanju.Location = new System.Drawing.Point(124, 78);
            this.numBonusUSkirvanju.Name = "numBonusUSkirvanju";
            this.numBonusUSkirvanju.Size = new System.Drawing.Size(141, 20);
            this.numBonusUSkirvanju.TabIndex = 5;
            // 
            // btnDodaj
            // 
            this.btnDodaj.Location = new System.Drawing.Point(150, 120);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(75, 23);
            this.btnDodaj.TabIndex = 6;
            this.btnDodaj.Text = "Dodaj";
            this.btnDodaj.UseVisualStyleBackColor = true;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // SegrtForma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 155);
            this.Controls.Add(this.btnDodaj);
            this.Controls.Add(this.numBonusUSkirvanju);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbRasa);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIme);
            this.Name = "SegrtForma";
            this.Text = "SegrtForma";
            ((System.ComponentModel.ISupportInitialize)(this.numBonusUSkirvanju)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIme;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbRasa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numBonusUSkirvanju;
        private System.Windows.Forms.Button btnDodaj;
    }
}