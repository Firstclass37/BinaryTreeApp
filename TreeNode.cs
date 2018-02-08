
namespace BinaryTreeApp
{
    internal sealed class TreeNode
    {
        public TreeNode(int value)
        {
            Value = value;
        }

        public int Value { get; }

        public TreeNode LeftChild { get; set; }

        public TreeNode RigthChild { get; set; }

        public static bool operator > (TreeNode first, TreeNode second)
        {
            return first?.Value > second?.Value;
        }

        public static bool operator <(TreeNode first, TreeNode second)
        {
            return first?.Value < second?.Value;
        }

        public static bool operator ==(TreeNode first, TreeNode second)
        {
            return first?.Value == second?.Value;
        }


        public static bool operator !=(TreeNode first, TreeNode second)
        {
            return first?.Value == second?.Value;
        }
    }
}
