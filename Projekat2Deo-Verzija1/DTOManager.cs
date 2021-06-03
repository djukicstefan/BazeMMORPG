using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Linq;
using Projekat2Deo_Verzija1.Entiteti;
using System.Windows.Forms;




namespace Projekat2Deo_Verzija1
{
    public class DTOManager
    {
        #region Alijansa
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

        public static bool PostojiIgrac(string nadimak, string lozinka)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                IList<Igrac> igrac = s.QueryOver<Igrac>()
                                      .Where(i => i.Nadimak == nadimak)
                                      .Where(i => i.Lozinka == lozinka)
                                      .List<Igrac>();

                if(igrac.Count > 0)
                {
                    return true;
                }
                
            }
            catch(Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
            return false;
        }

        #endregion

    }
}
