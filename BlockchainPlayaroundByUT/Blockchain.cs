using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoBlocks
{
    public class Blockchain
    {
        public Blockchain()
        {
            createGenesisBlock();
        }


        /// <summary>
        /// The collection of all the block in the blockchain.
        /// </summary>
        public List<Block> Chain { get; } = new List<Block>();

        /// <summary>
        /// The latest block in the blockchain.
        /// </summary>
        public Block LatestBlock { get { return getLatestBlock(); } }


        private void createGenesisBlock()
        {
            this.Chain.Add(new Block(DateTime.Now, "0", "00"));
        }


        private Block getLatestBlock()
        {
            return this.Chain[this.Chain.Count - 1];
        }


        public bool IsChainValid()
        {
            for (int i = 1; i < Chain.Count; i++)
            {
                Block currentBlock = Chain[i];
                Block previousBlock = Chain[i - 1];


                if (currentBlock.Hash != currentBlock.CalculateHash())
                {
                    return false;
                }

                if (currentBlock.PreviousHash != previousBlock.Hash)
                {
                    return false;
                }
            }

            return true;
        }


        //Create new block and add to block collection
        public void AddBlock(DateTime TimeStamp, object Transaction)
        {
            this.Chain.Add(new Block(TimeStamp, Transaction, LatestBlock.Hash));
        }
    }
}
