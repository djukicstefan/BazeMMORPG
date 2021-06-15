using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat2Deo_Verzija1.Entiteti
{
    public class Server
    {
        public virtual int Id { get; protected set; } 
        public virtual String Naziv { get; set; }

        public virtual IList<Igrac> Igraci { get; set; }

        public Server()
        {
            Igraci = new List<Igrac>();
        }
    }
}
