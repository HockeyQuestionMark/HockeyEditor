using System;

namespace HockeyEditor
{
    /// <summary>
    /// Contains information about the scores of the 2 teams
    /// </summary>
    public static class GameInfo
    {
        const int TIME_ADDRESS = 0x07D349A8;
        const int TIME_OFFSET = 0x0;
        const int PERIOD_OFFSET = 0x8;
        const int INTERMISSION_TIME_OFFSET = 0xC;

        const int STOP_TIME_ADDRESS = 0x07D33DA0;

        const int SCOREBOARD_ADDRESS = 0x07D33D98;
        const int RED_SCORE_OFFSET = 0x0;
        const int BLUE_SCORE_OFFSET = 0x4;

        const int CHAT_OPEN = 0x07CAAFE0;
        const int CHATMESSAGE = 0x07126C00;

        /// <summary>
        /// The red team's score
        /// </summary>
        public static int RedScore
        {
            get { return MemoryEditor.ReadInt(SCOREBOARD_ADDRESS + RED_SCORE_OFFSET); }
            set { MemoryEditor.WriteInt(value, SCOREBOARD_ADDRESS + RED_SCORE_OFFSET); }
        }

        /// <summary>
        /// The blue team's score
        /// </summary>
        public static int BlueScore
        {
            get { return MemoryEditor.ReadInt(SCOREBOARD_ADDRESS + BLUE_SCORE_OFFSET); }
            set { MemoryEditor.WriteInt(value, SCOREBOARD_ADDRESS + BLUE_SCORE_OFFSET); }
        }

        /// <summary>
        /// The game time in hundredths of a second
        /// </summary>
        public static int GameTime
        {
            get { return MemoryEditor.ReadInt(TIME_ADDRESS + TIME_OFFSET); }
            set { MemoryEditor.WriteInt(value, TIME_ADDRESS + TIME_OFFSET); }
        }

        /// <summary>
        /// The period. 0 = warmup, 1-3 = normal periods. 4+ = overtime
        /// </summary>
        public static int Period
        {
            get { return MemoryEditor.ReadInt(TIME_ADDRESS + PERIOD_OFFSET); }
            set { MemoryEditor.WriteInt(value, TIME_ADDRESS + PERIOD_OFFSET); }
        }

        /// <summary>
        /// The amount of time in hundredths of a second before the next period starts
        /// </summary>
        public static int IntermissionTime
        {
            get { return MemoryEditor.ReadInt(TIME_ADDRESS + INTERMISSION_TIME_OFFSET); }
            set { MemoryEditor.WriteInt(value, TIME_ADDRESS + INTERMISSION_TIME_OFFSET); }
        }

        /// <summary>
        /// The amount of time in hundredths of a second before the next faceoff starts (after a goal)
        /// </summary>
        public static int StopTime
        {
            get { return MemoryEditor.ReadInt(STOP_TIME_ADDRESS); }
            set { MemoryEditor.WriteInt(value, STOP_TIME_ADDRESS); }
        }

        /// <summary>
        /// Send a message to chat from local player
        /// </summary>
        /// <param name="message">the message to send, only the first 63 characters will be shown</param>
        public static void SendChatMessage(string message)
        {
            MemoryEditor.WriteInt(CHAT_OPEN, 0);
            MemoryEditor.WriteString(CHATMESSAGE, message );
        }
    }
}
