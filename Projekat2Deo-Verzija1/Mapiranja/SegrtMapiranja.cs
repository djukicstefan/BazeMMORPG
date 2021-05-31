using FluentNHibernate.Mapping;
using Projekat2Deo_Verzija1.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat2Deo_Verzija1.Mapiranja
{
    public class SegrtMapiranja : ClassMap<Segrt>
    {
        public SegrtMapiranja()
        {
            Table("ŠEGRT");

            CompositeId(s => s.Id)
                .KeyReference(s => s.Gazda, "ID_Lika")
                .KeyProperty(s => s.Ime, "Ime");

            Map(s => s.Rasa);
            Map(s => s.BonusUSkrivanju, "Bonus_u_skrivanju");

        }
    }
}
