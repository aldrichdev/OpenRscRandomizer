using Newtonsoft.Json;
using OpenRscRandomizer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OpenRscRandomizer
{
    class Program
    {
        static void Main(string[] args)
        {
            var projectPath = @"C:\Dev\Personal\OpenRscRandomizer\OpenRscRandomizer";
            var npcDefsFilePath = @"C:\Dev\Open RSC\core\server\conf\server\defs\NpcDefs.json";
            var npcLocsFilePath = $"{projectPath}\\Input\\NpcLocs.json";
            var groundItemsFilePath = $"{projectPath}\\Input\\GroundItems.json";

            var newSeedDir = CreateSeed(projectPath);

            GenerateRandomizedNpcLocs(npcLocsFilePath, newSeedDir, npcDefsFilePath);
            GenerateRandomizedGroundItems(groundItemsFilePath, newSeedDir);

            Console.WriteLine("Done");
        }

        private static DirectoryInfo CreateSeed(string projectPath)
        {
            var rnd = new Random();
            int seed = rnd.Next();

            return Directory.CreateDirectory($"{projectPath}\\Output\\Seed {seed}");
        }

        private static void GenerateRandomizedNpcLocs(string npcLocsFilePath, DirectoryInfo newSeedDir, string npcDefsFilePath)
        {
            IList<Npc> exclusions = GetExcludedNpcs(npcDefsFilePath);
            IList<int> exclusionIds = exclusions.Select(x => x.id).ToList();
            
            NpcLocs npcs;

            using (StreamReader reader = File.OpenText(npcLocsFilePath))
            {
                string json = reader.ReadToEnd();
                npcs = JsonConvert.DeserializeObject<NpcLocs>(json);
            }

            IList<NpcLoc> exclusionLocs = GetExcludedNpcLocs(npcs.npclocs, exclusionIds);

            IList<int> justTheIds = npcs.npclocs.Select(x => x.id).ToList();

            var rnd = new Random();
            IList<int> randomized = justTheIds.OrderBy(id => rnd.Next()).ToList();
            IList<int> groupedAttackableRandoms = randomized.Where(x => !exclusionIds.Contains(x)).Distinct().ToList();
            List<NpcLoc> newList = new List<NpcLoc>();

            int countRan = 0;
            List<int> processed = new List<int>();

            foreach (int rando in groupedAttackableRandoms)
            {
                foreach (NpcLoc npc in npcs.npclocs.Where(x => !exclusionIds.Contains(x.id)))
                {
                    countRan += 1;
                    Console.WriteLine($"processed {countRan}");
                    var thisId = npc.id;

                    // Get all NPCs with THIS ID ^^^
                    // Set THEIR ids to `rando`.
                    var matchingItems = npcs.npclocs.Where(x => x.id.Equals(thisId)).Select(x => { x.id = rando; return x; })
                        .ToList();
                    newList.AddRange(matchingItems);

                    // Remove those items from the list
                    foreach (var matchingItem in matchingItems)
                    {
                        npcs.npclocs.Remove(matchingItem);
                    }

                    break;
                }
            }

            newList.AddRange(exclusionLocs);
            npcs.npclocs = newList;

            // Write npcs to a new JSON file as a seed
            var newNpcLocsJson = JsonConvert.SerializeObject(npcs);
            File.WriteAllText($"{newSeedDir.FullName}\\NpcLocs.json", newNpcLocsJson);
        }

        private static void GenerateRandomizedGroundItems(string groundItemsFilePath, DirectoryInfo newSeedDir)
        {
            GroundItems items;
            using (StreamReader reader = File.OpenText(groundItemsFilePath))
            {
                string json = reader.ReadToEnd();
                items = JsonConvert.DeserializeObject<GroundItems>(json);
            }

            IList<int> justTheIds = items.grounditems.Select(x => x.id).ToList();

            var rnd = new Random();
            IList<int> randomized = justTheIds.OrderBy(id => rnd.Next()).ToList();

            // Change ground item IDs to the equivalent randomized ID.
            for (int i = 0; i < items.grounditems.Count(); i++)
            {
                items.grounditems[i].id = randomized[i];
            }

            // Write ground items to a new JSON file as a seed
            var newGroundItemsJson = JsonConvert.SerializeObject(items);
            File.WriteAllText($"{newSeedDir.FullName}\\GroundItems.json", newGroundItemsJson);
        }

        private static IList<Npc> GetExcludedNpcs(string npcDefsFilePath)
        {
            IList<int> attackableQuestNpcs = new List<int>() { 35, 50, 29, 109, 177, 178, 179, 180, 181, 182, 192, 196, 216, 
                244, 245, 246, 247, 252, 254, 259, 276, 315, 361, 364, 383, 384, 386, 388, 410, 426, 428, 473, 502, 531, 568, 
                613, 614, 615, 632, 633, 641, 644, 645, 646, 647, 651, 658, 663, 664, 669, 670, 673, 684, 692, 697, 713, 729, 
                757, 758, 759, 760, 761, 762, 766, 767, 769, 772, 789, 790, 791 };
            NpcDefs npcs;

            using (StreamReader reader = File.OpenText(npcDefsFilePath))
            {
                string json = reader.ReadToEnd();
                npcs = JsonConvert.DeserializeObject<NpcDefs>(json);
            }

            return npcs.npcs.Where(x => x.attackable == false && !attackableQuestNpcs.Contains(x.id)).Select(x => x).ToList();
        }

        private static List<NpcLoc> GetExcludedNpcLocs(IList<NpcLoc> originalNpcs, IList<int> excludedNpcInts)
        {
            List<NpcLoc> excludedNpcLocs = new List<NpcLoc>();

            foreach (var excludedId in excludedNpcInts)
            {
                var matchingNpcLocs = originalNpcs.Where(x => x.id.Equals(excludedId)).Select(x => x).ToList();

                excludedNpcLocs.AddRange(matchingNpcLocs);
            }

            return excludedNpcLocs;
        }
    }
}

// TODO: Save this code and use it as one type of randomizer ("randomize NPCs singularly" or something)
//// Change NPC IDs to the equivalent randomized ID.
//for (int i = 0; i < npcs.npclocs.Count(); i++)
//{
//    // set all ids like this one to a grouped randomized id

//    // Do not randomize any NPCs in the exclusions list.
//    if (!exclusions.Contains(npcs.npclocs[i].id) && !exclusions.Contains(randomized[i]))
//    {
//        npcs.npclocs[i].id = randomized[i];
//    }
//}