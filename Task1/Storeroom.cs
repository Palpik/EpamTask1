using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Storeroom : PaintingList
    {
        private List<Painting> _paintings;
        public override List<Painting> Paintings
        {
            get
            {
                return _paintings;
            }
        }
        public Storeroom()
        {
            _paintings = new List<Painting>();
        }
        public Storeroom(IEnumerable<Painting> paintings)
        {
            _paintings = new List<Painting>(paintings);
        }
        
        public override string ToString()
        {
            string tostring = "";
            foreach (Painting p in Paintings)
                tostring += p.ToString() + "\n";
            return tostring;
        }
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj is Storeroom storeroom)
                return ToString().Equals(storeroom.ToString());
            return false;
        }
    }
}
