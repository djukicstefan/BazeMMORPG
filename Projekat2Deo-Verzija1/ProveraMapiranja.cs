using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NHibernate;
using Projekat2Deo_Verzija1.Entiteti;
using Projekat2Deo_Verzija1.Mapiranja;

namespace Projekat2Deo_Verzija1
{
    public partial class frmProveraMapiranja : Form
    {
        public frmProveraMapiranja()
        {
            InitializeComponent();
        }

        private void cmdUcitavanjeServera_Click(object sender, EventArgs e)
        {
            try 
            {
                ISession ss = DataLayer.GetSession();

                Server s = ss.Load<Server>(3);

                MessageBox.Show(s.Naziv);

                ss.Close();
            }
            catch(Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdDodavanjeNovogServera_Click(object sender, EventArgs e)
        {
            ISession ss = DataLayer.GetSession();

            Server s = new Server();

            s.Naziv = "Spring";

            ss.Save(s);

            ss.Flush();
            ss.Close();
        }

        private void cmdUcitavanjeAlijanse_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Alijansa a = s.Load<Alijansa>("Espada");

                MessageBox.Show($"{a.Naziv}, {a.MaxIgraca}, {a.MinIgraca}, {a.BonusIskustvo}, " +
                    $"{a.BonusZdravlje}");

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdUcitavanjeZadatka_Click(object sender, EventArgs e)
        {
            ISession s = DataLayer.GetSession();

            Zadatak z = s.Load<Zadatak>(5);

            MessageBox.Show($"{z.Id}, {z.BonusIskustva}");

            s.Close();
        }

        private void cmdUcitavanjeLika_Click(object sender, EventArgs e)
        {
            ISession s = DataLayer.GetSession();

            Lik l = s.Load<Lik>(4);

            MessageBox.Show($"{l.Id}, {l.Iskustvo}, {l.StepenZamora}, {l.Zdravlje}, " +
                $"{l.KolicinaZlata}, {l.VestinaSkrivanja}, {l.TipOruzja}, {l.Mana}");

            s.Close();
        }

        private void cmpKljucniPredmet_Click(object sender, EventArgs e)
        {
            ISession s = DataLayer.GetSession();

            IList<Oprema> opreme = s.QueryOver<Oprema>()
                                    .Where(o => o.Id == 12)
                                    .List<Oprema>();
            KljucniPredmeti k = (KljucniPredmeti)opreme[0];

            MessageBox.Show($"{k.Id}, {k.Naziv}, {k.Opis}, {k.NadimakVlasnika}");

            s.Close();
        }

        private void cmdBonusPIO_Click(object sender, EventArgs e)
        {
            ISession s = DataLayer.GetSession();

            IList<Oprema> opreme = s.QueryOver<Oprema>()
                                    .Where(o => o.Id == 9)
                                    .List<Oprema>();

            BonusPredmetiIOruzija b = (BonusPredmetiIOruzija)opreme[0];

            MessageBox.Show($"{b.Id}, {b.BrojIskustvenihPoena}, {b.Rasa}, {b.PPredmet}");

            s.Close();
        }

        private void cmdIgracManyToOne_Click(object sender, EventArgs e)
        {
            try 
            { 
            
                ISession s = DataLayer.GetSession();

                Igrac i = s.Load<Igrac>(11);

                MessageBox.Show($"{i.Ime}, {i.Nadimak}, {i.Prezime}");
                MessageBox.Show($"Pripada alijansi: {i.PripadaAlijansi.Naziv}, {i.PripadaAlijansi.MaxIgraca}");
                MessageBox.Show($"Povezan na server: {i.PovezanNaServer.Naziv}");
                MessageBox.Show($"Kontrolise lika: {i.KontroliseLika.Id}, {i.KontroliseLika.Iskustvo}");

                s.Close();
            }
            catch(Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdServerOneToMany_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Server ser = s.Load<Server>(2);
                
                foreach(Igrac i in ser.Igraci)
                {
                    MessageBox.Show($"{i.Ime}, {i.Prezime}");
                }

                s.Close();
            }
            catch(Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdAlijansaOneToMany_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Alijansa alijansa = s.Load<Alijansa>("Alexandria");

                foreach (Igrac i in alijansa.Igraci)
                {
                    MessageBox.Show($"{i.Ime}, {i.Prezime}");
                }

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdDodavanjeIgraca_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Server ser = s.Load<Server>(1);

                Alijansa a = s.Load<Alijansa>("Espada");

                Igrac i = new Igrac()
                {
                    Nadimak = "Branka",
                    Lozinka = "branka123",
                    Ime = "Branislava",
                    Prezime = "Bratić",
                    Pol = 'Ž',
                    Uzrast = 20,
                    VremePovezivanja = new DateTime(2021, 7, 21, 18, 30, 5),
                    VremeOdjavljivanja = new DateTime(2021, 7, 21, 19, 5, 15),
                    BrojPoenaUSesiji = 700,
                    KolicinaZlataUSesiji = 17500
                };

                i.PripadaAlijansi = a;
                i.PovezanNaServer = ser;

                ser.Igraci.Add(i);
                a.Igraci.Add(i);

                s.Save(i);
                s.Update(ser);
                s.Update(a);

                s.Flush();
                s.Close();
            }
            catch(Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdManyToManyAlijanse_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Alijansa a1 = s.Load<Alijansa>("Espada");
                Alijansa a2 = s.Load<Alijansa>("Horda");

                SavezAlijansi sa = new SavezAlijansi();
                sa.Kljuc.AlijansaJedan = a1;
                sa.Kljuc.AlijansaDva = a2;

                s.Save(sa);
                s.Flush();

                MessageBox.Show("Dodat novi savez alijansi!");

                s.Close();
            }
            catch(Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdGrupniZadaci_Click(object sender, EventArgs e)
        {
            ISession s = DataLayer.GetSession();

            GrupniZadaci gp = s.Load<GrupniZadaci>(3);
            Alijansa a = s.Load<Alijansa>("Alijansa");

            MessageBox.Show($"{gp.Id}, {gp.AlijansaKojaResava.Naziv}, {gp.ZadatakKojiSeResava.Id}, {gp.VremeResavanja}");

            s.Close();
        }

        private void cmdIndividualniZadaci_Click(object sender, EventArgs e)
        {
            ISession s = DataLayer.GetSession();

            IndividualniZadaci iz = s.Load<IndividualniZadaci>(4);
            Igrac i = s.Load<Igrac>(7);

            MessageBox.Show($"{iz.Id}, {iz.IgracKojiResava.Ime}, {iz.IgracKojiResava.Prezime}, {iz.IgracKojiResava.Nadimak}, {iz.ZadatakKojiSeResava.Id}, {iz.ZadatakKojiSeResava.BonusIskustva}, {iz.VremeResavanja}");

            s.Close();
        }

        private void cmdDodajSegrta_Click(object sender, EventArgs e)
        {  
            ISession s = DataLayer.GetSession();

            Lik l = s.Load<Lik>(7);

            Segrt segrt = new Segrt() 
            {
                Rasa = "Patuljak",
                BonusUSkrivanju = 26
            };

            segrt.Id.Gazda = l;
            segrt.Id.Ime = "Zotlan";

            l.Segrti.Add(segrt);

            s.Save(segrt);
            s.Update(l);

            
            s.Flush();

            MessageBox.Show("Uspesno dodat novi segrt!");

            s.Close();
        }

        private void cmdPregledOpreme_Click(object sender, EventArgs e)
        {
            ISession s = DataLayer.GetSession();

            Oprema o = s.Load<Oprema>(7);

            MessageBox.Show($"{o.Id}, {o.Zadatak.Id}, {o.Zadatak.BonusIskustva}");

            s.Close();
        }

        private void cmdProveraAlternativeC_Click(object sender, EventArgs e)
        {
            try 
            {
                ISession s = DataLayer.GetSession();

                IList<Lik> likovi = s.QueryOver<Lik>()
                                     .List<Lik>();

                foreach (Lik l in likovi)
                {
                    if(l.GetType() == typeof(Čovek))
                    {
                        Čovek c = (Čovek)l;
                        MessageBox.Show($"Prikazuje se covek sa sledecim atributima");
                        MessageBox.Show($"{c.Iskustvo}, {c.StepenZamora}, {c.Zdravlje}, {c.KolicinaZlata}, {c.VestinaSkrivanja}");
                    }
                    else if (l.GetType() == typeof(Patuljak))
                    {
                        Patuljak p = (Patuljak)l;
                        MessageBox.Show($"Prikazuje se patuljak sa sledecim atributima");
                        MessageBox.Show($"{p.Iskustvo}, {p.StepenZamora}, {p.Zdravlje}, {p.KolicinaZlata}, {p.TipOruzja}");
                    }
                    else if(l.GetType() == typeof(Ork))
                    {
                        Ork o = (Ork)l;
                        MessageBox.Show($"Prikazuje se ork sa sledecim atributima");
                        MessageBox.Show($"{o.Iskustvo}, {o.StepenZamora}, {o.Zdravlje}, {o.KolicinaZlata}, {o.TipOruzja}");
                    }
                    else if(l.GetType() == typeof(Vilenjak))
                    {
                        Vilenjak v = (Vilenjak)l;
                        MessageBox.Show($"Prikazuje se vilenjak sa sledecim atributima");
                        MessageBox.Show($"{v.Iskustvo}, {v.StepenZamora}, {v.Zdravlje}, {v.KolicinaZlata}, {v.Mana}");
                    }
                    else
                    {
                        Demon d = (Demon)l;
                        MessageBox.Show($"Prikazuje se demon sa sledecim atributima");
                        MessageBox.Show($"{d.Iskustvo}, {d.StepenZamora}, {d.Zdravlje}, {d.KolicinaZlata}, {d.Mana}");
                    }
                }
            }
            catch(Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
            
        }

        private void cmdDodavanjeLika_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Patuljak p = new Patuljak()
                {
                    Iskustvo = 2000,
                    StepenZamora = 775,
                    Zdravlje = 2800,
                    TipOruzja = "Mač"
                };

                s.Save(p);

                s.Flush();
                s.Close();
            }
            catch(Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void btnVlasnistvoOpreme_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Lik l = s.Get<Lik>(10);

                foreach(Oprema o in l.Oprema)
                {
                    MessageBox.Show(o.Id.ToString());
                }

                Oprema oprema = s.Get<Oprema>(12);

                foreach (Lik lik in oprema.Likovi)
                {
                    MessageBox.Show(lik.Id.ToString());
                }

                s.Close();
            }
            catch(Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void btnUcitavanjeIgraca_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Igrac ig = s.Get<Igrac>(8);

                s.Close();
            }
            catch(Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }
    }
}
