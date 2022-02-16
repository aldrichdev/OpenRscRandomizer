using OpenRscRandomizer.Library;
using OpenRscRandomizer.Library.Enums;
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

            Console.WriteLine("Randomize NPCs? (y/n)");
            var randomizeNpcsResponse = Console.ReadLine();

            if (randomizeNpcsResponse.ToLower().StartsWith('y'))
            {
                Console.WriteLine("\r\nChoose an NPC randomizer mode. \r\nS = Singularly (each individual NPC gets randomized). \r\nG = Grouply (i.e. all chickens become farmers). \r\n\r\nEnter S or G now.");
                var npcRandomizerModeResponse = Console.ReadLine();

                Console.WriteLine("\r\nExclude Non-Attackable NPCs from randomization? (y/n)");
                var excludeNonAttackablesResponse = Console.ReadLine();

                Console.WriteLine("\r\nExclude attackable quest NPCs from randomization? (y/n)");
                var excludeAttackableQuestNpcsResponse = Console.ReadLine();

                NpcRandomizerMode npcRandomizerMode;
                if (npcRandomizerModeResponse.ToLower().StartsWith('g'))
                {
                    npcRandomizerMode = NpcRandomizerMode.Grouply;
                } else
                {
                    npcRandomizerMode = NpcRandomizerMode.Singularly;
                }

                bool excludeNonAttackables = false;
                if (excludeNonAttackablesResponse.ToLower().StartsWith('y'))
                {
                    excludeNonAttackables = true;
                }

                bool excludeAttackableQuestNpcs = false;
                if (excludeAttackableQuestNpcsResponse.ToLower().StartsWith('y'))
                {
                    excludeAttackableQuestNpcs = true;
                }

                randomizer.GenerateRandomizedNpcLocs(newSeedDir, npcRandomizerMode, excludeNonAttackables,
                    excludeAttackableQuestNpcs);
            }

            randomizer.GenerateRandomizedGroundItems(newSeedDir);

            Console.WriteLine("\r\nDone");
        }
    }
}