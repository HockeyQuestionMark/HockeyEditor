using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HockeyEditor
{
    public class Player
    {
        const int PLAYER_LIST_ADDRESS = 0x04A5B860;
        const int PLAYER_STRUCT_SIZE = 0x98;

        const int IN_SERVER_OFFSET = 0x0;
        const int ID_OFFSET = 0x4;
        const int TEAM_OFFSET = 0x8;
        const int ROLE_OFFSET = 0xC;
        const int LOCKOUT_TIME_OFFSET = 0x10;
        const int PLAYER_NAME_OFFSET = 0x14;
        const int STICK_ANGLE_OFFSET = 0x54;
        const int TURNING_OFFSET = 0x58;
        const int FORWARD_BACK_OFFSET = 0x60;
        const int STICK_X_ROTATION_OFFSET = 0x64;
        const int STICK_Y_ROTATION_OFFSET = 0x68;
        const int LEG_STATE_OFFSET = 0x74;
        const int HEAD_X_ROTATION_OFFSET = 0x78;
        const int HEAD_Y_ROTATION_OFFSET = 0x7C;
        const int GOALS_OFFSET = 0x88;
        const int ASSISTS_OFFSET = 0x8C;

        const int PLAYER_TRANSFORM_LIST_ADDRESS = 0x07D1C280;
        const int PLAYER_TRANSFORM_SIZE = 0xBD8;

        const int PLAYER_POSITION_OFFSET = 0x10;
        const int PLAYER_SIN_ROTATION_OFFSET = 0x28;
        const int PLAYER_COS_ROTATION_OFFSET = 0x30;
        const int STICK_POSITION_OFFSET = 0xA0;

        private int m_Slot;

        /// <summary>
        /// Creates a new Player object using the specified server slot
        /// </summary>
        /// <param name="slot">The slot in the server list (0 based)</param>
        internal Player(int slot)
        {
            this.m_Slot = slot;
        }

        /// <summary>
        /// Returns true if the player is in the server
        /// </summary>
        public bool InServer
        {
            get { return MemoryEditor.ReadInt(PLAYER_LIST_ADDRESS + m_Slot * PLAYER_STRUCT_SIZE + IN_SERVER_OFFSET) == 1; }
        }

        /// <summary>
        /// The player's id, used to get it's location data
        /// </summary>
        public int ID
        {
            get { return MemoryEditor.ReadInt(PLAYER_LIST_ADDRESS + m_Slot * PLAYER_STRUCT_SIZE + ID_OFFSET); }
        }

        /// <summary>
        /// The team that the player is on
        /// </summary>
        public HQMTeam Team
        {
            get { return (HQMTeam)MemoryEditor.ReadInt(PLAYER_LIST_ADDRESS + m_Slot * PLAYER_STRUCT_SIZE + TEAM_OFFSET); }
            set { MemoryEditor.WriteInt((int)value, PLAYER_LIST_ADDRESS + m_Slot * PLAYER_STRUCT_SIZE + TEAM_OFFSET); }
        }

        /// <summary>
        /// The role that the player is occupying
        /// </summary>
        public HQMRole Role
        {
            get { return (HQMRole)MemoryEditor.ReadInt(PLAYER_LIST_ADDRESS + m_Slot * PLAYER_STRUCT_SIZE + ROLE_OFFSET); }
            set { MemoryEditor.WriteInt((int)value, PLAYER_LIST_ADDRESS + m_Slot * PLAYER_STRUCT_SIZE + ROLE_OFFSET); }
        }

        /// <summary>
        /// Time amount of time in hundredths of a second that before the player can change team again
        /// </summary>
        public int LockoutTime
        {
            get { return MemoryEditor.ReadInt(PLAYER_LIST_ADDRESS + m_Slot * PLAYER_STRUCT_SIZE + LOCKOUT_TIME_OFFSET); }
        }

        /// <summary>
        /// The name of the player
        /// </summary>
        public string Name
        {
            get { return MemoryEditor.ReadString(PLAYER_LIST_ADDRESS + m_Slot * PLAYER_STRUCT_SIZE + PLAYER_NAME_OFFSET, 24); }
        }

        /// <summary>
        /// The angle of the player's stick. Ranges from -1 to 1 in increments of 0.25
        /// </summary>
        public float StickAngle
        {
            get { return MemoryEditor.ReadFloat(PLAYER_LIST_ADDRESS + m_Slot * PLAYER_STRUCT_SIZE + STICK_ANGLE_OFFSET); }
            set { MemoryEditor.WriteFloat(value, PLAYER_LIST_ADDRESS + m_Slot * PLAYER_STRUCT_SIZE + STICK_ANGLE_OFFSET); }
        }

        /// <summary>
        /// The direction the player is turning. -1 = Left, 1 = Right, 0 = not turning
        /// </summary>
        public float Turning
        {
            get { return MemoryEditor.ReadFloat(PLAYER_LIST_ADDRESS + m_Slot * PLAYER_STRUCT_SIZE + TURNING_OFFSET); }
            set { MemoryEditor.WriteFloat(value, PLAYER_LIST_ADDRESS + m_Slot * PLAYER_STRUCT_SIZE + TURNING_OFFSET); }
        }

        /// <summary>
        /// Whether the player is moving forwards (1), reversing (-1) or not moving (0)
        /// </summary>
        public float ForwardBack
        {
            get { return MemoryEditor.ReadFloat(PLAYER_LIST_ADDRESS + m_Slot * PLAYER_STRUCT_SIZE + FORWARD_BACK_OFFSET); }
            set { MemoryEditor.WriteFloat(value, PLAYER_LIST_ADDRESS + m_Slot * PLAYER_STRUCT_SIZE + FORWARD_BACK_OFFSET); }
        }

        /// <summary>
        /// The rotation of the stick around the player (in radians). Ranges from -Pi / 2 to Pi / 2
        /// </summary>
        public float StickXRotation
        {
            get { return MemoryEditor.ReadFloat(PLAYER_LIST_ADDRESS + m_Slot * PLAYER_STRUCT_SIZE + STICK_X_ROTATION_OFFSET); }
            set { MemoryEditor.WriteFloat(value, PLAYER_LIST_ADDRESS + m_Slot * PLAYER_STRUCT_SIZE + STICK_X_ROTATION_OFFSET); }
        }

        /// <summary>
        /// The rotation of the stick away from the player (in radians)
        /// </summary>
        public float StickYRotation
        {
            get { return MemoryEditor.ReadFloat(PLAYER_LIST_ADDRESS + m_Slot * PLAYER_STRUCT_SIZE + STICK_Y_ROTATION_OFFSET); }
            set { MemoryEditor.WriteFloat(value, PLAYER_LIST_ADDRESS + m_Slot * PLAYER_STRUCT_SIZE + STICK_Y_ROTATION_OFFSET); }
        }

        /// <summary>
        /// 1 = Jumping, 2 = Crouched, 16 = Stopped with Shift
        /// </summary>
        public int LegState
        {
            get { return MemoryEditor.ReadInt(PLAYER_LIST_ADDRESS + m_Slot * PLAYER_STRUCT_SIZE + LEG_STATE_OFFSET); }
            set { MemoryEditor.WriteInt(value, PLAYER_LIST_ADDRESS + m_Slot * PLAYER_STRUCT_SIZE + LEG_STATE_OFFSET); }
        }

        /// <summary>
        /// The rotation of the player's head looking left or right
        /// </summary>
        public float HeadXRotation
        {
            get { return MemoryEditor.ReadFloat(PLAYER_LIST_ADDRESS + m_Slot * PLAYER_STRUCT_SIZE + HEAD_X_ROTATION_OFFSET); }
            set { MemoryEditor.WriteFloat(value, PLAYER_LIST_ADDRESS + m_Slot * PLAYER_STRUCT_SIZE + HEAD_X_ROTATION_OFFSET); }
        }

        /// <summary>
        /// The rotation of the player's head looking up or down
        /// </summary>
        public float HeadYRotation
        {
            get { return MemoryEditor.ReadFloat(PLAYER_LIST_ADDRESS + m_Slot * PLAYER_STRUCT_SIZE + HEAD_Y_ROTATION_OFFSET); }
            set { MemoryEditor.WriteFloat(value, PLAYER_LIST_ADDRESS + m_Slot * PLAYER_STRUCT_SIZE + HEAD_Y_ROTATION_OFFSET); }
        }

        /// <summary>
        /// The number of goals that the player has scored
        /// </summary>
        public int Goals
        {
            get { return MemoryEditor.ReadInt(PLAYER_LIST_ADDRESS + m_Slot * PLAYER_STRUCT_SIZE + GOALS_OFFSET); }
        }

        /// <summary>
        /// The number of assists that the player has got
        /// </summary>
        public int Assists
        {
            get { return MemoryEditor.ReadInt(PLAYER_LIST_ADDRESS + m_Slot * PLAYER_STRUCT_SIZE + ASSISTS_OFFSET); }
        }

        /// <summary>
        /// The player's position
        /// </summary>
        public HQMVector Position
        {
            get { return MemoryEditor.ReadHQMVector(PLAYER_TRANSFORM_LIST_ADDRESS + ID * PLAYER_TRANSFORM_SIZE + PLAYER_POSITION_OFFSET); }
        }

        /// <summary>
        /// The Sine of the angle of the direction the player is facing
        /// </summary>
        public float SinRotation
        {
            get { return MemoryEditor.ReadFloat(PLAYER_TRANSFORM_LIST_ADDRESS + ID * PLAYER_TRANSFORM_SIZE + PLAYER_SIN_ROTATION_OFFSET); }
        }

        /// <summary>
        /// The Cosine of the angle of the direction the player is facing
        /// </summary>
        public float CosRotation
        {
            get { return MemoryEditor.ReadFloat(PLAYER_TRANSFORM_LIST_ADDRESS + ID * PLAYER_TRANSFORM_SIZE + PLAYER_COS_ROTATION_OFFSET); }
        }

        /// <summary>
        /// The position of the player's stick
        /// </summary>
        public HQMVector StickPosition
        {
            get { return MemoryEditor.ReadHQMVector(PLAYER_TRANSFORM_LIST_ADDRESS + ID * PLAYER_TRANSFORM_SIZE + STICK_POSITION_OFFSET); }
        }
    }

    public enum HQMRole
    {
        C = 0,
        LD = 1,
        RD = 2,
        LW = 3,
        RW = 4,
        G = 5
    }

    public enum HQMTeam
    {
        NoTeam = -1,
        Red = 0,
        Blue = 1
    }
}
