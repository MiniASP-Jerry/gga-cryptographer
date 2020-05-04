using System;
using System.IO;

namespace gga_cryptographer
{
    class Program
    {
        static void Main(string[] args)
        {
            string ciphertext, plaintext;
            var cryptographer = new Cryptographer();

            var key = File.ReadAllText("Key.txt");
            var toEncrypt = File.ReadAllText("ToEncrypt.txt");
            var toDecrypt = File.ReadAllText("ToDecrypt.txt");

            if (!string.IsNullOrEmpty(toEncrypt))
            {
                ciphertext = cryptographer.AESEncript(toEncrypt, key);
                Console.WriteLine($"加密結果：{ciphertext}");
            }

            if (!string.IsNullOrEmpty(toDecrypt))
            {
                plaintext = cryptographer.AESDecript(toDecrypt, key);
                Console.WriteLine($"解密結果：{plaintext}");
            }

            Console.ReadLine();
        }
    }
}
