using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public static class Rand
    {
        private static Random rnd = new Random((int)System.DateTime.Now.Ticks);
        public static int[] RandomArray(int length)
        {
            int[] array = new int[length];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next();
            }
            return array;
        }
    }
}
