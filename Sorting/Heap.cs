using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class Heap<T> : Sorter<T>
    {
        public Heap(T[] values, Func<T, int> selector, Func<int, int, int> comparator) : base(values, selector, comparator)
        {
        }

        public override SortPerformance Sort()
        {
            throw new NotImplementedException();
        }
    }
}
