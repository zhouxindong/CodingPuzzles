using System;

namespace CodingPuzzles.Tree
{
    public class BinaryNode<T>
        where T : IComparable<T>
    {
        public T Data { get; set; }
        public BinaryNode<T> Left { get; set; }
        public BinaryNode<T> Right { get; set; }

        public BinaryNode(T data, BinaryNode<T> left, BinaryNode<T> right)
        {
            Data = data;
            Left = left;
            Right = right;
        }

        public BinaryNode(T data) :
            this(data, null, null)
        { }
    }
}