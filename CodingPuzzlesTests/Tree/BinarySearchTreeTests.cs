using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodingPuzzles.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CodingPuzzles.Tree.Tests
{
    [TestClass()]
    public class BinarySearchTreeTests
    {
        [TestMethod()]
        public void InsertTest()
        {
            var bst = new BinarySearchTree<int>();
            var node5 = bst.Insert(5);
            var node3 = bst.Insert(3);
            var node9 = bst.Insert(9);
            var node7 = bst.Insert(7);
            var node4 = bst.Insert(4);
            var node11 = bst.Insert(11);
            var node2 = bst.Insert(2);
            Assert.AreEqual(bst.Root, node5);
            Assert.AreEqual(node3, node5.Left);
            Assert.AreEqual(node9, node5.Right);
            Assert.AreEqual(node2, node3.Left);
            Assert.AreEqual(node4, node3.Right);
            Assert.AreEqual(node7, node9.Left);
            Assert.AreEqual(node11, node9.Right);
            Assert.AreEqual(null, node2.Left);
            Assert.AreEqual(null, node2.Right);
            Assert.AreEqual(null, node4.Left);
            Assert.AreEqual(null, node4.Right);
            Assert.AreEqual(null, node7.Left);
            Assert.AreEqual(null, node7.Right);
            Assert.AreEqual(null, node11.Left);
            Assert.AreEqual(null, node11.Right);

            bst = new BinarySearchTree<int>();
            node5 = bst.Insert(5);
            node4 = bst.Insert(4);
            node3 = bst.Insert(3);
            node2 = bst.Insert(2);
            var node1 = bst.Insert(1);
            Assert.AreEqual(null, node1.Left);
            Assert.AreEqual(null, node1.Right);
            Assert.AreEqual(node2.Left, node1);
            Assert.AreEqual(node2.Right, null);
            Assert.AreEqual(node3.Left, node2);
            Assert.AreEqual(node3.Right, null);
            Assert.AreEqual(node4.Left, node3);
            Assert.AreEqual(node4.Right, null);
            Assert.AreEqual(node5.Left, node4);
            Assert.AreEqual(node5.Right, null);

            bst = new BinarySearchTree<int>();
            node5 = bst.Insert(5);
            var node6 = bst.Insert(6);
            node7 = bst.Insert(7);
            var node8 = bst.Insert(8);
            node9 = bst.Insert(9);
            Assert.AreEqual(node5.Left, null);
            Assert.AreEqual(node5.Right, node6);
            Assert.AreEqual(node6.Left, null);
            Assert.AreEqual(node6.Right, node7);
            Assert.AreEqual(node7.Left, null);
            Assert.AreEqual(node7.Right, node8);
            Assert.AreEqual(node8.Left, null);
            Assert.AreEqual(node8.Right, node9);
            Assert.AreEqual(node9.Left, null);
            Assert.AreEqual(node9.Right, null);
        }

        [TestMethod()]
        public void IsBalancedTest()
        {
            var bst = new BinarySearchTree<int>();
            var node5 = bst.Insert(5);
            var node3 = bst.Insert(3);
            var node9 = bst.Insert(9);
            var node7 = bst.Insert(7);
            var node4 = bst.Insert(4);
            var node11 = bst.Insert(11);
            var node2 = bst.Insert(2);
            Assert.IsTrue(bst.IsBalanced());

            bst = new BinarySearchTree<int>();
            node5 = bst.Insert(5);
            node4 = bst.Insert(4);
            node3 = bst.Insert(3);
            node2 = bst.Insert(2);
            var node1 = bst.Insert(1);
            Assert.IsFalse(bst.IsBalanced());

            bst = new BinarySearchTree<int>();
            node5 = bst.Insert(5);
            var node6 = bst.Insert(6);
            node7 = bst.Insert(7);
            var node8 = bst.Insert(8);
            node9 = bst.Insert(9);
            Assert.IsFalse(bst.IsBalanced());
        }

        [TestMethod()]
        public void IsBalancedTest2()
        {
            var bst = new BinarySearchTree<int>();
            var node5 = bst.Insert(5);
            var node3 = bst.Insert(3);
            var node9 = bst.Insert(9);
            //var node7 = bst.Insert(7);
            var node4 = bst.Insert(4);
            //var node11 = bst.Insert(11);
            var node2 = bst.Insert(2);
            Assert.IsTrue(bst.IsBalanced());
        }

        [TestMethod()]
        public void IsBalancedTest3()
        {
            var bst = new BinarySearchTree<int>();
            var node5 = bst.Insert(5);
            var node3 = bst.Insert(3);
            //var node9 = bst.Insert(9);
            //var node7 = bst.Insert(7);
            var node4 = bst.Insert(4);
            //var node11 = bst.Insert(11);
            var node2 = bst.Insert(2);
            Assert.IsFalse(bst.IsBalanced());
        }

        [TestMethod()]
        public void PreOrderTest()
        {
            var bst = new BinarySearchTree<int>();
            var node5 = bst.Insert(5);
            var node3 = bst.Insert(3);
            var node9 = bst.Insert(9);
            var node7 = bst.Insert(7);
            var node4 = bst.Insert(4);
            var node11 = bst.Insert(11);
            var node2 = bst.Insert(2);

            var results = new int[7];
            var index = 0;
            foreach (var node in bst.PreOrder(bst.Root))
            {
                results[index++] = node;
            }
            Assert.IsTrue(results.ArrayEquals(new int[] { 5, 3, 2, 4, 9, 7, 11 }));

            bst = new BinarySearchTree<int>();
            foreach (var node in bst.PreOrder(bst.Root))
            {
                Assert.Fail("No any node! This not be showed!!!");
            }

            bst = new BinarySearchTree<int>();
            bst.Insert(5);
            foreach (var node in bst.PreOrder(bst.Root))
            {
                Console.WriteLine($"##{node}");
            }
        }

        [TestMethod()]
        public void PreOrderTest1()
        {
            var bst = new BinarySearchTree<int>();
            var node5 = bst.Insert(5);
            var node3 = bst.Insert(3);
            var node9 = bst.Insert(9);
            var node7 = bst.Insert(7);
            var node4 = bst.Insert(4);
            var node11 = bst.Insert(11);
            var node2 = bst.Insert(2);

            var results = new int[7];
            var index = 0;
            foreach (var node in bst.PreOrder())
            {
                results[index++] = node;
            }
            Assert.IsTrue(results.ArrayEquals(new int[] { 5, 3, 2, 4, 9, 7, 11 }));

            bst = new BinarySearchTree<int>();
            foreach (var node in bst.PreOrder())
            {
                Assert.Fail("No any node! This not be showed!!!");
            }

            bst = new BinarySearchTree<int>();
            bst.Insert(5);
            foreach (var node in bst.PreOrder())
            {
                Console.WriteLine($"##{node}");
            }

            bst = new BinarySearchTree<int>();
            bst.Insert(5);
            bst.Insert(4);
            bst.Insert(3);
            bst.Insert(2);
            bst.Insert(1);
            foreach (var node in bst.PreOrder())
            {
                Console.WriteLine($"##{node}");
            }
            bst = new BinarySearchTree<int>();
            bst.Insert(6);
            bst.Insert(7);
            bst.Insert(8);
            bst.Insert(9);
            foreach (var node in bst.PreOrder())
            {
                Console.WriteLine($"##{node}");
            }
        }

        [TestMethod()]
        public void InOrderTest()
        {
            var bst = new BinarySearchTree<int>();
            var node5 = bst.Insert(5);
            var node3 = bst.Insert(3);
            var node9 = bst.Insert(9);
            var node7 = bst.Insert(7);
            var node4 = bst.Insert(4);
            var node11 = bst.Insert(11);
            var node2 = bst.Insert(2);

            var results = new int[7];
            var index = 0;
            foreach (var node in bst.InOrder(bst.Root))
            {
                results[index++] = node;
            }
            Assert.IsTrue(results.ArrayEquals(new int[] { 2, 3, 4, 5, 7, 9, 11 }));

            bst = new BinarySearchTree<int>();
            foreach (var node in bst.InOrder(bst.Root))
            {
                Assert.Fail("No any node! This not be showed!!!");
            }

            bst = new BinarySearchTree<int>();
            bst.Insert(5);
            foreach (var node in bst.InOrder(bst.Root))
            {
                Console.WriteLine($"##{node}");
            }

            bst = new BinarySearchTree<int>();
            bst.Insert(5);
            bst.Insert(4);
            bst.Insert(3);
            bst.Insert(2);
            bst.Insert(1);
            foreach (var node in bst.InOrder(bst.Root))
            {
                Console.WriteLine($"##{node}");
            }
            bst = new BinarySearchTree<int>();
            bst.Insert(6);
            bst.Insert(7);
            bst.Insert(8);
            bst.Insert(9);
            foreach (var node in bst.InOrder(bst.Root))
            {
                Console.WriteLine($"##{node}");
            }
        }

        [TestMethod()]
        public void InOrderTest1()
        {
            var bst = new BinarySearchTree<int>();
            var node5 = bst.Insert(5);
            var node3 = bst.Insert(3);
            var node9 = bst.Insert(9);
            var node7 = bst.Insert(7);
            var node4 = bst.Insert(4);
            var node11 = bst.Insert(11);
            var node2 = bst.Insert(2);

            var results = new int[7];
            var index = 0;
            foreach (var node in bst.InOrder())
            {
                results[index++] = node;
            }
            Assert.IsTrue(results.ArrayEquals(new int[] { 2, 3, 4, 5, 7, 9, 11 }));

            bst = new BinarySearchTree<int>();
            foreach (var node in bst.InOrder())
            {
                Assert.Fail("No any node! This not be showed!!!");
            }

            bst = new BinarySearchTree<int>();
            bst.Insert(5);
            foreach (var node in bst.InOrder())
            {
                Console.WriteLine($"##{node}");
            }

            bst = new BinarySearchTree<int>();
            bst.Insert(5);
            bst.Insert(4);
            bst.Insert(3);
            bst.Insert(2);
            bst.Insert(1);
            foreach (var node in bst.InOrder())
            {
                Console.WriteLine($"##{node}");
            }
            bst = new BinarySearchTree<int>();
            bst.Insert(6);
            bst.Insert(7);
            bst.Insert(8);
            bst.Insert(9);
            foreach (var node in bst.InOrder())
            {
                Console.WriteLine($"##{node}");
            }
        }

        [TestMethod()]
        public void PostOrderTest()
        {
            var bst = new BinarySearchTree<int>();
            var node5 = bst.Insert(5);
            var node3 = bst.Insert(3);
            var node9 = bst.Insert(9);
            var node7 = bst.Insert(7);
            var node4 = bst.Insert(4);
            var node11 = bst.Insert(11);
            var node2 = bst.Insert(2);

            var results = new int[7];
            var index = 0;
            foreach (var node in bst.PostOrder())
            {
                results[index++] = node;
            }
            Assert.IsTrue(results.ArrayEquals(new int[] { 2, 4, 3, 7, 11, 9, 5 }));
        }

        [TestMethod()]
        public void LevelOrderTest()
        {
            var bst = new BinarySearchTree<int>();
            var node5 = bst.Insert(5);
            var node3 = bst.Insert(3);
            var node9 = bst.Insert(9);
            var node7 = bst.Insert(7);
            var node4 = bst.Insert(4);
            var node11 = bst.Insert(11);
            var node2 = bst.Insert(2);

            var results = new int[7];
            var index = 0;
            foreach (var node in bst.LevelOrder())
            {
                results[index++] = node;
            }
            Assert.IsTrue(results.ArrayEquals(new int[] { 5, 3, 9, 2, 4, 7, 11 }));
        }

        [TestMethod()]
        public void BuildTreeTest()
        {
            var preorder = new int[] {7, 10, 4, 3, 1, 2, 8, 11};
            var inorder = new int[] {4, 10, 3, 1, 7, 11, 8, 2};
            var bst = new BinarySearchTree<int>();
            bst.FromPreInOrder(preorder, inorder);
            var build_preorder = bst.PreOrder().ToArray();
            var build_inorder = bst.InOrder().ToArray();
            Assert.IsTrue(preorder.ArrayEquals(build_preorder));
            Assert.IsTrue(inorder.ArrayEquals(build_inorder));
        }
    }
}