using System;

namespace HockeyEditor
{
    /// <summary>
    /// Contains information about the scores of the 2 teams
    /// </summary>
    public static class Scoreboard
    {
        const int ScoreboardAddress = 0x07D33D98;
        const int RedOffset = 0x0;
        const int BlueOffset = 0x4;
        
        /// <summary>
        /// The red team's score
        /// </summary>
        public static int red
        {
            get { return MemoryWriter.ReadInt(ScoreboardAddress + RedOffset); }
            set { MemoryWriter.WriteInt(value, ScoreboardAddress + RedOffset); }
        }

        /// <summary>
        /// The blue team's score
        /// </summary>
        public static int blue
        {
            get { return MemoryWriter.ReadInt(ScoreboardAddress + BlueOffset); }
            set { MemoryWriter.WriteInt(value, ScoreboardAddress + BlueOffset); }
        }
    }
}
