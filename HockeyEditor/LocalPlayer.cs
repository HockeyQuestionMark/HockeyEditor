using System;

namespace HockeyEditor
{
    /// <summary>
    /// Refers to the player on your client (the player that you control)
    /// </summary>
    public static class LocalPlayer
    {
        const int LocalPlayerSlotOffset = 0x080B62C4;

        const int PlayerListAddress = 0x04A5B860;
        const int Length = 0x98;

        const int InServerOffset = 0x0;
	    const int IdOffset = 0x4;
	    const int TeamOffset = 0x8;
	    const int RoleOffset = 0xC;
	    const int LockoutTimeOffset = 0x10;
        const int NameOffset = 0x14;
        const int StickAngleOffset = 0x54;
        const int TurningOffset = 0x58;
        const int ForwardBackOffset = 0x60;
        const int StickXRotationOffset = 0x64;
        const int StickYRotationOffset = 0x68;
        const int LegStateOffset = 0x74;
        const int HeadXRotationOffset = 0x78;
        const int HeadYRotationOffset = 0x7C;
        const int GoalsOffset = 0x88;
        const int AssistsOffset = 0x8C;

        const int LocationsAddress = 0x07D1C280;
        const int LocationsLength = 0xBD8;

        const int PositionOffset = 0x10;
        const int SinRotationOffset = 0x28;
        const int CosRotationOffset = 0x30;
        const int StickPositionOffset = 0xA0;

        private static int slot
        {
            get { return MemoryWriter.ReadInt(LocalPlayerSlotOffset); }
        }
        
        /// <summary>
        /// Returns true if the player is in the server
        /// </summary>
        public static bool inServer
        {
            get { return MemoryWriter.ReadInt(PlayerListAddress + slot * Length + InServerOffset) == 1; }
        }

        /// <summary>
        /// The player's id, used to get it's location data
        /// </summary>
        public static int id
        {
            get { return MemoryWriter.ReadInt(PlayerListAddress + slot * Length + IdOffset); }
        }

        /// <summary>
        /// The team that the player is on
        /// </summary>
        public static HQMTeam team
        {
            get { return (HQMTeam)MemoryWriter.ReadInt(PlayerListAddress + slot * Length + TeamOffset); }
            set { MemoryWriter.WriteInt((int)value, PlayerListAddress + slot * Length + TeamOffset); }
        }

        /// <summary>
        /// The role that the player is occupying
        /// </summary>
        public static HQMRole role
        {
            get { return (HQMRole)MemoryWriter.ReadInt(PlayerListAddress + slot * Length + RoleOffset); }
            set { MemoryWriter.WriteInt((int)value, PlayerListAddress + slot * Length + RoleOffset); }
        }

        /// <summary>
        /// Time amount of time in hundredths of a second that before the player can change team again
        /// </summary>
        public static int lockoutTime
        {
            get { return MemoryWriter.ReadInt(PlayerListAddress + slot * Length + LockoutTimeOffset); }
        }

        /// <summary>
        /// The name of the player
        /// </summary>
        public static string name
        {
            get { return MemoryWriter.ReadString(PlayerListAddress + slot * Length + NameOffset, 24); }
        }

        /// <summary>
        /// The angle of the player's stick. Ranges from -1 to 1 in increments of 0.25
        /// </summary>
        public static float stickAngle
        {
            get { return MemoryWriter.ReadFloat(PlayerListAddress + slot * Length + StickAngleOffset); }
            set { MemoryWriter.WriteFloat(value, PlayerListAddress + slot * Length + StickAngleOffset); }
        }

        /// <summary>
        /// The direction the player is turning. -1 = Left, 1 = Right, 0 = not turning
        /// </summary>
        public static float turning
        {
            get { return MemoryWriter.ReadFloat(PlayerListAddress + slot * Length + TurningOffset); }
            set { MemoryWriter.WriteFloat(value, PlayerListAddress + slot * Length + TurningOffset); }
        }

        /// <summary>
        /// Whether the player is moving forwards (1), reversing (-1) or not moving (0)
        /// </summary>
        public static float forwardBack
        {
            get { return MemoryWriter.ReadFloat(PlayerListAddress + slot * Length + ForwardBackOffset); }
            set { MemoryWriter.WriteFloat(value, PlayerListAddress + slot * Length + ForwardBackOffset); }
        }

        /// <summary>
        /// The rotation of the stick around the player (in radians). Ranges from -Pi / 2 to Pi / 2
        /// </summary>
        public static float stickXRotation
        {
            get { return MemoryWriter.ReadFloat(PlayerListAddress + slot * Length + StickXRotationOffset); }
            set { MemoryWriter.WriteFloat(value, PlayerListAddress + slot * Length + StickXRotationOffset); }
        }

        /// <summary>
        /// The rotation of the stick away from the player (in radians)
        /// </summary>
        public static float stickYRotation
        {
            get { return MemoryWriter.ReadFloat(PlayerListAddress + slot * Length + StickYRotationOffset); }
            set { MemoryWriter.WriteFloat(value, PlayerListAddress + slot * Length + StickYRotationOffset); }
        }

        /// <summary>
        /// 1 = Jumping, 2 = Crouched, 16 = Stopped with Shift
        /// </summary>
        public static int legState
        {
            get { return MemoryWriter.ReadInt(PlayerListAddress + slot * Length + LegStateOffset); }
            set { MemoryWriter.WriteInt(value, PlayerListAddress + slot * Length + LegStateOffset); }
        }

        /// <summary>
        /// The rotation of the player's head looking left or right
        /// </summary>
        public static float headXRotation
        {
            get { return MemoryWriter.ReadFloat(PlayerListAddress + slot * Length + HeadXRotationOffset); }
            set { MemoryWriter.WriteFloat(value, PlayerListAddress + slot * Length + HeadXRotationOffset); }
        }

        /// <summary>
        /// The rotation of the player's head looking up or down
        /// </summary>
        public static float headYRotation
        {
            get { return MemoryWriter.ReadFloat(PlayerListAddress + slot * Length + HeadYRotationOffset); }
            set { MemoryWriter.WriteFloat(value, PlayerListAddress + slot * Length + HeadYRotationOffset); }
        }

        /// <summary>
        /// The number of goals that the player has scored
        /// </summary>
        public static int goals
        {
            get { return MemoryWriter.ReadInt(PlayerListAddress + slot * Length + GoalsOffset); }
        }

        /// <summary>
        /// The number of assists that the player has got
        /// </summary>
        public static int assists
        {
            get { return MemoryWriter.ReadInt(PlayerListAddress + slot * Length + AssistsOffset); }
        }

        /// <summary>
        /// The player's position
        /// </summary>
        public static HQMVector position
        {
            get { return MemoryWriter.ReadHQMVector(LocationsAddress + id * LocationsLength + PositionOffset); }
        }

        /// <summary>
        /// The Sine of the angle of the direction the player is facing
        /// </summary>
        public static float sinRotation
        {
            get { return MemoryWriter.ReadFloat(LocationsAddress + id * LocationsLength + SinRotationOffset); }
        }

        /// <summary>
        /// The Cosine of the angle of the direction the player is facing
        /// </summary>
        public static float cosRotation
        {
            get { return MemoryWriter.ReadFloat(LocationsAddress + id * LocationsLength + CosRotationOffset); }
        }

        /// <summary>
        /// The position of the player's stick
        /// </summary>
        public static HQMVector stickPosition
        {
            get { return MemoryWriter.ReadHQMVector(LocationsAddress + id * LocationsLength + StickPositionOffset); }
        }
    }
}
