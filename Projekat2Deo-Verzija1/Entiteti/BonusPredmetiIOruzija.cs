using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat2Deo_Verzija1.Entiteti
{
    public class BonusPredmetiIOruzija : Oprema
    {
        public virtual int BrojIskustvenihPoena { get; set; }
        public virtual String Rasa { get; set; }
        public virtual Char PPredmet { get; set; }
    }
}
