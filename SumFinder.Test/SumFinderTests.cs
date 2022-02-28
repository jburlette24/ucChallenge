using NUnit.Framework;

namespace SumFinder.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(new int[]{  -1, 2, 1, 4 }, 1, 2)]
        [TestCase(new int[]{ 27, 4, 15, -12, 48, -1, 67, 7 }, 6, 7)]
        [TestCase(new int[] { -1, 99, 66, 55}, -2, 120)]
        public void CalculateSums(int[] numbers, int target, int expected )
        {
            var result = UtilityCloudChallenge.SumFinder.SumThreeClosest(numbers, target);
            
            Assert.AreEqual(expected, result);
        }
    }
}