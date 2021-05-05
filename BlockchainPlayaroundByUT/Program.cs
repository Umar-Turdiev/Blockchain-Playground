using System;

namespace CryptoBlocks
{
    class Program
    {
        static void Main()
        {
            //#region Test chain
            //Blockchain TestChain = new Blockchain();

            //TestChain.AddBlock("Change ownership to Jeff.");
            //TestChain.AddBlock("foo");
            //TestChain.AddBlock("bar");
            //TestChain.AddBlock(950);
            //#endregion

            Blockchain blockchain = new Blockchain();

            blockchain.AddBlock(new DateTime(2021, 2, 3), "1000$");
            blockchain.AddBlock(new DateTime(2021, 2, 4), "2000$");
            blockchain.AddBlock(new DateTime(2021, 2, 5), "3000$");
            blockchain.AddBlock(new DateTime(2021, 2, 6), "4000$");


            foreach (var item in blockchain.Chain)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"{Environment.NewLine}IsChainValid: {blockchain.IsChainValid()}");
            blockchain.Chain[2].CalculateHash();
            blockchain.Chain[1].Mine(1);

            Console.WriteLine("Mined");

            Console.ReadLine();
        }
    }
}
