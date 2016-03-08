using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HockeyEditor
{
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

        public static int Slot
        {
            get { return MemoryWriter.ReadInt(LocalPlayerSlotOffset); }
        }
        
        /// <summary>
        /// Returns true if the player is in the server
        /// </summary>
        public static bool InServer
        {
            get { return MemoryWriter.ReadInt(PlayerListAddress + Slot * Length + InServerOffset) == 1; }
        }

        /// <summary>
        /// The player's id, used to get it's location data
        /// </summary>
        public static int ID
        {
            get { return MemoryWriter.ReadInt(PlayerListAddress + Slot * Length + IdOffset); }
        }

        /// <summary>
        /// The team that the player is on
        /// </summary>
        public static HQMTeam Team
        {
            get { return (HQMTeam)MemoryWriter.ReadInt(PlayerListAddress + Slot * Length + TeamOffset); }
            set { MemoryWriter.WriteInt((int)value, PlayerListAddress + Slot * Length + TeamOffset); }
        }

        /// <summary>
        /// The role that the player is occupying
        /// </summary>
        public static HQMRole Role
        {
            get { return (HQMRole)MemoryWriter.ReadInt(PlayerListAddress + Slot * Length + RoleOffset); }
            set { MemoryWriter.WriteInt((int)value, PlayerListAddress + Slot * Length + RoleOffset); }
        }

        /// <summary>
        /// Time amount of time in milliseconds that before the player can change team again
        /// </summary>
        public static int LockoutTime
        {
            get { return MemoryWriter.ReadInt(PlayerListAddress + Slot * Length + LockoutTimeOffset); }
        }

        /// <summary>
        /// The name of the player
        /// </summary>
        public static string Name
        {
            get { return MemoryWriter.ReadString(PlayerListAddress + Slot * Length + NameOffset, 24); }
        }

        /// <summary>
        /// The angle of the player's stick. Ranges from -1 to 1 in increments of 0.25
        /// </summary>
        public static float StickAngle
        {
            get { return MemoryWriter.ReadFloat(PlayerListAddress + Slot * Length + StickAngleOffset); }
            set { MemoryWriter.WriteFloat(value, PlayerListAddress + Slot * Length + StickAngleOffset); }
        }

        /// <summary>
        /// The direction the player is turning. -1 = Left, 1 = Right, 0 = not turning
        /// </summary>
        public static float Turning
        {
            get { return MemoryWriter.ReadFloat(PlayerListAddress + Slot * Length + TurningOffset); }
            set { MemoryWriter.WriteFloat(value, PlayerListAddress + Slot * Length + TurningOffset); }
        }

        /// <summary>
        /// Whether the player is moving forwards (1), reversing (-1) or not moving (0)
        /// </summary>
        public static float ForwardBack
        {
            get { return MemoryWriter.ReadFloat(PlayerListAddress + Slot * Length + ForwardBackOffset); }
            set { MemoryWriter.WriteFloat(value, PlayerListAddress + Slot * Length + ForwardBackOffset); }
        }

        /// <summary>
        /// The rotation of the stick around the player (in radians). Ranges from -Pi / 2 to Pi / 2
        /// </summary>
        public static float StickXRotation
        {
            get { return MemoryWriter.ReadFloat(PlayerListAddress + Slot * Length + StickXRotationOffset); }
            set { MemoryWriter.WriteFloat(value, PlayerListAddress + Slot * Length + StickXRotationOffset); }
        }

        /// <summary>
        /// The rotation of the stick away from the player (in radians)
        /// </summary>
        public static float StickYRotation
        {
            get { return MemoryWriter.ReadFloat(PlayerListAddress + Slot * Length + StickYRotationOffset); }
            set { MemoryWriter.WriteFloat(value, PlayerListAddress + Slot * Length + StickYRotationOffset); }
        }

        /// <summary>
        /// 1 = Jumping, 2 = Crouched, 16 = Stopped with Shift
        /// </summary>
        public static int LegState
        {
            get { return MemoryWriter.ReadInt(PlayerListAddress + Slot * Length + LegStateOffset); }
            set { MemoryWriter.WriteInt(value, PlayerListAddress + Slot * Length + LegStateOffset); }
        }

        /// <summary>
        /// The rotation of the player's head looking left or right
        /// </summary>
        public static float HeadXRotation
        {
            get { return MemoryWriter.ReadFloat(PlayerListAddress + Slot * Length + HeadXRotationOffset); }
            set { MemoryWriter.WriteFloat(value, PlayerListAddress + Slot * Length + HeadXRotationOffset); }
        }

        /// <summary>
        /// The rotation of the player's head looking up or down
        /// </summary>
        public static float HeadYRotation
        {
            get { return MemoryWriter.ReadFloat(PlayerListAddress + Slot * Length + HeadYRotationOffset); }
            set { MemoryWriter.WriteFloat(value, PlayerListAddress + Slot * Length + HeadYRotationOffset); }
        }

        /// <summary>
        /// The number of goals that the player has scored
        /// </summary>
        public static int Goals
        {
            get { return MemoryWriter.ReadInt(PlayerListAddress + Slot * Length + GoalsOffset); }
        }

        /// <summary>
        /// The number of assists that the player has got
        /// </summary>
        public static int Assists
        {
            get { return MemoryWriter.ReadInt(PlayerListAddress + Slot * Length + AssistsOffset); }
        }

        /// <summary>
        /// The player's position
        /// </summary>
        public static HQMVector Position
        {
            get { return MemoryWriter.ReadHQMVector(LocationsAddress + ID * LocationsLength + PositionOffset); }
        }

        /// <summary>
        /// The Sine of the angle of the direction the player is facing
        /// </summary>
        public static float SinRotation
        {
            get { return MemoryWriter.ReadFloat(LocationsAddress + ID * LocationsLength + SinRotationOffset); }
        }

        /// <summary>
        /// The Cosine of the angle of the direction the player is facing
        /// </summary>
        public static float CosRotation
        {
            get { return MemoryWriter.ReadFloat(LocationsAddress + ID * LocationsLength + CosRotationOffset); }
        }

        public static HQMVector StickPosition
        {
            get { return MemoryWriter.ReadHQMVector(LocationsAddress + ID * LocationsLength + StickPositionOffset); }
        }
    }
}
