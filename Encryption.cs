using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WTUSA
{
    public static class Encryption
    {
        internal static byte[] AES_Decrypt(byte[] input, string pass = "kyleistheman")
        {
            byte[] decryptedBytes = null;
            if (input != null)
            {
                var AES = new System.Security.Cryptography.RijndaelManaged();
                var hashAES = new System.Security.Cryptography.MD5CryptoServiceProvider();
                var hash = new byte[32];
                var temp = hashAES.ComputeHash(System.Text.Encoding.ASCII.GetBytes(pass));
                Array.Copy(temp, 0, hash, 0, 16);
                Array.Copy(temp, 0, hash, 15, 16);
                AES.Key = hash;
                AES.Mode = System.Security.Cryptography.CipherMode.ECB;
                var DESDecryptor = AES.CreateDecryptor();
                //Dim Buffer As Byte() = Convert.FromBase64String(input)
                //decrypted = System.Text.ASCIIEncoding.ASCII.GetString(DESDecrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
                decryptedBytes = DESDecryptor.TransformFinalBlock(input, 0, input.Length);
            }
            
            return decryptedBytes;
        }

        internal static byte[] AES_Encrypt(byte[] input, string pass = "kyleistheman")
        {
            var AES = new System.Security.Cryptography.RijndaelManaged();
            var Hash_AES = new System.Security.Cryptography.MD5CryptoServiceProvider();
            //Dim encrypted As String = ""
            try
            {
                var hash = new byte[32];
                var temp = Hash_AES.ComputeHash(System.Text.Encoding.ASCII.GetBytes(pass));
                Array.Copy(temp, 0, hash, 0, 16);
                Array.Copy(temp, 0, hash, 15, 16);
                AES.Key = hash;
                AES.Mode = System.Security.Cryptography.CipherMode.ECB;
                var DESEncryptor = AES.CreateEncryptor();
                //Dim Buffer As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(input)
                byte[] encryptedBytes = DESEncryptor.TransformFinalBlock(input, 0, input.Length);
                return encryptedBytes;
            }
            catch
            {
                throw;
            }
        }
    }
}
