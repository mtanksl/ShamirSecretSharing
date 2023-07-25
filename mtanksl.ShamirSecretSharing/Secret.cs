using System;
using System.Numerics;
using System.Text;

namespace mtanksl.ShamirSecretSharing
{
    internal class Secret
    {
        private static readonly int[] MersennePrimes = new int[] { 2, 3, 5, 7, 13, 17, 19, 31, 61, 89, 107, 127, 521, 607, 1279, 2203, 2281, 3217, 4253, 4423, 9689, 9941, 11213, 19937, 21701, 23209, 44497, 86243, 110503, 132049, 216091, 756839, 859433, 1257787, 1398269, 2976221, 3021377, 6972593, 13466917, 20996011, 24036583, 25964951, 30402457, 32582657, 37156667, 42643801, 43112609 };

        public static BigInteger CalculateModulo(BigInteger value)
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

        public Secret(string message)
        {
            Message = message;

            Value = new BigInteger(Encoding.UTF8.GetBytes(Message), true);

            Modulo = CalculateModulo(Value);
        }

        public Secret(BigInteger value, BigInteger modulo)
        {
            Value = value;

            Modulo = modulo;

            Message = Encoding.UTF8.GetString(Value.ToByteArray() );
        }

        public string Message { get; }

        public BigInteger Value { get; }

        public BigInteger Modulo { get; }       
    }
}