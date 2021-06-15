using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat2Deo_Verzija1.Entiteti
{
    public class Zadatak
    {
        public virtual int Id { get; protected set; }
        public virtual int BonusIskustva { get; set; }
        public virtual IList<GrupniZadaci> Alijanse { get; set; }
        public virtual IList<IndividualniZadaci> Igraci { get; set; }
        public virtual IList<Oprema> Oprema { get; set; }

        public Zadatak()
        {
            Alijanse = new List<GrupniZadaci>();
            Igraci = new List<IndividualniZadaci>();
            Oprema = new List<Oprema>();
        }
    }
}
