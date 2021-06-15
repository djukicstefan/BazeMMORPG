using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat2Deo_Verzija1.Entiteti
{
    public class Oprema
    {
        public virtual int Id { get; protected set; }
        public virtual Zadatak Zadatak { get; set; }
        public virtual IList<Lik> Likovi { get; set; }

        public Oprema()
        {
            Likovi = new List<Lik>();
        }

        public override string ToString()
        {
            return $"{Id} {Zadatak}";
        }
    }

}
