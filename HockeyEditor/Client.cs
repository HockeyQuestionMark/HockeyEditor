using System;
using System.Linq;


namespace HockeyEditor
{
    public static class Client
    {
        public static float[] PuckPosition
        {
            get { return MemoryWriter.ReadVector3(HQMClientAddresses.PUCK_POS); }
            set { if (value.Length == 3) MemoryWriter.WriteVector3(value, HQMClientAddresses.PUCK_POS); }
        }

        public static float[] PuckVelocity
        {
            get { return MemoryWriter.ReadVector3(HQMClientAddresses.PUCK_VELOCITY); }
            set { if (value.Length == 3) MemoryWriter.WriteVector3(value, HQMClientAddresses.PUCK_VELOCITY); }
        }

        public static float[] PuckRotationalVelocity
        {
            get { return MemoryWriter.ReadVector3(HQMClientAddresses.PUCK_ROT_VELOCITY); }
            set { if (value.Length == 3) MemoryWriter.WriteVector3(value, HQMClientAddresses.PUCK_ROT_VELOCITY); }
        }

        public static float[] PlayerPosition
        {
            get { return MemoryWriter.ReadVector3(HQMClientAddresses.PLAYER_POS); }
            //set { if (value.Length == 3) WriteVector3(value, HQMClientAddresses.PLAYER_POS); }
        }

        public static float[] PlayerStickPosition
        {
            get { return MemoryWriter.ReadVector3(HQMClientAddresses.PLAYER_STICK_POS); }
            //set { if (value.Length == 3) MemoryWriter.WriteVector3(value, HQMClientAddresses.PLAYER_STICK_POS); }
        }            

        public static class HQMClientAddresses
        {
            public const int PUCK_POS = 0x07D1C290;
            public const int PUCK_VELOCITY = 0x07D1C2CC;
            public const int PUCK_ROT_VELOCITY = 0x07D1C2E4;
            public const int PLAYER_POS = 0x04C25258;
            public const int PLAYER_STICK_POS = 0X07D1CEF8;
        }
    }

      

    
}
