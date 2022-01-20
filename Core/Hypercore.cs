using System;

namespace HY
{
    public class Key
    {
        public Key(byte[] bytes)
        {
            if (bytes == null)
            {
                throw new ArgumentNullException(nameof(bytes));
            }
            if (bytes.Length != 32)
            {
                throw new ArgumentException("Hypercore key should be 32 bytes");
            }
        }
    }

    public interface ICrypto
    {
        // Returns discovery key
        object DiscoveryKey(object publicKey);
        // Returns tree hash
        object TreeHash(object roots);
    }

    public interface ICache
    {

    }

    public class Extensions
    {

    }

    public class Hypercore
    {
        private readonly ICrypto _crypto;
        private readonly ICache _cache;
        private readonly Key? _key;
        private readonly Extensions? _extensions;
        public Hypercore(
          ICrypto crypto,
          ICache cache,
          string storage,
          Key? key = null,
          Extensions? extensions = null)
        {

            _crypto = crypto;
            _cache = cache;
            _key = key;
            _extensions = extensions;
        }
    }
}