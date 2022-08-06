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
        public SortPerformance BulkSort(Func<int, T[]> randArr,int runs=1000,int size = 1000)
        {
            var perfs = new SortPerformance[runs];
            for (int i = 0; i < runs; i++)
            {
                this.values = randArr(size);
                perfs[i] = this.Sort();
                perfs[i].Stopped();
            }

            return new SortPerformance()
            {
                reads = (int)perfs.Average(x => x.reads),
                writes = (int)perfs.Average(x => x.writes),
                ms = (int)perfs.Average(x => x.ms)
            };
        }
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
            ms = (int)(end - start).TotalMilliseconds;
        }

        public SortPerformance()
        {
            reads = 0; writes = 0; ms = 0;
            start = DateTime.Now;
        }
    }
}
