using System;
using Xunit;

namespace CryptoBlocks.Test
{
    public class BlockchainTest
    {
        #region Test chain
        /// <summary>
        /// Blockchain for testing.
        /// </summary>
        Blockchain TestChain = new Blockchain();

        private void LoadTestChian()
        {
            TestChain.AddBlock(new DateTime(2021, 2, 3), "Change ownership to Jeff.");
            TestChain.AddBlock(new DateTime(2021, 2, 3), "foo");
            TestChain.AddBlock(new DateTime(2021, 2, 3), "bar");
            TestChain.AddBlock(new DateTime(2021, 2, 3), 950);
        }
        #endregion


        /// <summary>
        /// Varifies that LatestBlock property returns the latest block of the chain.
        /// </summary>
        [Fact]
        public void GetLatestBlcokTest()
        {
            Assert.Equal(TestChain.Chain[TestChain.Chain.Count - 1], TestChain.LatestBlock);
        }


        /// <summary>
        /// Varifies the chain validation test function.
        /// </summary>
        [Fact]
        public void ChainValidationTest()
        {
            LoadTestChian();

            Assert.True(TestChain.IsChainValid());
        }


        /// <summary>
        /// Varifies that the chain validation function returns "False" after hash of the current block been modified.
        /// </summary>
        [Fact]
        public void ChainValidationTestAfterHashModified()
        {
            LoadTestChian();

            TestChain.Chain[2].Hash = "8613E5CF3231302E749356AB2AC1861ADD42B4160304986770CAAC8164E46A8B";

            Assert.False(TestChain.IsChainValid());
        }


        /// <summary>
        /// Varifies that the chain validation function returns "False" after previous hash of the current block been modified.
        /// </summary>
        [Fact]
        public void ChainValidationTestAfterPreviousHashModified()
        {
            LoadTestChian();

            TestChain.Chain[3].PreviousHash = "8613E5CF3231302E749356AB2AC1861ADD42B4160304986770CAAC8164E46A8B";

            Assert.False(TestChain.IsChainValid());
        }
    }
}
