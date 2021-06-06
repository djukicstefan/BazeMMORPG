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
    public partial class AlijansaForma : Form
    {
        private string naziv;
        private IgracForma parent;
        private List<DTOs.GrupniZadaciBasic> listaZadataka;

        public AlijansaForma(IgracForma parent, string naziv)
        {
            InitializeComponent();

            this.naziv = naziv;
            this.parent = parent;
        }

        private void AlijansaForma_Load(object sender, EventArgs e)
        {
            DTOs.AlijansaBasic a = DTOManager.VratiAlijansu(naziv);

            Osvezi();
            UcitajZadatke();

            lblNaziv.Text = naziv;

            txtNaziv.Text = a.Naziv;
            numMaxIgraci.Value = a.MaxIgraca;
            numMinIgraci.Value = a.MinIgraca;
            numBonusIskustvo.Value = a.BonusIskustvo;
            numBonusZdravlje.Value = a.BonusZdravlje;
        }

        private void Osvezi()
        {
            listMoguciSavezi.Items.Clear();
            listSavezi.Items.Clear();

            List<DTOs.AlijansaBasic> alijanseUSavezu = DTOManager.VratiAlijanseUSavezu(naziv);
            List<DTOs.AlijansaBasic> ostaleAlijanse = DTOManager.VratiAlijanse();

            listSavezi.Items.AddRange(alijanseUSavezu.Select(x => x.Naziv).ToArray());
            foreach (DTOs.AlijansaBasic al in ostaleAlijanse)
            {
                bool find = listSavezi.Items.Contains(al.Naziv) || al.Naziv == naziv;
                if (!find)
                    listMoguciSavezi.Items.Add(al.Naziv);
            }
        }

        private void btnSklopiSavez_Click(object sender, EventArgs e)
        {
            DTOManager.SklopiSavez(naziv, listMoguciSavezi.SelectedItem.ToString());
            Osvezi();
        }

        private void btnPrekiniSavez_Click(object sender, EventArgs e)
        {
            DTOManager.PrekiniSavez(naziv, listSavezi.SelectedItem.ToString());
            Osvezi();
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            DTOManager.IzmeniAlijansu(new DTOs.AlijansaBasic(
                    naziv,
                    (int)numMaxIgraci.Value,
                    (int)numMinIgraci.Value,
                    (int)numBonusIskustvo.Value,
                    (int)numBonusZdravlje.Value
                ));
            Osvezi();
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            DTOManager.ObrisiAlijansu(naziv);
         
            parent.UcitajIgraca();
            parent.UcitajAlijanse();
            
            Close();
        }

        public void UcitajZadatke()
        {
            listaZadataka = DTOManager.VratiGrupneZadatkeAlijanse(naziv);
            if (listaZadataka.Count > 0)
            {
                livGrupniZadatak.Items.Clear();

                foreach (DTOs.GrupniZadaciBasic gzd in listaZadataka)
                {
                    ListViewItem item = new ListViewItem(new string[] {
                        gzd.Id.ToString(),
                        gzd.ZadatakKojiSeResava.Id.ToString(),
                        gzd.VremeResavanja,
                        gzd.ZadatakKojiSeResava.BonusIskustva.ToString()
                    });

                    livGrupniZadatak.Items.Add(item);
                }
            }
        }

        private void btnResiZadatak_Click(object sender, EventArgs e)
        {
            DTOManager.ResiGrupniZadatak(int.Parse(livGrupniZadatak.SelectedItems[0].SubItems[0]));
            UcitajZadatke();
        }
    }
}
