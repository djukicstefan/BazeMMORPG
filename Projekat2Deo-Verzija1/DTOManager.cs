using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Linq;
using Projekat2Deo_Verzija1.Entiteti;
using System.Windows.Forms;
using System.Security.Cryptography;

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

        public static Igrac PostojiIgrac(string nadimak, string lozinka)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                IList<Igrac> igrac = s.QueryOver<Igrac>()
                                      .Where(i => i.Nadimak == nadimak)
                                      .Where(i => i.Lozinka == lozinka)
                                      .List<Igrac>();


                if (igrac != null)
                {
                    return igrac[0];
                }
                
            }
            catch(Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
            return null;
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
                    listaSegrta.Add(new DTOs.SegrtBasic(new DTOs.SegrtIdBasic(new DTOs.LikBasic(ss.Id.Gazda.Id, ss.Id.Gazda.Iskustvo, ss.Id.Gazda.StepenZamora, ss.Id.Gazda.Zdravlje, ss.Id.Gazda.KolicinaZlata), ss.Id.Ime), ss.Rasa, ss.BonusUSkrivanju));
                }

                s.Close();
            }
            catch(Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
            return listaSegrta;
        }

        public static Lik OtpustiSegrta(SegrtId seg)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Segrt segrt = s.Load<Segrt>(seg);

                int idLika = segrt.Id.Gazda.Id;

                Lik lik = s.Load<Lik>(idLika);

                

                foreach(Segrt segi in lik.Segrti)
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
                return lik;
            }
            catch(Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
            return null;
        }

        #endregion
    }
}
