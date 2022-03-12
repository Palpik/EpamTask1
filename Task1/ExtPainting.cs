using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public static class PaintingListExtension
    {
        public static List<Painting> FindByTechnic(this PaintingList pl, string technic)
        {
            return pl.Paintings.FindAll(delegate (Painting p) 
            { 
                if(p is ExtPainting ep)
                    return ep.Technic == technic;
                return false;
            });
        }
    }
    public class ExtPainting : Painting
    {
        public string Technic { get; }
        public ExtPainting(string name, string genre, string author, int year, string technic) : base(name, genre, author, year)
        {
            Technic = technic;
        }
        public override int IsSimilarTo(Painting painting)
        {
            int score = base.IsSimilarTo(painting);
            if (painting is ExtPainting extpainting)
            {
                score += Technic == extpainting.Technic ? 1 : 0;
                return score;
            }
            return score;
        }
        public override string ToString()
        {
            return $"[{Name};{Genre};{Author};{Year};{Technic}]";
        }
        public override int GetHashCode()
        {
            return (Name + Genre + Author + Year.ToString() + Technic).GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj is ExtPainting extPainting)
                return base.Equals(extPainting) && extPainting.Technic == Technic;
            return false;
        }
    }
}
