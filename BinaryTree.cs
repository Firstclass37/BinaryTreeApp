using System;
using System.Collections.Generic;

namespace BinaryTreeApp
{
    internal sealed class BinaryTree<T> : IFormattable
    {
        private TreeNode<T> _root;
        private readonly IComparer<T> _comparer;

        public BinaryTree(IComparer<T> comparer)
        {
            _comparer = comparer ?? throw new ArgumentNullException(nameof(comparer));
        }
        
        public void Add(T value)
        {
            var inputNode = new TreeNode<T>(value);
            Add(ref _root, inputNode);
        }

        public void Add(T[] values)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));
            foreach (var value in values)
                Add(value);
        }

        public bool Contains(T value)
        {
            var isExist = IsExist(_root, value);
            return isExist;
        }

        public void Remove(T value)
        {
            Remove(ref _root, value);
        }

        public override string ToString()
        {
            return this.ToString("inx", null);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            var targetFormat = format.ToUpperInvariant();
            switch (targetFormat)
            {
                case "PRX":
                    return Show(_root, ShowType.Prefix);
                case "PSX":
                    return Show(_root, ShowType.Postfix);
                case "INX":
                    return Show(_root, ShowType.Infix);
                default:
                    throw new FormatException($"The format \"{format}\" is not supported.");
            }
        }

        private void Remove(ref TreeNode<T> currentNode, T value)
        {
            if (currentNode == null)
                return;
            if (_comparer.Compare(currentNode.Value, value) == 0)
            {
                if (currentNode.LeftChild == null && currentNode.RigthChild == null)
                    currentNode = null;
                else if (currentNode.LeftChild != null && currentNode.RigthChild == null)
                    currentNode = currentNode.LeftChild;
                else if (currentNode.RigthChild != null && currentNode.LeftChild == null)
                    currentNode = currentNode.RigthChild;
                else
                    currentNode.Value = TakeLastLeftValue(ref currentNode.RigthChild);
            }
            else if (_comparer.Compare(currentNode.Value, value) == -1)
                Remove(ref currentNode.RigthChild, value);
            else if (_comparer.Compare(currentNode.Value, value) == 1)
                Remove(ref currentNode.LeftChild, value);
        }

        private string Show(TreeNode<T> node, ShowType showType)
        {
            if (node == null)
                return " ";
            if (node.RigthChild == null && node.LeftChild == null)
                return node.Value.ToString();
            switch (showType)
            {
                case ShowType.Prefix: return $"({node.Value.ToString()}, {Show(node.LeftChild, showType)}, {Show(node.RigthChild, showType)})";
                case ShowType.Infix: return $"({Show(node.LeftChild, showType)}, {node.Value.ToString()}, {Show(node.RigthChild, showType)})";
                case ShowType.Postfix: return $"({Show(node.LeftChild, showType)}, {Show(node.RigthChild, showType)}), {node.Value.ToString()}";
            }
            throw new Exception("oops:(");
        }

        private T TakeLastLeftValue(ref TreeNode<T> currentNode)
        {
            if (currentNode.LeftChild != null)
                return TakeLastLeftValue(ref currentNode.LeftChild);
            if (currentNode.RigthChild != null)
                return TakeLastLeftValue(ref currentNode.RigthChild);
            var value = currentNode.Value;
            currentNode = null;
            return value;
        }

        private void Add(ref TreeNode<T> currentNode, TreeNode<T> node)
        {
            if (currentNode == null)
                currentNode = node;
            if (_comparer.Compare(currentNode.Value, node.Value) == 0)
                return;
            if (_comparer.Compare(currentNode.Value, node.Value) == -1)
                Add(ref currentNode.RigthChild, node);
            else if (_comparer.Compare(currentNode.Value, node.Value) == 1)
                Add(ref currentNode.LeftChild, node);
        }

        private bool IsExist(TreeNode<T> currentNode, T value)
        {
            if (currentNode == null)
                return false;
            if (_comparer.Compare(currentNode.Value, value) == 0)
                return true;
            if (_comparer.Compare(currentNode.Value, value) == 1)
                return IsExist(currentNode.LeftChild, value);
            if (_comparer.Compare(currentNode.Value, value) == -1)
                return IsExist(currentNode.RigthChild, value);
            return false;
        }
    }
}