using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat2Deo_Verzija1.Entiteti
{
    public class SegrtId
    {
        public virtual Lik Gazda { get; set; }
        public virtual String Ime { get; set; }

        public override bool Equals(object obj)
        {
            if (Object.ReferenceEquals(this, obj))
                return true;

            if (obj.GetType() != typeof(SegrtId))
                return false;

            SegrtId recievedObject = (SegrtId)obj;

            if ((Gazda.Id == recievedObject.Gazda.Id) &&
                (Ime == recievedObject.Ime))
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
