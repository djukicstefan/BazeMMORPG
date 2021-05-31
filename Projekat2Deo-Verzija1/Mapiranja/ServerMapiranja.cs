using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Mapping;
using Projekat2Deo_Verzija1.Entiteti;

namespace Projekat2Deo_Verzija1.Mapiranja
{
    public class ServerMapiranja : ClassMap<Server>
    {
        ServerMapiranja()
        {
            Table("SERVER");

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            Map(x => x.Naziv, "Naziv");

            //mapiranje 1:N na 1 strani
            HasMany(x => x.Igraci).KeyColumn("Id_Servera").LazyLoad().Cascade.All().Inverse();
        }


    }
}
