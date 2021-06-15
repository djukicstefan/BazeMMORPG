using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Projekat2Deo_Verzija1.Entiteti;

namespace Projekat2Deo_Verzija1.Mapiranja
{
    class BonusPredmetiIOruzijaMapiranja : SubclassMap<BonusPredmetiIOruzija>
    {
        public BonusPredmetiIOruzijaMapiranja()
        {
            Table("BONUS_PREDMETI_I_ORUŽIJA");

            KeyColumn("ID");

            Map(b => b.BrojIskustvenihPoena, "Broj_iskustvenih_poena");
            Map(b => b.Rasa);
            Map(b => b.PPredmet);
        }
    }
}
