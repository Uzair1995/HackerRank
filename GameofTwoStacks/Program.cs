using System;

namespace GameofTwoStacks
{
    class Program
    {
        static void Main(string[] args)
        {
            int g = Convert.ToInt32(Console.ReadLine());
            for (int gItr = 0; gItr < g; gItr++)
            {
                string[] nmx = Console.ReadLine().Split(' ');

                int n = Convert.ToInt32(nmx[0]);

                int m = Convert.ToInt32(nmx[1]);

                int x = Convert.ToInt32(nmx[2]);

                int[] a = Array.ConvertAll(Console.ReadLine().Split(' '), aTemp => Convert.ToInt32(aTemp))
                ;

                int[] b = Array.ConvertAll(Console.ReadLine().Split(' '), bTemp => Convert.ToInt32(bTemp))
                ;
                int result = twoStacks(x, a, b);
                Console.WriteLine(result);
            }
        }

        static int twoStacks(int x, int[] a, int[] b)
        {
            int lengthB = 0;
            int sum = 0;
            while (lengthB < b.Length && sum + b[lengthB] <= x)
            {
                sum += b[lengthB];
                lengthB++;
            }

            int maxScore = lengthB;
            for (int lengthA = 1; lengthA <= a.Length; lengthA++)
            {
                sum += a[lengthA - 1];

                while (sum > x && lengthB > 0)
                {
                    lengthB--;
                    sum -= b[lengthB];
                }

                if (sum > x)
                {
                    break;
                }

                maxScore = Math.Max(maxScore, lengthA + lengthB);
            }
            return maxScore;
        }
    }
}
