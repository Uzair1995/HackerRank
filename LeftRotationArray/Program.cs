using System;

namespace LeftRotationArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter space seperated integer array for rotation. Example -> [1 2 3 4 5]: ");
            string[] nd = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(nd[0]);
            int d = Convert.ToInt32(nd[1]);
            int[] a = Array.ConvertAll(nd, aTemp => Convert.ToInt32(aTemp));

            Console.WriteLine("Please enter how many times to rotate the array: ");
            int times = Convert.ToInt32(Console.ReadLine());


            for (int i = 0; i < times; i++)
            {
                Console.Write($"Iteration # {i + 1}: ");
                a = RotateLeft(n, d, a);
                
                for (int j = 0; j < a.Length; j++)
                    Console.Write(a[j] + " ");
                Console.WriteLine();
            }
        }


        static int[] RotateLeft(int n, int d, int[] a)
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

            return finalArr;
        }

    }
}
