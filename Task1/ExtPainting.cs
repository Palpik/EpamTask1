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
    /// <summary>
    /// Extended painting inherited class Painting and supplemented with information
    /// about technic.
    /// </summary>
    public class ExtPainting : Painting
    {
        public string Technic { get; }
        public ExtPainting(string name, string genre, string author, int year, string technic) : base(name, genre, author, year)
        {
            Technic = technic;
        }
        /// <summary>
        /// Method counts field matches this painting with another.
        /// If there are no matches returns 0.
        /// Max score 5. This score means That paintings are equal.
        /// </summary>
        /// <param name="painting">painting for comparing</param>
        /// <returns>returns count of field matches</returns>
        /// <returns></returns>
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
