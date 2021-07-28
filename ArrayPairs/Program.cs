using System;
using System.Linq;

namespace ArrayPairs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solve(new int[] { 1, 1, 2, 4, 2 }));
            Console.ReadKey();
        }

        static long solve(int[] arr)
        {
            long[] array = arr.Select(x => (long)x).ToArray();
            sort(array);

            int cut = 0;
            while (cut < array.Length && array[cut] * array[cut] <= array[array.Length - 1])
                cut++;

            long total = cut * (cut - 1) / 2;

            int i = cut;
            while (i >= 0)
            {
                if (array[cut] * array[i] <= array[array.Length - 1])
                {
                    total = total + i + 1;
                    break;
                }
                i--;
            }
            return total;
        }
        static void sort(long[] arr)
        {
            long n = arr.Length;

            // Build heap (rearrange array) 
            for (long i = n / 2 - 1; i >= 0; i--)
                heapify(arr, n, i);

            // One by one extract an element from heap 
            for (long i = n - 1; i >= 0; i--)
            {
                // Move current root to end 
                long temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;

                // call max heapify on the reduced heap 
                heapify(arr, i, 0);
            }
        }
        static void heapify(long[] arr, long n, long i)
        {
            long largest = i; // Initialize largest as root 
            long l = 2 * i + 1; // left = 2*i + 1 
            long r = 2 * i + 2; // right = 2*i + 2 

            // If left child is larger than root 
            if (l < n && arr[l] > arr[largest])
                largest = l;

            // If right child is larger than largest so far 
            if (r < n && arr[r] > arr[largest])
                largest = r;

            // If largest is not root 
            if (largest != i)
            {
                long swap = arr[i];
                arr[i] = arr[largest];
                arr[largest] = swap;

                // Recursively heapify the affected sub-tree 
                heapify(arr, n, largest);
            }
        }
    }
}
