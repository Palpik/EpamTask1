using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Exhibition
    {
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public Exhibition(DateTime start)
        {
            Start = start;
        }
        public Exhibition(DateTime start, DateTime end) : this(start)
        {
            End = end;
        }
        public override string ToString()
        {
            if (End is null)
                return $"{((DateTime)Start).ToString("dd.MM.yyyy")} - Going";
            return $"{((DateTime)Start).ToString("dd.MM.yyyy")} - {((DateTime)End).ToString("dd.MM.yyyy")}";
        }
        public override bool Equals(object obj)
        {
            if (obj is Exhibition ex)
                return ex.Start == Start && ex.End == End;
            return false;
        }
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
    }
    public class History
    {
        public List<Exhibition> exhibitions = new List<Exhibition>();
        public bool isGoingExhibit = false;
        public void StartExhibit()
        {
            exhibitions.Add(new Exhibition(DateTime.Now));
            isGoingExhibit = true;
        }
        public void StartExhibit(DateTime time)
        {
            exhibitions.Add(new Exhibition(time));
            isGoingExhibit = true;
        }
        public void EndExhibit()
        {
            if (isGoingExhibit == true)
                exhibitions[^1].End = DateTime.Now;
        }
        public void EndExhibit(DateTime time)
        {
            if (isGoingExhibit == true)
                exhibitions[^1].End = time;
        }
        public override string ToString()
        {
            string tostring = "";
            for (int i = 0; i < exhibitions.Count; i++)
                tostring += exhibitions[i].ToString() + "\n";
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
