using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Storeroom : PaintingList
    {
        private List<Painting> _paintings = new List<Painting>();
        public override List<Painting> Paintings
        {
            get
            {
                return _paintings;
            }
        }
        public Storeroom() { }
        public Storeroom(IEnumerable<Painting> paintings)
        {
            _paintings = new List<Painting>(paintings);
        }
        
        public override string ToString()
        {
            return Paintings.ToString();
        }
        public override int GetHashCode()
        {
            return Paintings.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj is Storeroom sroom)
                return Paintings.Equals(sroom.Paintings);
            return false;
        }
    }
}
