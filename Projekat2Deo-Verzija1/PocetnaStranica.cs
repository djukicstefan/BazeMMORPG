using Projekat2Deo_Verzija1.Entiteti;
using Projekat2Deo_Verzija1.Forme;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekat2Deo_Verzija1
{
    public partial class frmPocetnaStranica : Form
    {
        public frmPocetnaStranica()
        {
            InitializeComponent();
        }

        public void UcitajServere()
        {
            int ukupno = 0;
            List<DTOs.ServerBasic> serveri = DTOManager.VratiServere();
            livServeri.Items.Clear();
            
            foreach(DTOs.ServerBasic ser in serveri)
            {
                int brojIgraca;
                brojIgraca = DTOManager.VratiBrojIgraca(ser.Id);
                ListViewItem item = new ListViewItem(new string[] { ser.Id.ToString(), ser.Naziv.ToString(), brojIgraca.ToString() });
                livServeri.Items.Add(item);
                ukupno += brojIgraca;
            }
            lblUkupanBrojIgraca.Text = ukupno.ToString();
        }

        private void btnRegistracija_Click(object sender, EventArgs e)
        {
            RegistracijaForma form = new RegistracijaForma(this);
            form.ShowDialog();
            
        }

        private void btnPrijava_Click(object sender, EventArgs e)
        {
            PrijavaForma form = new PrijavaForma(this);
            form.ShowDialog();
        }

        private void frmPocetnaStranica_Load(object sender, EventArgs e)
        {
            UcitajServere();
        }

        private void btnDodavanjeServera_Click(object sender, EventArgs e)
        {
            ServerForma form = new ServerForma(this);
            form.ShowDialog();
        }
    }
}
