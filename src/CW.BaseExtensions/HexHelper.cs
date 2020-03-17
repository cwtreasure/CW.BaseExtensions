namespace System
{
    public static class HexHelper
    {
        public static string BytesToHex(byte[] bytes)
        {
            var hexString = BitConverter.ToString(bytes, 0).Replace("-", string.Empty).ToUpper();
            return hexString;
        }

        public static byte[] HexToBytes(string hexString)
        {
            var bytes = new byte[hexString.Length / 2];
            for (var x = 0; x < bytes.Length; x++)
            {
                var i = Convert.ToInt32(hexString.Substring(x * 2, 2), 16);
                bytes[x] = (byte)i;
            }

            return bytes;
        }
    }
}
