using System;
using System.Collections.Generic;
using System.Data.SqlTypes;

namespace CodingPuzzles.Tree
{
    public class BinarySearchTree<T>
        where T : IComparable<T>
    {
        /// <summary>
        /// 树根节点
        /// </summary>
        public BinaryNode<T> Root { get; set; }

        /// <summary>
        /// 通过不断插入节点构造树
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public BinaryNode<T> Insert(T data)
        {
            var n = new BinaryNode<T>(data, null, null);
            if (Root == null)
            {
                Root = n;
            }
            else
            {
                var current = Root;
                BinaryNode<T> parent;
                while (true)
                {
                    parent = current;
                    if (data.CompareTo(current.Data) < 0)
                    {
                        current = current.Left;
                        if (current == null)
                        {
                            parent.Left = n;
                            break;
                        }
                    }
                    else
                    {
                        current = current.Right;
                        if (current == null)
                        {
                            parent.Right = n;
                            break;
                        }
                    }
                }
            }
            return n;
        }

        /// <summary>
        /// 树是否平衡
        /// </summary>
        /// <returns></returns>
        public bool IsBalanced()
        {
            if (Root == null) return true;
            int val = GetBalance(Root);
            if (val == -1) return false;
            return true;
        }

        private int GetBalance(BinaryNode<T> node)
        {
            if (node == null)
                return 0;
            int left = GetBalance(node.Left);
            if (left == -1) return -1;
            int right = GetBalance(node.Right);
            if (right == -1) return -1;
            if (left - right > 1 || right - left > 1)
                return -1;
            return left > right ? left + 1 : right + 1;
        }

        /// <summary>
        /// 树前序遍历
        /// 1. 递归
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public IEnumerable<T> PreOrder(BinaryNode<T> node)
        {
            if (node == null) yield break;
            yield return node.Data;
            foreach (var n in PreOrder(node.Left))
            {
                yield return n;
            }
            foreach (var n in PreOrder(node.Right))
            {
                yield return n;
            }
        }

        /// <summary>
        /// 树前序遍历
        /// 2. 循环
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> PreOrder()
        {
            if(Root == null) yield break;
            var stack = new Stack<BinaryNode<T>>();
            stack.Push(Root);
            while (stack.Count > 0)
            {
                var current = stack.Pop();
                yield return current.Data;
                if(current.Right != null) stack.Push(current.Right);
                if(current.Left != null) stack.Push(current.Left);
            }
        }

        /// <summary>
        /// 树的中序遍历
        /// 1. 递归
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public IEnumerable<T> InOrder(BinaryNode<T> node)
        {
            if(node == null) yield break;
            foreach (var n in InOrder(node.Left))
            {
                yield return n;
            }
            yield return node.Data;
            foreach (var n in InOrder(node.Right))
            {
                yield return n;
            }
        }

        /// <summary>
        /// 树的中序遍历
        /// 2. 循环
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> InOrder()
        {
            if(Root == null) yield break;
            var stack = new Stack<BinaryNode<T>>();
            var current = Root;
            while (stack.Count > 0 || current != null)
            {
                if (current != null)
                {
                    stack.Push(current);
                    current = current.Left;
                }
                else
                {
                    current = stack.Pop();
                    yield return current.Data;
                    current = current.Right;
                }
            }
        }

        /// <summary>
        /// 树的遍历
        /// 1. 递归
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public IEnumerable<T> PostOrder(BinaryNode<T> node)
        {
            if(node == null) yield break;
            foreach (var n in PostOrder(node.Left))
            {
                yield return n;
            }
            foreach (var n in PreOrder(node.Right))
            {
                yield return n;
            }
            yield return node.Data;
        }

        /// <summary>
        /// 树的遍历
        /// 2. 循环
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> PostOrder()
        {
            if(Root == null) yield break;
            var current = Root;
            var stack = new Stack<BinaryNode<T>>();
            BinaryNode<T> last_visited = null;
            BinaryNode<T> peek = null;

            while (stack.Count > 0 || current != null)
            {
                if (current != null)
                {
                    stack.Push(current);
                    current = current.Left;
                }
                else
                {
                    peek = stack.Peek();
                    if (peek.Right != null && last_visited != peek.Right)
                    {
                        current = peek.Right;
                    }
                    else
                    {
                        stack.Pop();
                        yield return peek.Data;
                        last_visited = peek;
                    }
                }
            }
        }

        /// <summary>
        /// 树的层级遍历
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> LevelOrder()
        {
            if(Root == null) yield break;
            var queue = new Queue<BinaryNode<T>>();
            queue.Enqueue(Root);
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                yield return current.Data;
                if(current.Left != null) queue.Enqueue(current.Left);
                if(current.Right != null) queue.Enqueue(current.Right);
            }
        }

        /// <summary>
        /// 从前序遍历和中序遍历构造二叉树
        /// </summary>
        /// <param name="preorder"></param>
        /// <param name="inorder"></param>
        public void FromPreInOrder(T[] preorder, T[] inorder)
        {
            Root = BuildTreePI(preorder, inorder,
                0, preorder.Length - 1, 0, preorder.Length);
        }

        private BinaryNode<T> BuildTreePI(
            T[] preorder,
            T[] inorder,
            int p_s, int p_e,
            int i_s, int i_e)
        {
            if (p_s > p_e) return null;
            T pivot = preorder[i_s];
            int i = p_s;
            for (; i < p_e; i++)
            {
                if (inorder[i].CompareTo(pivot) == 0) break;
            }
            BinaryNode<T> node = new BinaryNode<T>(pivot)
            {
                Left = BuildTreePI(preorder, inorder, p_s, i - 1, i_s + 1, i - p_s + i_s),
                Right = BuildTreePI(preorder, inorder, i + 1, p_e, i - p_s + i_s + 1, i_e)
            };
            return node;
        }
    }

}