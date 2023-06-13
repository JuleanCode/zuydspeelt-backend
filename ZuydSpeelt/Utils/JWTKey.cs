using System.Security.Cryptography;

namespace ZuydSpeelt
{
    public sealed class JWTKey
    {
        private static readonly JWTKey instance = new JWTKey();
        private readonly string key;

        private JWTKey()
        {
            key = Guid.NewGuid().ToString();
        }

        public static JWTKey Instance
        {
            get
            {
                return instance;
            }
        }

        public string GetKey()
        {
            return key;
        }
    }
}


