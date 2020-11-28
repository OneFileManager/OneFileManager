using System.Security.Cryptography;
using System.Text;

namespace OneFileManager.Security
{
    public class Rfc2898
    {

        public static byte[] GetSecretkey(string pwd, int keySize)
        {
            var salt = new byte[16];
            salt = new SHA1Managed().ComputeHash(Encoding.UTF8.GetBytes(pwd));
            var myIterations = 1000;
            var derivedBytes = new Rfc2898DeriveBytes(Encoding.UTF8.GetBytes(pwd), salt, myIterations);
            var key = derivedBytes.GetBytes(keySize);
            return key;
        }
    }
}