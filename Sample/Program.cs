using System;
using HY;
using System.Linq;
using System.Text;

namespace Sample
{
    class Program
    {
        public static void Main(string[] args)
        {
            byte[][] values = new[]
            {
                "Test1",
                "Test2",
                "Test3",
                "Test4",
                "Test5",
                "Test6",
                "Test7"
            }
            .Select(v => Encoding.UTF8.GetBytes(v))
            .ToArray();
            MerkleTree tree = MerkleTree.Build(values);
            Console.WriteLine("Hello World!");
        }
    }
}
