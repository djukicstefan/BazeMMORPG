using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Linq;
using Projekat2Deo_Verzija1.Entiteti;
using System.Windows.Forms;
using NHibernate.Hql.Ast.ANTLR.Tree;

namespace Projekat2Deo_Verzija1
{
    public class DTOManager
    {
        #region Alijansa
        public static List<DTOs.AlijansaBasic> VratiAlijanse()
        {
            List<DTOs.AlijansaBasic> listaAlijansi = new List<DTOs.AlijansaBasic>();
            try
            {
                ISession s = DataLayer.GetSession();
                IList<Alijansa> alijanse = s.QueryOver<Alijansa>()
                                            .List<Alijansa>();

                foreach(Alijansa a in alijanse)
                {
                    listaAlijansi.Add(new DTOs.AlijansaBasic(a.Naziv, a.MaxIgraca, a.MinIgraca, a.BonusIskustvo, a.BonusZdravlje));
                }

                s.Close();
            }
             catch(Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
            return listaAlijansi;
        }

        public static DTOs.AlijansaBasic VratiAlijansu(string naziv)
        {
            DTOs.AlijansaBasic alijansa = new DTOs.AlijansaBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                Alijansa a = s.Get<Alijansa>(naziv);

                alijansa.Naziv = a.Naziv;
                alijansa.MaxIgraca = a.MaxIgraca;
                alijansa.MinIgraca = a.MinIgraca;
                alijansa.BonusIskustvo = a.BonusIskustvo;
                alijansa.BonusZdravlje = a.BonusZdravlje;

                s.Close();
            }
            catch(Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
            return alijansa;
        }

        public static void NapustiAlijansu(string naziv, int igracId)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Alijansa a = s.Get<Alijansa>(naziv);
                Igrac i = s.Get<Igrac>(igracId);

                i.PripadaAlijansi = null;

                foreach (Igrac ig in a.Igraci)
                {
                    if (ig.Id == i.Id)
                    {
                        a.Igraci.Remove(ig);
                        break;
                    }
                }

                s.Update(i);
                s.Update(a);
                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        public static void PridruziSeAlijansi(string naziv, int igracId)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Alijansa a = s.Get<Alijansa>(naziv);
                Igrac i = s.Get<Igrac>(igracId);

                i.PripadaAlijansi = a;
                a.Igraci.Add(i);

                s.Update(i);
                s.Update(a);
                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        public static void IzmeniAlijansu(DTOs.AlijansaBasic alijansa)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Alijansa a = s.Get<Alijansa>(alijansa.Naziv);

                a.MaxIgraca = alijansa.MaxIgraca;
                a.MinIgraca = alijansa.MinIgraca;
                a.BonusIskustvo = alijansa.BonusIskustvo;
                a.BonusZdravlje = alijansa.BonusZdravlje;
                
                s.Update(a);
                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        public static void ObrisiAlijansu(string naziv)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Alijansa a = s.Get<Alijansa>(naziv);

                foreach (Igrac i in a.Igraci)
                { 
                    i.PripadaAlijansi = null;
                    s.Update(i);
                }
                a.Igraci.Clear();

                IList<SavezAlijansi> savezi = s.QueryOver<SavezAlijansi>().List<SavezAlijansi>();
                foreach (SavezAlijansi sa in savezi)
                {
                    Alijansa a1 = sa.Kljuc.AlijansaJedan;
                    Alijansa a2 = sa.Kljuc.AlijansaDva;

                    string a1Naziv = a1.Naziv;
                    string a2Naziv = a2.Naziv;

                    if (a1Naziv == a.Naziv || a2Naziv == a.Naziv)
                        s.Delete(sa);
                }

                foreach (GrupniZadaci gz in a.GrupniZadaci)
                {
                    Zadatak z = s.Get<Zadatak>(gz.Id);
                    s.Delete(gz);
                    s.Delete(z);
                }

                s.Delete(a);
                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        public static void DodajAlijansu(DTOs.AlijansaPregled alijansa, int idIgraca)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Alijansa a = new Alijansa();
                a.Naziv = alijansa.Naziv;
                a.MaxIgraca = alijansa.MaxIgraca;
                a.MinIgraca = alijansa.MinIgraca;
                a.BonusIskustvo = alijansa.BonusIskustvo;
                a.BonusZdravlje = alijansa.BonusZdravlje;

                Igrac i = s.Get<Igrac>(idIgraca);

                i.PripadaAlijansi = a;
                a.Igraci.Add(i);

                s.Save(a);
                s.Update(i);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        #endregion

        #region SavezAlijansi

        public static List<DTOs.AlijansaBasic> VratiAlijanseUSavezu(string naziv)
        {
            List<DTOs.AlijansaBasic> alijanse = new List<DTOs.AlijansaBasic>();
            try
            {
                ISession s = DataLayer.GetSession();

                IList<SavezAlijansi> savezi = s.QueryOver<SavezAlijansi>().List<SavezAlijansi>();

                foreach (SavezAlijansi sa in savezi)
                {
                    Alijansa a1 = sa.Kljuc.AlijansaJedan;
                    Alijansa a2 = sa.Kljuc.AlijansaDva;

                    string a1Naziv = a1.Naziv;
                    string a2Naziv = a2.Naziv;

                    if (a1Naziv == naziv)
                    {
                        alijanse.Add(new DTOs.AlijansaBasic(a2.Naziv, a2.MaxIgraca, a2.MinIgraca, a2.BonusIskustvo, a2.BonusZdravlje));
                    }
                    else if (a2Naziv == naziv)
                    {
                        alijanse.Add(new DTOs.AlijansaBasic(a1.Naziv, a1.MaxIgraca, a1.MinIgraca, a1.BonusIskustvo, a1.BonusZdravlje));
                    }
                }

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
            return alijanse;
        }

        public static void SklopiSavez(string nazivPrve, string nazivDruge)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Alijansa a1 = s.Get<Alijansa>(nazivPrve);
                Alijansa a2 = s.Get<Alijansa>(nazivDruge);
                SavezAlijansiId savezId = new SavezAlijansiId();
                SavezAlijansi sa = new SavezAlijansi();

                savezId.AlijansaJedan = a1;
                savezId.AlijansaDva = a2;
                sa.Kljuc = savezId;

                a1.AlijanseUSavezu.Add(sa);
                a2.AlijanseUSavezu.Add(sa);

                s.Save(sa);
                s.Update(a1);
                s.Update(a2);
                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        public static void PrekiniSavez(string nazivPrve, string nazivDruge)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Alijansa a1 = s.Get<Alijansa>(nazivPrve);
                Alijansa a2 = s.Get<Alijansa>(nazivDruge);

                SavezAlijansiId savezId = new SavezAlijansiId();
                savezId.AlijansaJedan = a1;
                savezId.AlijansaDva = a2;

                SavezAlijansi sa = s.Get<SavezAlijansi>(savezId);

                a1.AlijanseUSavezu.Remove(sa);
                a2.AlijanseUSavezu.Remove(sa);

                s.Delete(sa);
                s.Update(a1);
                s.Update(a2);
                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        #endregion

        #region Server

        public static List<DTOs.ServerBasic> VratiServere()
        {
            List<DTOs.ServerBasic> listaServera = new List<DTOs.ServerBasic>();
          
            try
            {
                ISession s = DataLayer.GetSession();

                IList<Server> serveri = s.QueryOver<Server>()
                                               .List<Server>();

                foreach(Server srv in serveri)
                {
                    listaServera.Add(new DTOs.ServerBasic(srv.Id, srv.Naziv));
                }


                s.Close();
            }
            catch(Exception ec)
            {
                MessageBox.Show(ec.Message);
            }

            return listaServera;
        }

        public static int VratiBrojIgraca(int id)
        {
            int brojIgraca = 0;
            try
            {
                ISession s = DataLayer.GetSession();

                IList<Server> serveri = s.QueryOver<Server>()
                                               .Where(ser => ser.Id == id)
                                               .List<Server>();

                if(serveri != null)
                {
                    brojIgraca = serveri[0].Igraci.Count;
                }
                else
                {
                    MessageBox.Show("Ne postoji server sa zadatim id-jem u bazi!");
                    return 0;
                }

            }
            catch(Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
            return brojIgraca;
        }

        public static DTOs.ServerBasic VratiServer(int id)
        {
            DTOs.ServerBasic server = new DTOs.ServerBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                Server ss = s.Get<Server>(id);

                server.Id = ss.Id;
                server.Naziv = ss.Naziv;

                s.Close();
                
            }
            catch(Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
            return server;
        }

        public static void DodajServer(string naziv)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Server srv = new Server();
                srv.Naziv = naziv;

                s.Save(srv);
                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }
        #endregion

        #region Igrac

        public static void DodajIgraca(DTOs.IgracBasic i, String server, String rasa)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Igrac igrac = new Igrac();
                igrac.Nadimak = i.Nadimak;
                igrac.Lozinka = i.Lozinka;
                igrac.Ime = i.Ime;
                igrac.Prezime = i.Prezime;
                igrac.Pol = i.Pol;
                igrac.Uzrast = i.Uzrast;
                igrac.VremePovezivanja = DateTime.Now;

                IList<Server> sserver = s.QueryOver<Server>()
                                         .Where(ss => ss.Naziv == server)
                                         .List();

                igrac.PovezanNaServer = sserver[0];

                sserver[0].Igraci.Add(igrac);

                Lik lik = null;
                switch (rasa)
                {
                    case "Čovek":
                        lik = new Čovek();
                        lik.VestinaSkrivanja = 50;
                        break;

                    case "Patuljak":
                        lik = new Patuljak();
                        lik.TipOruzja = "Malj";
                        break;

                    case "Ork":
                        lik = new Ork();
                        lik.TipOruzja = "Sekira";
                        break;

                    case "Vilenjak":
                        lik = new Vilenjak();
                        lik.Mana = 200;
                        break;
                    case "Demon":
                        lik = new Demon();
                        lik.Mana = 200;
                        break;
                }
                lik.KolicinaZlata = 2000;
                lik.Zdravlje = 100;

                igrac.KontroliseLika = lik;

                s.Save(lik);
                s.Save(igrac);
                s.Update(sserver[0]);

                s.Flush();
                s.Close();

            }
            catch(Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        public static DTOs.IgracBasic PostojiIgrac(string nadimak, string lozinka)
        {
            DTOs.IgracBasic igracc = new DTOs.IgracBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                IList<Igrac> igrac = s.QueryOver<Igrac>()
                                      .Where(i => i.Nadimak == nadimak)
                                      .Where(i => i.Lozinka == lozinka)
                                      .List<Igrac>();


                if (igrac.Count > 0)
                {
                    igrac[0].VremePovezivanja = DateTime.Now;

                    igracc.Id = igrac[0].Id;
                    igracc.Nadimak = igrac[0].Nadimak;
                    igracc.Lozinka = igrac[0].Lozinka;
                    igracc.Ime = igrac[0].Ime;
                    igracc.Prezime = igrac[0].Prezime;
                    igracc.Pol = igrac[0].Pol;
                    igracc.Uzrast = igrac[0].Uzrast;
                    igracc.VremePovezivanja = igrac[0].VremePovezivanja;
                    igracc.VremeOdjavljivanja = igrac[0].VremeOdjavljivanja;
                    igracc.BrojPoenaUSesiji = igrac[0].BrojPoenaUSesiji;
                    igracc.KolicinaZlataUSesiji = igrac[0].KolicinaZlataUSesiji;
                    igracc.PovezanNaServer = VratiServer(igrac[0].PovezanNaServer.Id);
                    igracc.PripadaAlijansi = igrac[0].PripadaAlijansi != null ? VratiAlijansu(igrac[0].PripadaAlijansi.Naziv) : null;
                    igracc.KontroliseLika = VratiLika(igrac[0].KontroliseLika.Id);

                    s.Update(igrac[0]);
                    s.Flush();
                    return igracc;
                }
                
            }
            catch(Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
            return null;
        }

        public static void ZavrsiSesiju(DTOs.IgracBasic igrac)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Igrac i = s.Get<Igrac>(igrac.Id);
                i.VremeOdjavljivanja = DateTime.Now;
                
                Random r = new Random();

                i.KolicinaZlataUSesiji += r.Next() % 10000;
                i.BrojPoenaUSesiji += r.Next() % 10000;

                s.Update(i);
                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        #endregion

        #region Segrt

        public static List<DTOs.SegrtBasic> VratiSegrte()
        {
            List<DTOs.SegrtBasic> listaSegrta = new List<DTOs.SegrtBasic>();

            try
            {
                ISession s = DataLayer.GetSession();
                IList<Segrt> segrti = s.QueryOver<Segrt>()
                                       .List<Segrt>();

                foreach(Segrt ss in segrti)
                {
                    var p = ss.Id.Gazda.ToString().Split('.');
                    listaSegrta.Add(new DTOs.SegrtBasic(new DTOs.SegrtIdBasic(new DTOs.LikBasic(ss.Id.Gazda.Id, ss.Id.Gazda.Iskustvo, ss.Id.Gazda.StepenZamora, ss.Id.Gazda.Zdravlje, ss.Id.Gazda.KolicinaZlata, ss.Id.Gazda.VestinaSkrivanja, ss.Id.Gazda.TipOruzja, ss.Id.Gazda.Mana, p[2]), ss.Id.Ime), ss.Rasa, ss.BonusUSkrivanju));
                }

                s.Close();
            }
            catch(Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
            return listaSegrta;
        }

        public static List<DTOs.SegrtBasic> VratiSegrte(int idLika)
        {
            List<DTOs.SegrtBasic> listaSegrta = new List<DTOs.SegrtBasic>();

            try
            {
                ISession s = DataLayer.GetSession();
                IList<Segrt> segrti = s.QueryOver<Segrt>()
                                       .List<Segrt>();

                foreach (Segrt ss in segrti)
                {
                    if (ss.Id.Gazda.Id == idLika)
                    {
                        var p = ss.Id.Gazda.ToString().Split('.');
                        listaSegrta.Add(new DTOs.SegrtBasic(new DTOs.SegrtIdBasic(new DTOs.LikBasic(ss.Id.Gazda.Id, ss.Id.Gazda.Iskustvo, ss.Id.Gazda.StepenZamora, ss.Id.Gazda.Zdravlje, ss.Id.Gazda.KolicinaZlata, ss.Id.Gazda.VestinaSkrivanja, ss.Id.Gazda.TipOruzja, ss.Id.Gazda.Mana, p[2]), ss.Id.Ime), ss.Rasa, ss.BonusUSkrivanju));
                    } 
                        
                }

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
            return listaSegrta;
        }

        public static void OtpustiSegrta(DTOs.SegrtIdBasic seg)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Lik lik = s.Load<Lik>(seg.Gazda.Id);
                SegrtId segId = new SegrtId();
                
                segId.Gazda = lik;
                segId.Ime = seg.Ime;

                Segrt segrt = s.Load<Segrt>(segId);

                foreach (Segrt segi in lik.Segrti)
                {
                    if (segi.Id.Gazda.Id == segrt.Id.Gazda.Id && segi.Id.Ime.CompareTo(segi.Id.Ime) == 0) 
                    {
                            lik.Segrti.Remove(segi);
                            break;
                    }
                }

                s.Update(lik);
                s.Delete(segrt);

                s.Flush();
                s.Close();
            }
            catch(Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        public static void DodajSegrta(DTOs.SegrtBasic seg)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Segrt se = new Segrt();
                SegrtId seId = new SegrtId();
                Lik l = s.Get<Lik>(seg.Id.Gazda.Id);

                seId.Gazda = l;
                seId.Ime = seg.Id.Ime;
                se.Id = seId;
                se.Rasa = seg.Rasa;
                se.BonusUSkrivanju = seg.BonusUSkrivanju;

                l.Segrti.Add(se);

                s.Update(l);
                s.Save(se);
                s.Flush();
    
                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        #endregion

        #region Lik

        public static DTOs.LikBasic VratiLika(int id)
        {
            DTOs.LikBasic lik = new DTOs.LikBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                Lik l = s.Get<Lik>(id);
                var p = l.GetType().ToString().Split('.');


                lik.Id = l.Id;
                lik.Iskustvo = l.Iskustvo;
                lik.StepenZamora = l.StepenZamora;
                lik.Zdravlje = l.Zdravlje;
                lik.KolicinaZlata = l.KolicinaZlata;
                lik.TipOruzja = l.TipOruzja;
                lik.Mana = l.Mana;
                lik.VestinaSkrivanja = l.VestinaSkrivanja;
                lik.Rasa = p[2];
                s.Close();
            }
            catch(Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
            return lik;
        }

        public static List<DTOs.LikBasic> VratiLikove()
        {
            List<DTOs.LikBasic> listaLikova = new List<DTOs.LikBasic>();
            try
            {
                ISession s = DataLayer.GetSession();
                IList<Lik> likovi = s.QueryOver<Lik>()
                                            .List<Lik>();

                

                foreach (Lik l in likovi)
                {
                    var p = l.GetType().ToString().Split('.');
                    listaLikova.Add(new DTOs.LikBasic(l.Id, l.Iskustvo, l.StepenZamora, l.Zdravlje, l.KolicinaZlata, l.VestinaSkrivanja, l.TipOruzja, l.Mana, p[2]));
                }

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
            return listaLikova;
        }

        #endregion

        #region Oprema

        #endregion

        #region KljucniPredmeti
        public static List<DTOs.KljucniPredmetiPregled> VratiKljucnePredmeteLika(int idLika)
        {
            List<DTOs.KljucniPredmetiPregled> listaOprema = new List<DTOs.KljucniPredmetiPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                Lik l = s.Get<Lik>(idLika);
               
                if (l.Oprema.Count > 0)
                {
                    foreach(Oprema o in l.Oprema)
                    {
                        KljucniPredmeti kp = s.Get<KljucniPredmeti>(o.Id);
                        if(kp != null)
                        {
                            listaOprema.Add(new DTOs.KljucniPredmetiPregled(o.Id, kp.Naziv, kp.Opis, kp.NadimakVlasnika));
                        }
                    }  
                }

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
            return listaOprema;
        }

        public static void DodajKljucniPredmet(string nazivOpreme, string opisOpreme, string nazivVlasnika, int idIgraca, int idZadatka)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Zadatak z = s.Get<Zadatak>(idZadatka);

                KljucniPredmeti kp = new KljucniPredmeti();
                kp.Zadatak = z;
                kp.Naziv = nazivOpreme;
                kp.Opis = opisOpreme;
                kp.NadimakVlasnika = nazivVlasnika;

                Igrac i = s.Get<Igrac>(idIgraca);

                i.KontroliseLika.Oprema.Add(kp);
                kp.Likovi.Add(i.KontroliseLika);

                s.Update(i.KontroliseLika);
                s.Save(kp);
                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }
        public static void OslobodiKljucnuOpremu(int idIgraca, int idOpreme)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Igrac i = s.Get<Igrac>(idIgraca);
                Oprema o = s.Get<Oprema>(idOpreme);

                i.KontroliseLika.Oprema.Remove(o);
                o.Likovi.Remove(i.KontroliseLika);

                s.Update(o);
                s.Update(i);
                s.Flush();
                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        #endregion

        #region BonusPredmetiIOruzija
        public static List<DTOs.BonusPredmetiIOruzijaPregled> VratiBonusPredmeteIOruzijaLika(int idLika)
        {
            List<DTOs.BonusPredmetiIOruzijaPregled> listaOprema = new List<DTOs.BonusPredmetiIOruzijaPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                Lik l = s.Get<Lik>(idLika);

                if (l.Oprema.Count > 0)
                {
                    foreach (Oprema o in l.Oprema)
                    {
                        BonusPredmetiIOruzija bp = s.Get<BonusPredmetiIOruzija>(o.Id);
                        if (bp != null)
                        {
                            listaOprema.Add(new DTOs.BonusPredmetiIOruzijaPregled(o.Id, bp.BrojIskustvenihPoena, bp.Rasa, bp.PPredmet));
                        }
                    }
                }

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
            return listaOprema;
        }

        public static void OslobodiBonusOpremu(int idIgraca, int idOpreme)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Igrac i = s.Get<Igrac>(idIgraca);
                Oprema o = s.Get<Oprema>(idOpreme);

                i.KontroliseLika.Oprema.Remove(o);
                o.Likovi.Remove(i.KontroliseLika);
                
                s.Update(o);
                s.Update(i);
                s.Flush();
                s.Close();
       
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }
        #endregion

        #region Zadatak
        public static List<int> VratiZadatke()
        {
            List<int> zadIds = new List<int>();
            try
            {
                ISession s = DataLayer.GetSession();

                IList<Zadatak> zadaci = s.QueryOver<Zadatak>().List<Zadatak>();

                zadaci.ToList().ForEach(x => { 
                    if (x.Alijanse.Count == 0 && x.Igraci.Count == 0)
                        zadIds.Add(x.Id);
                });

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
            return zadIds;
        }

        public static void NapraviZadatak(int bonusIskustva)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Zadatak z = new Zadatak();
                z.BonusIskustva = bonusIskustva;

                s.Save(z);
                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        public static void DodajBonusPredmetiOruzje(int bonusIskustva, string rasa, char pPredmet, int idIgraca, int idZadatka)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Zadatak z = s.Get<Zadatak>(idZadatka);

                BonusPredmetiIOruzija bp = new BonusPredmetiIOruzija();
                bp.Zadatak = z;
                bp.BrojIskustvenihPoena = bonusIskustva;
                bp.Rasa = rasa;
                bp.PPredmet = pPredmet;

                Igrac i = s.Get<Igrac>(idIgraca);

                i.KontroliseLika.Oprema.Add(bp);
                bp.Likovi.Add(i.KontroliseLika);

                s.Update(i.KontroliseLika);
                s.Save(bp);
                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }
        #endregion

        #region IndividualniZadaci
        public static List<DTOs.IndividualniZadaciBasic> VratiIndividualneZadatkeIgraca(int idIgraca)
        {
            List<DTOs.IndividualniZadaciBasic> listaIndividualnihZadataka = new List<DTOs.IndividualniZadaciBasic>();
            try
            {
                ISession s = DataLayer.GetSession();

                IList<IndividualniZadaci> lista = s.QueryOver<IndividualniZadaci>()
                                                .Where(x => x.IgracKojiResava.Id == idIgraca)
                                                .List<IndividualniZadaci>();

                if(lista.Count > 0)
                {
                    foreach(IndividualniZadaci iz in lista)
                    {
                        DTOs.ZadatakBasic z = new DTOs.ZadatakBasic();
                        DTOs.IgracBasic i = new DTOs.IgracBasic();
                        z.BonusIskustva = iz.ZadatakKojiSeResava.BonusIskustva;
                        z.Id = iz.ZadatakKojiSeResava.Id;
                        i.Id = iz.IgracKojiResava.Id;
                        DTOs.IndividualniZadaciBasic izb = new DTOs.IndividualniZadaciBasic();
                        izb.Id = iz.Id;
                        izb.ZadatakKojiSeResava = z;
                        izb.IgracKojiResava = i;
                        izb.VremeResavanja = iz.VremeResavanja;
                        listaIndividualnihZadataka.Add(izb);
                    }
                }

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
            return listaIndividualnihZadataka;
        }

        public static void ResiIndividualniZadatak(int idIndividualnogZadatka)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                IndividualniZadaci iz = s.Get<IndividualniZadaci>(idIndividualnogZadatka);

                Zadatak z = s.Get<Zadatak>(iz.ZadatakKojiSeResava.Id);

                iz.IgracKojiResava.KontroliseLika.Iskustvo += iz.ZadatakKojiSeResava.BonusIskustva;
                s.Update(iz.IgracKojiResava.KontroliseLika);
                
                z.Oprema.Clear();
                z.Igraci.Clear();

                IList<Oprema> oprema = s.QueryOver<Oprema>()
                                        .Where(x => x.Zadatak.Id == z.Id)
                                        .List<Oprema>();

                oprema.ToList().ForEach(x => {
                    x.Zadatak = null;
                    s.Update(x);
                });

                iz.ZadatakKojiSeResava = null;
                iz.IgracKojiResava = null;

                s.Delete(z);
                s.Delete(iz);
                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        public static void DodajIndividualniZadatak(int idIgraca, string vremeResavanja, int zadId)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Zadatak z = s.Get<Zadatak>(zadId);
                Igrac i = s.Get<Igrac>(idIgraca);

                IndividualniZadaci iz = new IndividualniZadaci();
                iz.ZadatakKojiSeResava = z;
                iz.IgracKojiResava = i;
                iz.VremeResavanja = vremeResavanja;

                i.IndividualniZadaci.Add(iz);
                z.Igraci.Add(iz);

                s.Update(i);
                s.Update(z);
                s.Save(iz);
                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }
        #endregion

        #region GrupniZadaci

        public static List<DTOs.GrupniZadaciBasic> VratiGrupneZadatkeAlijanse(string naziv)
        {
            List<DTOs.GrupniZadaciBasic> listaGrupnihZadataka = new List<DTOs.GrupniZadaciBasic>();
            try
            {
                ISession s = DataLayer.GetSession();

                IList<GrupniZadaci> lista = s.QueryOver<GrupniZadaci>()
                                                .Where(x => x.AlijansaKojaResava.Naziv == naziv)
                                                .List<GrupniZadaci>();

                if (lista.Count > 0)
                {
                    foreach (GrupniZadaci gz in lista)
                    {
                        DTOs.ZadatakBasic z = new DTOs.ZadatakBasic();
                        
                        z.BonusIskustva = gz.ZadatakKojiSeResava.BonusIskustva;
                        z.Id = gz.ZadatakKojiSeResava.Id;

                        DTOs.GrupniZadaciBasic gzb = new DTOs.GrupniZadaciBasic();
                        gzb.Id = gz.Id;
                        gzb.ZadatakKojiSeResava = z;
                        gzb.VremeResavanja = gz.VremeResavanja;
                        
                        listaGrupnihZadataka.Add(gzb);
                    }
                }

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
            return listaGrupnihZadataka;
        }

        public static void ResiGrupniZadatak(int idGrupnogZadatka)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                GrupniZadaci gz = s.Get<GrupniZadaci>(idGrupnogZadatka);

                Zadatak z = s.Get<Zadatak>(gz.ZadatakKojiSeResava.Id);

                foreach (Igrac i in gz.AlijansaKojaResava.Igraci)
                {
                    i.KontroliseLika.Iskustvo += gz.ZadatakKojiSeResava.BonusIskustva;
                    s.Update(i.KontroliseLika);
                }
                z.Oprema.Clear();
                z.Alijanse.Clear();

                IList<Oprema> oprema = s.QueryOver<Oprema>()
                                        .Where(x => x.Zadatak.Id == z.Id)
                                        .List<Oprema>();

                oprema.ToList().ForEach(x => { 
                    x.Zadatak = null;
                    s.Update(x);
                });

                gz.ZadatakKojiSeResava = null;
                gz.AlijansaKojaResava = null;
                
                s.Delete(z);  
                s.Delete(gz);
                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        public static void DodajGrupniZadatak(string nazivAlijanse, string vremeResavanja, int zadId)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Zadatak z = s.Get<Zadatak>(zadId);
                Alijansa a = s.Get<Alijansa>(nazivAlijanse);

                GrupniZadaci gz = new GrupniZadaci();
                gz.ZadatakKojiSeResava = z;
                gz.AlijansaKojaResava = a;
                gz.VremeResavanja = vremeResavanja;

                a.GrupniZadaci.Add(gz);
                z.Alijanse.Add(gz);

                s.Update(a);
                s.Update(z);
                s.Save(gz);
                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }
    }
    #endregion
}

