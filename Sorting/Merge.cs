using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class Merge : Sorter<int>
    {
        public Merge(int[] values) : base(values, x=>x, (l,r)=>r>l?1:(l==r)?0:-1)
        {
        }

        public override SortPerformance Sort()
        {
            this.values = Sublist(0, values.Length-1);
            currentSort.Stopped();
            return currentSort;
        }

        private int[] MergeArr(int[] a, int[] b)
        {
            int[] c = new int[a.Length + b.Length];
            for (int i = 0, ai=0, bi=0; i < c.Length; i++)
            {
                int vai = ai < a.Length ? a[ai] : int.MaxValue;
                int vbi = bi < b.Length ? b[bi] : int.MaxValue;
                if (comparator(vai, vbi) == 1)
                {
                    c[i] = a[ai];
                    ai++;
                }
                else
                {
                    c[i] = b[bi];
                    bi++;
                }
                this.currentSort.writes++;
                this.currentSort.reads += 2;
            }
            return c;
        }

        private int[] Sublist(int iStart, int iEnd)
        {
            if (iEnd > iStart+1)
            {
                int span = iEnd - iStart;
                int mid = span / 2;
                var la = Sublist(iStart, iStart + mid - 1);
                var ra = Sublist(iStart+mid, iEnd);

                return MergeArr(la, ra);
            }
            else if (iStart == iEnd)
            {
                return new int[] {GetVal(iStart)};
            }
            else
            {
                int v = GetVal(iStart);
                int vi = GetVal(iEnd);
                return this.comparator(v, vi) == -1 ? new int[] { vi, v } : new int[] { v, vi };
            }
        }
    }
}
