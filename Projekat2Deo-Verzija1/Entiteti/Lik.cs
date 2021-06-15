using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat2Deo_Verzija1.Entiteti
{
    public abstract class Lik
    {
        public virtual int Id { get; protected set; }
        public virtual int Iskustvo { get; set; }
        public virtual int StepenZamora { get; set; }
        public virtual int Zdravlje { get; set; }
        public virtual int KolicinaZlata { get; set; }
        public virtual int VestinaSkrivanja { get; set; }
        public virtual String TipOruzja { get; set; }
        public virtual int Mana { get; set; }
        public virtual IList<Segrt> Segrti { get; set; }
        public virtual IList<Oprema> Oprema { get; set; }
    }

    public class Čovek : Lik
    {
    }

    public class Patuljak : Lik
    {
    }

    public class Ork : Lik
    {
    }

    public class Vilenjak : Lik
    {
    }

    public class Demon : Lik
    {
    }
}
