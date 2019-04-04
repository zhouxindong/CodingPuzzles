using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodingPuzzles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingPuzzles.Tests
{
    [TestClass()]
    public class HelperTests
    {
        [TestMethod()]
        public void ArrayEqualsTest()
        {
            Assert.IsFalse((new int[1]).ArrayEquals(null));
            Assert.IsTrue((new int[] {1,2,3,4,5}).ArrayEquals(new int[] {1,2,3,4,5}));
            Assert.IsFalse((new int[] {1,2,3,4,5}).ArrayEquals(new int[] {1,2,3,4,5,6}));
            Assert.IsFalse((new int[] {1,2,3,4,5}).ArrayEquals(new int[] {5,4,3,2,1}));
        }
    }
}