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

                foreach (NpcLoc npc in npcs.npclocs.Where(x => !exclusionIds.Contains(x.id) &&
                    !processed.Contains(x.id)).ToList())
                {
                    countRan += 1;
                    Console.WriteLine($"processed {countRan}");
                    var thisId = npc.id;

                    // Get all NPCs with THIS ID ^^^
                    // Set THEIR ids to `rando`.
                    var matchingItems = npcs.npclocs.Where(x => x.id.Equals(thisId)).Select(x => { x.id = rando; return x; })
                        .ToList();
                    newList.AddRange(matchingItems);
                    processed.Add(thisId);

                    // Remove those items from the list
                    foreach (var matchingItem in matchingItems)
                    {
                        npcs.npclocs.Remove(matchingItem);
                    }

                    break;
                }
            }

            // DEDUPE by start.
            var deduped = newList.GroupBy(x => x.start).Select(x => x.First()).ToList();
            deduped.AddRange(exclusionLocs);
            npcs.npclocs = deduped;

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
            NpcDefs npcs;

            using (StreamReader reader = File.OpenText(npcDefsFilePath))
            {
                string json = reader.ReadToEnd();
                npcs = JsonConvert.DeserializeObject<NpcDefs>(json);
            }

            return npcs.npcs.Where(x => x.attackable == false).Select(x => x).ToList();
        }

        private static List<NpcLoc> GetExcludedNpcLocs(IList<NpcLoc> originalNpcs, IList<int> excludedNpcInts)
        {
            List<NpcLoc> excludedNpcLocs = new List<NpcLoc>();

            foreach (var excludedId in excludedNpcInts)
            {
                // Get ALL objects from originalNpcs that match this excludedId
                var allThoseObjects = originalNpcs.Where(x => x.id.Equals(excludedId)).Select(x => x).ToList();

                excludedNpcLocs.AddRange(allThoseObjects);

                //excludedNpcLocs.Add(originalNpcs.Select(x => x.id.Equals(excludedId)).ToList());
            }

            return excludedNpcLocs;
        }
    }
}


// We NEED to remove the objects from the iteration when they are added to newList.
// Example - rando is 243, grey wolf. We know `npc` below is going to be 401, Black Knight Titan.
// So we set BKT's id to 243, which puts a grey wolf where BKT was, and add BKT's id to the processed list
// So far, so good, and this all makes sense.

// Break out, and next rando is 8 - Bear. 
// `npc` below is now 243, which is the grey wolf which used to be a BKT.
// We have to remove that guy so we don't update the same NPC location over and over and over.

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