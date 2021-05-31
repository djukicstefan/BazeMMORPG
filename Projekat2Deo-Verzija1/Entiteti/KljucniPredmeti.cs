using Projekat2Deo_Verzija1.Mapiranja;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat2Deo_Verzija1.Entiteti
{
    public class KljucniPredmeti : Oprema
    {
        public virtual String Naziv { get; set; }
        public virtual String Opis { get; set; }
        public virtual String NadimakVlasnika {get; set;}
    }
}
