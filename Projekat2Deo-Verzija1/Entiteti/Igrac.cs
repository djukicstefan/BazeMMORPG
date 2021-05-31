using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat2Deo_Verzija1.Entiteti
{
    public class Igrac
    {
        public virtual int Id { get; protected set; }
        public virtual String Nadimak { get; set; }
        public virtual String Lozinka { get; set; }
        public virtual String Ime { get; set; }
        public virtual String Prezime { get; set; }
        public virtual Char Pol { get; set; }
        public virtual int Uzrast { get; set; }
        public virtual DateTime VremePovezivanja { get; set; }
        public virtual DateTime VremeOdjavljivanja { get; set; }
        public virtual int BrojPoenaUSesiji { get; set; }
        public virtual int KolicinaZlataUSesiji { get; set; }
        public virtual Server PovezanNaServer { get; set; }
        public virtual Alijansa PripadaAlijansi { get; set; }
        public virtual Lik KontroliseLika { get; set; }
        public virtual IList<IndividualniZadaci> IndividualniZadaci { get; set; }

        public Igrac()
        {
            IndividualniZadaci = new List<IndividualniZadaci>();
        }
    }
}
