using System;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;

namespace mtanksl.ShamirSecretSharing.Example.Encryption
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var file = new byte[1024];

            for (int i = 0; i < file.Length; i++)
            {
                file[i] = (byte)(i % 255);
            }

            // How to encrypt a file and split the private key into shares

            var encryptedFile = Encrypt(file, 2, 3, out var shares);

            foreach (var share in shares)
            {
                Console.WriteLine(share);
            }

            // How to join shares into the private key and decrypt a file

            file = Decrypt(encryptedFile, shares.Take(2).ToArray() );

            for (int i = 0; i < file.Length; i++)
            {
                Console.Write(file[i].ToString("X2") + " ");
            }
        }

        static byte[] Encrypt(byte[] file, int minimumShares, int totalShares, out Share[] shares)
        {
            using (var aes = Aes.Create() )
            {
                byte[] vector = aes.IV;

                byte[] key = aes.Key;

                using (var sss = new ShamirSecretSharing() )
                {
                    var message = vector.Concat(key).ToArray();

                    var value = new BigInteger(message.Concat(new byte[] { 0x00 } ).ToArray() );

                    var modulo = BigInteger.Pow(2, 521) - 1;

                    shares = sss.Split(minimumShares, totalShares, value, modulo);
                }

                using (var memoryStream = new MemoryStream() )
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(key, vector), CryptoStreamMode.Write) )
                    {
                        using (var fileStream = new MemoryStream(file) )
                        {
                            fileStream.CopyTo(cryptoStream);
                        }
                    }

                    return memoryStream.ToArray();
                }
            }
        }

        static byte[] Decrypt(byte[] file, Share[] shares)
        {
            using (var aes = Aes.Create() )
            {
                byte[] vector;

                byte[] key;

                using (var sss = new ShamirSecretSharing() )
                {
                    var modulo = BigInteger.Pow(2, 521) - 1;

                    var value = sss.Join(shares, modulo);

                    var message = value.ToByteArray();

                    vector = message.Take(16).ToArray();

                    key = message.Skip(16).Take(32).ToArray();
                }

                using (var memoryStream = new MemoryStream() )
                {
                    using (var fileStream = new MemoryStream(file) )
                    {
                        using (var cryptoStream = new CryptoStream(fileStream, aes.CreateDecryptor(key, vector), CryptoStreamMode.Read) )
                        {
                            cryptoStream.CopyTo(memoryStream);
                        }
                    }

                    return memoryStream.ToArray();                        
                }
            }
        }
    }
}