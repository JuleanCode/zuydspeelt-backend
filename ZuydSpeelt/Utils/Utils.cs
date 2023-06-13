using System.Security.Cryptography;

namespace ZuydSpeelt
{
    public class Utils
    {
        public static string GenerateBase64()
        {
            int length = 10; // Desired length of the Base64 string
            byte[] randomBytes = new byte[length];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }
            string base64String = Convert.ToBase64String(randomBytes);

            return base64String;
        }


    }
}


