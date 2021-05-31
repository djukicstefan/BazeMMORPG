using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat2Deo_Verzija1.Entiteti
{
    public class SavezAlijansiId
    {
        public virtual Alijansa AlijansaJedan { get; set; }
        public virtual Alijansa AlijansaDva { get; set; }

        public override bool Equals(object obj)
        {
            if (Object.ReferenceEquals(this, obj))
                return true;

            if (obj.GetType() != typeof(SavezAlijansiId))
                return false;

            SavezAlijansiId recievedObject = (SavezAlijansiId)obj;

            if ((AlijansaJedan.Naziv == recievedObject.AlijansaJedan.Naziv) &&
                (AlijansaDva.Naziv == recievedObject.AlijansaDva.Naziv))
            {
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
