using Newtonsoft.Json;
using System;
using System.Security.Cryptography;
using System.Text;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                SHA256 sha256Hash = SHA256.Create();

                //string rawData = $"{JsonConvert.SerializeObject(this.Transaction)}{this.PreviousHash}{this.Timestamp}";
                string rawData = Console.ReadLine();


                //Compute hash
                byte[] hash = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));


                string hashString = string.Empty;

                foreach (byte item in hash)
                {
                    hashString += item.ToString("x2");
                }


                Console.WriteLine(hashString);
            }
        }
    }
}
