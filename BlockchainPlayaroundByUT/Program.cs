using System;

namespace CryptoBlocks
{
    class Program
    {
        static void Main()
        {
            Blockchain blockchain = new Blockchain();

            blockchain.AddBlock(new DateTime(2021, 2, 3), "1000$");
            blockchain.AddBlock(new DateTime(2021, 2, 4), "2000$");
            blockchain.AddBlock(new DateTime(2021, 2, 5), "3000$");
            blockchain.AddBlock(new DateTime(2021, 2, 6), "4000$");


            foreach (Block block in blockchain.Chain)
            {
                Console.WriteLine(block);
            }

            Console.ReadLine();
        }
    }
}
