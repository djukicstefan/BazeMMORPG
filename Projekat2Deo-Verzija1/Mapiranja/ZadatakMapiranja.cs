using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Projekat2Deo_Verzija1.Entiteti;

namespace Projekat2Deo_Verzija1.Mapiranja
{
    public class ZadatakMapiranja : ClassMap<Zadatak>
    {
        ZadatakMapiranja()
        {
            Table("ZADATAK");

            Id(z => z.Id, "ID").GeneratedBy.TriggerIdentity();

            Map(z => z.BonusIskustva, "Bonus_iskustva");

            HasMany(z => z.Alijanse).KeyColumn("Naziv_alijanse").LazyLoad().Cascade.All().Inverse();
            HasMany(z => z.Igraci).KeyColumn("ID_Igrača").LazyLoad().Cascade.All().Inverse();
        }
    }
}
