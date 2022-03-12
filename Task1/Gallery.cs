using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Gallery
    {
        public Storeroom storeroom;
        public Dictionary<int,Hall> halls = new Dictionary<int,Hall>();
        public Dictionary<Painting, History> history = new Dictionary<Painting, History>();
        public Gallery(IEnumerable<Painting> list)
        {
            storeroom = new Storeroom(list);
        }
        public void ExhebitTo(int paintingNum, Hall hall, int placeNum)
        {
            if (paintingNum >= storeroom.Paintings.Count)
                throw new IndexOutOfRangeException();
            if (hall.Places.ContainsKey(placeNum))
            {
                storeroom.Paintings.Add(hall.Places[placeNum]);
                history[hall.Places[placeNum]].EndExhibit();
            }
            hall.Places[placeNum] = storeroom.Paintings[paintingNum];
            history[storeroom.Paintings[paintingNum]].StartExhibit();
            storeroom.Paintings.RemoveAt(paintingNum);
        }
        public void Move(Hall hall1, int placeNum1, Hall hall2, int placeNum2)
        {
            if (hall1.Places.ContainsKey(placeNum1) == false)
                throw new IndexOutOfRangeException();
            if (hall2.Places.ContainsKey(placeNum2) )
            {
                storeroom.Paintings.Add(hall2.Places[placeNum2]);
                history[hall2.Places[placeNum2]].EndExhibit();
            }
            hall2.Places[placeNum2] = hall1.Places[placeNum1];
            history[hall2.Places[placeNum2]].StartExhibit();
            hall1.Places.Remove(placeNum1);
        }
        public void InStoreroom(Hall hall, int placeNum)
        {
            if(hall.Places.ContainsKey(placeNum) == false)
                throw new IndexOutOfRangeException();
            storeroom.Paintings.Add(hall.Places[placeNum]);
            history[hall.Places[placeNum]].EndExhibit();
            hall.Places.Remove(placeNum);
        }
        public override string ToString()
        {
            string tostring = storeroom.ToString();
            foreach (Hall hall in halls.Values)
                tostring += hall.ToString();
            return tostring;
        }
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
        public override bool Equals(object? obj)
        {
            if(obj is Gallery gallery)
                return this.ToString().Equals(gallery.ToString());
            return false;
        }
    }
}
