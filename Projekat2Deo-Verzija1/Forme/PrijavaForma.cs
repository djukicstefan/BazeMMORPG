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
    public partial class PrijavaForma : Form
    {
        public PrijavaForma()
        {
            InitializeComponent();
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPotvrdi_Click(object sender, EventArgs e)
        {
            if(DTOManager.PostojiIgrac(txtNadimak.Text, txtLozinka.Text))
            {
                MessageBox.Show($"Dobrodosli nazad!");

            }
            else
            {
                MessageBox.Show($"Neki od parametara nisu validni!");
                this.Close();
            }
        }
    }
}
