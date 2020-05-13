using System;
using System.Security.Cryptography;
using System.Text;

namespace gga_cryptographer
{
    public class Cryptographer
    {
        public string AESEncript(string plainText, string key)
        {
            //密碼轉譯一定都是用byte[] 所以把string都換成byte[]
            byte[] plainTextByte = Encoding.UTF8.GetBytes(plainText);
            byte[] keyByte = Encoding.UTF8.GetBytes(key);

            //加解密函數的key通常都會有固定的長度 而使用者輸入的key長度不定 因此用hash過後的值當做key
            MD5CryptoServiceProvider provider_MD5 = new MD5CryptoServiceProvider();
            byte[] md5Byte = provider_MD5.ComputeHash(keyByte);

            //產生加密實體
            RijndaelManaged aesProvider = new RijndaelManaged();
            ICryptoTransform aesEncrypt = aesProvider.CreateEncryptor(md5Byte, md5Byte);

            //output就是加密過後的結果
            byte[] output = aesEncrypt.TransformFinalBlock(plainTextByte, 0, plainTextByte.Length);

            //將加密後的位元組轉成16進制字串
            return BitConverter.ToString(output).Replace("-", "");
        }

        public string AESDecript(string ciphertext, string key)
        {
            byte[] chipherTextByte = new byte[ciphertext.Length / 2];
            int j = 0;

            for (int i = 0; i < ciphertext.Length / 2; i++)
            {
                chipherTextByte[i] = byte.Parse(ciphertext[j].ToString() + ciphertext[j + 1].ToString(), System.Globalization.NumberStyles.HexNumber);
                j += 2;
            }

            //密碼轉譯一定都是用byte[] 所以把string都換成byte[]
            byte[] keyByte = Encoding.UTF8.GetBytes(key);

            //加解密函數的key通常都會有固定的長度 而使用者輸入的key長度不定 因此用hash過後的值當做key
            MD5CryptoServiceProvider provider_MD5 = new MD5CryptoServiceProvider();
            byte[] md5Byte = provider_MD5.ComputeHash(keyByte);

            //產生解密實體
            RijndaelManaged aesProvider = new RijndaelManaged();
            ICryptoTransform aesDecrypt = aesProvider.CreateDecryptor(md5Byte, md5Byte);

            //string_secretContent就是解密後的明文
            byte[] plainTextByte = aesDecrypt.TransformFinalBlock(chipherTextByte, 0, chipherTextByte.Length);
            string plainText = Encoding.UTF8.GetString(plainTextByte);
            return plainText;
        }
    }
}
