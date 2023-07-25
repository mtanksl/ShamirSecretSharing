using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Numerics;

namespace mtanksl.ShamirSecretSharing.Tests
{
    [TestClass]
    public class ShamirSecretSharingSimpleTests
    {
        [TestMethod]
        public void Test2Of2()
        {
            var minimumShares = 2;

            var totalShares = 2;

            var value = new BigInteger(6);

            var modulo = new BigInteger(11);

            var shamirSecretSharing = new ShamirSecretSharing();

            var shares = shamirSecretSharing.Split(minimumShares, totalShares, value, modulo);

            var actual = shamirSecretSharing.Join(new[] { shares[0], shares[1] }, modulo);

            Assert.AreEqual(value, actual);
        }

        [TestMethod]
        public void Test2Of3()
        {
            var minimumShares = 2;

            var totalShares = 3;

            var value = new BigInteger(6);

            var modulo = new BigInteger(11);

            var shamirSecretSharing = new ShamirSecretSharing();

            var shares = shamirSecretSharing.Split(minimumShares, totalShares, value, modulo);

            var actual = shamirSecretSharing.Join(new[] { shares[0], shares[1] }, modulo);

            Assert.AreEqual(value, actual);

            actual = shamirSecretSharing.Join(new[] { shares[0], shares[2] }, modulo);

            Assert.AreEqual(value, actual);
                                    
            actual = shamirSecretSharing.Join(new[] { shares[1], shares[2] }, modulo);

            Assert.AreEqual(value, actual);
        }

        [TestMethod]
        public void Test2Of4()
        {
            var minimumShares = 2;

            var totalShares = 4;

            var value = new BigInteger(6);

            var modulo = new BigInteger(11);

            var shamirSecretSharing = new ShamirSecretSharing();

            var shares = shamirSecretSharing.Split(minimumShares, totalShares, value, modulo);

            var actual = shamirSecretSharing.Join(new[] { shares[0], shares[1] }, modulo);

            Assert.AreEqual(value, actual);

            actual = shamirSecretSharing.Join(new[] { shares[0], shares[2] }, modulo);

            Assert.AreEqual(value, actual);

            actual = shamirSecretSharing.Join(new[] { shares[0], shares[3] }, modulo);

            Assert.AreEqual(value, actual);
                        
            actual = shamirSecretSharing.Join(new[] { shares[1], shares[2] }, modulo);

            Assert.AreEqual(value, actual);

            actual = shamirSecretSharing.Join(new[] { shares[1], shares[3] }, modulo);

            Assert.AreEqual(value, actual);

            actual = shamirSecretSharing.Join(new[] { shares[2], shares[3] }, modulo);

            Assert.AreEqual(value, actual);
        }

        [TestMethod]
        public void Test2Of5()
        {
            var minimumShares = 2;

            var totalShares = 5;

            var value = new BigInteger(6);

            var modulo = new BigInteger(11);

            var shamirSecretSharing = new ShamirSecretSharing();

            var shares = shamirSecretSharing.Split(minimumShares, totalShares, value, modulo);

            var actual = shamirSecretSharing.Join(new[] { shares[0], shares[1] }, modulo);

            Assert.AreEqual(value, actual);

            actual = shamirSecretSharing.Join(new[] { shares[0], shares[2] }, modulo);

            Assert.AreEqual(value, actual);

            actual = shamirSecretSharing.Join(new[] { shares[0], shares[3] }, modulo);

            Assert.AreEqual(value, actual);

            actual = shamirSecretSharing.Join(new[] { shares[0], shares[4] }, modulo);

            Assert.AreEqual(value, actual);

            actual = shamirSecretSharing.Join(new[] { shares[1], shares[2] }, modulo);

            Assert.AreEqual(value, actual);

            actual = shamirSecretSharing.Join(new[] { shares[1], shares[3] }, modulo);

            Assert.AreEqual(value, actual);

            actual = shamirSecretSharing.Join(new[] { shares[1], shares[4] }, modulo);

            Assert.AreEqual(value, actual);

            actual = shamirSecretSharing.Join(new[] { shares[2], shares[3] }, modulo);

            Assert.AreEqual(value, actual);

            actual = shamirSecretSharing.Join(new[] { shares[2], shares[4] }, modulo);

            Assert.AreEqual(value, actual);

            actual = shamirSecretSharing.Join(new[] { shares[3], shares[4] }, modulo);

            Assert.AreEqual(value, actual);
        }

        [TestMethod]
        public void Test3Of3()
        {
            var minimumShares = 3;

            var totalShares = 3;

            var value = new BigInteger(6);

            var modulo = new BigInteger(11);

            var shamirSecretSharing = new ShamirSecretSharing();

            var shares = shamirSecretSharing.Split(minimumShares, totalShares, value, modulo);

            var actual = shamirSecretSharing.Join(new[] { shares[0], shares[1], shares[2] }, modulo);

            Assert.AreEqual(value, actual);
        }

