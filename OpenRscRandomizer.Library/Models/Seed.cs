using OpenRscRandomizer.Library.Enums;

namespace OpenRscRandomizer.Library.Models
{
    public class Seed
    {
        public NpcRandomizationMode NpcRandomizationMode { get; set; } = NpcRandomizationMode.None;
        public bool ExcludeNonAttackables { get; set; }
        public bool ExcludeAttackableQuestNpcs { get; set; }
        public bool RandomizeGroundItems { get; set; }
    }
}
