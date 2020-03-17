namespace System
{
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;

    public static class EncryptHelper
    {
        public static string AesEncrypt(string rawStr, string aesKey)
        {
            byte[] key = Encoding.UTF8.GetBytes(aesKey);
            byte[] plainBytes = Encoding.UTF8.GetBytes(rawStr);
            byte[] iv = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, };

            byte[] encryptData = null;
            using Aes aes = Aes.Create();
            try
            {
                using MemoryStream memory = new MemoryStream();
                using CryptoStream encryptor = new CryptoStream(memory, aes.CreateEncryptor(key, iv), CryptoStreamMode.Write);
                encryptor.Write(plainBytes, 0, plainBytes.Length);
                encryptor.FlushFinalBlock();

                encryptData = memory.ToArray();
            }
            catch
            {
                encryptData = null;
            }

            return Convert.ToBase64String(encryptData);
        }

        public static string AesDecrypt(string encStr, string aesKey)
        {
            byte[] key = Encoding.UTF8.GetBytes(aesKey);
            byte[] encryptedBytes = Convert.FromBase64String(encStr);
            byte[] iv = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, };

            byte[] decryptedData = null;
            using Aes aes = Aes.Create();
            try
            {
                using MemoryStream memory = new MemoryStream(encryptedBytes);
                using CryptoStream decryptor = new CryptoStream(memory, aes.CreateEncryptor(key, iv), CryptoStreamMode.Read);
                using MemoryStream tempMemory = new MemoryStream();
                byte[] buffer = new byte[1024];
                int readBytes = 0;
                while ((readBytes = decryptor.Read(buffer, 0, buffer.Length)) > 0)
                {
                    tempMemory.Write(buffer, 0, readBytes);
                }

                decryptedData = tempMemory.ToArray();
            }
            catch
            {
                decryptedData = null;
            }

            return Encoding.UTF8.GetString(decryptedData);
        }

        public static string AesEncrypt(string rawStr, string aesKey, byte[] iv)
        {
            byte[] key = Encoding.UTF8.GetBytes(aesKey);
            byte[] plainBytes = Encoding.UTF8.GetBytes(rawStr);

            byte[] encryptData = null;
            using Aes aes = Aes.Create();
            try
            {
                using MemoryStream memory = new MemoryStream();
                using CryptoStream encryptor = new CryptoStream(memory, aes.CreateEncryptor(key, iv), CryptoStreamMode.Write);
                encryptor.Write(plainBytes, 0, plainBytes.Length);
                encryptor.FlushFinalBlock();

                encryptData = memory.ToArray();
            }
            catch
            {
                encryptData = null;
            }

            return Convert.ToBase64String(encryptData);
        }

        public static string AesDecrypt(string encStr, string aesKey, byte[] iv)
        {
            byte[] key = Encoding.UTF8.GetBytes(aesKey);
            byte[] encryptedBytes = Convert.FromBase64String(encStr);

            byte[] decryptedData = null;
            using Aes aes = Aes.Create();
            try
            {
                using MemoryStream memory = new MemoryStream(encryptedBytes);
                using CryptoStream decryptor = new CryptoStream(memory, aes.CreateEncryptor(key, iv), CryptoStreamMode.Read);
                using MemoryStream tempMemory = new MemoryStream();
                byte[] buffer = new byte[1024];
                int readBytes = 0;
                while ((readBytes = decryptor.Read(buffer, 0, buffer.Length)) > 0)
                {
                    tempMemory.Write(buffer, 0, readBytes);
                }

                decryptedData = tempMemory.ToArray();
            }
            catch
            {
                decryptedData = null;
            }

            return Encoding.UTF8.GetString(decryptedData);
        }

        public static string AesHexEncrypt(string rawStr, string aesKey)
        {
            byte[] key = Encoding.UTF8.GetBytes(aesKey);
            byte[] plainBytes = Encoding.UTF8.GetBytes(rawStr);
            byte[] iv = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, };

            byte[] encryptData = null;
            using Aes aes = Aes.Create();
            try
            {
                using MemoryStream memory = new MemoryStream();
                using CryptoStream encryptor = new CryptoStream(memory, aes.CreateEncryptor(key, iv), CryptoStreamMode.Write);
                encryptor.Write(plainBytes, 0, plainBytes.Length);
                encryptor.FlushFinalBlock();

                encryptData = memory.ToArray();
            }
            catch
            {
                encryptData = null;
            }

            return HexHelper.BytesToHex(encryptData);
        }

        public static string AesHexDecrypt(string encStr, string aesKey)
        {
            byte[] key = Encoding.UTF8.GetBytes(aesKey);
            byte[] encryptedBytes = HexHelper.HexToBytes(encStr);
            byte[] iv = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, };

            byte[] decryptedData = null;
            using Aes aes = Aes.Create();
            try
            {
                using MemoryStream memory = new MemoryStream(encryptedBytes);
                using CryptoStream decryptor = new CryptoStream(memory, aes.CreateEncryptor(key, iv), CryptoStreamMode.Read);
                using MemoryStream tempMemory = new MemoryStream();
                byte[] buffer = new byte[1024];
                int readBytes = 0;
                while ((readBytes = decryptor.Read(buffer, 0, buffer.Length)) > 0)
                {
                    tempMemory.Write(buffer, 0, readBytes);
                }

                decryptedData = tempMemory.ToArray();
            }
            catch
            {
                decryptedData = null;
            }

            return Encoding.UTF8.GetString(decryptedData);
        }
    }
}
