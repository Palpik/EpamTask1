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
}
