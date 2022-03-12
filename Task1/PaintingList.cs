using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    /// <summary>
    /// A basic abstract class for using a list of paintings.
    /// Implements painting search methods
    /// </summary>
    public abstract class PaintingList
    {
        public abstract List<Painting> Paintings { get; }
        public List<Painting> FindByGenre(string genre)
        {
            return Paintings.FindAll(delegate (Painting p) { return p.Genre == genre; });
        }
        public List<Painting> FindByName(string name)
        {
            return Paintings.FindAll(delegate (Painting p) { return p.Name == name; });
        }
        public List<Painting> FindByAuthor(string author)
        {
            return Paintings.FindAll(delegate (Painting p) { return p.Author == author; });
        }
        public List<Painting> FindByYear(int? year)
        {
            return Paintings.FindAll(delegate (Painting p) { return p.Year == year; });
        }
        public List<Painting> Find(Painting painting)
        {
            return Paintings.FindAll(delegate (Painting p) { return p.IsSimilarTo(painting) > 0; });
        }
    }
}
