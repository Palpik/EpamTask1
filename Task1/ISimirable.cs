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
}
