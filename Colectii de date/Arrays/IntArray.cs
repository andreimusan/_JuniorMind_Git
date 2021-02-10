using System;

namespace Arrays
{
    class IntArray
    {
        int[] array;

        public IntArray()
        {
            // construiește noul șir
            array = new int[] { };
        }

        public void Add(int element)
        {
            // adaugă un nou element la sfârșitul șirului
            Array.Resize(ref array, array.Length + 1);
            array[array.Length - 1] = element;
        }
    }
}
