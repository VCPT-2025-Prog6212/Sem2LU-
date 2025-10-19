using System.Security.Cryptography;

namespace prjFileUpload
{
    public class EncryptionHelper
    {
        // this class helps encrpyt and decrypt data using AES - Advanced Encryption Standard
        private static readonly byte[] Key = Convert.FromHexString("4b4a531a06a5a06f6e772523369883cf4b0126acd3201447432b6e43d7b723aa");
        private static readonly byte[] IV = Convert.FromHexString("161979AD5E1ECF561DB41822E672E0BF");

        // helper method that does the actual encryption and decryption work
        private static byte[] PerformCryptography(byte[] data, ICryptoTransform cryptoTransform)
        {
            using (var memoryStream = new MemoryStream()) // temp storage space in memory
            {
                // links the memory stream with the encryption decryption process
                using (var cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(data, 0, data.Length);
                    cryptoStream.FlushFinalBlock();
                    return memoryStream.ToArray();
                }
            }
        }

        // method to encrypt data
        public static byte[] Encrypt(byte[] data)
        {
            using (Aes aes = Aes.Create())
            {
                // set secret key and IV
                aes.Key = Key;
                aes.IV = IV;

                using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV)) // tool created from AES object
                {
                    return PerformCryptography(data, encryptor); // call helper method to actually encrypt 
                }
            }
        }

        // method to decrypt data
        public static byte[] Decrypt(byte[] data)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Key; // Key is like a password used to lock and unlock data
                aes.IV = IV;
                /* IV - Initialization Vector adds randomness so that even if two files have the same 
                 * content their encrypted versions will look different*/

                using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                {
                    return PerformCryptography(data, decryptor);
                }
            }
        }
    }
}


