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
    public partial class RegistracijaForma : Form
    {
        public enum Rasa { Čovek, Patuljak, Ork, Vilenjak, Demon };

        public RegistracijaForma()
        {
            InitializeComponent();
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

            //DTOs.LikBasic lik = NapraviLika((Rasa)cmbRasa.SelectedIndex);
            string rasa = cmbRasa.Text;

            DTOManager.DodajIgraca(igrac, server, rasa);



            MessageBox.Show("Vas nalog je uspesno kreiran!");

            this.Close();
        }

      /*  private DTOs.LikBasic NapraviLika(Rasa r)
        {
            DTOs.LikBasic lik = null;

            switch (r)
            {
                case Rasa.Čovek:
                    lik = new DTOs.LikBasic.ČoverBasic();
                    break;

                case Rasa.Patuljak:
                    break;

                case Rasa.Ork:
                    break;

                case Rasa.Vilenjak:
                    break;

                case Rasa.Demon:
                    break;
            }

            return lik;
        }*/
    }
}
