using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public abstract class Sorter<T>
    {
        public T[] values { get; protected set; }

        public void SetVal(int idx, T val)
        {
            values[idx] = val;
            currentSort.writes++;
        }

        public T GetVal(int idx)
        {
            currentSort.reads++;
            return values[idx]; 
        }

        public bool OrderCheck(Func<T,T,bool> order)
        {
            for (int i = 0; i < values.Length-1; i++)
            {
                if (!order(values[i], values[i + 1])) return false;
            }
            return true;
        }

        protected SortPerformance currentSort;
        public abstract SortPerformance Sort();
        protected Func<T, int> selector;
        protected Func<int, int, int> comparator;

        public Sorter(T[] values, Func<T, int> selector, Func<int, int, int> comparator)
        {
            this.values = values;
            this.selector = selector;
            this.comparator = comparator;
            this.currentSort = new SortPerformance();
        }
    }

    public class SortPerformance
    {
        public int reads;
        public int writes;
        public int ms;
        private DateTime start, end;
        public TimeSpan elapsed
        {
            get { return end - start; }
        }

        public void Stopped()
        {
            end = DateTime.Now;
        }

        public SortPerformance()
        {
            reads = 0; writes = 0; ms = 0;
            start = DateTime.Now;
        }
    }
}
