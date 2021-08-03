using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqExercitii
{
    public class IntOperations
    {
        private readonly int[] array;
        private readonly int number;

        public IntOperations(int[] array, int number)
        {
            this.array = array;
            this.number = number;
        }

        public IEnumerable GenerateSubArrayWithSumLessThanNumber()
        {
            var result = from i in Enumerable.Range(0, array.Length)
                         from j in Enumerable.Range(1, array.Length - i)
                         let subarray = array.Skip(i).Take(j)
                         orderby subarray.Count()
                         where subarray.Sum() <= number
                         select subarray.ToList();

            return result;
        }
    }
}
