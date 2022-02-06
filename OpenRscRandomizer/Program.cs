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
            IList<int> exclusions = GetExclusions(npcDefsFilePath);
            NpcLocs npcs;

            using (StreamReader reader = File.OpenText(npcLocsFilePath))
            {
                string json = reader.ReadToEnd();
                npcs = JsonConvert.DeserializeObject<NpcLocs>(json);
            }

            IList<int> justTheIds = npcs.npclocs.Select(x => x.id).ToList();

            var rnd = new Random();
            IList<int> randomized = justTheIds.OrderBy(id => rnd.Next()).ToList();

            // Change NPC IDs to the equivalent randomized ID.
            for (int i = 0; i < npcs.npclocs.Count(); i++)
            {
                // Do not randomize any NPCs in the exclusions list.
                if (!exclusions.Contains(npcs.npclocs[i].id) && !exclusions.Contains(randomized[i]))
                {
                    npcs.npclocs[i].id = randomized[i];
                }
            }

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

        private static IList<int> GetExclusions(string npcDefsFilePath)
        {
            IList<int> exclusions = new List<int>() { 95, 224, 268, 540, 617 };
            NpcDefs npcs;

            using (StreamReader reader = File.OpenText(npcDefsFilePath))
            {
                string json = reader.ReadToEnd();
                npcs = JsonConvert.DeserializeObject<NpcDefs>(json);
            }

            return npcs.npcs.Where(x => x.attackable == false).Select(x => x.id).ToList();
        }
    }
}
