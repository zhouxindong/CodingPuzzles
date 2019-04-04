using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodingPuzzles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingPuzzles.Tests
{
    [TestClass()]
    public class NumberSumTests
    {
        [TestMethod()]
        public void TwoSumTest()
        {
            var result = NumberSum.TwoSum(new[] { 7, 11, 2, 15 }, 9);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void CombinationSumTest()
        {
            var result = NumberSum.CombinationSum(new[] {2, 3, 6, 7}, 7, true);
            PrintResult(result); // [2,2,3][7]

            result = NumberSum.CombinationSum(new[] {10, 1, 2, 7, 6, 1, 5}, 8, false);
            PrintResult(result);
        }

        private void PrintResult(List<int[]> result)
        {
            foreach (var item in result)
            {
                foreach (var v in item)
                {
                    Console.Write($"{v} ");
                }
                Console.WriteLine();
            }
        }
    }
}