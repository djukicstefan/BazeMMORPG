namespace Projekat2Deo_Verzija1
{
    partial class frmProveraMapiranja
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
            this.cmdUcitavanjeServera = new System.Windows.Forms.Button();
            this.cmdDodavanjeNovogServera = new System.Windows.Forms.Button();
            this.cmdUcitavanjeAlijanse = new System.Windows.Forms.Button();
            this.cmdUcitavanjeZadatka = new System.Windows.Forms.Button();
            this.cmdUcitavanjeLika = new System.Windows.Forms.Button();
            this.cmpKljucniPredmet = new System.Windows.Forms.Button();
            this.cmdBonusPIO = new System.Windows.Forms.Button();
            this.cmdIgracManyToOne = new System.Windows.Forms.Button();
            this.cmdServerOneToMany = new System.Windows.Forms.Button();
            this.cmdAlijansaOneToMany = new System.Windows.Forms.Button();
            this.cmdDodavanjeIgraca = new System.Windows.Forms.Button();
            this.cmdManyToManyAlijanse = new System.Windows.Forms.Button();
            this.cmdGrupniZadaci = new System.Windows.Forms.Button();
            this.cmdIndividualniZadaci = new System.Windows.Forms.Button();
            this.cmdDodajSegrta = new System.Windows.Forms.Button();
            this.cmdPregledOpreme = new System.Windows.Forms.Button();
            this.cmdProveraAlternativeC = new System.Windows.Forms.Button();
            this.cmdDodavanjeLika = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdUcitavanjeServera
            // 
            this.cmdUcitavanjeServera.Location = new System.Drawing.Point(12, 12);
            this.cmdUcitavanjeServera.Name = "cmdUcitavanjeServera";
            this.cmdUcitavanjeServera.Size = new System.Drawing.Size(144, 43);
            this.cmdUcitavanjeServera.TabIndex = 0;
            this.cmdUcitavanjeServera.Text = "Ucitavanje servera";
            this.cmdUcitavanjeServera.UseVisualStyleBackColor = true;
            this.cmdUcitavanjeServera.Click += new System.EventHandler(this.cmdUcitavanjeServera_Click);
            // 
            // cmdDodavanjeNovogServera
            // 
            this.cmdDodavanjeNovogServera.Location = new System.Drawing.Point(175, 15);
            this.cmdDodavanjeNovogServera.Name = "cmdDodavanjeNovogServera";
            this.cmdDodavanjeNovogServera.Size = new System.Drawing.Size(189, 36);
            this.cmdDodavanjeNovogServera.TabIndex = 1;
            this.cmdDodavanjeNovogServera.Text = "Dodavanje novog servera";
            this.cmdDodavanjeNovogServera.UseVisualStyleBackColor = true;
            this.cmdDodavanjeNovogServera.Click += new System.EventHandler(this.cmdDodavanjeNovogServera_Click);
            // 
            // cmdUcitavanjeAlijanse
            // 
            this.cmdUcitavanjeAlijanse.Location = new System.Drawing.Point(12, 61);
            this.cmdUcitavanjeAlijanse.Name = "cmdUcitavanjeAlijanse";
            this.cmdUcitavanjeAlijanse.Size = new System.Drawing.Size(189, 39);
            this.cmdUcitavanjeAlijanse.TabIndex = 2;
            this.cmdUcitavanjeAlijanse.Text = "Ucitavanje alijanse";
            this.cmdUcitavanjeAlijanse.UseVisualStyleBackColor = true;
            this.cmdUcitavanjeAlijanse.Click += new System.EventHandler(this.cmdUcitavanjeAlijanse_Click);
            // 
            // cmdUcitavanjeZadatka
            // 
            this.cmdUcitavanjeZadatka.Location = new System.Drawing.Point(12, 106);
            this.cmdUcitavanjeZadatka.Name = "cmdUcitavanjeZadatka";
            this.cmdUcitavanjeZadatka.Size = new System.Drawing.Size(189, 40);
            this.cmdUcitavanjeZadatka.TabIndex = 3;
            this.cmdUcitavanjeZadatka.Text = "Ucitavanje zadatka";
            this.cmdUcitavanjeZadatka.UseVisualStyleBackColor = true;
            this.cmdUcitavanjeZadatka.Click += new System.EventHandler(this.cmdUcitavanjeZadatka_Click);
            // 
            // cmdUcitavanjeLika
            // 
            this.cmdUcitavanjeLika.Location = new System.Drawing.Point(12, 152);
            this.cmdUcitavanjeLika.Name = "cmdUcitavanjeLika";
            this.cmdUcitavanjeLika.Size = new System.Drawing.Size(189, 34);
            this.cmdUcitavanjeLika.TabIndex = 4;
            this.cmdUcitavanjeLika.Text = "Ucitavanje lika";
            this.cmdUcitavanjeLika.UseVisualStyleBackColor = true;
            this.cmdUcitavanjeLika.Click += new System.EventHandler(this.cmdUcitavanjeLika_Click);
            // 
            // cmpKljucniPredmet
            // 
            this.cmpKljucniPredmet.Location = new System.Drawing.Point(12, 192);
            this.cmpKljucniPredmet.Name = "cmpKljucniPredmet";
            this.cmpKljucniPredmet.Size = new System.Drawing.Size(208, 37);
            this.cmpKljucniPredmet.TabIndex = 5;
            this.cmpKljucniPredmet.Text = "Ucitavanje kljucnog predmeta";
            this.cmpKljucniPredmet.UseVisualStyleBackColor = true;
            this.cmpKljucniPredmet.Click += new System.EventHandler(this.cmpKljucniPredmet_Click);
            // 
            // cmdBonusPIO
            // 
            this.cmdBonusPIO.Location = new System.Drawing.Point(12, 235);
            this.cmdBonusPIO.Name = "cmdBonusPIO";
            this.cmdBonusPIO.Size = new System.Drawing.Size(208, 51);
            this.cmdBonusPIO.TabIndex = 6;
            this.cmdBonusPIO.Text = "Ucitavanje bonus predmeta ili oruzija";
            this.cmdBonusPIO.UseVisualStyleBackColor = true;
            this.cmdBonusPIO.Click += new System.EventHandler(this.cmdBonusPIO_Click);
            // 
            // cmdIgracManyToOne
            // 
            this.cmdIgracManyToOne.Location = new System.Drawing.Point(12, 292);
            this.cmdIgracManyToOne.Name = "cmdIgracManyToOne";
            this.cmdIgracManyToOne.Size = new System.Drawing.Size(208, 40);
            this.cmdIgracManyToOne.TabIndex = 7;
            this.cmdIgracManyToOne.Text = "Igrac many-to-one";
            this.cmdIgracManyToOne.UseVisualStyleBackColor = true;
            this.cmdIgracManyToOne.Click += new System.EventHandler(this.cmdIgracManyToOne_Click);
            // 
            // cmdServerOneToMany
            // 
            this.cmdServerOneToMany.Location = new System.Drawing.Point(12, 347);
            this.cmdServerOneToMany.Name = "cmdServerOneToMany";
            this.cmdServerOneToMany.Size = new System.Drawing.Size(208, 56);
            this.cmdServerOneToMany.TabIndex = 8;
            this.cmdServerOneToMany.Text = "Server one-to-many";
            this.cmdServerOneToMany.UseVisualStyleBackColor = true;
            this.cmdServerOneToMany.Click += new System.EventHandler(this.cmdServerOneToMany_Click);
            // 
            // cmdAlijansaOneToMany
            // 
            this.cmdAlijansaOneToMany.Location = new System.Drawing.Point(12, 409);
            this.cmdAlijansaOneToMany.Name = "cmdAlijansaOneToMany";
            this.cmdAlijansaOneToMany.Size = new System.Drawing.Size(208, 35);
            this.cmdAlijansaOneToMany.TabIndex = 9;
            this.cmdAlijansaOneToMany.Text = "Alijansa one-to-many";
            this.cmdAlijansaOneToMany.UseVisualStyleBackColor = true;
            this.cmdAlijansaOneToMany.Click += new System.EventHandler(this.cmdAlijansaOneToMany_Click);
            // 
            // cmdDodavanjeIgraca
            // 
            this.cmdDodavanjeIgraca.Location = new System.Drawing.Point(239, 288);
            this.cmdDodavanjeIgraca.Name = "cmdDodavanjeIgraca";
            this.cmdDodavanjeIgraca.Size = new System.Drawing.Size(178, 48);
            this.cmdDodavanjeIgraca.TabIndex = 10;
            this.cmdDodavanjeIgraca.Text = "Dodavanje novog igraca";
            this.cmdDodavanjeIgraca.UseVisualStyleBackColor = true;
            this.cmdDodavanjeIgraca.Click += new System.EventHandler(this.cmdDodavanjeIgraca_Click);
            // 
            // cmdManyToManyAlijanse
            // 
            this.cmdManyToManyAlijanse.Location = new System.Drawing.Point(12, 450);
            this.cmdManyToManyAlijanse.Name = "cmdManyToManyAlijanse";
            this.cmdManyToManyAlijanse.Size = new System.Drawing.Size(208, 41);
            this.cmdManyToManyAlijanse.TabIndex = 11;
            this.cmdManyToManyAlijanse.Text = "Many-To-Many Alijanse";
            this.cmdManyToManyAlijanse.UseVisualStyleBackColor = true;
            this.cmdManyToManyAlijanse.Click += new System.EventHandler(this.cmdManyToManyAlijanse_Click);
            // 
            // cmdGrupniZadaci
            // 
            this.cmdGrupniZadaci.Location = new System.Drawing.Point(12, 506);
            this.cmdGrupniZadaci.Name = "cmdGrupniZadaci";
            this.cmdGrupniZadaci.Size = new System.Drawing.Size(208, 49);
            this.cmdGrupniZadaci.TabIndex = 12;
            this.cmdGrupniZadaci.Text = "Grupni zadaci";
            this.cmdGrupniZadaci.UseVisualStyleBackColor = true;
            this.cmdGrupniZadaci.Click += new System.EventHandler(this.cmdGrupniZadaci_Click);
            // 
            // cmdIndividualniZadaci
            // 
            this.cmdIndividualniZadaci.Location = new System.Drawing.Point(17, 572);
            this.cmdIndividualniZadaci.Name = "cmdIndividualniZadaci";
            this.cmdIndividualniZadaci.Size = new System.Drawing.Size(203, 44);
            this.cmdIndividualniZadaci.TabIndex = 13;
            this.cmdIndividualniZadaci.Text = "Individualni zadaci";
            this.cmdIndividualniZadaci.UseVisualStyleBackColor = true;
            this.cmdIndividualniZadaci.Click += new System.EventHandler(this.cmdIndividualniZadaci_Click);
            // 
            // cmdDodajSegrta
            // 
            this.cmdDodajSegrta.Location = new System.Drawing.Point(17, 636);
            this.cmdDodajSegrta.Name = "cmdDodajSegrta";
            this.cmdDodajSegrta.Size = new System.Drawing.Size(203, 50);
            this.cmdDodajSegrta.TabIndex = 14;
            this.cmdDodajSegrta.Text = "Dodaj segrta";
            this.cmdDodajSegrta.UseVisualStyleBackColor = true;
            this.cmdDodajSegrta.Click += new System.EventHandler(this.cmdDodajSegrta_Click);
            // 
            // cmdPregledOpreme
            // 
            this.cmdPregledOpreme.Location = new System.Drawing.Point(460, 22);
            this.cmdPregledOpreme.Name = "cmdPregledOpreme";
            this.cmdPregledOpreme.Size = new System.Drawing.Size(134, 33);
            this.cmdPregledOpreme.TabIndex = 15;
            this.cmdPregledOpreme.Text = "Oprema pregled";
            this.cmdPregledOpreme.UseVisualStyleBackColor = true;
            this.cmdPregledOpreme.Click += new System.EventHandler(this.cmdPregledOpreme_Click);
            // 
            // cmdProveraAlternativeC
            // 
            this.cmdProveraAlternativeC.Location = new System.Drawing.Point(460, 61);
            this.cmdProveraAlternativeC.Name = "cmdProveraAlternativeC";
            this.cmdProveraAlternativeC.Size = new System.Drawing.Size(150, 50);
            this.cmdProveraAlternativeC.TabIndex = 16;
            this.cmdProveraAlternativeC.Text = "Provera alternative C nad klasom Lik";
            this.cmdProveraAlternativeC.UseVisualStyleBackColor = true;
            this.cmdProveraAlternativeC.Click += new System.EventHandler(this.cmdProveraAlternativeC_Click);
            // 
            // cmdDodavanjeLika
            // 
            this.cmdDodavanjeLika.Location = new System.Drawing.Point(642, 61);
            this.cmdDodavanjeLika.Name = "cmdDodavanjeLika";
            this.cmdDodavanjeLika.Size = new System.Drawing.Size(178, 50);
            this.cmdDodavanjeLika.TabIndex = 17;
            this.cmdDodavanjeLika.Text = "Dodavanje lika";
            this.cmdDodavanjeLika.UseVisualStyleBackColor = true;
            this.cmdDodavanjeLika.Click += new System.EventHandler(this.cmdDodavanjeLika_Click);
            // 
            // frmProveraMapiranja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 696);
            this.Controls.Add(this.cmdDodavanjeLika);
            this.Controls.Add(this.cmdProveraAlternativeC);
            this.Controls.Add(this.cmdPregledOpreme);
            this.Controls.Add(this.cmdDodajSegrta);
            this.Controls.Add(this.cmdIndividualniZadaci);
            this.Controls.Add(this.cmdGrupniZadaci);
            this.Controls.Add(this.cmdManyToManyAlijanse);
            this.Controls.Add(this.cmdDodavanjeIgraca);
            this.Controls.Add(this.cmdAlijansaOneToMany);
            this.Controls.Add(this.cmdServerOneToMany);
            this.Controls.Add(this.cmdIgracManyToOne);
            this.Controls.Add(this.cmdBonusPIO);
            this.Controls.Add(this.cmpKljucniPredmet);
            this.Controls.Add(this.cmdUcitavanjeLika);
            this.Controls.Add(this.cmdUcitavanjeZadatka);
            this.Controls.Add(this.cmdUcitavanjeAlijanse);
            this.Controls.Add(this.cmdDodavanjeNovogServera);
            this.Controls.Add(this.cmdUcitavanjeServera);
            this.Name = "frmProveraMapiranja";
            this.Text = "Provera mapiranja";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdUcitavanjeServera;
        private System.Windows.Forms.Button cmdDodavanjeNovogServera;
        private System.Windows.Forms.Button cmdUcitavanjeAlijanse;
        private System.Windows.Forms.Button cmdUcitavanjeZadatka;
        private System.Windows.Forms.Button cmdUcitavanjeLika;
        private System.Windows.Forms.Button cmpKljucniPredmet;
        private System.Windows.Forms.Button cmdBonusPIO;
        private System.Windows.Forms.Button cmdIgracManyToOne;
        private System.Windows.Forms.Button cmdServerOneToMany;
        private System.Windows.Forms.Button cmdAlijansaOneToMany;
        private System.Windows.Forms.Button cmdDodavanjeIgraca;
        private System.Windows.Forms.Button cmdManyToManyAlijanse;
        private System.Windows.Forms.Button cmdGrupniZadaci;
        private System.Windows.Forms.Button cmdIndividualniZadaci;
        private System.Windows.Forms.Button cmdDodajSegrta;
        private System.Windows.Forms.Button cmdPregledOpreme;
        private System.Windows.Forms.Button cmdProveraAlternativeC;
        private System.Windows.Forms.Button cmdDodavanjeLika;
    }
}

