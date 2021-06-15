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
    public partial class SegrtForma : Form
    {
        private int likId;
        private IgracForma parent;

        public SegrtForma(IgracForma parent, int likId)
        {
            InitializeComponent();

            foreach (Rasa r in Enum.GetValues(typeof(Rasa)))
            {
                cmbRasa.Items.Add(r.ToString());
            }
            cmbRasa.SelectedIndex = 0;

            this.likId = likId;
            this.parent = parent;
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            var segrtId = new DTOs.SegrtIdBasic();
            segrtId.Gazda.Id = likId;
            segrtId.Ime = txtIme.Text;

            DTOs.SegrtBasic seg = new DTOs.SegrtBasic(
                    segrtId,
                    cmbRasa.Text,
                    (int)numBonusUSkirvanju.Value
                );

            DTOManager.DodajSegrta(seg);
            parent.UcitajSegrte();
            Close();
        }
    }
}
