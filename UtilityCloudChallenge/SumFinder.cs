using System;
using System.Collections.Generic;
using System.Linq;

namespace UtilityCloudChallenge
{
    public class SumFinder
    {
        public static int SumThreeClosest(int[] numbers, int target)
        {
            var sums = CalculateSums(numbers);
            return sums.OrderBy(sum => Math.Abs(target - sum)).First();
        }

        private static List<int> CalculateSums(int[] numbers)
        {
            List<int> sums = new List<int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 0; j < numbers.Length; j++)
                {
                    if (j != i)
                    {
                        for (int k = 0; k < numbers.Length; k++)
                        {
                            if (k != i && k != j)
                            {
                                sums.Add(numbers[i] + numbers[j] + numbers[k]);
                            }
                        }
                    }
                }

            }
            return sums;
        }
    }
}
