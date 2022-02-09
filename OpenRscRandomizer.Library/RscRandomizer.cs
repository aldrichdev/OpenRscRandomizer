using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using OpenRscRandomizer.Library.Models;

namespace OpenRscRandomizer.Library
{
    public class RscRandomizer
    {
        public const string PROJECT_PATH = @"C:\Dev\Personal\OpenRscRandomizer\OpenRscRandomizer";
        public const string NPC_DEFS_FILE_PATH = @"C:\Dev\Open RSC\core\server\conf\server\defs\NpcDefs.json";
        public string NPC_LOCS_FILE_PATH = $"{PROJECT_PATH}\\Input\\NpcLocs.json";
        public string GROUND_ITEMS_FILE_PATH = $"{PROJECT_PATH}\\Input\\GroundItems.json";

        public DirectoryInfo CreateSeed()
        {
            var rnd = new Random();
            int seed = rnd.Next();

            return Directory.CreateDirectory($"{PROJECT_PATH}\\Output\\Seed {seed}");
        }

        public void GenerateRandomizedNpcLocs(DirectoryInfo newSeedDir)
        {
            // Randomize npcs.
            NpcLocs npcs = GetRandomizedNpcLocations();

            // Write npcs to a new JSON file as a seed
            var newNpcLocsJson = JsonConvert.SerializeObject(npcs);
            File.WriteAllText($"{newSeedDir.FullName}\\NpcLocs.json", newNpcLocsJson);
        }

        public void GenerateRandomizedGroundItems(DirectoryInfo newSeedDir)
        {
            GroundItems items;
            using (StreamReader reader = File.OpenText(GROUND_ITEMS_FILE_PATH))
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

        public NpcLocs GetRandomizedNpcLocations()
        {
            IList<Npc> exclusions = GetExcludedNpcs(NPC_DEFS_FILE_PATH);
            IList<int> exclusionIds = exclusions.Select(x => x.id).ToList();

            NpcLocs npcs = GetNpcLocations();

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

            return npcs;
        }

        public NpcLocs GetNpcLocations()
        {
            NpcLocs npcs;

            using (StreamReader reader = File.OpenText(NPC_LOCS_FILE_PATH))
            {
                string json = reader.ReadToEnd();
                npcs = JsonConvert.DeserializeObject<NpcLocs>(json);
            }

            return npcs;
        }

        private IList<Npc> GetExcludedNpcs(string npcDefsFilePath)
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

            return npcs.npcs.Where(x => x.attackable == false || attackableQuestNpcs.Contains(x.id)).Select(x => x).ToList();
        }

        private List<NpcLoc> GetExcludedNpcLocs(IList<NpcLoc> originalNpcs, IList<int> excludedNpcInts)
        {
            List<NpcLoc> excludedNpcLocs = new List<NpcLoc>();

            foreach (var excludedId in excludedNpcInts)
            {
                var matchingNpcLocs = originalNpcs.Where(x => x.id.Equals(excludedId)).Select(x => x).ToList();

                excludedNpcLocs.AddRange(matchingNpcLocs);
            }

            return excludedNpcLocs;
        }

        private NpcLocs GetSingularlyRandomizedNpcs(NpcLocs npcs, IList<int> randomized, IList<int> exclusions)
        {
            NpcLocs newNpcs = npcs;

            for (int i = 0; i < newNpcs.npclocs.Count(); i++)
            {
                // Do not randomize any NPCs in the exclusions list.
                if (!exclusions.Contains(newNpcs.npclocs[i].id) && !exclusions.Contains(randomized[i]))
                {
                    newNpcs.npclocs[i].id = randomized[i];
                }
            }

            return newNpcs;
        }
    }
}
