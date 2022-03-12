using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    /// <summary>
    /// Contains list of exhibitions info
    /// </summary>
    public class History
    {
        public List<Exhibition> Exhibitions { get; }
        private bool _isGoingExhibit = false;
        public bool IsGoingExhibit 
        { 
            get { return _isGoingExhibit; }
            set { _isGoingExhibit = value; }
        }
        /// <summary>
        /// открывает новую выставку
        /// Если выставка идет закрывает её и открывает новую
        /// </summary>
        public void StartExhibit()
        {
            if (IsGoingExhibit)
                Exhibitions[^1].End = DateTime.Now;
            Exhibitions.Add(new Exhibition(DateTime.Now));
            IsGoingExhibit = true;
        }

        /// <summary>
        /// открывает новую выставку на заданную дату.
        /// Если выставка идет закрывает её и открывает новую
        /// </summary>
        /// <param name="time"></param>
        public void StartExhibit(DateTime date)
        {
            if (IsGoingExhibit)
                Exhibitions[^1].End = date;
            Exhibitions.Add(new Exhibition(date));
            IsGoingExhibit = true;
        }
        /// <summary>
        /// Если идет выставка закрывает её
        /// </summary>
        public void EndExhibit()
        {
            if (IsGoingExhibit == true)
                Exhibitions[^1].End = DateTime.Now;
            IsGoingExhibit = false;
        }
        /// <summary>
        /// Если идет выставвка закрывает её на заданную дату
        /// </summary>
        /// <param name="date"></param>
        public void EndExhibit(DateTime date)
        {
            if (IsGoingExhibit == true)
                Exhibitions[^1].End = date;
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
