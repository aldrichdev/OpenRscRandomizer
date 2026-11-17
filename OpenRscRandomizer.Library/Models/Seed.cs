using OpenRscRandomizer.Library.Enums;
using System.ComponentModel.DataAnnotations;

namespace OpenRscRandomizer.Library.Models
{
    public class Seed
    {
        public NpcRandomizationMode NpcRandomizationMode { get; set; } = NpcRandomizationMode.None;
        public bool ExcludeNonAttackables { get; set; }
        public bool ExcludeAttackableQuestNpcs { get; set; }
        public bool RandomizeGroundItems { get; set; }
        /// <summary>
        /// User-defined seed number to control randomization.
        /// </summary>
        public int? SeedNumber { get; set; }
    }
}
