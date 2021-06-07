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
        public AlijansaForma parent;
        private string nazivAlijanse;

        public ZadatakForma(AlijansaForma parent, string nazivAlijanse)
        {
            InitializeComponent();

            this.parent = parent;
            this.nazivAlijanse = nazivAlijanse;
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            DTOManager.NapraviZadatak((int)numBonus.Value);
            (new GrupniZadatakForma(this, nazivAlijanse)).ShowDialog();
            Close();
        }
    }
}
