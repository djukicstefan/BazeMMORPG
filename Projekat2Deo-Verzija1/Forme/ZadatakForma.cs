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
    public partial class ZadatakForma : Form
    {
        public AlijansaForma parentAlijansa;
        public IgracForma parentIgrac;
        private string nazivAlijanse;
        private int idIgraca;

        public ZadatakForma(AlijansaForma parent, string nazivAlijanse)
        {
            InitializeComponent();

            parentAlijansa = parent;
            this.nazivAlijanse = nazivAlijanse;
        }

        public ZadatakForma(IgracForma parent, int idIgraca)
        {
            InitializeComponent();

            parentIgrac = parent;
            this.idIgraca = idIgraca;
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            DTOManager.NapraviZadatak((int)numBonus.Value);
            if (parentAlijansa != null)
                (new GIZadatakForma(this, nazivAlijanse)).ShowDialog();
            else
                (new GIZadatakForma(this, idIgraca)).ShowDialog();
            Close();
        }
    }
}
