using System;
using System.Linq;
using System.Security.Cryptography;

namespace HY
{
    public abstract class Node
    {
        public HashDigest HashDigest { get; }

        protected Node(HashDigest signature)
        {
            HashDigest = signature ?? throw new ArgumentNullException(nameof(signature));
        }
    }

    public class BranchNode : Node
    {
        public Node Left { get; }
        public Node? Right { get; }

        private BranchNode(HashDigest hashDigest, Node left, Node? right) : base(hashDigest)
        {
            Right = right;
            Left = left;
        }

        internal static BranchNode Create(Node left, Node? right)
        {
            byte[] value;
            if (right != null)
            {
                value = left.HashDigest.Value
                    .Concat(right.HashDigest.Value)
                    .ToArray();
            }
            else
            {
                value = left.HashDigest;
            }
            HashDigest digest = HashUtil.ComputeSHA256Digest(value);
            return new BranchNode(digest, left, right);
        }
    }

    public class LeafNode : Node
    {
        public byte[] Value { get; }
        private LeafNode(HashDigest hashDigest, byte[] value) : base(hashDigest)
        {
            Value = value;
        }

        public static LeafNode Create(byte[] value)
        {
            HashDigest digest = HashUtil.ComputeSHA256Digest(value);
            return new LeafNode(digest, value);
        }
    }
}