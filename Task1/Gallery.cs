using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
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
