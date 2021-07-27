using System;

namespace LeftRotationArray
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] nd = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(nd[0]);

            int d = Convert.ToInt32(nd[1]);

            int[] a = Array.ConvertAll(nd, aTemp => Convert.ToInt32(aTemp));

            //function call
            RotateLeft(n, d, a);
        }


        //length - rot + index
        static void RotateLeft(int n, int d, int[] a)
        {
            d = d % n;
            int[] finalArr = new int[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                int index = n - d + i;
                if (index > a.Length - 1)
                    index = index % a.Length;
                finalArr[index] = a[i];
            }
            //print in , seperated way
            for (int i = 0; i < finalArr.Length; i++)
            {
                Console.Write(finalArr[i] + " ");
            }
        }

    }
}
