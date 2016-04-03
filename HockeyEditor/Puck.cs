namespace HockeyEditor
{
    /// <summary>
    /// Contains information about the Puck
    /// </summary>
    public static class Puck
    {
        const int PUCK_TRANSFORM_ADDRESS = 0x07D1C280;
        const int PUCK_POSITION_OFFSET = 0x10;
        const int PUCK_VELOCITY_OFFSET = 0x4C;
        const int PUCK_ROTATIONAL_VELOCITY_OFFSET = 0x64;
        /// <summary>
        /// The position of the puck
        /// </summary>
        public static HQMVector Position
        {
            get { return MemoryEditor.ReadHQMVector(PUCK_TRANSFORM_ADDRESS + PUCK_POSITION_OFFSET); }
            set { MemoryEditor.WriteHQMVector(value, PUCK_TRANSFORM_ADDRESS + PUCK_POSITION_OFFSET); }
        }

        /// <summary>
        /// The velocity of the puck
        /// </summary>
        public static HQMVector Velocity
        {
            get { return MemoryEditor.ReadHQMVector(PUCK_TRANSFORM_ADDRESS + PUCK_VELOCITY_OFFSET); }
            set { MemoryEditor.WriteHQMVector(value, PUCK_TRANSFORM_ADDRESS + PUCK_VELOCITY_OFFSET); }
        }

        /// <summary>
        /// The spin or rotational velocity of the puck
        /// </summary>
        public static HQMVector RotationalVelocity
        {
            get { return MemoryEditor.ReadHQMVector(PUCK_TRANSFORM_ADDRESS + PUCK_ROTATIONAL_VELOCITY_OFFSET); }
            set { MemoryEditor.WriteHQMVector(value, PUCK_TRANSFORM_ADDRESS + PUCK_ROTATIONAL_VELOCITY_OFFSET); }
        }
    }
}
