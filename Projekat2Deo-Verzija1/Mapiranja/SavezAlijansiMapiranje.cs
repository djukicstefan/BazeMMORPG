using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Mapping;
using Projekat2Deo_Verzija1.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat2Deo_Verzija1.Mapiranja
{
    public class SavezAlijansiMapiranje : ClassMap<SavezAlijansi>
    {
        public SavezAlijansiMapiranje()
        {
            Table("SAVEZ_ALIJANSI");

            CompositeId(sa => sa.Kljuc)
                .KeyReference(sa => sa.AlijansaJedan, "Naziv_prve")
                .KeyReference(sa => sa.AlijansaDva, "Naziv_druge");
        }
    }
}
