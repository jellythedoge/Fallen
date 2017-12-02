using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

namespace Memory
{
    internal class MemoryManager
    {
        public static Process m_Process;
        public static IntPtr m_pProcessHandle;

        public static int m_iNumberOfBytesRead = 0;
        public static int m_iNumberOfBytesWritten = 0;

        public static void Initialize(string ProcessName)
        {
            // Check if program.exe is running
            if (Process.GetProcessesByName(ProcessName).Length > 0)
                m_Process = Process.GetProcessesByName(ProcessName)[0];
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Couldn't find " + ProcessName + ", Please start it first!");
                Console.ResetColor();
                Console.ReadKey();
                Environment.Exit(1);
            }
            m_pProcessHandle = OpenProcess(PROCESS_VM_OPERATION | PROCESS_VM_READ | PROCESS_VM_WRITE, false, m_Process.Id); // Sets Our ProcessHandle
        }

        public static int GetModuleAdress(string ModuleName)
        {
            try
            {
                foreach (ProcessModule ProcMod in m_Process.Modules)
                {
                    if (!ModuleName.Contains(".dll"))
                        ModuleName = ModuleName.Insert(ModuleName.Length, ".dll");

                    if (ModuleName == ProcMod.ModuleName)
                    {
                        return (int)ProcMod.BaseAddress;
                    }
                }
            }
            catch { }
            return -1;
        }

        public static T ReadMemory<T>(int address) where T : struct
        {
            int ByteSize = Marshal.SizeOf(typeof(T));

            byte[] buffer = new byte[ByteSize];

            ReadProcessMemory((int)m_pProcessHandle, address, buffer, buffer.Length, ref m_iNumberOfBytesRead);

            return ByteArrayToStructure<T>(buffer);
        }

        public static byte[] ReadMemory(int offset, int size)
        {
            byte[] buffer = new byte[size];

            ReadProcessMemory((int)m_pProcessHandle, offset, buffer, size, ref m_iNumberOfBytesRead);

            return buffer;
        }

        public static float[] ReadMatrix<T>(int Adress, int MatrixSize) where T : struct
        {
            int ByteSize = Marshal.SizeOf(typeof(T));
            byte[] buffer = new byte[ByteSize * MatrixSize]; // Create A Buffer With Size Of ByteSize * MatrixSize
            ReadProcessMemory((int)m_pProcessHandle, Adress, buffer, buffer.Length, ref m_iNumberOfBytesRead);

            return ConvertToFloatArray(buffer); // Transform the ByteArray to A Float Array (PseudoMatrix ;P)
        }

        public static void WriteMemory<T>(int Adress, object Value)
        {
            byte[] buffer = StructureToByteArray(Value); // Transform Data To ByteArray

            WriteProcessMemory((int)m_pProcessHandle, Adress, buffer, buffer.Length, out m_iNumberOfBytesWritten);
        }

        public static void WriteMemory<T>(int Adress, char[] Value)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(Value);

            WriteProcessMemory((int)m_pProcessHandle, Adress, buffer, buffer.Length, out m_iNumberOfBytesWritten);
        }

        //S1ONS SIG SCANNER!
        //I DONT KNOW HOW TO MAKE ONE ,-,
        //

        #region SigScanning

        public static int ScanPattern(int dll, string pattern, int extra, int offset, bool modeSubtract)
        {
            int tempOffset = BitConverter.ToInt32(ReadMemory(AobScan(dll, 0x1800000, pattern, 0) + extra, 4), 0) + offset;

            if (modeSubtract) tempOffset -= dll;

            return tempOffset;
        }

        private static int AobScan(int dll, int range, string signature, int instance)
        {
            if (signature == string.Empty) return -1;

            string tempSignature = Regex.Replace(signature.Replace("??", "3F"), "[^a-fA-F0-9]", "");

            int count = -1;

            byte[] searchRange = new byte[(tempSignature.Length / 2)];

            for (int i = 0; i <= searchRange.Length - 1; i++) searchRange[i] = byte.Parse(tempSignature.Substring(i * 2, 2), NumberStyles.HexNumber);

            byte[] readMemory = ReadMemory(dll, range);

            int temp1 = 0;
            int iEnd = searchRange.Length < 0x20 ? searchRange.Length : 0x20;

            for (int j = 0; j <= iEnd - 1; j++)
            {
                if ((searchRange[j] == 0x3f)) temp1 = (temp1 | (Convert.ToInt32(1) << ((iEnd - j) - 1)));
            }

            int[] sBytes = new int[0x100];

            if ((temp1 != 0))
            {
                for (int k = 0; k <= sBytes.Length - 1; k++) sBytes[k] = temp1;
            }

            temp1 = 1;

            int index = (iEnd - 1);

            while ((index >= 0))
            {
                sBytes[searchRange[index]] = (sBytes[searchRange[index]] | temp1);

                index -= 1;

                temp1 = (temp1 << 1);
            }

            int temp2 = 0;

            while ((temp2 <= (readMemory.Length - searchRange.Length)))
            {
                int last = searchRange.Length;

                temp1 = (searchRange.Length - 1);

                int temp3 = -1;

                while ((temp3 != 0))
                {
                    temp3 = (temp3 & sBytes[readMemory[temp2 + temp1]]);

                    if ((temp3 != 0))
                    {
                        if ((temp1 == 0))
                        {
                            count += 1;

                            if (count == instance) return dll + temp2;

                            temp2 += 2;
                        }

                        last = temp1;
                    }

                    temp1 -= 1;

                    temp3 = (temp3 << 1);
                }

                temp2 += last;
            }

            return -1;
        }

        #endregion SigScanning

        #region Transformation

        public static float[] ConvertToFloatArray(byte[] bytes)
        {
            if (bytes.Length % 4 != 0)
                throw new ArgumentException();

            float[] floats = new float[bytes.Length / 4];

            for (int i = 0; i < floats.Length; i++)
                floats[i] = BitConverter.ToSingle(bytes, i * 4);

            return floats;
        }

        private static T ByteArrayToStructure<T>(byte[] bytes) where T : struct
        {
            var handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            try
            {
                return (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
            }
            finally
            {
                handle.Free();
            }
        }

        private static byte[] StructureToByteArray(object obj)
        {
            int length = Marshal.SizeOf(obj);

            byte[] array = new byte[length];

            IntPtr pointer = Marshal.AllocHGlobal(length);

            Marshal.StructureToPtr(obj, pointer, true);
            Marshal.Copy(pointer, array, 0, length);
            Marshal.FreeHGlobal(pointer);

            return array;
        }

        #endregion Transformation

        #region DllImports

        [DllImport("kernel32.dll")]
        private static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        private static extern bool ReadProcessMemory(int hProcess, int lpBaseAddress, byte[] buffer, int size, ref int lpNumberOfBytesRead);

        [DllImport("kernel32.dll")]
        private static extern bool WriteProcessMemory(int hProcess, int lpBaseAddress, byte[] buffer, int size, out int lpNumberOfBytesWritten);

        #endregion DllImports

        #region Constants

        private const int PROCESS_VM_OPERATION = 0x0008;
        private const int PROCESS_VM_READ = 0x0010;
        private const int PROCESS_VM_WRITE = 0x0020;

        #endregion Constants
    }
}