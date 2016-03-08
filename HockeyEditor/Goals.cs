using System;

namespace HockeyEditor
{
    /// <summary>
    /// Contains information about the 2 goals' positions
    /// </summary>
    public static class Goals
    {
        const int BlueGoalAddress = 0x07125FB4;
        const int RedGoalAddress = 0x07126014;

        const int RightFrontBottomOffset = 0x0;
        const int LeftFrontBottomOffset =  0xC;
        const int LeftBackBottomOffset =  0x18;
        const int RightBacktBottomOffset = 0x24;

        const int RightFrontTopOffset = 0x30;
        const int LeftFrontTopOffset = 0x3C;
        const int LeftBackTopOffset = 0x48;
        const int RightBackTopOffset = 0x54;

        /// <summary>
        /// The red goal
        /// </summary>
        public static class Red
        {
            public static void Reset()
            {
                rightFrontBottom = defaults[0];
                leftFrontBottom = defaults[1];
                leftBackBottom = defaults[2];
                rightBackBottom = defaults[3];
                rightFrontTop = defaults[4];
                leftFrontTop = defaults[5];
                leftBackTop = defaults[6];
                rightBackTop = defaults[7];
            }

            /// <summary>
            /// Translates the whole goals by the given vector
            /// </summary>
            /// <param name="translation">The vector to translate</param>
            public static void Translate(HQMVector translation)
            {
                rightFrontBottom += translation;
                leftFrontBottom += translation;
                leftBackBottom += translation;
                rightBackBottom += translation;
                rightFrontTop += translation;
                leftFrontTop += translation;
                leftBackTop += translation;
                rightBackTop += translation;
            }

            private static HQMVector[] defaults = new HQMVector[]
            {
                new HQMVector(13.5f, 0, 57),
                new HQMVector(16.5f, 0, 57),
                new HQMVector(16.25f, 0, 58),
                new HQMVector(13.75f, 0, 58),
                new HQMVector(13.5f, 1, 57),
                new HQMVector(16.5f, 1, 57),
                new HQMVector(16.25f, 1, 57.75f),
                new HQMVector(13.75f, 1, 57.75f)
            };
            
            public static HQMVector rightFrontBottom
            {
                get { return MemoryWriter.ReadHQMVector(RedGoalAddress + RightFrontBottomOffset); }
                set { MemoryWriter.WriteHQMVector(value, RedGoalAddress + RightFrontBottomOffset); }
            }

            public static HQMVector leftFrontBottom
            {
                get { return MemoryWriter.ReadHQMVector(RedGoalAddress + LeftFrontBottomOffset); }
                set { MemoryWriter.WriteHQMVector(value, RedGoalAddress + LeftFrontBottomOffset); }
            }

            public static HQMVector leftBackBottom
            {
                get { return MemoryWriter.ReadHQMVector(RedGoalAddress + LeftBackBottomOffset); }
                set { MemoryWriter.WriteHQMVector(value, RedGoalAddress + LeftBackBottomOffset); }
            }

            public static HQMVector rightBackBottom
            {
                get { return MemoryWriter.ReadHQMVector(RedGoalAddress + RightBacktBottomOffset); }
                set { MemoryWriter.WriteHQMVector(value, RedGoalAddress + RightBacktBottomOffset); }
            }

            public static HQMVector rightFrontTop
            {
                get { return MemoryWriter.ReadHQMVector(RedGoalAddress + RightFrontTopOffset); }
                set { MemoryWriter.WriteHQMVector(value, RedGoalAddress + RightFrontTopOffset); }
            }

            public static HQMVector leftFrontTop
            {
                get { return MemoryWriter.ReadHQMVector(RedGoalAddress + LeftFrontTopOffset); }
                set { MemoryWriter.WriteHQMVector(value, RedGoalAddress + LeftFrontTopOffset); }
            }

            public static HQMVector leftBackTop
            {
                get { return MemoryWriter.ReadHQMVector(RedGoalAddress + LeftBackTopOffset); }
                set { MemoryWriter.WriteHQMVector(value, RedGoalAddress + LeftBackTopOffset); }
            }

