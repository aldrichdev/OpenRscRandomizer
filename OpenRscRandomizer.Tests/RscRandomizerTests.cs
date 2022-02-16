using NUnit.Framework;
using OpenRscRandomizer.Library;
using OpenRscRandomizer.Library.Enums;
using System.IO;

namespace OpenRscRandomizer.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Seed_Folder_Creation_Succeeds()
        {
            var randomizer = new RscRandomizer();
            var seedDir = randomizer.CreateSeed();
            var folderExists = Directory.Exists(seedDir.FullName);
            var folderPathIsCorrect = seedDir.FullName
                .Contains($"{RscRandomizer.PROJECT_PATH}\\Output\\Seed");

            Assert.NotNull(seedDir);
            Assert.IsTrue(folderExists);
            Assert.IsTrue(folderPathIsCorrect);
        }

        [Test]
        [TestCase(NpcRandomizerMode.Singularly, false, false)]
        [TestCase(NpcRandomizerMode.Singularly, false, true)]
        [TestCase(NpcRandomizerMode.Singularly, true, false)]
        [TestCase(NpcRandomizerMode.Singularly, true, true)]
        [TestCase(NpcRandomizerMode.Grouply, false, false)]
        [TestCase(NpcRandomizerMode.Grouply, false, true)]
        [TestCase(NpcRandomizerMode.Grouply, true, false)]
        [TestCase(NpcRandomizerMode.Grouply, true, true)]
        public void Npc_Input_Count_Matches_Output_Count(NpcRandomizerMode mode, bool excludeNonAttackables,
            bool excludeAttackableQuestNpcs)
        {
            var randomizer = new RscRandomizer();
            var defaultNpcLocations = randomizer.GetNpcLocations();
            var randomizedNpcLocations = randomizer.GetRandomizedNpcLocations(mode, excludeNonAttackables,
                excludeAttackableQuestNpcs);

            var npcInputCount = defaultNpcLocations.npclocs.Count;
            var npcOutputCount = randomizedNpcLocations.npclocs.Count;

            Assert.AreEqual(npcInputCount, npcOutputCount);
        }
    }
}