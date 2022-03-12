using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Hall : PaintingList
    {
        private Dictionary<int, Painting> _places;
        public Dictionary<int, Painting> Places => _places;
        public override List<Painting> Paintings => Places.Values.ToList();
        public Hall()
        {
            _places = new Dictionary<int, Painting>();
        }
        public Hall(Dictionary<int, Painting> dict)
        {
            _places = new Dictionary<int, Painting>(dict);
        }
        public override string ToString()
        {
            string tostring = "";
            foreach (int i in Places.Keys)
                tostring = $"{i} - {Places[i]}\n";
            return tostring;
        }
        public override int GetHashCode()
        {
            return Places.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if(obj is Hall hall)
                return Places.Equals(hall.Places);
            return false;
        }
    }
}
