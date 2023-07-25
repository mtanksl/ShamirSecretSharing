using System;
using System.Numerics;

namespace mtanksl.ShamirSecretSharing
{
    public static class BigIntegerExtensions
    {
        public static (BigInteger gcd, BigInteger s, BigInteger t) ExtendedGreatestCommonDivisor(BigInteger a, BigInteger b)
        {
            if (a <= 0)
            {
                throw new ArgumentException("a must be greater than zero.", nameof(a) );
            }

            if (b <= 0)
            {
                throw new ArgumentException("b must be greater than zero.", nameof(b) );
            }

            BigInteger temp;

            BigInteger old_r = a; BigInteger r = b;

            BigInteger old_s = 1; BigInteger s = 0;

            while (r != 0)
            {
                var quotient = old_r / r;

                temp = r; r = old_r - temp * quotient; old_r = temp;

                temp = s; s = old_s - temp * quotient; old_s = temp;
            }

            if (b != 0)
            {
                return (old_r, old_s, (old_r - old_s * a) / b);
            }

            return (old_r, old_s, 0);
        }

        public static BigInteger ModInverse(BigInteger a, BigInteger modulo)
        {
            if (a == 0)
            {
                throw new ArgumentException("a must be different than zero.", nameof(a) );
            }

            if (modulo == 0)
            {
                throw new ArgumentException("modulo must be different than zero.", nameof(modulo) );
            }

            var result = ExtendedGreatestCommonDivisor(BigInteger.Abs(a), BigInteger.Abs(modulo) );

            if (result.gcd != 1)
            {
                throw new InvalidOperationException("a is not invertible.");
            }

            var t = result.s;

            if (t < 0)
            {
                t += modulo;
            }

            if ( (a < 0 && modulo < 0) || (a > 0 && modulo > 0) )
            {
                return t;
            }

            return -t;
        }
    }
}