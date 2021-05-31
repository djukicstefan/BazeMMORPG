using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Projekat2Deo_Verzija1.Entiteti;

namespace Projekat2Deo_Verzija1.Mapiranja
{
    public class KljucniPredmetiMapiranja : SubclassMap<KljucniPredmeti>
    {
        public KljucniPredmetiMapiranja()
        {
            Table("KLJUČNI_PREDMETI");

            //Table per class interitance
            KeyColumn("ID");

            Map(kp => kp.Naziv);
            Map(kp => kp.Opis);
            Map(kp => kp.NadimakVlasnika, "Nadimak_vlasnika");
        }
    }
}
