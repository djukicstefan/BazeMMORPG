using FluentNHibernate.Mapping;
using Projekat2Deo_Verzija1.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat2Deo_Verzija1.Mapiranja
{
    public class OpremaMapiranja : ClassMap<Oprema>
    {
        public OpremaMapiranja()
        {
            Table("OPREMA");

            Id(o => o.Id, "ID").GeneratedBy.TriggerIdentity();

            References(o => o.Zadatak).Column("ID_Zadatka").LazyLoad();

            HasManyToMany(o => o.Likovi)
                .Table("VLASNIŠTVO_OPREME")
                .ParentKeyColumn("ID_Opreme")
                .ChildKeyColumn("ID_Lika"); 
        }
    }
}
