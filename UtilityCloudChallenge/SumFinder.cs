using System;
using System.Collections.Generic;
using System.Linq;

namespace UtilityCloudChallenge
{
    public class SumFinder
    {

        public int SumThreeClosest(int[] numbers, int target, bool recursive = true)
        {
            var sums = new List<int>();
            if (recursive)
            {
                CalculateSumsRecursive(numbers, sums, 0, null);
            }
            else
            {
                sums = CalculateSums(numbers);
            }
            return sums.OrderBy(sum => Math.Abs(target - sum)).First();
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
        private static void CalculateSumsRecursive(int[] numbers, List<int> sums, int currentIndex, List<int> indexList = null)
        {
            indexList ??= new List<int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (indexList.Contains(i))
                {
                    continue;
                }

                if (indexList.Count == 2)
                {
                    sums.Add(numbers[i] + numbers[indexList[0]] + numbers[indexList[1]]);
                    if (currentIndex < numbers.Length)
                    {
                        CalculateSumsRecursive(numbers, sums, currentIndex + 1, new List<int> { currentIndex });
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    indexList.Add(i);
                    if (currentIndex < numbers.Length)
                    {
                        CalculateSumsRecursive(numbers, sums, currentIndex, new List<int>(indexList));
                    }else
                    {
                        return;
                    }
                }
            }
        }
    }
}
