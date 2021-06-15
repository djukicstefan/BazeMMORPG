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
    public partial class ServerForma : Form
    {
        private frmPocetnaStranica parent;
        public ServerForma(frmPocetnaStranica parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnPotvrdi_Click(object sender, EventArgs e)
        {
            DTOManager.DodajServer(txtNazivServera.Text);
            parent.UcitajServere();
            Close();
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
