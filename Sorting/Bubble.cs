using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class Bubble : Sorter<int>
    {
        public Bubble(int[] values) : base(values, x => x, (l, r) => r > l ? 1 : (l == r) ? 0 : -1)
        {
        }

        public override SortPerformance Sort()
        {
            int iRight = 0;
            bool arrayChanged = true;
            while (arrayChanged)
            {
                arrayChanged = false;
                for (int i = 0; i < values.Length - iRight - 1; i++)
                {
                    int v = GetVal(i), vi = GetVal(i + 1);
                    if (this.comparator(v, vi) <= 0)
                    {
                        SetVal(i, vi);
                        SetVal(i + 1, v);
                        arrayChanged = true;
                    }
                }
                iRight++;
            }
            currentSort.Stopped();
            return currentSort;
        }
    }
}
