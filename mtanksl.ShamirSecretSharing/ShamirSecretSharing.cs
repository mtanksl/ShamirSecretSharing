using System;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;

namespace mtanksl.ShamirSecretSharing
{
    public class ShamirSecretSharing : IDisposable
    {
        private static readonly int[] MersennePrimes = new int[] { /* 2, 3, 5, 7, 13, 17, 19, 31, 61, 89, 107, 127 */ 521, 607, 1279, 2203, 2281, 3217, 4253, 4423, 9689, 9941, 11213, 19937, 21701, 23209, 44497, 86243, 110503, 132049, 216091, 756839, 859433, 1257787, 1398269, 2976221, 3021377, 6972593, 13466917, 20996011, 24036583, 25964951, 30402457, 32582657, 37156667, 42643801, 43112609 };

        private static BigInteger CalculateModulo(BigInteger value)
        {
            foreach (var exponent in MersennePrimes)
            {
                var modulo = BigInteger.Pow(2, exponent) - 1;

                if (modulo > value)
                {
                    return modulo;
                }
            }

            throw new NotImplementedException();
        }

        private static BigInteger CalculateModulo(int length)
        {
            foreach (var exponent in MersennePrimes)
            {
                var modulo = BigInteger.Pow(2, exponent) - 1;

                if (modulo.GetByteCount() == length)
                {
                    return modulo;
                }
            }

            throw new NotImplementedException();
        }

        private RandomNumberGenerator random;

        public ShamirSecretSharing()
        {
            random = RandomNumberGenerator.Create();
        }

        ~ShamirSecretSharing()
        {
            Dispose(false);
        }

        /// <summary>
        /// Split the message into n (totalShares) shares, requiring m (minimumShares) shares to reconstruct it.
        /// </summary>        
        public Share[] Split(int minimumShares, int totalShares, string message)
        {
            var value = new BigInteger(Encoding.UTF8.GetBytes(message), true);

            var modulo = CalculateModulo(value);

            var shares = Split(minimumShares, totalShares, value, modulo);

            return shares;
        }

        /// <summary>
        /// Split the message into n (totalShares) shares, requiring m (minimumShares) shares to reconstruct it.
        /// </summary>
        public Share[] Split(int minimumShares, int totalShares, BigInteger value, BigInteger modulo)
        {
            if (minimumShares < 2)
            {
                throw new ArgumentException("Minimum shares must be greater than or equal to 2.", nameof(minimumShares) );
            }

            if (totalShares < minimumShares)
            {
                throw new ArgumentException("Total shares must be greater than or equal to minimum shares.", nameof(totalShares) );
            }

            if (modulo <= value)
            {
                throw new ArgumentException("Modulo must be a prime number greater than value.", nameof(modulo) );
            }

            var coeficients = new BigInteger[minimumShares];

            coeficients[0] = value; // c

            for (int i = 1; i < coeficients.Length; i++)
            {
                var randomNumber = new byte[ modulo.GetByteCount() ];

                random.GetNonZeroBytes(randomNumber);

                coeficients[i] = new BigInteger(randomNumber, true); // k₁, k₂, ..., kₙ
            }

            var shares = new Share[totalShares];

            for (int j = 0; j < shares.Length; j++)
            {
                var x = new BigInteger(j + 1);

                var y = new BigInteger(0);

                for (int i = 0; i < coeficients.Length; i++)
                {
                    // f(x) = c + k₁ * x + k₂ * x² + ... + kₙ * xⁿ

                    y = (y + coeficients[i] * BigInteger.Pow(x, i) ) % modulo;
                }

                shares[j] = new Share(x, y, modulo.GetByteCount() );
            }

            return shares;
        }

        /// <summary>
        /// Reconstruct the message using the minimum required shares.
        /// </summary>      
        public string Join(Share[] shares)
        {
            var modulo = CalculateModulo(shares[0].Length);

            var value = Join(shares, modulo);

            var message = Encoding.UTF8.GetString(value.ToByteArray() );

            return message;
        }

        /// <summary>
        /// Reconstruct the message using the minimum required shares.
        /// </summary>
        public BigInteger Join(Share[] shares, BigInteger modulo)
        {
            var y = new BigInteger(0);

            for (int i = 0; i < shares.Length; i++)
            {
                var delta = new BigInteger(1);

                for (int j = 0; j < shares.Length; j++)
                {
                    if (i != j)
                    {
                        // d(i, x) = ∏ (x - j) / (i - j) for j E { i₁, i₂, ..., iₙ }, i != j

                        delta *= -1 * shares[j].X * BigIntegerExtensions.ModInverse(shares[i].X - shares[j].X, modulo);
                    }
                }

                // f(x) = f(i₁) * d(i₁, x) + f(i₂) * d(i₂, x) + ... + f(iₙ) * d(iₙ, x)

                y = (y + shares[i].Y * delta) % modulo;
            }

            if (y < 0)
            {
                y += modulo;
            }

            return y;
        }

        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                disposed = true;

                if (disposing)
                {
                    if (random != null)
                    {
                        random.Dispose();
                    }
                }
            }
        }
    }
}