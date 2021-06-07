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
    public partial class GrupniZadatakForma : Form
    { 
        private ZadatakForma parent;
        private string nazivAlijanse;

        public GrupniZadatakForma(ZadatakForma parent, string nazivAlijanse)
        {
            InitializeComponent();

            this.parent = parent;
            this.nazivAlijanse = nazivAlijanse;
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            DTOManager.DodajGrupniZadatak(nazivAlijanse, txtVreme.Text, int.Parse(cmbZadaci.SelectedItem.ToString()));
            Close();
            parent.Close();
            parent.parent.UcitajZadatke();
        }

        private void GrupniZadatakForma_Load(object sender, EventArgs e)
        {
            DTOManager.VratiZadatke().ForEach(x => cmbZadaci.Items.Add(x));
        }
    }
}
