namespace HockeyEditor
{
    /// <summary>
    /// Contains information about the 2 goals' positions
    /// </summary>
    public class Net
    {
        const int BLUE_NET_ADDRESS = 0x07125FB4;
        const int RED_NET_ADDRESS = 0x07126014;

        const int RIGHT_FRONT_BOTTOM_OFFSET = 0x0;
        const int LEFT_FRONT_BOTTOM_OFFSET = 0xC;
        const int LEFT_BACK_BOTTOM_OFFSET = 0x18;
        const int RIGHT_BACK_BOTTOM_OFFSET = 0x24;

        const int RIGHT_FRONT_TOP_OFFSET = 0x30;
        const int LEFT_FRONT_TOP_OFFSET = 0x3C;
        const int LEFT_BACK_TOP_OFFSET = 0x48;
        const int RIGHT_BACK_TOP_OFFSET = 0x54;

        public static class RedDefaultPositions
        {
            public static readonly HQMVector RIGHT_FRONT_BOTTOM = new HQMVector(13.5f, 0, 57);
            public static readonly HQMVector LEFT_FRONT_BOTTOM = new HQMVector(16.5f, 0, 57);
            public static readonly HQMVector LEFT_BACK_BOTTOM = new HQMVector(16.25f, 0, 58);
            public static readonly HQMVector RIGHT_BACK_BOTTOM = new HQMVector(13.75f, 0, 58);
            public static readonly HQMVector RIGHT_FRONT_TOP = new HQMVector(13.5f, 1, 57);
            public static readonly HQMVector LEFT_FRONT_TOP = new HQMVector(16.5f, 1, 57);
            public static readonly HQMVector LEFT_BACK_TOP = new HQMVector(16.25f, 1, 57.75f);
            public static readonly HQMVector RIGHT_BACK_TOP = new HQMVector(13.75f, 1, 57.75f);
        }

        public static class BlueDefaultPositions
        {
            public static readonly HQMVector RIGHT_FRONT_BOTTOM = new HQMVector(16.5f, 0, 4);
            public static readonly HQMVector LEFT_FRONT_BOTTOM = new HQMVector(13.5f, 0, 4);
            public static readonly HQMVector LEFT_BACK_BOTTOM = new HQMVector(13.75f, 0, 3);
            public static readonly HQMVector RIGHT_BACK_BOTTOM = new HQMVector(16.25f, 0, 3);
            public static readonly HQMVector RIGHT_FRONT_TOP = new HQMVector(16.5f, 1, 4);
            public static readonly HQMVector LEFT_FRONT_TOP = new HQMVector(13.5f, 1, 4);
            public static readonly HQMVector LEFT_BACK_TOP = new HQMVector(13.75f, 1, 3.25f);
            public static readonly HQMVector RIGHT_BACK_TOP = new HQMVector(16.25f, 1, 3.25f);
        }

        private int m_BaseAddress;

        private Net(int baseAddress)
        {
            m_BaseAddress = baseAddress;
        }

        public HQMVector RightFrontBottom
        {
            get { return MemoryEditor.ReadHQMVector(m_BaseAddress + RIGHT_FRONT_BOTTOM_OFFSET); }
            set { MemoryEditor.WriteHQMVector(value, m_BaseAddress + RIGHT_FRONT_BOTTOM_OFFSET); }
        }

        public HQMVector LeftFrontBottom
        {
            get { return MemoryEditor.ReadHQMVector(m_BaseAddress + LEFT_FRONT_BOTTOM_OFFSET); }
            set { MemoryEditor.WriteHQMVector(value, m_BaseAddress + LEFT_FRONT_BOTTOM_OFFSET); }
        }

        public HQMVector LeftBackBottom
        {
            get { return MemoryEditor.ReadHQMVector(m_BaseAddress + LEFT_BACK_BOTTOM_OFFSET); }
            set { MemoryEditor.WriteHQMVector(value, m_BaseAddress + LEFT_BACK_BOTTOM_OFFSET); }
        }

