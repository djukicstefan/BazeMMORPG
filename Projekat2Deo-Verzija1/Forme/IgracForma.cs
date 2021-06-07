using Projekat2Deo_Verzija1.Entiteti;
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
    public partial class IgracForma : Form
    {
        private DTOs.IgracBasic igrac;
        private List<DTOs.SegrtBasic> TrenutniSegrti;
        private List<DTOs.BonusPredmetiIOruzijaPregled> BonusOpremaLika;
        private List<DTOs.KljucniPredmetiPregled> KljucnaOpremaLika;
        private List<DTOs.IndividualniZadaciBasic> listaZadataka;
        private List<DTOs.AlijansaBasic> alijanse;

        public IgracForma()
        {
            InitializeComponent();
        }

        public IgracForma(DTOs.IgracBasic i)
        {
            InitializeComponent();
            igrac = i;
            UcitajPodatke();
        }

        public void UcitajPodatke()
        {
            UcitajIgraca();
            UcitajSegrte();
            UcitajInventar();
            UcitajZadatke();
            UcitajAlijanse();
        }

        public void UcitajZadatke()
        {
            listaZadataka = DTOManager.VratiIndividualneZadatkeIgraca(igrac.Id);
            livIndividualniZadaci.Items.Clear();
            
            if (listaZadataka.Count > 0)
            {
                foreach (DTOs.IndividualniZadaciBasic izd in listaZadataka)
                {
                    ListViewItem item = new ListViewItem(new string[] {
                        izd.Id.ToString(),
                        izd.ZadatakKojiSeResava.Id.ToString(),
                        izd.VremeResavanja,
                        izd.ZadatakKojiSeResava.BonusIskustva.ToString()
                    });

                    livIndividualniZadaci.Items.Add(item);
                }
            }
        }

        public void UcitajInventar()
        {
            BonusOpremaLika = DTOManager.VratiBonusPredmeteIOruzijaLika(igrac.KontroliseLika.Id);
            KljucnaOpremaLika = DTOManager.VratiKljucnePredmeteLika(igrac.KontroliseLika.Id);

            livBonusOprema.Items.Clear();
            livKljucnaOprema.Items.Clear();
            
            if (BonusOpremaLika.Count > 0)
            {
                foreach (DTOs.BonusPredmetiIOruzijaPregled bo in BonusOpremaLika)
                {
                    ListViewItem item = new ListViewItem(new string[] {
                        bo.Id.ToString(),
                        bo.BrojIskustvenihPoena.ToString(),
                        bo.Rasa,
                        bo.PPredmet.ToString()
                    });

                    livBonusOprema.Items.Add(item);
                }
            }


            if (KljucnaOpremaLika.Count > 0)
            {
                foreach (DTOs.KljucniPredmetiPregled ko in KljucnaOpremaLika)
                {
                    ListViewItem item = new ListViewItem(new string[] {
                        ko.Id.ToString(),
                        ko.Naziv,
                        ko.Opis,
                        igrac.Nadimak
                    });

                    livKljucnaOprema.Items.Add(item);
                }
            }
        }

        public void UcitajIgraca()
        {
            igrac = DTOManager.PostojiIgrac(igrac.Nadimak, igrac.Lozinka);

            lblIme.Text = $"Ime: {igrac.Ime}";
            lblPrezime.Text = $"Prezime: {igrac.Prezime}";
            lblPol.Text = $"Pol: {igrac.Pol}";
            lblUzrast.Text = $"Uzrast: {igrac.Uzrast}";
            lblNadimakServer.Text = $"{igrac.Nadimak}@{igrac.PovezanNaServer.Naziv}";


            lblRasa.Text = $"Rasa: {igrac.KontroliseLika.Rasa}";
            lblZlato.Text = $"Zlato: {igrac.KontroliseLika.KolicinaZlata}";
            lblIskustvo.Text = $"Iskustvo: {igrac.KontroliseLika.Iskustvo}";
            lblZdravlje.Text = $"Zdravlj: {igrac.KontroliseLika.Zdravlje}";
            lblZamor.Text = $"Zamor: {igrac.KontroliseLika.StepenZamora}";

            if (lblRasa.Text == "Čovek")
                lblSpecAtr.Text = $"Veština skrivanja: {igrac.KontroliseLika.VestinaSkrivanja}";
            else if (lblRasa.Text == "Patuljak" || lblRasa.Text == "Ork")
                lblSpecAtr.Text = $"Tip oružja: {igrac.KontroliseLika.TipOruzja}";
            else
                lblSpecAtr.Text = $"Mana: {igrac.KontroliseLika.Mana}";

            lblAlijansa.Text = igrac.PripadaAlijansi != null ? igrac.PripadaAlijansi.Naziv : "Nema alijanse";
        }

        public void UcitajAlijanse()
        {
            alijanse = DTOManager.VratiAlijanse();
            livAlijanse.Items.Clear();
            
            if (alijanse.Count > 0)
            {
                foreach (DTOs.AlijansaBasic al in alijanse)
                {
                    if (igrac.PripadaAlijansi != null && igrac.PripadaAlijansi.Naziv == al.Naziv) continue;
                    ListViewItem item = new ListViewItem(new string[] {
                        al.Naziv,
                        al.MaxIgraca.ToString(),
                        al.MinIgraca.ToString(),
                        al.BonusIskustvo.ToString(),
                        al.BonusZdravlje.ToString()
                    });

                    livAlijanse.Items.Add(item);
                }
            }
            btnPridruziSeAlijansi.Enabled = igrac.PripadaAlijansi == null;
            btnNapustiAlijansu.Enabled = !btnPridruziSeAlijansi.Enabled;
            btnUpravljajAlijansom.Enabled = btnNapustiAlijansu.Enabled;
        }

        public void UcitajSegrte()
        {
            TrenutniSegrti = DTOManager.VratiSegrte(igrac.KontroliseLika.Id);
            livTrenutniSegrti.Items.Clear();
            
            if (TrenutniSegrti.Count > 0)
            {
                foreach (DTOs.SegrtBasic sb in TrenutniSegrti)
                {
                    ListViewItem item = new ListViewItem(new string[] {
                        sb.Id.Gazda.Id.ToString(),
                        sb.Id.Ime,
                        sb.Rasa,
                        sb.BonusUSkrivanju.ToString()
                    });

                    livTrenutniSegrti.Items.Add(item);
                }
            }
        }

        private void btnOtpustiSegrta_Click(object sender, EventArgs e)
        {
            DTOs.SegrtIdBasic segId = new DTOs.SegrtIdBasic();
            segId.Gazda.Id = int.Parse(livTrenutniSegrti.SelectedItems[0].SubItems[0].Text);
            segId.Ime = livTrenutniSegrti.SelectedItems[0].SubItems[1].Text;

            DTOManager.OtpustiSegrta(segId);

            UcitajPodatke();
        }

        private void btnZaposliZegrta_Click(object sender, EventArgs e)
        {
            (new SegrtForma(this, igrac.Id)).ShowDialog();
        }

        private void btnNapustiAlijansu_Click(object sender, EventArgs e)
        {
            DTOManager.NapustiAlijansu(igrac.PripadaAlijansi.Naziv, igrac.Id);
            
            UcitajIgraca();
            UcitajAlijanse();
        }

        private void btnPridruziSeAlijansi_Click(object sender, EventArgs e)
        {
            DTOManager.PridruziSeAlijansi(
                livAlijanse.SelectedItems[0].SubItems[0].Text,
                igrac.Id
            );

            UcitajIgraca();
            UcitajAlijanse();
        }

        private void btnUpravljajAlijansom_Click(object sender, EventArgs e)
        {
            (new AlijansaForma(this, igrac.PripadaAlijansi.Naziv)).ShowDialog();
        }

        private void btnResiZadatak_Click(object sender, EventArgs e)
        {
            DTOManager.ResiIndividualniZadatak(int.Parse(livIndividualniZadaci.SelectedItems[0].SubItems[0].Text));
            UcitajIgraca();
            UcitajZadatke();
        }

        private void btnDodajZadatak_Click(object sender, EventArgs e)
        {
            (new ZadatakForma(this, igrac.Id)).ShowDialog();
        }

        private void btnDodajOpremu_Click(object sender, EventArgs e)
        {
            (new OpremaIPredmetiForma(this, igrac.Id, igrac.Nadimak)).ShowDialog();
            UcitajInventar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DTOManager.ZavrsiSesiju(igrac);
            Close();
        }

        private void btnOslobodiBonusOpremu_Click(object sender, EventArgs e)
        {
            DTOManager.OslobodiBonusOpremu(igrac.Id, int.Parse(livBonusOprema.SelectedItems[0].SubItems[0].Text));
            UcitajInventar();
        }

        private void btnOslobodiKljucnuOpremu_Click(object sender, EventArgs e)
        {
            DTOManager.OslobodiKljucnuOpremu(igrac.Id, int.Parse(livKljucnaOprema.SelectedItems[0].SubItems[0].Text));
            UcitajInventar();
        }

        private void btnDodajAlijansu_Click(object sender, EventArgs e)
        {
            if(lblAlijansa.Text == "Nema alijanse")
            {
                (new NovaAlijansaForma(this, igrac.Id)).ShowDialog();
            }
            else
            {
                MessageBox.Show($"Morate prvo napustiti alijansu kojoj ste priključeni!");
            }
        }
    }
}
