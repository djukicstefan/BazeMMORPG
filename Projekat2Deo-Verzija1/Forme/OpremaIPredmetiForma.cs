using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekat2Deo_Verzija1.Forme
{
    public partial class OpremaIPredmetiForma : Form
    {
        private IgracForma parent;
        private string nadimakVlasnika;
        private int idIgraca;

        public OpremaIPredmetiForma(IgracForma parent, int idIgraca, string nadimakVlasnika)
        {
            InitializeComponent();
            this.parent = parent;
            this.idIgraca = idIgraca;
            this.nadimakVlasnika = nadimakVlasnika;
        }

        private void btnDodajKljucni_Click(object sender, EventArgs e)
        {
            DTOManager.DodajKljucniPredmet(txtNaziv.Text, txtOpis.Text, nadimakVlasnika, idIgraca, int.Parse(cmbZadId1.SelectedItem.ToString()));
            Close();
        }

        private void OpremaIPredmetiForma_Load(object sender, EventArgs e)
        {
            DTOManager.VratiZadatke().ForEach(x => {
                cmbZadId1.Items.Add(x);
                cmbZadId2.Items.Add(x);
            });
            
            cmbRasa.Items.Clear();
            foreach (Rasa r in Enum.GetValues(typeof(Rasa)))
            {
                cmbRasa.Items.Add(r.ToString());
            }
            cmbRasa.SelectedIndex = 0;

            cmbPP.Items.Clear();
            cmbPP.Items.Add("D");
            cmbPP.Items.Add("N");
            cmbPP.SelectedIndex = 0;
        }

        private void btnDodajPredmetOruzje_Click(object sender, EventArgs e)
        {
            DTOManager.DodajBonusPredmetiOruzje((int)numPoeni.Value, cmbRasa.SelectedItem.ToString(), char.Parse(cmbPP.SelectedItem.ToString()), idIgraca, int.Parse(cmbZadId2.SelectedItem.ToString()));
            Close();
        }
    }
}
