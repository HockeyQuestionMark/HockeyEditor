using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HockeyEditor
{
    public class HQMVector
    {
        public float X;
        public float Y;
        public float Z;

        public HQMVector(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// The length of the vector
        /// </summary>
        public float Magnitude
        {
            get { return (float)Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z, 2)); }
        }

        /// <summary>
        /// The same vector with a magnitude of 1
        /// </summary>
        public HQMVector Normalized
        {
            get
            {
                float m = Magnitude;
                return new HQMVector(X / m, Y / m, Z / m);
            }
        }

        public static HQMVector operator +(HQMVector left, HQMVector right)
        {
            return new HQMVector(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
        }

        public static HQMVector operator -(HQMVector left, HQMVector right)
        {
            return new HQMVector(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
        }

        public static HQMVector operator *(HQMVector vector, float scale)
        {
            return new HQMVector(vector.X * scale, vector.Y * scale, vector.Z * scale);
        }

        public static HQMVector operator /(HQMVector vector, float scale)
        {
            return new HQMVector(vector.X / scale, vector.Y / scale, vector.Z / scale);
        }

        public static bool operator ==(HQMVector left, HQMVector right)
        {
            return left.X == right.X && left.Y == right.Y && left.Z == right.Z;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator !=(HQMVector left, HQMVector right)
        {
            return !(left == right);
        }

        public override string ToString()
        {
            return X.ToString("F2") + "," + Y.ToString("F2") + "," + Z.ToString("F2");
        }
    }
}
