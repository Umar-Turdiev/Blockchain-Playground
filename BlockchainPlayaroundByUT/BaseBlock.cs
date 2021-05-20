using System;
using System.Security.Cryptography;
using System.Text;

namespace CryptoBlocks
{
    abstract class BaseBlock
    {
        public BaseBlock(DateTime TimeStamp, object Transaction, string PreviousHash)
        {
            this.Timestamp = TimeStamp;
            this.Transaction = Transaction;
            this.PreviousHash = PreviousHash;
            this.Hash = CalculateHash();
        }


        #region Properties
        public DateTime Timestamp { get; }

        public object Transaction { get; set; }

        public string Hash { get; set; }
        public string PreviousHash { get; set; }

        public int Nonce { get; set; } = 0;
        #endregion


        /// <summary>
        /// Calculate hash for current block using SHA256.
        /// </summary>
        /// <returns>
        /// The string representation of the current block's hash.
        /// </returns>
        public string CalculateHash()
        {
            SHA256 sha256Hash = SHA256.Create();

            string rawData = $"{this.Timestamp:yyyy/MM/dd/HH:mm:ss}{this.Transaction}{this.PreviousHash}{this.Nonce}";


            //Compute hash
            byte[] hash = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));


            string hashString = string.Empty;

            foreach (byte item in hash)
            {
                hashString += item.ToString("x2");
            }


            return hashString;
        }

        public override string ToString()
        {
            return $"{Environment.NewLine}" +
                $"\tTimestamp: \"{this.Timestamp}\"{Environment.NewLine}" +
                $"\tTransaction: \"{this.Transaction}\"{Environment.NewLine}" +
                $"\tHash: \"{this.Hash}\"{Environment.NewLine}" +
                $"\tPreviousHash: \"{this.PreviousHash}\"{Environment.NewLine}" +
                $"\tNonece: \"{this.Nonce}\"{Environment.NewLine}";
        }
    }
}
