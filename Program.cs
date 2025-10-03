using System;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Usage:");
            Console.WriteLine("  genkey <.json keyfile>");
            Console.WriteLine("  encrypt text <keyfile> <your text>");
            Console.WriteLine("  decrypt text <keyfile> <your text>");
            Console.WriteLine("  encrypt file <keyfile> <inputfile> <outputfile>");
            Console.WriteLine("  decrypt file <keyfile> <inputfile> <outputfile>");
            return;
        }

        if (args[0] == "genkey")
        {
            string keyfile = args[1];
            using var aes = Aes.Create();
            aes.GenerateKey();
            aes.GenerateIV();
            KeyFileHelper.SaveKey(keyfile, aes.Key, aes.IV);
            Console.WriteLine($"Key + IV saved to {keyfile}");
        }
        else if (args[0] == "encrypt" && args[1] == "text")
        {
            string keyfile = args[2];
            var (key, iv) = KeyFileHelper.LoadKey(keyfile);
            string text = string.Join(" ", args, 3, args.Length - 3);
            byte[] encrypted = SimpleEncryptor.EncryptString(text, key, iv);
            Console.WriteLine("Encrypted (Base64): " + Convert.ToBase64String(encrypted));
        }
        else if (args[0] == "encrypt" && args[1] == "file")
        {
            string keyfile = args[2];
            var (key, iv) = KeyFileHelper.LoadKey(keyfile);
            string inputFile = args[3];
            string outputFile = args[4];
            SimpleEncryptor.EncryptFile(inputFile, outputFile, key, iv);
            Console.WriteLine("File encrypted!");
        }
        else if (args[0] == "decrypt" && args[1] == "file")
        {
            string keyfile = args[2];
            var (key, iv) = KeyFileHelper.LoadKey(keyfile);
            string inputFile = args[3];
            string outputFile = args[4];
            SimpleEncryptor.DecryptFile(inputFile, outputFile, key, iv);
            Console.WriteLine("File decrypted!");
        }
	else if (args[0] == "decrypt" && args[1] == "text")
	{
		string keyfile = args[2];
		var (key, iv) = KeyFileHelper.LoadKey(keyfile);

		// join everything after the keyfile into one string
		string base64 = string.Join(" ", args, 3, args.Length - 3);

		// decode Base64 back to bytes
		byte[] cipherBytes = Convert.FromBase64String(base64);

		string decrypted = SimpleEncryptor.DecryptString(cipherBytes, key, iv);
		Console.WriteLine("Decrypted: " + decrypted);
	}
    }
}
