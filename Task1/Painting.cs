using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public interface ISimilarable
    {
        public int IsSimilarTo(object obj);
    }
    public interface ISimilarable<T>
    {
        public int IsSimilarTo(T obj);
    }
    public class Painting : ISimilarable<Painting>
    {
        public string Name { get; }
        public string Genre { get; }
        public string Author { get; }
        public int? Year { get; }
        public Painting(string name, string genre, string author,int year)
        {
            Name = name;
            Genre = genre;
            Author = author;
            Year = year;
        }
        public virtual int IsSimilarTo(Painting painting)
        {
            if (painting is null)
                return 0;
            int score = 0;
            score += this.Name == painting.Name ? 1 : 0;
            score += this.Author == painting.Author ? 1 : 0;
            score += this.Genre == painting.Genre ? 1 : 0;
            score += this.Year == painting.Year? 1 : 0;
            return score;
        }
        public override string ToString()
        {
            return $"[{Name};{Genre};{Author};{Year}]";
        }
        public override int GetHashCode()
        {
            string hash = Name + Genre + Author + Year.ToString();
            return hash.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if(obj is Painting p)
            {
                if(Name.Equals(p.Name) && Genre.Equals(p.Genre) && Author.Equals(p.Author) && Year.Equals(p.Year))
                    return true;
            }
            return false;
        }
    }
    public class ExtPainting : Painting
    { 
        public string Technic { get; }
        public ExtPainting(string name, string genre, string author, int year, string technic) : base(name,genre,author,year)
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