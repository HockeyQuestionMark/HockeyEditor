using System;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace HockeyEditor
{
    public static class MemoryEditor
    {
        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesWritten);

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        private const int PROCESS_ALL_ACCESS = 0x1F0FFF;
        private static Process hockeyProcess = null;
        private static IntPtr hockeyProcessHandle;


        /// <summary>
        /// Attaches to hockey.exe. Must be called before anything else. Make sure hockey is running
        /// </summary>
        /// <param name="launchHockey">Whether to launch the hockey process or not.</param>
        public static void Init(bool isServer)
        {
            try
            {
                hockeyProcess = Process.GetProcessesByName("hockey")[0];
            }
            catch (System.IndexOutOfRangeException e)  // CS0168
            {
                System.Console.WriteLine(e.Message);

                throw new System.ArgumentOutOfRangeException("no hockey.exe found", e);
            }
            hockeyProcessHandle = OpenProcess(PROCESS_ALL_ACCESS, false, hockeyProcess.Id);
        }

        /// <summary>
        /// Read a 32 bit integer from memory.
        /// </summary>
        /// <param name="address">the address to read from</param>
        public static int ReadInt(int address)
        {
            int bytesRead = 0;
            var buffer = new byte[4];
            ReadProcessMemory((int)hockeyProcessHandle, address, buffer, buffer.Length, ref bytesRead);

            return BitConverter.ToInt32(buffer, 0);
        }

        /// <summary>
        /// Write a 32 bit integer to memory.
        /// </summary>
        /// <param name="value">the integer to write</param>
        /// <param name="address">the address to write to</param>
        public static void WriteInt(int value, int address)
        {
            int bytesWritten = 0;
            var buffer = BitConverter.GetBytes(value);

            WriteProcessMemory((int)hockeyProcessHandle, address, buffer, buffer.Length, ref bytesWritten);
        }

        /// <summary>
        /// Read a float from memory.
        /// </summary>
        /// <param name="address">the address to read from</param>
        public static float ReadFloat(int address)
        {
            int bytesRead = 0;
            var buffer = new byte[4];
            ReadProcessMemory((int)hockeyProcessHandle, address, buffer, buffer.Length, ref bytesRead);

            return BitConverter.ToSingle(buffer, 0);
        }

        /// <summary>
        /// Write a float to memory.
        /// </summary>
        /// <param name="value">the float to write</param>
        /// <param name="address">the address to write to</param>
        public static void WriteFloat(float value, int address)
        {
            int bytesWritten = 0;
            var buffer = BitConverter.GetBytes(value);

            WriteProcessMemory((int)hockeyProcessHandle, address, buffer, buffer.Length, ref bytesWritten);
        }

        /// <summary>
        /// Read a string from memory
        /// </summary>
        /// <param name="address">the address to read from</param>
        /// <param name="length">the length of the string to read</param>
        public static string ReadString(int address, int length)
        {
            int bytesRead = 0;
            var buffer = new byte[length];
            ReadProcessMemory((int)hockeyProcessHandle, address, buffer, buffer.Length, ref bytesRead);

            // Read up until a \0 is encounted
            return Encoding.ASCII.GetString(buffer).Split('\0')[0];
        }

        /// <summary>
        /// Writes a Vector3 to memory.
        /// </summary>
        /// <param name="v">float[] representing a Vector3.  x (width) = v[0]. y (height) = v[1], z (length) = v[2]</param>
        /// <param name="address"> The address of the vector to write. Addresses are contained in HQMClientAddresses or HQMServerAddresses</param>
        public static void WriteHQMVector(HQMVector v, int address)
        {         
            int bytesWritten = 0;
            var buffer = new byte[12];
            var posArray = new float[] { v.X, v.Y, v.Z };
            Buffer.BlockCopy(posArray, 0, buffer, 0, buffer.Length);

            WriteProcessMemory((int)hockeyProcessHandle, address, buffer, buffer.Length, ref bytesWritten);
        }

        /// <summary>
        /// Reads a Vector3 from memory
        /// </summary>
        /// <param name="address">The address of the Vector3 to write. . Addresses are contained in HQMClientAddresses or HQMServerAddresses</param>
        /// <returns>float[] representing a Vector3. x (width) = v[0]. y (height) = v[1], z (length) = v[2]</returns>
        public static HQMVector ReadHQMVector(int address)
        {
            int bytesRead = 0;
            byte[] buffer = new byte[12];

            ReadProcessMemory((int)hockeyProcessHandle, address, buffer, buffer.Length, ref bytesRead);

            var posArray = new float[3];
            Buffer.BlockCopy(buffer, 0, posArray, 0, buffer.Length);
            HQMVector v = new HQMVector(posArray[0], posArray[1], posArray[2]);

            return v;
        }
    }
}
