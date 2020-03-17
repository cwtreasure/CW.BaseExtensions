namespace System
{
    using System.Security.Cryptography;
    using System.Text;

    public static class HashHelper
    {
        public static string GetMd5(string str, bool upperCase = false)
        {
            using var md5 = MD5.Create();
            var inputBytes = Encoding.UTF8.GetBytes(str);
            var hashBytes = md5.ComputeHash(inputBytes);

            var sb = new StringBuilder();
            foreach (var hashByte in hashBytes)
            {
                sb.Append(hashByte.ToString(upperCase ? "X2" : "x2"));
            }

            return sb.ToString();
        }

        public static string GetSha1(string str, bool upperCase = false)
        {
            using SHA1 sha1 = SHA1.Create();
            var inputBytes = Encoding.UTF8.GetBytes(str);
            var hashBytes = sha1.ComputeHash(inputBytes);

            var sb = new StringBuilder();
            foreach (var hashByte in hashBytes)
            {
                sb.Append(hashByte.ToString(upperCase ? "X2" : "x2"));
            }

            return sb.ToString();
        }

        public static string GetSha256(string str, bool upperCase = false)
        {
            using SHA256 sha256 = SHA256.Create();
            var inputBytes = Encoding.UTF8.GetBytes(str);
            var hashBytes = sha256.ComputeHash(inputBytes);

            var sb = new StringBuilder();
            foreach (var hashByte in hashBytes)
            {
                sb.Append(hashByte.ToString(upperCase ? "X2" : "x2"));
            }

            return sb.ToString();
        }
    }
}
