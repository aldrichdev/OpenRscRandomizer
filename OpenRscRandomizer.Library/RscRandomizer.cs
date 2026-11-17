using OpenRscRandomizer.Library.Enums;
using OpenRscRandomizer.Library.Interfaces;
using OpenRscRandomizer.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenRscRandomizer.Library
{
    public class RscRandomizer
    {
        private IDefSource _defSource;

        public RscRandomizer(IDefSource defSource)
        {
            _defSource = defSource;
        }

        public int GetNewSeed()
        {
            var rnd = new Random();
            int seed = rnd.Next();

            return seed;
        }

        public async Task<NpcLocs> GetRandomizedNpcLocations(int seed, NpcRandomizationMode npcRandomizerMode,
            bool excludeNonAttackables, bool excludeAttackableQuestNpcs)
        {
            NpcDefs defs = await GetNpcDefsAsync();

            IList<Npc> exclusions = GetExcludedNpcs(defs, excludeNonAttackables, excludeAttackableQuestNpcs);
            IList<int> exclusionIds = exclusions.Select(x => x.id).ToList();

            NpcLocs npcs = await GetNpcLocations();

            IList<NpcLoc> exclusionLocs = GetExcludedNpcLocs(npcs.npclocs, exclusionIds);
            IList<int> justTheIds = npcs.npclocs.Select(x => x.id).ToList();

            var rnd = new Random(seed);
            IList<int> randomized = justTheIds.OrderBy(id => rnd.Next()).ToList();

            switch (npcRandomizerMode)
            {
                case NpcRandomizationMode.Individually:
                    return GetSingularlyRandomizedNpcs(npcs, randomized, exclusionIds);
                case NpcRandomizationMode.ByType:
                    return GetGrouplyRandomizedNpcs(npcs, randomized, exclusionIds, exclusionLocs);
                default:
                    return GetSingularlyRandomizedNpcs(npcs, randomized, exclusionIds);
            }
        }

        /// <summary>
        /// Fetches the npcDefs.json file from the Core Framework GitLab repository.
        /// </summary>
        private async Task<NpcDefs> GetNpcDefsAsync()
        {
            NpcDefs npcs = await _defSource.LoadAsync<NpcDefs>("NpcDefs.json");

            return npcs;
        }

        private IList<Npc> GetExcludedNpcs(NpcDefs defs, bool excludeNonAttackables, bool excludeAttackableQuestNpcs)
        {
            IList<int> attackableQuestNpcs = new List<int>() { 35, 50, 29, 109, 177, 178, 179, 180, 181, 182, 192, 196, 216,
                244, 245, 246, 247, 252, 254, 259, 276, 315, 361, 364, 383, 384, 386, 388, 410, 426, 428, 473, 502, 531, 568,
                613, 614, 615, 632, 633, 641, 644, 645, 646, 647, 651, 658, 663, 664, 669, 670, 673, 684, 692, 697, 713, 729,
                757, 758, 759, 760, 761, 762, 766, 767, 769, 772, 789, 790, 791 };

            return defs.npcs.Where(x => (excludeNonAttackables && x.attackable == 0) || 
                (excludeAttackableQuestNpcs && attackableQuestNpcs.Contains(x.id)))
                .Select(x => x)
                .ToList();
        }

        public async Task<NpcLocs> GetNpcLocations()
        {
            NpcLocs npcs = await _defSource.LoadAsync<NpcLocs>("locs/NpcLocs.json");

            return npcs;
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

        private static NpcLocs GetGrouplyRandomizedNpcs(NpcLocs npcs, IList<int> randomized, IList<int> exclusionIds,
            IList<NpcLoc> exclusionLocs)
        {
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

            NpcLocs newNpcs = npcs;
            newList.AddRange(exclusionLocs);
            newNpcs.npclocs = newList;

            return newNpcs;
        }

        public async Task<GroundItems> GetRandomizedGroundItems(int seed)
        {
            GroundItems items = await GetGroundItemsAsync();

            IList<int> justTheIds = items.grounditems.Select(x => x.id).ToList();

            var rnd = new Random(seed);
            IList<int> randomized = justTheIds.OrderBy(id => rnd.Next()).ToList();

            // Change ground item IDs to the equivalent randomized ID.
            for (int i = 0; i < items.grounditems.Count(); i++)
            {
                items.grounditems[i].id = randomized[i];
            }

            return items;
        }

        /// <summary>
        /// Fetches the groundItems.json file from the Core Framework GitLab repository as an object.
        /// </summary>
        private async Task<GroundItems> GetGroundItemsAsync()
        {
            GroundItems items = await _defSource.LoadAsync<GroundItems>("locs/GroundItems.json");

            return items;
        }
    }
}
