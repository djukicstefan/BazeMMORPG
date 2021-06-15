namespace Projekat2Deo_Verzija1.Forme
{
    partial class NovaAlijansaForma
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
            this.numMaxIgraci = new System.Windows.Forms.NumericUpDown();
            this.lblMaxIgraca = new System.Windows.Forms.Label();
            this.lblNazivAlijanse = new System.Windows.Forms.Label();
            this.txtNazivAlijanse = new System.Windows.Forms.TextBox();
            this.btnOdustani = new System.Windows.Forms.Button();
            this.btnPotvrdi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxIgraci)).BeginInit();
            this.SuspendLayout();
            // 
            // numMaxIgraci
            // 
            this.numMaxIgraci.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMaxIgraci.Location = new System.Drawing.Point(182, 100);
            this.numMaxIgraci.Margin = new System.Windows.Forms.Padding(4);
            this.numMaxIgraci.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numMaxIgraci.Name = "numMaxIgraci";
            this.numMaxIgraci.Size = new System.Drawing.Size(107, 30);
            this.numMaxIgraci.TabIndex = 21;
            // 
            // lblMaxIgraca
            // 
            this.lblMaxIgraca.AutoSize = true;
            this.lblMaxIgraca.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxIgraca.Location = new System.Drawing.Point(29, 102);
            this.lblMaxIgraca.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaxIgraca.Name = "lblMaxIgraca";
            this.lblMaxIgraca.Size = new System.Drawing.Size(151, 25);
            this.lblMaxIgraca.TabIndex = 20;
            this.lblMaxIgraca.Text = "Max broj igrača:";
            // 
            // lblNazivAlijanse
            // 
            this.lblNazivAlijanse.AutoSize = true;
            this.lblNazivAlijanse.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNazivAlijanse.Location = new System.Drawing.Point(107, 48);
            this.lblNazivAlijanse.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNazivAlijanse.Name = "lblNazivAlijanse";
            this.lblNazivAlijanse.Size = new System.Drawing.Size(67, 25);
            this.lblNazivAlijanse.TabIndex = 19;
            this.lblNazivAlijanse.Text = "Naziv:";
            // 
            // txtNazivAlijanse
            // 
            this.txtNazivAlijanse.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNazivAlijanse.Location = new System.Drawing.Point(181, 45);
            this.txtNazivAlijanse.Name = "txtNazivAlijanse";
            this.txtNazivAlijanse.Size = new System.Drawing.Size(226, 30);
            this.txtNazivAlijanse.TabIndex = 22;
            // 
            // btnOdustani
            // 
            this.btnOdustani.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOdustani.Location = new System.Drawing.Point(112, 170);
            this.btnOdustani.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOdustani.Name = "btnOdustani";
            this.btnOdustani.Size = new System.Drawing.Size(117, 39);
            this.btnOdustani.TabIndex = 24;
            this.btnOdustani.Text = "Odustani";
            this.btnOdustani.UseVisualStyleBackColor = true;
            this.btnOdustani.Click += new System.EventHandler(this.btnOdustani_Click);
            // 
            // btnPotvrdi
            // 
            this.btnPotvrdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPotvrdi.Location = new System.Drawing.Point(245, 170);
            this.btnPotvrdi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPotvrdi.Name = "btnPotvrdi";
            this.btnPotvrdi.Size = new System.Drawing.Size(104, 39);
            this.btnPotvrdi.TabIndex = 23;
            this.btnPotvrdi.Text = "Potvrdi";
            this.btnPotvrdi.UseVisualStyleBackColor = true;
            this.btnPotvrdi.Click += new System.EventHandler(this.btnPotvrdi_Click);
            // 
            // NovaAlijansaForma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 241);
            this.Controls.Add(this.btnOdustani);
            this.Controls.Add(this.btnPotvrdi);
            this.Controls.Add(this.txtNazivAlijanse);
            this.Controls.Add(this.numMaxIgraci);
            this.Controls.Add(this.lblMaxIgraca);
            this.Controls.Add(this.lblNazivAlijanse);
            this.Name = "NovaAlijansaForma";
            this.Text = "Nova alijansa";
            ((System.ComponentModel.ISupportInitialize)(this.numMaxIgraci)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numMaxIgraci;
        private System.Windows.Forms.Label lblMaxIgraca;
        private System.Windows.Forms.Label lblNazivAlijanse;
        private System.Windows.Forms.TextBox txtNazivAlijanse;
        private System.Windows.Forms.Button btnOdustani;
        private System.Windows.Forms.Button btnPotvrdi;
    }
}