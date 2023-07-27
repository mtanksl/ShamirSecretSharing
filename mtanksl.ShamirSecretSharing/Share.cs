using System;
using System.Linq;
using System.Numerics;

namespace mtanksl.ShamirSecretSharing
{
    public class Share
    {
        public static Share Parse(string value)
        {
            var splits = value.Split('-');

            var x = new byte[splits[0].Length / 2];

            for (int i = 0; i < splits[0].Length / 2; i++)
            {
                x[i] = Convert.ToByte(splits[0].Substring(i * 2, 2), 16);
            }

            var y = new byte[splits[1].Length / 2];

            for (int i = 0; i < splits[1].Length / 2; i++)
            {
                y[i] = Convert.ToByte(splits[1].Substring(i * 2, 2), 16);
            }

            return new Share(new BigInteger(x.Concat(new byte[] { 0x00 } ).ToArray() ), new BigInteger(y.Concat(new byte[] { 0x00 } ).ToArray() ), y.Length);
        }

        public static bool TryParse(string value, out Share result)
        {
            try
            {
                result = Parse(value);

                return true;
            }
            catch 
            {
                result = null;

                return false;
            }          
        }

        public Share(BigInteger x, BigInteger y, int length)
        {
            X = x;

            Y = y;

            Length = length;
        }

        public BigInteger X { get; }

        public BigInteger Y { get; }

        public int Length { get; }

        public override string ToString()
        {
            var extended = new byte[Length];

            var y = Y.ToByteArray();

            for (int i = 0; i < y.Length; i++)
            {
                extended[i] = y[i];
            }

            return string.Concat(X.ToByteArray().Select(b => b.ToString("X2") ) ) + "-" + string.Concat(extended.Select(b => b.ToString("X2") ) );
        }
    }
}