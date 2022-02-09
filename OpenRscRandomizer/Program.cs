using OpenRscRandomizer.Library;
using System;

namespace OpenRscRandomizer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Open RSC Randomizer! Press ENTER to create a new seed.");
            Console.ReadLine();

            var randomizer = new RscRandomizer();
            var newSeedDir = randomizer.CreateSeed();

            randomizer.GenerateRandomizedNpcLocs(newSeedDir);
            randomizer.GenerateRandomizedGroundItems(newSeedDir);

            Console.WriteLine("Done");
        }
    }
}