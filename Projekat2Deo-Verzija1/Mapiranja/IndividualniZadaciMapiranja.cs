using FluentNHibernate.Mapping;
using Projekat2Deo_Verzija1.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat2Deo_Verzija1.Mapiranja
{
    public class IndividualniZadaciMapiranja : ClassMap<IndividualniZadaci>
    {
        public IndividualniZadaciMapiranja()
        {
            Table("INDIVIDUALNI_ZADACI");

            Id(iz => iz.Id, "ID").GeneratedBy.TriggerIdentity();

            Map(iz => iz.VremeResavanja, "Vreme_rešavanja");

            References(iz => iz.IgracKojiResava).Column("ID_Igrača");
            References(iz => iz.ZadatakKojiSeResava).Column("ID_Zadatka");
        }
    }
}
