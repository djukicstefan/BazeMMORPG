using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Projekat2Deo_Verzija1.Entiteti;

namespace Projekat2Deo_Verzija1.Mapiranja
{
    public class LikMapiranja : ClassMap<Lik>
    {
        public LikMapiranja()
        {
            Table("LIK");

            
            DiscriminateSubClassesOnColumn("Rasa");

            Id(l => l.Id, "ID").GeneratedBy.TriggerIdentity();

            Map(l => l.Iskustvo);
            Map(l => l.StepenZamora, "Stepen_zamora");
            Map(l => l.Zdravlje);
            Map(l => l.KolicinaZlata, "Količina_zlata");
            Map(l => l.VestinaSkrivanja, "Veština_skrivanja");
            Map(l => l.TipOruzja, "Tip_oružja");
            Map(l => l.Mana);

            HasMany(l => l.Segrti).KeyColumn("ID_Lika").LazyLoad().Cascade.All().Inverse();

            HasManyToMany(l => l.Oprema)
                .Table("VLASNIŠTVO_OPREME")
                .ParentKeyColumn("ID_Lika")
                .ChildKeyColumn("ID_Opreme");
        }
    }

    public class ČovekMapiranja : SubclassMap<Čovek>
    {
        public ČovekMapiranja()
        {
            DiscriminatorValue("Čovek");
        }
    }

    public class PatuljakMapiranja : SubclassMap<Patuljak>
    {
        public PatuljakMapiranja()
        {
            DiscriminatorValue("Patuljak");
        }
    }

    public class OrkMapiranja : SubclassMap<Ork>
    {
        public OrkMapiranja()
        {
            DiscriminatorValue("Ork");
        }
    }

    public class VilenjakMapiranja : SubclassMap<Vilenjak>
    {
        public VilenjakMapiranja()
        {
            DiscriminatorValue("Vilenjak");
        }
    }

    public class DemonMapiranja : SubclassMap<Demon>
    {
        public DemonMapiranja()
        {
            DiscriminatorValue("Demon");
        }
    }
}
