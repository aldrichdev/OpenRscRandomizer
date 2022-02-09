using NUnit.Framework;
using OpenRscRandomizer.Library;
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
        public void Npc_Input_Count_Matches_Output_Count()
        {
            var randomizer = new RscRandomizer();
            var defaultNpcLocations = randomizer.GetNpcLocations();
            var randomizedNpcLocations = randomizer.GetRandomizedNpcLocations();

            var npcInputCount = defaultNpcLocations.npclocs.Count;
            var npcOutputCount = randomizedNpcLocations.npclocs.Count;

            Assert.AreEqual(npcInputCount, npcOutputCount);
        }
    }
}