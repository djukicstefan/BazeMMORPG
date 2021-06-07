namespace Projekat2Deo_Verzija1.Forme
{
    partial class ServerForma
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
            this.btnOdustani = new System.Windows.Forms.Button();
            this.btnPotvrdi = new System.Windows.Forms.Button();
            this.lblNazivServer = new System.Windows.Forms.Label();
            this.txtNazivServera = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnOdustani
            // 
            this.btnOdustani.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOdustani.Location = new System.Drawing.Point(59, 119);
            this.btnOdustani.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOdustani.Name = "btnOdustani";
            this.btnOdustani.Size = new System.Drawing.Size(117, 39);
            this.btnOdustani.TabIndex = 7;
            this.btnOdustani.Text = "Odustani";
            this.btnOdustani.UseVisualStyleBackColor = true;
            this.btnOdustani.Click += new System.EventHandler(this.btnOdustani_Click);
            // 
            // btnPotvrdi
            // 
            this.btnPotvrdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPotvrdi.Location = new System.Drawing.Point(192, 119);
            this.btnPotvrdi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPotvrdi.Name = "btnPotvrdi";
            this.btnPotvrdi.Size = new System.Drawing.Size(104, 39);
            this.btnPotvrdi.TabIndex = 6;
            this.btnPotvrdi.Text = "Potvrdi";
            this.btnPotvrdi.UseVisualStyleBackColor = true;
            this.btnPotvrdi.Click += new System.EventHandler(this.btnPotvrdi_Click);
            // 
            // lblNazivServer
            // 
            this.lblNazivServer.AutoSize = true;
            this.lblNazivServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNazivServer.Location = new System.Drawing.Point(29, 46);
            this.lblNazivServer.Name = "lblNazivServer";
            this.lblNazivServer.Size = new System.Drawing.Size(137, 25);
            this.lblNazivServer.TabIndex = 9;
            this.lblNazivServer.Text = "Naziv servera:";
            // 
            // txtNazivServera
            // 
            this.txtNazivServera.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNazivServera.Location = new System.Drawing.Point(162, 43);
            this.txtNazivServera.Name = "txtNazivServera";
            this.txtNazivServera.Size = new System.Drawing.Size(173, 30);
            this.txtNazivServera.TabIndex = 10;
            this.txtNazivServera.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // ServerForma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 208);
            this.Controls.Add(this.txtNazivServera);
            this.Controls.Add(this.lblNazivServer);
            this.Controls.Add(this.btnOdustani);
            this.Controls.Add(this.btnPotvrdi);
            this.MaximumSize = new System.Drawing.Size(381, 255);
            this.MinimumSize = new System.Drawing.Size(381, 255);
            this.Name = "ServerForma";
            this.Text = "ServerForma";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOdustani;
        private System.Windows.Forms.Button btnPotvrdi;
        private System.Windows.Forms.Label lblNazivServer;
        private System.Windows.Forms.TextBox txtNazivServera;
    }
}