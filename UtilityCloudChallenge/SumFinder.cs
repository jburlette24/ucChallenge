using System;
using System.Collections.Generic;
using System.Linq;

namespace UtilityCloudChallenge
{
    public class SumFinder
    {
        private static List<int> Sums = new List<int>();

        public int SumThreeClosest(int[] numbers, int target, bool recursive = true)
        {
            Sums.Clear();
            if (recursive)
            {
                CalculateSumsRecursive(numbers);
            }
            else
            {
                Sums = CalculateSums(numbers);
            }
            return Sums.OrderBy(sum => Math.Abs(target - sum)).First();
        }

        /*Nested Loops*/
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

        /* Recursive */
        private static void CalculateSumsRecursive(int[] numbers, List<int> indexList = null, int currentIndex = 0 )
        {
            indexList ??= new List<int>();

            for (int i = 0; i < numbers.Length && currentIndex < numbers.Length; i++)
            {
                if (indexList.Contains(i))
                {
                    continue;
                }

                if (indexList.Count == 2)
                {
                    Sums.Add(numbers[i] + numbers[indexList[0]] + numbers[indexList[1]]);
                    CalculateSumsRecursive(numbers, new List<int>(), currentIndex++);
                }
                else
                {
                    indexList.Add(i);
                    CalculateSumsRecursive(numbers, indexList, currentIndex);
                }
            }
        }
    }
}
