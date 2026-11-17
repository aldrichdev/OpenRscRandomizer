using NUnit.Framework;
using OpenRscRandomizer.Library;
using OpenRscRandomizer.Library.Enums;
using OpenRscRandomizer.Library.Models;
using System.Threading.Tasks;

namespace OpenRscRandomizer.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(NpcRandomizationMode.Individually, false, false)]
        [TestCase(NpcRandomizationMode.Individually, false, true)]
        [TestCase(NpcRandomizationMode.Individually, true, false)]
        [TestCase(NpcRandomizationMode.Individually, true, true)]
        [TestCase(NpcRandomizationMode.ByType, false, false)]
        [TestCase(NpcRandomizationMode.ByType, false, true)]
        [TestCase(NpcRandomizationMode.ByType, true, false)]
        [TestCase(NpcRandomizationMode.ByType, true, true)]
        public async Task Npc_Input_Count_Matches_Output_Count(NpcRandomizationMode mode, bool excludeNonAttackables,
            bool excludeAttackableQuestNpcs)
        {
            var source = new FileDefSource("Fixtures");
            var randomizer = new RscRandomizer(source);
            var seed = randomizer.GetNewSeed();

            var defaultNpcLocations = await randomizer.GetNpcLocations();
            var randomizedNpcLocations = await randomizer.GetRandomizedNpcLocations(seed, mode, 
                excludeNonAttackables, excludeAttackableQuestNpcs);

            var npcInputCount = defaultNpcLocations.npclocs.Count;
            var npcOutputCount = randomizedNpcLocations.npclocs.Count;

            Assert.AreEqual(npcInputCount, npcOutputCount);
        }
    }
}