using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat2Deo_Verzija1.Entiteti
{
    public class SavezAlijansi
    {
        public virtual SavezAlijansiId Kljuc { get; set; }

        public SavezAlijansi()
        {
            Kljuc = new SavezAlijansiId();
        }
    }
}
