namespace BinaryTreeApp
{
    internal sealed class BinaryTree
    {
        private TreeNode _root;


        public void Add(int value)
        {
            var inputNode = new TreeNode(value);
            if (object.ReferenceEquals(_root, null))
                _root = inputNode;
            else
                Add(_root, inputNode);
        }

        public void Add(int[] values)
        {
            foreach (var value in values)
                Add(value);
        }

        public bool Contains(int value)
        {
            var isExist = false;
            if (!object.ReferenceEquals(_root, null))
                 isExist = Contains(_root, new TreeNode(value));
            return isExist;
        }

        private bool Contains(TreeNode currentNode, TreeNode node)
        {
            bool isExist = false;
            if (object.ReferenceEquals(currentNode, null))
                isExist =  false;
            else if (currentNode == node)
                isExist = true;
            else if (node > currentNode)
                isExist =  Contains(currentNode.RigthChild, node);
            else if (node < currentNode)
                isExist = Contains(currentNode.LeftChild, node);
            return isExist;
        }

        private void Add(TreeNode currentNode, TreeNode node)
        {
            if (currentNode == node || HasEqualsChild(currentNode, node))
                return;
            if (TrySetChild(currentNode, node))
                return;
            if(node < currentNode)
                Add(currentNode.LeftChild, node);
            if(node > currentNode)
                Add(currentNode.RigthChild, node);
        }

        private bool HasEqualsChild(TreeNode node, TreeNode nodeForCheck)
        {
            return node.LeftChild == nodeForCheck || node.RigthChild == nodeForCheck;
        }

        private bool TrySetChild(TreeNode node, TreeNode checkNode)
        {
            bool added = false;
            if (checkNode < node && object.ReferenceEquals(node.LeftChild, null))
            {
                node.LeftChild = checkNode;
                added = true;
            }
            else if (checkNode > node && object.ReferenceEquals(node.RigthChild, null))
            {
                node.RigthChild = checkNode;
                added = true;
            }
            return added;
        }
    }
}