            public static HQMVector rightBackTop
            {
                get { return MemoryWriter.ReadHQMVector(RedGoalAddress + RightBackTopOffset); }
                set { MemoryWriter.WriteHQMVector(value, RedGoalAddress + RightBackTopOffset); }
            }
        }

        /// <summary>
        /// The blue goal
        /// </summary>
        public static class Blue
        {
            /// <summary>
            /// Resets the goal posts to the default position
            /// </summary>
            public static void Reset()
            {
                rightFrontBottom = defaults[0];
                leftFrontBottom = defaults[1];
                leftBackBottom = defaults[2];
                rightBackBottom = defaults[3];
                rightFrontTop = defaults[4];
                leftFrontTop = defaults[5];
                leftBackTop = defaults[6];
                rightBackTop = defaults[7];
            }

            /// <summary>
            /// Translates the whole goals by the given vector
            /// </summary>
            /// <param name="translation">The vector to translate</param>
            public static void Translate(HQMVector translation)
            {
                rightFrontBottom += translation;
                leftFrontBottom += translation;
                leftBackBottom += translation;
                rightBackBottom += translation;
                rightFrontTop += translation;
                leftFrontTop += translation;
                leftBackTop += translation;
                rightBackTop += translation;
            }

            private static HQMVector[] defaults = new HQMVector[]
            {
                new HQMVector(16.5f, 0, 4),
                new HQMVector(13.5f, 0, 4),
                new HQMVector(13.75f, 0, 3),
                new HQMVector(16.25f, 0, 3),
                new HQMVector(16.5f, 1, 4),
                new HQMVector(13.5f, 1, 4),
                new HQMVector(13.75f, 1, 3.25f),
                new HQMVector(16.25f, 1, 3.25f)
            };
            
            public static HQMVector rightFrontBottom
            {
                get { return MemoryWriter.ReadHQMVector(BlueGoalAddress + RightFrontBottomOffset); }
                set { MemoryWriter.WriteHQMVector(value, BlueGoalAddress + RightFrontBottomOffset); }
            }

            public static HQMVector leftFrontBottom
            {
                get { return MemoryWriter.ReadHQMVector(BlueGoalAddress + LeftFrontBottomOffset); }
                set { MemoryWriter.WriteHQMVector(value, BlueGoalAddress + LeftFrontBottomOffset); }
            }

            public static HQMVector leftBackBottom
            {
                get { return MemoryWriter.ReadHQMVector(BlueGoalAddress + LeftBackBottomOffset); }
                set { MemoryWriter.WriteHQMVector(value, BlueGoalAddress + LeftBackBottomOffset); }
            }

            public static HQMVector rightBackBottom
            {
                get { return MemoryWriter.ReadHQMVector(BlueGoalAddress + RightBacktBottomOffset); }
                set { MemoryWriter.WriteHQMVector(value, BlueGoalAddress + RightBacktBottomOffset); }
            }

            public static HQMVector rightFrontTop
            {
                get { return MemoryWriter.ReadHQMVector(BlueGoalAddress + RightFrontTopOffset); }
                set { MemoryWriter.WriteHQMVector(value, BlueGoalAddress + RightFrontTopOffset); }
            }

            public static HQMVector leftFrontTop
            {
                get { return MemoryWriter.ReadHQMVector(BlueGoalAddress + LeftFrontTopOffset); }
                set { MemoryWriter.WriteHQMVector(value, BlueGoalAddress + LeftFrontTopOffset); }
            }

            public static HQMVector leftBackTop
            {
                get { return MemoryWriter.ReadHQMVector(BlueGoalAddress + LeftBackTopOffset); }
                set { MemoryWriter.WriteHQMVector(value, BlueGoalAddress + LeftBackTopOffset); }
            }

            public static HQMVector rightBackTop
            {
                get { return MemoryWriter.ReadHQMVector(BlueGoalAddress + RightBackTopOffset); }
                set { MemoryWriter.WriteHQMVector(value, BlueGoalAddress + RightBackTopOffset); }
            }
        }
    }
}
