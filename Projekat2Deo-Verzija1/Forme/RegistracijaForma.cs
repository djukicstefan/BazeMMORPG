using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Projekat2Deo_Verzija1;

namespace Projekat2Deo_Verzija1.Forme
{
    public enum Rasa { Čovek, Patuljak, Ork, Vilenjak, Demon };
    
    public partial class RegistracijaForma : Form
    {
        private frmPocetnaStranica parent;

        public RegistracijaForma(frmPocetnaStranica parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void RegistracijaForma_Load(object sender, EventArgs e)
        {
            cmbPol.Items.Add("M");
            cmbPol.Items.Add("Ž");
            cmbPol.SelectedIndex = 0;

            List<DTOs.ServerBasic> serveri = DTOManager.VratiServere();
            foreach(DTOs.ServerBasic ser in serveri)
            {
                cmbServer.Items.Add(ser.Naziv);
            }
            cmbServer.SelectedIndex = 0;

            foreach (Rasa r in Enum.GetValues(typeof(Rasa)))
            {
                cmbRasa.Items.Add(r.ToString());
            }
            cmbRasa.SelectedIndex = 0;
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPotvrdi_Click(object sender, EventArgs e)
        {
            DTOs.IgracBasic igrac = new DTOs.IgracBasic();

            igrac.Nadimak = txtNadimak.Text;
            igrac.Lozinka = txtLozinka.Text;
            igrac.Ime = txtIme.Text;
            igrac.Prezime = txtPrezime.Text;
            igrac.Pol = Char.Parse(cmbPol.Text);
            igrac.Uzrast = (int)nudUzdrast.Value;
            String server = cmbServer.Text;

            string rasa = cmbRasa.Text;

            bool postoji = DTOManager.ProveriDaLiPostojiTajNadimak(igrac.Nadimak);

            if (postoji)
            {
                MessageBox.Show($"Izabrali ste već postojeći nadimak. Molimo izaberite neki drugi!");
                Close();
            }
            else
            {
                DTOManager.DodajIgraca(igrac, server, rasa);

                MessageBox.Show("Vas nalog je uspesno kreiran!");

                parent.UcitajServere();
                this.Close();
            }
            
        }

    }
}
