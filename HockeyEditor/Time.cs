using System;

namespace HockeyEditor
{
    /// <summary>
    /// Contains information about the various game timers
    /// </summary>
    public static class Time
    {
        const int TimeAddress = 0x07D349A8;
        const int TimeOffset = 0x0;
        const int PeriodOffset = 0x8;
        const int IntermissionTimeOffset = 0xC;

        const int StopTimeAddress = 0x07D33DA0;

        /// <summary>
        /// The game time in hundredths of a second
        /// </summary>
        public static int time
        {
            get { return MemoryWriter.ReadInt(TimeAddress + TimeOffset); }
            set { MemoryWriter.WriteInt(value, TimeAddress + TimeOffset); }
        }

        /// <summary>
        /// The period. 0 = warmup, 1-3 = normal periods. 4+ = overtime
        /// </summary>
        public static int period
        {
            get { return MemoryWriter.ReadInt(TimeAddress + PeriodOffset); }
            set { MemoryWriter.WriteInt(value, TimeAddress + PeriodOffset); }
        }

        /// <summary>
        /// The amount of time in hundredths of a second before the next period starts
        /// </summary>
        public static int intermissionTime
        {
            get { return MemoryWriter.ReadInt(TimeAddress + IntermissionTimeOffset); }
            set { MemoryWriter.WriteInt(value, TimeAddress + IntermissionTimeOffset); }
        }

        /// <summary>
        /// The amount of time in hundredths of a second before the next faceoff starts (after a goal)
        /// </summary>
        public static int stopTime
        {
            get { return MemoryWriter.ReadInt(StopTimeAddress); }
            set { MemoryWriter.WriteInt(value, StopTimeAddress); }
        }
    }
}
