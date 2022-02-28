using System;
using System.Collections.Generic;
using System.Linq;

namespace UtilityCloudChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { -1, 2, 1, 4 };
            int target = 1;
            Console.WriteLine($"Result: {UtilityCloudChallenge.SumFinder.SumThreeClosest(numbers, target)}");
        }


    }
}

