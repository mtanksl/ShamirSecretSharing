using System;
using System.Collections.Generic;

namespace mtanksl.ShamirSecretSharing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1 - Split message into shares");
                Console.WriteLine("2 - Join shares into message");

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
            try
            {
                Console.WriteLine("Minimum shares (numeric):");

                var minimumShares = int.Parse(Console.ReadLine() );

                Console.WriteLine("Total shares (numeric):");

                var totalShares = int.Parse(Console.ReadLine() );

                Console.WriteLine("Message (alphanumeric):");

                var message = Console.ReadLine();

                using (var sss = new ShamirSecretSharing() )
                {
                    var shares = sss.Split(minimumShares, totalShares, message);

                    foreach (var share in shares)
                    {
                        Console.WriteLine("Share:");

                        Console.WriteLine(share);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString() );
            }
        }

        private static void Join()
        {
            try
            {
                var shares = new List<Share>();

                Console.WriteLine("How many shares (numeric):");

                var length = int.Parse(Console.ReadLine() );

                for (int i = 0; i < length; i++)
                {
                    Console.WriteLine("Share:");

                    var share = Console.ReadLine();

                    shares.Add(Share.Parse(share) );
                }

                using (var sss = new ShamirSecretSharing() )
                {                  
                    var message = sss.Join(shares.ToArray() );

                    Console.WriteLine("Message:");

                    Console.WriteLine(message);
                }            
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString() );
            }
        }
    }
}