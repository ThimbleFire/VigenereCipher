using System;
					
public class Program
{
	public static void Main()
	{
		// The plaintext message you want to encrypt
		string plaintext = "HELLOWORLD";
		// The key for both encryption and decryption
		string key = "KEY";

		// Encrypt the plaintext
		string cipherText = VigenereCipher.Encipher(plaintext, key);
		Console.WriteLine("Encrypted: " + cipherText);

		// Decrypt the cipherText
		string decryptedText = VigenereCipher.Decipher(cipherText, key);
		Console.WriteLine("Decrypted: " + decryptedText);
	}
}

public class VigenereCipher
{
    private const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    public static string Encipher(string input, string key)
    {
        string output = string.Empty;
        input = input.ToUpper();
        key = key.ToUpper();

        for (int i = 0, j = 0; i < input.Length; i++)
        {
            char c = input[i];
            if (c < 'A' || c > 'Z')
                continue;

            output += (char)((c + key[j] - 2 * 'A') % 26 + 'A');
            j = (j + 1) % key.Length;
        }
        return output;
    }

    public static string Decipher(string input, string key)
    {
        string output = string.Empty;
        input = input.ToUpper();
        key = key.ToUpper();

        for (int i = 0, j = 0; i < input.Length; i++)
        {
            char c = input[i];
            if (c < 'A' || c > 'Z')
                continue;

            output += (char)((c - key[j] + 26) % 26 + 'A');
            j = (j + 1) % key.Length;
        }
        return output;
    }
}
