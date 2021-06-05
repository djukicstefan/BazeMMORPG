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
    public class AlijansaMapiranja : ClassMap<Alijansa>
    {
        public AlijansaMapiranja()
        {
            Table("ALIJANSA");

            Id(a => a.Naziv, "Naziv").GeneratedBy.Assigned(); //Assigned znaci da ga ne generise baza 
                                                              //nego ga korisnik unosi!

            Map(a => a.MaxIgraca, "Max_igrača");
            Map(a => a.MinIgraca, "Min_igrača");
            Map(a => a.BonusIskustvo, "Bonus_iskustvo");
            Map(a => a.BonusZdravlje, "Bonus_zdravlje");

            HasMany(a => a.Igraci).KeyColumn("Naziv_alijanse").LazyLoad().Cascade.All().Inverse();

            /* HasMany(a => a.AlijanseUSavezu)
                 .Table("SAVEZ_ALIJANSI")
                 .KeyColumn("Naziv_prve")
                 .LazyLoad()
                 .Cascade.All()
                 .Inverse();*/

            HasMany(a => a.GrupniZadaci).KeyColumn("Naziv_alijanse").LazyLoad().Cascade.All().Inverse();

            HasMany(a => a.AlijanseUSavezu).KeyColumn("Naziv_prve").LazyLoad().Cascade.All().Inverse();
        }
        
    }
}
