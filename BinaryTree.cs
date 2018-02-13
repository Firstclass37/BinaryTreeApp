using System;
using System.Collections.Generic;

namespace BinaryTreeApp
{
    internal sealed class BinaryTree<T>
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
            if (_root ==  null)
                _root = inputNode;
            else
                Add(_root, inputNode);
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
            var isExist = false;
            if (_root != null)
                 isExist = Find(_root, value) != null;
            return isExist;
        }

        private void Add(TreeNode<T> currentNode, TreeNode<T> node)
        {
            if (_comparer.Compare(currentNode.Value, node.Value) == 0 || HasEqualsChild(currentNode, node))
                return;
            if (TrySetChild(currentNode, node))
                return;
            if(_comparer.Compare(currentNode.Value, node.Value) == -1)
                Add(currentNode.RigthChild, node);
            else if(_comparer.Compare(currentNode.Value, node.Value) == 1)
                Add(currentNode.LeftChild, node);
        }

        private TreeNode<T> Find(TreeNode<T> currentNode, T value)
        {
            TreeNode<T> foundNode = null;
            if (currentNode == null)
                foundNode = null;
            else if (_comparer.Compare(currentNode.Value, value) == 0)
                foundNode = currentNode;
            else if (_comparer.Compare(currentNode.Value, value) == 1)
                foundNode = Find(currentNode.LeftChild, value);
            else if (_comparer.Compare(currentNode.Value, value) == -1)
                foundNode = Find(currentNode.RigthChild, value);
            return foundNode;
        }

        private bool HasEqualsChild(TreeNode<T> node, TreeNode<T> nodeForCheck)
        {
            return node.LeftChild != null && _comparer.Compare(node.LeftChild.Value, nodeForCheck.Value) == 0 ||
                   node.RigthChild != null && _comparer.Compare(node.RigthChild.Value, nodeForCheck.Value) == 0;
        }

        private bool TrySetChild(TreeNode<T> node, TreeNode<T> checkNode)
        {
            var added = false;
            if (_comparer.Compare(checkNode.Value, node.Value) == -1 && node.LeftChild == null)
            {
                node.LeftChild = checkNode;
                added = true;
            }
            else if (_comparer.Compare(checkNode.Value, node.Value) == 1 && node.RigthChild == null)
            {
                node.RigthChild = checkNode;
                added = true;
            }
            return added;
        }
    }
}