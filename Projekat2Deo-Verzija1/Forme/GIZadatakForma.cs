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
    public partial class GIZadatakForma : Form
    { 
        private ZadatakForma parent;
        private string nazivAlijanse = "";
        private int idIgraca = -1;

        public GIZadatakForma(ZadatakForma parent, string nazivAlijanse)
        {
            InitializeComponent();

            this.parent = parent;
            this.nazivAlijanse = nazivAlijanse;
        }

        public GIZadatakForma(ZadatakForma parent, int idIgraca)
        {
            InitializeComponent();

            this.parent = parent;
            this.idIgraca = idIgraca;
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(nazivAlijanse))
            { 
                DTOManager.DodajGrupniZadatak(nazivAlijanse, txtVreme.Text, int.Parse(cmbZadaci.SelectedItem.ToString()));
                parent.parentAlijansa.UcitajZadatke();
            }
            else if (idIgraca > -1)
            {
                DTOManager.DodajIndividualniZadatak(idIgraca, txtVreme.Text, int.Parse(cmbZadaci.SelectedItem.ToString()));
                parent.parentIgrac.UcitajZadatke();
            }

            Close();
            parent.Close();
        }

        private void GrupniZadatakForma_Load(object sender, EventArgs e)
        {
            DTOManager.VratiZadatke().ForEach(x => cmbZadaci.Items.Add(x));
        }
    }
}
