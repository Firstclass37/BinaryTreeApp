namespace BinaryTreeApp
{
    internal sealed class TreeNode<T>
    {
        public TreeNode(T value)
        {
            Value = value;
        }
        
        public T Value { get; set; }

        public TreeNode<T> LeftChild;

        public TreeNode<T> RigthChild;
    }
}
