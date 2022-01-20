using System;

namespace HY
{
    public class Signature
    {
        public string Algorithm { get; }
        public byte[] Value { get; }

        public Signature(string algorithm, byte[] value)
        {
            if(string.IsNullOrWhiteSpace(algorithm))
            {
                throw new ArgumentException("Algorith must be specified", algorithm);
            }
            if(value.Length == 0)
            {
                throw new ArgumentException("Signature value must have data");
            }
            Algorithm = algorithm;
            Value = value;
        }
    }
}