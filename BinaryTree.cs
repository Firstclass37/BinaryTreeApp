using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

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

        
        // smpt   from to data 
        // 
        // 
        // 
        
        public string Show(ShowType type)
        {
            switch (type)
            {
               case ShowType.Infix : return ShowInfix(_root);
               case ShowType.Postfix : return ShowPost(_root);
               case ShowType.Prefix : return ShowPrefix(_root);
            }
            return ShowPost(_root);
        }

        private string ShowInfix(TreeNode<T> node)
        {
            if (node == null)
                return " ";
            if (node.RigthChild == null && node.LeftChild == null)
                return node.Value.ToString();
            return $"({ShowInfix(node.LeftChild)}, {node.Value.ToString()}, {ShowInfix(node.RigthChild)})";
        }
        
        private string ShowPost(TreeNode<T> node)
        {
            if (node == null)
                return " ";
            if (node.RigthChild == null && node.LeftChild == null)
                return node.Value.ToString();
            return $"({ShowPost(node.LeftChild)}, {ShowPost(node.RigthChild)}), {node.Value.ToString()}";
        }
        
        private string ShowPrefix(TreeNode<T> node)
        {
            if (node == null)
                return " ";
            if (node.RigthChild == null && node.LeftChild == null)
                return node.Value.ToString();
            return $"({node.Value.ToString()}, {ShowPrefix(node.LeftChild)}, {ShowPrefix(node.RigthChild)})";
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

        public void Remove(T value)
        {
            if (_root == null)
                return;
            if (_comparer.Compare(_root.Value, value) == 0)
            {
                _root = FindReplacement(_root);
            }
            else
            {
                var parent = FindParent(_root, value);
                if (parent == null)
                    return;
                if (parent.LeftChild != null && _comparer.Compare(parent.LeftChild.Value, value) == 0)
                {
                    parent.LeftChild = FindReplacement(parent.LeftChild);
                }
                else if (parent.RigthChild != null && _comparer.Compare(parent.RigthChild.Value, value) == 0)
                {
                    parent.RigthChild = FindReplacement(parent.RigthChild);
                }
            }
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

        private TreeNode<T> FindParent(TreeNode<T> currentNode, T value)
        {
            TreeNode<T> parent = null;
            if (currentNode == null)
                parent = null;
            else if (HasEqualsChild(currentNode, value))
                parent = currentNode;
            else if (_comparer.Compare(currentNode.Value, value) == 1)
                parent = FindParent(currentNode.LeftChild, value);
            else if (_comparer.Compare(currentNode.Value, value) == -1)
                parent = FindParent(currentNode.RigthChild, value);
            return parent;
        }

        private TreeNode<T> FindReplacement(TreeNode<T> searchFor)
        {
            if (searchFor.LeftChild == null && searchFor.RigthChild == null)
                return null;
            if (searchFor.LeftChild != null && searchFor.RigthChild == null)
                return searchFor.LeftChild;
            if (searchFor.RigthChild != null && searchFor.LeftChild == null)
                return searchFor.RigthChild;
            var lastLeft =  TakeLastLeft(searchFor.RigthChild, searchFor);
            searchFor.Value = lastLeft.Value;
            return searchFor;
        }

        private TreeNode<T> TakeLastLeft(TreeNode<T> searchFor, TreeNode<T> parent)
        {
            if (searchFor == null)
                return null;
            if (searchFor.LeftChild == null)
            {
                parent.LeftChild = null;
                return searchFor;
            }
            return TakeLastLeft(searchFor.LeftChild, searchFor);
        }

        private bool HasEqualsChild(TreeNode<T> node, TreeNode<T> nodeForCheck)
        {
            return node.LeftChild != null && _comparer.Compare(node.LeftChild.Value, nodeForCheck.Value) == 0 ||
                   node.RigthChild != null && _comparer.Compare(node.RigthChild.Value, nodeForCheck.Value) == 0;
        }

        private bool HasEqualsChild(TreeNode<T> node, T value)
        {
            return node.LeftChild != null && _comparer.Compare(node.LeftChild.Value, value) == 0 ||
                   node.RigthChild != null && _comparer.Compare(node.RigthChild.Value, value) == 0;
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