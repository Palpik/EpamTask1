using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    /// <summary>
    /// Class of the painting
    /// Сontains information about the name, genre, author and year of creation
    /// Implements the isSimilarTo method of the IsSimilar interface. 
    /// If the fields completely match returns 4.
    /// </summary>
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
        /// <summary>
        /// Method counts field matches this painting with another.
        /// If there are no matches returns 0.
        /// Max score 4. This score means That paintings are equal.
        /// </summary>
        /// <param name="painting">painting for comparing</param>
        /// <returns>returns count of field matches</returns>
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
}