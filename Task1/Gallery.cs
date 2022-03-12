using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    /// <summary>
    /// A class of Gallery. Contains storeroom, halls and history for all exhibited paintings 
    /// </summary>
    public class Gallery
    {
        private Storeroom _storeroom;
        private Dictionary<int,Hall> _halls = new Dictionary<int,Hall>();
        private Dictionary<Painting, History> _history = new Dictionary<Painting, History>();
        public Storeroom Storeroom => _storeroom;
        public Dictionary<int, Hall> Halls => _halls;
        public Dictionary<Painting, History> History => _history;


        public Gallery()
        {
            _storeroom = new Storeroom();
        }
        public Gallery(IEnumerable<Painting> list)
        {
            _storeroom = new Storeroom(list);
        }
        /// <summary>
        /// Method places given Painting in given hall and place and saves history of exhibitions.
        /// If there are painting in given place of hall moves it in storeroom.  
        /// </summary>
        /// <param name="paintingNum">index of Painting in storeroom</param>
        /// <param name="hall"></param>
        /// <param name="placeNum">number of place</param>
        public void ExhebitTo(int paintingNum, Hall hall, int placeNum)
        {
            if (paintingNum >= Storeroom.Paintings.Count)
                throw new IndexOutOfRangeException();
            if (hall.Places.ContainsKey(placeNum))
            {
                Storeroom.Paintings.Add(hall.Places[placeNum]);
                History[hall.Places[placeNum]].EndExhibit();
            }
            hall.Places[placeNum] = Storeroom.Paintings[paintingNum];
            if (!History.ContainsKey(Storeroom.Paintings[paintingNum]))
                History[Storeroom.Paintings[paintingNum]] = new History();
            History[Storeroom.Paintings[paintingNum]].StartExhibit();
            Storeroom.Paintings.RemoveAt(paintingNum);
        }

        /// <summary>
        /// Method moves given Painting in given hall and place and saves history of exhibitions.
        /// If there are painting in given place of hall moves it in storeroom.  
        /// </summary>
        /// <param name="hall1"></param>
        /// <param name="placeNum1"></param>
        /// <param name="hall2"></param>
        /// <param name="placeNum2"></param>
        public void Move(Hall hall1, int placeNum1, Hall hall2, int placeNum2)
        {
            if (hall1.Places.ContainsKey(placeNum1) == false)
                throw new IndexOutOfRangeException();
            if (hall2.Places.ContainsKey(placeNum2) )
            {
                Storeroom.Paintings.Add(hall2.Places[placeNum2]);
                History[hall2.Places[placeNum2]].EndExhibit();
            }
            hall2.Places[placeNum2] = hall1.Places[placeNum1];
            History[hall2.Places[placeNum2]].StartExhibit();
            hall1.Places.Remove(placeNum1);
        }
        /// <summary>
        /// Method moves given Painting in storeroom and saves history of exhibitions.
        /// </summary>
        /// <param name="hall"></param>
        /// <param name="placeNum"></param>
        public void ToStoreroom(Hall hall, int placeNum)
        {
            if(hall.Places.ContainsKey(placeNum) == false)
                throw new IndexOutOfRangeException();
            Storeroom.Paintings.Add(hall.Places[placeNum]);
            History[hall.Places[placeNum]].EndExhibit();
            hall.Places.Remove(placeNum);
        }
        public override string ToString()
        {
            string tostring = Storeroom.ToString();
            foreach (Hall hall in Halls.Values)
                tostring += hall.ToString();
            return tostring;
        }
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if(obj is Gallery gallery)
                return this.ToString().Equals(gallery.ToString());
            return false;
        }
    }
}
