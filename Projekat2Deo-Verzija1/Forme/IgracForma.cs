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
        private List<DTOs.BonusPredmetiIOruzijaBasic> BonusOpremaLika;
        private List<DTOs.KljucniPredmetiBasic> KljucnaOpremaLika;
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
            if (listaZadataka.Count > 0)
            {
                livIndividualniZadaci.Items.Clear();

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

            if (BonusOpremaLika.Count > 0)
            {
                livBonusOprema.Items.Clear();

                foreach (DTOs.BonusPredmetiIOruzijaBasic bo in BonusOpremaLika)
                {
                    ListViewItem item = new ListViewItem(new string[] {
                        bo.BrojIskustvenihPoena.ToString(),
                        bo.Rasa,
                        bo.PPredmet.ToString()
                    });

                    livBonusOprema.Items.Add(item);
                }
            }
            if (KljucnaOpremaLika.Count > 0)
            {
                livKljucnaOprema.Items.Clear();

                foreach (DTOs.KljucniPredmetiBasic ko in KljucnaOpremaLika)
                {
                    ListViewItem item = new ListViewItem(new string[] {
                        ko.Naziv,
                        ko.Opis,
                        ko.NadimakVlasnika
                    });

                    livKljucnaOprema.Items.Add(item);
                }
            }
        }

        public void UcitajIgraca()
        {
            igrac = DTOManager.PostojiIgrac(igrac.Nadimak, igrac.Lozinka);

            lblIme.Text = igrac.Ime;
            lblPrezime.Text = igrac.Prezime;
            lblPol.Text = igrac.Pol.ToString();
            lblUzrast.Text = igrac.Uzrast.ToString();
            lblNadimakServer.Text = $"{igrac.Nadimak}@{igrac.PovezanNaServer.Naziv}";


            lblRasa.Text = igrac.KontroliseLika.Rasa;
            lblZlato.Text = igrac.KontroliseLika.KolicinaZlata.ToString();
            lblIskustvo.Text = igrac.KontroliseLika.Iskustvo.ToString();
            lblZdravlje.Text = igrac.KontroliseLika.Zdravlje.ToString();
            lblZamor.Text = igrac.KontroliseLika.StepenZamora.ToString();
            if (lblRasa.Text == "Čovek")
                lblSpecAtr.Text = igrac.KontroliseLika.VestinaSkrivanja.ToString();
            else if (lblRasa.Text == "Patuljak" || lblRasa.Text == "Ork")
                lblSpecAtr.Text = igrac.KontroliseLika.TipOruzja.ToString();
            else
                lblSpecAtr.Text = igrac.KontroliseLika.Mana.ToString();

            lblAlijansa.Text = igrac.PripadaAlijansi != null ? igrac.PripadaAlijansi.Naziv : "Nema alijanse";
        }

        public void UcitajAlijanse()
        {
            alijanse = DTOManager.VratiAlijanse();
            if (alijanse.Count > 0)
            {
                livAlijanse.Items.Clear();

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
            if (TrenutniSegrti.Count > 0)
            {
                livTrenutniSegrti.Items.Clear();

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
    }
}
