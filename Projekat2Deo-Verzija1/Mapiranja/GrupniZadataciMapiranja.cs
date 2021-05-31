using FluentNHibernate.Mapping;
using Projekat2Deo_Verzija1.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat2Deo_Verzija1.Mapiranja
{
    public class GrupniZadataciMapiranja : ClassMap<GrupniZadaci>
    {
        public GrupniZadataciMapiranja()
        {
            Table("GRUPNI_ZADACI");

            Id(gz => gz.Id, "ID").GeneratedBy.TriggerIdentity();

            Map(gz => gz.VremeResavanja, "Vreme_rešavanja");

            References(gz => gz.AlijansaKojaResava).Column("Naziv_alijanse");
            References(gz => gz.ZadatakKojiSeResava).Column("Id_zadatka");
        }
    }
}
