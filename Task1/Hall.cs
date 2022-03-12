using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Hall : PaintingList
    {
        Dictionary<int, Painting> places = new Dictionary<int, Painting>();
        public override List<Painting> Paintings
        {
            get
            {
                return places.Values.ToList();
            }
        }
        public Dictionary<int, Painting> Places
        {
            get
            {
                return Places;
            }
        }
        public Hall()
        { }
        public Hall(Dictionary<int, Painting> dict)
        {
            places = new Dictionary<int, Painting>(dict);
        }
        public override string ToString()
        {
            return Places.ToString();
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
