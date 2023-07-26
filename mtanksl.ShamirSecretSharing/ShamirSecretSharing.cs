using System;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;

namespace mtanksl.ShamirSecretSharing
{
    public class ShamirSecretSharing : IDisposable
    {
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
            var secret = new Secret(message);

            var shares = Split(minimumShares, totalShares, secret.Value, secret.Modulo);

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

                shares[j] = new Share(x, y);
            }

            return shares;
        }

        /// <summary>
        /// Reconstruct the message using the minimum required shares.
        /// </summary>      
        public string Join(Share[] shares)
        {
            var modulo = Secret.CalculateModulo(shares.Max(s => s.Y) );

            var value = Join(shares, modulo);

            var secret = new Secret(value, modulo);

            return secret.Message;
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