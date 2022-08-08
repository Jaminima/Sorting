using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class Heap<T> : Sorter<T>
    {
        public Heap(T[] values, Func<T, int> selector) : base(values, selector)
        {
        }
        public Heap(T[] values, Func<T, int> selector, Func<T,T,int> comparator) : base(values, selector, comparator)
        {
        }

        protected int parentIDX(int i)
        {
            return (int)Math.Floor((i - 1)/2.0f);
        }

        protected int leftIDX(int i)
        {
            return 2 * i + 1;
        }
        protected int rightIDX(int i)
        {
            return 2 * i + 2;
        }

        protected void swapArr(int i, int j)
        {
            T t = GetVal(i);
            SetVal(i, GetVal(j));
            SetVal(j,t);
        }

        protected void siftDown(int startIDX, int endIDX)
        {
            int root = startIDX;

            while (leftIDX(root) <= endIDX)
            {
                int child = leftIDX(root);
                int swap = child;

                if (child+1 <= endIDX && this.comparator(GetVal(swap), GetVal(child + 1))==-1)
                {
                    swap = child + 1;
                }
                if (swap == root)
                {
                    return;
                }
                else
                {
                    swapArr(root, swap);
                    root = swap;
                }
            }
        }

        protected void Heapify()
        {
            int curIDX = parentIDX(this.values.Length-1);

            while (curIDX >= 0)
            {
                siftDown(curIDX, this.values.Length - 1);

                curIDX--;
            }
        }

        public override SortPerformance Sort()
        {
            this.Heapify();

            int end = this.values.Length - 1;

            while (end > 0)
            {
                swapArr(end, 0);
                end--;
                siftDown(0, end);
            }

            currentSort.Stopped();
            return currentSort;
        }
    }
}
