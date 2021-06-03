namespace Projekat2Deo_Verzija1
{
    partial class frmPocetnaStranica
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
            this.lblMMORPG = new System.Windows.Forms.Label();
            this.gpbAktivniServeri = new System.Windows.Forms.GroupBox();
            this.livServeri = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gpbPrijava = new System.Windows.Forms.GroupBox();
            this.btnPrijava = new System.Windows.Forms.Button();
            this.btnRegistracija = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblUkupanBrojIgraca = new System.Windows.Forms.Label();
            this.gpbAktivniServeri.SuspendLayout();
            this.gpbPrijava.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMMORPG
            // 
            this.lblMMORPG.AutoSize = true;
            this.lblMMORPG.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMMORPG.Location = new System.Drawing.Point(249, 21);
            this.lblMMORPG.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMMORPG.Name = "lblMMORPG";
            this.lblMMORPG.Size = new System.Drawing.Size(123, 29);
            this.lblMMORPG.TabIndex = 0;
            this.lblMMORPG.Text = "MMORPG";
            // 
            // gpbAktivniServeri
            // 
            this.gpbAktivniServeri.Controls.Add(this.livServeri);
            this.gpbAktivniServeri.Location = new System.Drawing.Point(268, 96);
            this.gpbAktivniServeri.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gpbAktivniServeri.Name = "gpbAktivniServeri";
            this.gpbAktivniServeri.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gpbAktivniServeri.Size = new System.Drawing.Size(352, 189);
            this.gpbAktivniServeri.TabIndex = 1;
            this.gpbAktivniServeri.TabStop = false;
            this.gpbAktivniServeri.Text = "Aktivni serveri";
            // 
            // livServeri
            // 
            this.livServeri.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.livServeri.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.livServeri.FullRowSelect = true;
            this.livServeri.GridLines = true;
            this.livServeri.HideSelection = false;
            this.livServeri.Location = new System.Drawing.Point(2, 13);
            this.livServeri.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.livServeri.MaximumSize = new System.Drawing.Size(352, 173);
            this.livServeri.Name = "livServeri";
            this.livServeri.Size = new System.Drawing.Size(346, 172);
            this.livServeri.TabIndex = 0;
            this.livServeri.UseCompatibleStateImageBehavior = false;
            this.livServeri.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Id";
            this.columnHeader1.Width = 68;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Naziv";
            this.columnHeader2.Width = 189;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Broj igrača";
            this.columnHeader3.Width = 210;
            // 
            // gpbPrijava
            // 
            this.gpbPrijava.Controls.Add(this.btnPrijava);
            this.gpbPrijava.Controls.Add(this.btnRegistracija);
            this.gpbPrijava.Location = new System.Drawing.Point(9, 79);
            this.gpbPrijava.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gpbPrijava.Name = "gpbPrijava";
            this.gpbPrijava.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gpbPrijava.Size = new System.Drawing.Size(204, 102);
            this.gpbPrijava.TabIndex = 2;
            this.gpbPrijava.TabStop = false;
            this.gpbPrijava.Text = "Prijava";
            // 
            // btnPrijava
            // 
            this.btnPrijava.Location = new System.Drawing.Point(124, 32);
            this.btnPrijava.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPrijava.Name = "btnPrijava";
            this.btnPrijava.Size = new System.Drawing.Size(75, 36);
            this.btnPrijava.TabIndex = 4;
            this.btnPrijava.Text = "Prijavi se";
            this.btnPrijava.UseVisualStyleBackColor = true;
            this.btnPrijava.Click += new System.EventHandler(this.btnPrijava_Click);
            // 
            // btnRegistracija
            // 
            this.btnRegistracija.Location = new System.Drawing.Point(4, 32);
            this.btnRegistracija.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRegistracija.Name = "btnRegistracija";
            this.btnRegistracija.Size = new System.Drawing.Size(75, 36);
            this.btnRegistracija.TabIndex = 3;
            this.btnRegistracija.Text = "Registruj se";
            this.btnRegistracija.UseVisualStyleBackColor = true;
            this.btnRegistracija.Click += new System.EventHandler(this.btnRegistracija_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(310, 61);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ukupan broj igrača:";
            // 
            // lblUkupanBrojIgraca
            // 
            this.lblUkupanBrojIgraca.AutoSize = true;
            this.lblUkupanBrojIgraca.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUkupanBrojIgraca.Location = new System.Drawing.Point(448, 61);
            this.lblUkupanBrojIgraca.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUkupanBrojIgraca.Name = "lblUkupanBrojIgraca";
            this.lblUkupanBrojIgraca.Size = new System.Drawing.Size(16, 18);
            this.lblUkupanBrojIgraca.TabIndex = 4;
            this.lblUkupanBrojIgraca.Text = "0";
            // 
            // frmPocetnaStranica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 366);
            this.Controls.Add(this.lblUkupanBrojIgraca);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gpbPrijava);
            this.Controls.Add(this.gpbAktivniServeri);
            this.Controls.Add(this.lblMMORPG);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmPocetnaStranica";
            this.Text = "Dobrodošli";
            this.Load += new System.EventHandler(this.frmPocetnaStranica_Load);
            this.gpbAktivniServeri.ResumeLayout(false);
            this.gpbPrijava.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMMORPG;
        private System.Windows.Forms.GroupBox gpbAktivniServeri;
        private System.Windows.Forms.GroupBox gpbPrijava;
        private System.Windows.Forms.Button btnPrijava;
        private System.Windows.Forms.Button btnRegistracija;
        private System.Windows.Forms.ListView livServeri;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblUkupanBrojIgraca;
    }
}