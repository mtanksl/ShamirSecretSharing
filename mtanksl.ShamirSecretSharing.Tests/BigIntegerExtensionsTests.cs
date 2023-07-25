using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace mtanksl.ShamirSecretSharing.Tests
{
    [TestClass]
    public class BigIntegerExtensionsTests
    {
        [TestMethod]
        public void TestExtendedEuclideanAlgorithm()
        {
            for (int i = 1; i < 127; i++)
            {
                for (int j = 1; j < 127; j++)
                {
                    var result = BigIntegerExtensions.ExtendedGreatestCommonDivisor(i, j);

                    Assert.AreEqual(result.gcd, i * result.s + j * result.t);
                }
            }
        }

        [TestMethod]
        public void TestModularMultiplicativeInverse()
        {
            for (int i = 1; i < 127; i++)
            {
                foreach (var j in new[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 103, 107, 109, 113, 127 } )
                {
                    if (i < j)
                    {
                        var result = BigIntegerExtensions.ModInverse(i, j);

                        Assert.AreEqual(1, (i * result) % j);
                    }
                }
            }
        }
    }
}