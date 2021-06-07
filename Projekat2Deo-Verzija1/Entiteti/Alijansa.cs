using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat2Deo_Verzija1.Entiteti
{
    public class Alijansa
    {
        public virtual String Naziv { get; set; }
        public virtual int MaxIgraca { get; set; }
        public virtual int MinIgraca { get; set; }
        public virtual int BonusIskustvo { get; set; }
        public virtual int BonusZdravlje { get; set; }
        public virtual IList<Igrac> Igraci { get; set; }
        public virtual IList<GrupniZadaci> GrupniZadaci { get; set; }
        public virtual IList<SavezAlijansi> AlijanseUSavezu { get; set; }

        public Alijansa()
        {
            Igraci = new List<Igrac>();
            GrupniZadaci = new List<GrupniZadaci>();
            AlijanseUSavezu = new List<SavezAlijansi>();
        }
    }
}
