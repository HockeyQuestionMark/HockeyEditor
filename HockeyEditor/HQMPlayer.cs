using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HockeyEditor
{
    public class HQMPlayer
    {
        public bool InServer;
        public bool Spectating;
        public HQMTeam Team;
        public HQMRole Role; //their position on the team; center, leftwing etc
        public string Name;
        public float StickRotation;
        public HQMVector StickPosition;
        public HQMVector Position;
        public int Goals;
        public int Assists;
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
