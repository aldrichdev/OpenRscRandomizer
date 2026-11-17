namespace OpenRscRandomizer.Library.Enums
{
    public enum NpcRandomizationMode
    {
        None,
        /// <summary>
        /// Randomizes NPCs one-by-one. (Legacy: "Singularly")
        /// </summary>
        Individually,
        /// <summary>
        /// Randomizes by NPC type. (Legacy: "Grouply")
        /// </summary>
        ByType,
        /// <summary>
        /// Randomizes by NPC nest. (Legacy: "Grouply By Location")
        /// </summary>
        ByNest,
    }
}
