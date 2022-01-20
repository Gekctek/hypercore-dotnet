namespace HY
{
    public class MerkleTree
    {
        public BranchNode Root { get; }

        public MerkleTree(BranchNode root)
        {
            Root = root;
        }

        public MerkleTree AddNode(LeafNode node)
        {
            BranchNode newRoot = Root.Add(node);
            return new MerkleTree(newRoot);
        }
    }
}