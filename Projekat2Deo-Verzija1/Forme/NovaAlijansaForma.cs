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
    public partial class NovaAlijansaForma : Form
    {
        private IgracForma parent;
        private int IdIgraca; 
        public NovaAlijansaForma(IgracForma parent, int idIGraca)
        {
            InitializeComponent();
            this.parent = parent;
            this.IdIgraca = idIGraca;
        }

        private void btnPotvrdi_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            DTOs.AlijansaPregled a = new DTOs.AlijansaPregled();
            a.Naziv = txtNazivAlijanse.Text;
            a.MaxIgraca = (int)numMaxIgraci.Value;
            a.MinIgraca = 1;
            a.BonusIskustvo = r.Next() % 100000;
            a.BonusZdravlje = r.Next() % 100000;
            DTOManager.DodajAlijansu(a, this.IdIgraca);

            parent.UcitajIgraca();
            parent.UcitajAlijanse();

            Close();
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
