using SecretSharingDotNet.Cryptography;
using SecretSharingDotNet.Math;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1 - Split password into shares");
                Console.WriteLine("2 - Join shares into password");

                var option = Console.ReadLine();

                if (option == "1")
                {
                    Split();
                }
                else if (option == "2")
                {
                    Join();
                }
                else
                {
                    break;
                }
            }
        }

        private static void Split()
        {
            Secret.LegacyMode.Value = true;

            try
            {
                var gcd = new ExtendedEuclideanAlgorithm<BigInteger>();

                var split = new ShamirsSecretSharing<BigInteger>(gcd);

                Console.WriteLine("Minimum shares (numeric):");

                var minimumShares = int.Parse(Console.ReadLine() );

                Console.WriteLine("Total shares (numeric):");
                
                var totalShares = int.Parse(Console.ReadLine() );

                Console.WriteLine("Password (alphanumeric):");

                var password = Console.ReadLine();

                var shares = split.MakeShares(minimumShares, totalShares, password);

                foreach (var share in shares)
                {
                    Console.WriteLine("Share:");

                    Console.WriteLine(share);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString() );
            }
            finally
            {
                Secret.LegacyMode.Value = false;
            }
        }

        private static void Join()
        {
            Secret.LegacyMode.Value = true;

            try
            {
                var gcd = new ExtendedEuclideanAlgorithm<BigInteger>();

                var combine = new ShamirsSecretSharing<BigInteger>(gcd);

                var shares = new List<string>();

                Console.WriteLine("How many shares (numeric):");

                var length = int.Parse(Console.ReadLine() );

                for (int i = 0; i < length; i++)
                {
                    Console.WriteLine("Share:");

                    var share = Console.ReadLine();

                    shares.Add(share);
                }

                var password = combine.Reconstruction(shares.ToArray() );

                Console.WriteLine("Password:");

                Console.WriteLine(password);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString() );
            }
            finally
            {
                Secret.LegacyMode.Value = false;
            }
        }
    }
}