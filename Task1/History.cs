using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    
    public class History
    {
        public List<Exhibition> Exhibitions { get; }
        private bool _isGoingExhibit = false;
        public bool IsGoingExhibit 
        { 
            get { return _isGoingExhibit; }
            set { _isGoingExhibit = value; }
        }
        public void StartExhibit()
        {
            if (IsGoingExhibit)
                Exhibitions[^1].End = DateTime.Now;
            Exhibitions.Add(new Exhibition(DateTime.Now));
            IsGoingExhibit = true;
        }
        public void StartExhibit(DateTime time)
        {
            if (IsGoingExhibit)
                Exhibitions[^1].End = time;
            Exhibitions.Add(new Exhibition(time));
            IsGoingExhibit = true;
        }
        public void EndExhibit()
        {
            if (IsGoingExhibit == true)
                Exhibitions[^1].End = DateTime.Now;
            IsGoingExhibit = false;
        }
        public void EndExhibit(DateTime time)
        {
            if (IsGoingExhibit == true)
                Exhibitions[^1].End = time;
            IsGoingExhibit = false;
        }
        public History()
        {
            Exhibitions = new List<Exhibition>();
        }
        public override string ToString()
        {
            string tostring = "";
            for (int i = 0; i < Exhibitions.Count; i++)
                tostring += Exhibitions[i].ToString() + "\n";
            return tostring;
        }
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj is History story)
                return ToString().Equals(story.ToString());
            return false;
        }
    }
}
