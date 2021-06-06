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

        private void UcitajPodatke()
        {
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
            else if(lblRasa.Text == "Patuljak" || lblRasa.Text == "Ork")
                lblSpecAtr.Text = igrac.KontroliseLika.TipOruzja.ToString();
            else
                lblSpecAtr.Text = igrac.KontroliseLika.Mana.ToString();

            if (igrac.PripadaAlijansi != null)
                lblAlijansa.Text = igrac.PripadaAlijansi.Naziv;

            TrenutniSegrti = DTOManager.VratiSegrte(igrac.KontroliseLika.Id);
            if(TrenutniSegrti.Count > 0)
            {
                foreach(DTOs.SegrtBasic s in TrenutniSegrti)
                {
                    listTrenutniSegrti.Items.Add(s);
                }
            }

  
            BonusOpremaLika = DTOManager.VratiBonusPredmeteIOruzijaLika(igrac.KontroliseLika.Id);
            KljucnaOpremaLika = DTOManager.VratiKljucnePredmeteLika(igrac.KontroliseLika.Id);
            if(BonusOpremaLika.Count > 0)
            {
                listInventar.Items.AddRange(BonusOpremaLika.ToArray());
            }
            if(KljucnaOpremaLika.Count > 0)
            {
                listInventar.Items.AddRange(KljucnaOpremaLika.ToArray());
            }


            listaZadataka = DTOManager.VratiIndividualneZadatkeIgraca(igrac.Id);
            if(listaZadataka.Count > 0)
            {
                listIndividualniZadaci.Items.AddRange(listaZadataka.ToArray());
            }

            List<DTOs.SegrtBasic> segrti = DTOManager.VratiSegrte();
            foreach(DTOs.SegrtBasic seg in segrti)
            {
                listSegrti.Items.Add(seg);
            }

            List<DTOs.AlijansaBasic> alijanse = DTOManager.VratiAlijanse();
            foreach(DTOs.AlijansaBasic a in alijanse)
            {
                listAlijanse.Items.Add(a);
            }



            livIndividualniZadaci.Items.Clear();

            foreach (DTOs.IndividualniZadaciBasic izd in listaZadataka)
            {
                //int brojIgraca;
                //brojIgraca = DTOManager.VratiBrojIgraca(ser.Id);
                ListViewItem item = new ListViewItem(new string[] { izd.Id.ToString(), izd.IgracKojiResava.Id.ToString(), izd.ZadatakKojiSeResava.Id.ToString(), izd.VremeResavanja.ToString() });
                livIndividualniZadaci.Items.Add(item);
                //ukupno += brojIgraca;
            }
            //lblUkupanBrojIgraca.Text = ukupno.ToString();
        }

        private void IgracForma_Load(object sender, EventArgs e)
        {

        }

        private void btnOtpustiSegrta_Click(object sender, EventArgs e)
        {
            //if (listTrenutniSegrti.Items.Count > 0)
            //{
            //    var curIndex = listTrenutniSegrti.SelectedIndex;
            //    Segrt selektovaniSegrt = (Segrt)listTrenutniSegrti.Items[curIndex];
            //    Lik lik = DTOManager.OtpustiSegrta(selektovaniSegrt.Id);
            //    igrac.KontroliseLika = lik;
            //    UcitajPodatke(igrac);
            //}
            
        }
    }
}
