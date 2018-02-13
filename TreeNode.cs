
using System;

namespace BinaryTreeApp
{
    internal sealed class TreeNode<T>
    {
        public TreeNode(T value)
        {
            Value = value;
        }
        
        public T Value { get; }

        public TreeNode<T> LeftChild { get; set; }

        public TreeNode<T> RigthChild { get; set; }
    }
}
