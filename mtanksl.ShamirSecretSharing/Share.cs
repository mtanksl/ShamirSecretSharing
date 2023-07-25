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

            return new Share(new BigInteger(x, true), new BigInteger(y, true) );
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

        public Share(BigInteger x, BigInteger y)
        {
            X = x;

            Y = y;
        }

        public BigInteger X { get; }

        public BigInteger Y { get; }

        public override string ToString()
        {
            return string.Concat(X.ToByteArray().Select(b => b.ToString("X2") ) ) + "-" + string.Concat(Y.ToByteArray().Select(b => b.ToString("X2") ) );
        }
    }
}