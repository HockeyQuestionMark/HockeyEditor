using System;

namespace HockeyEditor
{
    /// <summary>
    /// Contains information about the Puck
    /// </summary>
    public static class Puck
    {
        const int LocationsAddress = 0x07D1C280;
        
        const int PositionOffset = 0x10;
        const int VelocityOffset = 0x4C;
        const int SpinOffset = 0x64;

        /// <summary>
        /// The position of the puck
        /// </summary>
        public static HQMVector position
        {
            get { return MemoryWriter.ReadHQMVector(LocationsAddress + PositionOffset); }
            set { MemoryWriter.WriteHQMVector(value, LocationsAddress + PositionOffset); }
        }

        /// <summary>
        /// The velocity of the puck
        /// </summary>
        public static HQMVector velocity
        {
            get { return MemoryWriter.ReadHQMVector(LocationsAddress + VelocityOffset); }
            set { MemoryWriter.WriteHQMVector(value, LocationsAddress + VelocityOffset); }
        }

        /// <summary>
        /// The spin or rotational velocity of the puck
        /// </summary>
        public static HQMVector spin
        {
            get { return MemoryWriter.ReadHQMVector(LocationsAddress + SpinOffset); }
            set { MemoryWriter.WriteHQMVector(value, LocationsAddress + SpinOffset); }
        }
    }
}
