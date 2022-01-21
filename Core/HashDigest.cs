using System;
using System.Collections.Generic;

namespace HY
{
    public class HashDigest : IComparable<HashDigest>, IEquatable<HashDigest>
    {
        public byte[] Value { get; }

        public HashDigest(byte[] value)
        {
            if (value == null || value.Length < 1)
            {
                throw new ArgumentException("Hash digest must have a value", nameof(value));
            }
            Value = value;
        }

        public override bool Equals(object? obj)
        {
            return obj is HashDigest digest && this.Equals(digest);
        }

        public override int GetHashCode()
        {
            int hashCode = -1146841596;
            hashCode = hashCode * -1521134295 + EqualityComparer<byte[]>.Default.GetHashCode(Value);
            return hashCode;
        }

        public int CompareTo(HashDigest other)
        {
            return Comparer<byte[]>.Default.Compare(Value, other.Value);
        }

        public bool Equals(HashDigest other)
        {
            return this.CompareTo(other) == 0;
        }

        public static bool operator <(HashDigest left, HashDigest right)
        {
			return left.CompareTo(right) < 0;
        }

        public static bool operator >(HashDigest left, HashDigest right)
        {
			return left.CompareTo(right) > 0;
        }
		
        public static implicit operator HashDigest(byte[] value)
        {
			return new HashDigest(value);
        }

        public static implicit operator byte[](HashDigest digest)
        {
			return digest.Value;
        }
    }
}