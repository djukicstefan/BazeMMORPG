using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat2Deo_Verzija1.Entiteti
{
    public class Segrt
    {
        public virtual SegrtId Id { get; set; }
        public virtual String Rasa { get; set; }
        public virtual int BonusUSkrivanju { get; set; }

        public Segrt()
        {
            Id = new SegrtId();
        }
    }
}
