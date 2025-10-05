using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public static class SimpleEncryptor
{

    public static byte[] EncryptString(string plainText, byte[] key, byte[] iv)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = key;
            aes.IV = iv;

            using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                using (var sw = new StreamWriter(cs))
                {
                    sw.Write(plainText);
                }

                return ms.ToArray();
            }
        }
    }

    public static string DecryptString(byte[] cipherText, byte[] key, byte[] iv)
                                    // using byte arrays
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = key;
            aes.IV = iv;
            using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
            using (var ms = new MemoryStream(cipherText))
            using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
            using (var sr = new StreamReader(cs))
            {
                return sr.ReadToEnd();
            }
        }
    }

    public static void EncryptFile(string inputFile, string outputFile, byte[] key, byte[] iv)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = key;
            aes.IV = iv;

            using (var fsInput = new FileStream(inputFile, FileMode.Open, FileAccess.Read))
            using (var fsOutput = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
            using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
            using (var cs = new CryptoStream(fsOutput, encryptor, CryptoStreamMode.Write))
            {
                fsInput.CopyTo(cs);
            }
        }
    }

    public static void DecryptFile(string inputFile, string outputFile, byte[] key, byte[] iv)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = key;
            aes.IV = iv;

            using (var fsInput = new FileStream(inputFile, FileMode.Open, FileAccess.Read))
            using (var fsOutput = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
            using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
            using (var cs = new CryptoStream(fsInput, decryptor, CryptoStreamMode.Read))
            {
                cs.CopyTo(fsOutput);
            }
        }
    }
}