        public HQMVector RightBackBottom
        {
            get { return MemoryEditor.ReadHQMVector(m_BaseAddress + RIGHT_BACK_BOTTOM_OFFSET); }
            set { MemoryEditor.WriteHQMVector(value, m_BaseAddress + RIGHT_BACK_BOTTOM_OFFSET); }
        }

        public HQMVector RightFrontTop
        {
            get { return MemoryEditor.ReadHQMVector(m_BaseAddress + RIGHT_FRONT_TOP_OFFSET); }
            set { MemoryEditor.WriteHQMVector(value, m_BaseAddress + RIGHT_FRONT_TOP_OFFSET); }
        }

        public HQMVector LeftFrontTop
        {
            get { return MemoryEditor.ReadHQMVector(m_BaseAddress + LEFT_FRONT_TOP_OFFSET); }
            set { MemoryEditor.WriteHQMVector(value, m_BaseAddress + LEFT_FRONT_TOP_OFFSET); }
        }

        public HQMVector LeftBackTop
        {
            get { return MemoryEditor.ReadHQMVector(m_BaseAddress + LEFT_BACK_TOP_OFFSET); }
            set { MemoryEditor.WriteHQMVector(value, m_BaseAddress + LEFT_BACK_TOP_OFFSET); }
        }

        public HQMVector RightBackTop
        {
            get { return MemoryEditor.ReadHQMVector(m_BaseAddress + RIGHT_BACK_TOP_OFFSET); }
            set { MemoryEditor.WriteHQMVector(value, m_BaseAddress + RIGHT_BACK_TOP_OFFSET); }
        }

        /// <summary>
        /// Reset the net to its default position
        /// </summary>
        public void Reset()
        {
            if (m_BaseAddress == RED_NET_ADDRESS)
            {
                RightFrontBottom = RedDefaultPositions.RIGHT_FRONT_BOTTOM;
                LeftFrontBottom = RedDefaultPositions.LEFT_FRONT_BOTTOM;
                LeftBackBottom = RedDefaultPositions.LEFT_BACK_BOTTOM;
                RightBackBottom = RedDefaultPositions.RIGHT_BACK_BOTTOM;
                RightFrontTop = RedDefaultPositions.RIGHT_FRONT_TOP;
                LeftFrontTop = RedDefaultPositions.LEFT_FRONT_TOP;
                LeftBackTop = RedDefaultPositions.LEFT_BACK_TOP;
                RightBackTop = RedDefaultPositions.RIGHT_BACK_TOP;
            }
            else if (m_BaseAddress == BLUE_NET_ADDRESS)
            {
                RightFrontBottom = BlueDefaultPositions.RIGHT_FRONT_BOTTOM;
                LeftFrontBottom = BlueDefaultPositions.LEFT_FRONT_BOTTOM;
                LeftBackBottom = BlueDefaultPositions.LEFT_BACK_BOTTOM;
                RightBackBottom = BlueDefaultPositions.RIGHT_BACK_BOTTOM;
                RightFrontTop = BlueDefaultPositions.RIGHT_FRONT_TOP;
                LeftFrontTop = BlueDefaultPositions.LEFT_FRONT_TOP;
                LeftBackTop = BlueDefaultPositions.LEFT_BACK_TOP;
                RightBackTop = BlueDefaultPositions.RIGHT_BACK_TOP;
            }
        }

        /// <summary>
        /// Translates the whole net by the given vector
        /// </summary>
        /// <param name="translation">The vector to translate</param>
        public void Translate(HQMVector translation)
        {
            RightFrontBottom += translation;
            LeftFrontBottom += translation;
            LeftBackBottom += translation;
            RightBackBottom += translation;
            RightFrontTop += translation;
            LeftFrontTop += translation;
            LeftBackTop += translation;
            RightBackTop += translation;
        }

        public static Net RedNet
        {
            get { return new Net(RED_NET_ADDRESS); }
        }

        public static Net BlueNet
        {
            get { return new Net(BLUE_NET_ADDRESS); }
        }

    }
}
