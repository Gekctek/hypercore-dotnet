using System;

namespace HY
{
    public abstract class Node
    {
        public Signature Signature { get; }

        protected Node(Signature signature)
        {
            Signature = signature ?? throw new ArgumentNullException(nameof(signature));
        }
    }

    public class BranchNode : Node
    {
        public Node Right { get; }
        public Node Left { get; }

        public BranchNode(Signature signature, Node right, Node left) : base(signature)
        {
            Right = right;
            Left = left;
        }

        public BranchNode Add(LeafNode node)
        {
            throw new NotImplementedException();
        }
    }

    public class LeafNode : Node
    {
        public LeafNode(Signature signature) : base(signature)
        {

        }
    }
}