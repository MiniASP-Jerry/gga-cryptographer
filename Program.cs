using System;

namespace gga_cryptographer
{
    class Program
    {
        static void Main(string[] args)
        {
            var key = args[0];
            var toEncode = args[1];
            var toDecode = args[2];
            var crypto = new Cryptographer();
            var encoded = crypto.AESEncript(toEncode, key);
            var decoded = crypto.AESDecript(toDecode, key);
            Console.WriteLine($"加密後：{encoded}");
            Console.WriteLine($"解密後：{decoded}");
        }
    }
}
