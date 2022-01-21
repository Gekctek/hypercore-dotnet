using System.Security.Cryptography;

namespace HY 
{
    public static class HashUtil
    {
        public static HashDigest ComputeSHA256Digest(byte[] value)
        {
            using (SHA256 sha = SHA256.Create())
            {
                return sha.ComputeHash(value);
            }
        }
    }
}