        [TestMethod]
        public void Test3Of4()
        {
            var minimumShares = 3;

            var totalShares = 4;

            var value = new BigInteger(6);

            var modulo = new BigInteger(11);

            var shamirSecretSharing = new ShamirSecretSharing();

            var shares = shamirSecretSharing.Split(minimumShares, totalShares, value, modulo);

            var actual = shamirSecretSharing.Join(new[] { shares[0], shares[1], shares[2] }, modulo);

            Assert.AreEqual(value, actual);

            actual = shamirSecretSharing.Join(new[] { shares[0], shares[1], shares[3] }, modulo);

            Assert.AreEqual(value, actual);

            actual = shamirSecretSharing.Join(new[] { shares[0], shares[2], shares[3] }, modulo);

            Assert.AreEqual(value, actual);

            actual = shamirSecretSharing.Join(new[] { shares[1], shares[2], shares[3] }, modulo);

            Assert.AreEqual(value, actual);
        }

        [TestMethod]
        public void Test3Of5()
        {
            var minimumShares = 3;

            var totalShares = 5;

            var value = new BigInteger(6);

            var modulo = new BigInteger(11);

            var shamirSecretSharing = new ShamirSecretSharing();

            var shares = shamirSecretSharing.Split(minimumShares, totalShares, value, modulo);

            var actual = shamirSecretSharing.Join(new[] { shares[0], shares[1], shares[2] }, modulo);

            Assert.AreEqual(value, actual);

            actual = shamirSecretSharing.Join(new[] { shares[0], shares[1], shares[3] }, modulo);

            Assert.AreEqual(value, actual);

            actual = shamirSecretSharing.Join(new[] { shares[0], shares[1], shares[4] }, modulo);

            Assert.AreEqual(value, actual);

            actual = shamirSecretSharing.Join(new[] { shares[0], shares[2], shares[3] }, modulo);

            Assert.AreEqual(value, actual);

            actual = shamirSecretSharing.Join(new[] { shares[0], shares[2], shares[4] }, modulo);

            Assert.AreEqual(value, actual);

            actual = shamirSecretSharing.Join(new[] { shares[0], shares[3], shares[4] }, modulo);

            Assert.AreEqual(value, actual);

            actual = shamirSecretSharing.Join(new[] { shares[1], shares[2], shares[3] }, modulo);

            Assert.AreEqual(value, actual);

            actual = shamirSecretSharing.Join(new[] { shares[1], shares[2], shares[4] }, modulo);

            Assert.AreEqual(value, actual);

            actual = shamirSecretSharing.Join(new[] { shares[1], shares[3], shares[4] }, modulo);

            Assert.AreEqual(value, actual);

            actual = shamirSecretSharing.Join(new[] { shares[2], shares[3], shares[4] }, modulo);

            Assert.AreEqual(value, actual);
        }

        [TestMethod]
        public void Test4Of4()
        {
            var minimumShares = 4;

            var totalShares = 4;

            var value = new BigInteger(6);

            var modulo = new BigInteger(11);

            var shamirSecretSharing = new ShamirSecretSharing();

            var shares = shamirSecretSharing.Split(minimumShares, totalShares, value, modulo);

            var actual = shamirSecretSharing.Join(new[] { shares[0], shares[1], shares[2], shares[3] }, modulo);

            Assert.AreEqual(value, actual);
        }

        [TestMethod]
        public void Test4Of5()
        {
            var minimumShares = 4;

            var totalShares = 5;

            var value = new BigInteger(6);

            var modulo = new BigInteger(11);

            var shamirSecretSharing = new ShamirSecretSharing();

            var shares = shamirSecretSharing.Split(minimumShares, totalShares, value, modulo);

            var actual = shamirSecretSharing.Join(new[] { shares[0], shares[1], shares[2], shares[3] }, modulo);

            Assert.AreEqual(value, actual);

            actual = shamirSecretSharing.Join(new[] { shares[0], shares[1], shares[2], shares[4] }, modulo);

            Assert.AreEqual(value, actual);

            actual = shamirSecretSharing.Join(new[] { shares[0], shares[1], shares[3], shares[4] }, modulo);

            Assert.AreEqual(value, actual);

            actual = shamirSecretSharing.Join(new[] { shares[0], shares[2], shares[3], shares[4] }, modulo);

            Assert.AreEqual(value, actual);

            actual = shamirSecretSharing.Join(new[] { shares[1], shares[2], shares[3], shares[4] }, modulo);

            Assert.AreEqual(value, actual);
        }

        [TestMethod]
        public void Test5Of5()
        {
            var minimumShares = 5;

            var totalShares = 5;

            var value = new BigInteger(6);

            var modulo = new BigInteger(11);

            var shamirSecretSharing = new ShamirSecretSharing();

            var shares = shamirSecretSharing.Split(minimumShares, totalShares, value, modulo);

            var actual = shamirSecretSharing.Join(new[] { shares[0], shares[1], shares[2], shares[3], shares[4] }, modulo);

            Assert.AreEqual(value, actual);
        }
    }
}