using System;
using System.Collections.Generic;
using System.Linq;

namespace HY
{
    public class MerkleTree
    {
        public BranchNode Root { get; }
        public MerkleTree(BranchNode root)
        {
            Root = root;
        }

        public static MerkleTree Build(IEnumerable<byte[]> values)
        {
            List<LeafNode> leaves = values
                .Select(v => LeafNode.Create(v))
                .ToList();

            List<BranchNode> nodes = A(leaves).ToList();
            while (nodes.Count > 1)
            {
                 nodes = A(nodes).ToList();
            }

            return new MerkleTree(nodes.Single());
        }

        private static IEnumerable<BranchNode> A<T>(List<T> nodes)
            where T : Node
        {
            for (int i = 0; i < nodes.Count; i += 2)
            {
                Node left = nodes[i];
                Node? right = nodes.ElementAtOrDefault(i + 1);

                yield return BranchNode.Create(left, right);
            }
        }
    }
}