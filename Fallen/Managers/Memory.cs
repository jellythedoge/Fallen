#region

using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

#endregion

namespace Fallen.Managers
{
    internal class Memory
    {
        static Process m_iProcess;
        static IntPtr m_iProcessHandle;

        static int m_iBytesWritten;
        static int m_iBytesRead;

        public static void Initialize(string processName)
        {
            if (Process.GetProcessesByName(processName).Length > 0)
            {
                m_iProcess = Process.GetProcessesByName(processName)[0];
                m_iProcessHandle = Imports.OpenProcess(Flags.PROCESS_VM_OPERATION | Flags.PROCESS_VM_READ | Flags.PROCESS_VM_WRITE, false, m_iProcess.Id);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: Cannot find - " + processName + " | Check ProcessName.");
                Console.ResetColor();
                Console.ReadKey();
                Environment.Exit(0);
            }
        }

        public static void WriteMemory<T>(int Address, object Value)
        {
            byte[] buffer = StructureToByteArray(Value);

            Imports.WriteProcessMemory((int)m_iProcessHandle, Address, buffer, buffer.Length, out m_iBytesWritten);
        }

        public static void WriteMemory<T>(int Adress, char[] Value)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(Value);

            Imports.WriteProcessMemory((int)m_iProcessHandle, Adress, buffer, buffer.Length, out m_iBytesWritten);
        }

        public static T ReadMemory<T>(int address) where T : struct
        {
            var ByteSize = Marshal.SizeOf(typeof(T));

            byte[] buffer = new byte[ByteSize];

            Imports.ReadProcessMemory((int)m_iProcessHandle, address, buffer, buffer.Length, ref m_iBytesRead);

            return ByteArrayToStructure<T>(buffer);
        }

        public static byte[] ReadMemory(int offset, int size)
        {
            byte[] buffer = new byte[size];

            Imports.ReadProcessMemory((int)m_iProcessHandle, offset, buffer, size, ref m_iBytesRead);

            return buffer;
        }

        public static float[] ReadMatrix<T>(int Adress, int MatrixSize) where T : struct
        {
            var ByteSize = Marshal.SizeOf(typeof(T));
            byte[] buffer = new byte[ByteSize * MatrixSize];
            Imports.ReadProcessMemory((int)m_iProcessHandle, Adress, buffer, buffer.Length, ref m_iBytesRead);

            return ConvertToFloatArray(buffer);
        }

        public static int GetModuleAddress(string Name)
        {
            try
            {
                foreach (ProcessModule ProcMod in m_iProcess.Modules)
                {
                    if (Name == ProcMod.ModuleName)
                    {
                        return (int)ProcMod.BaseAddress;
                    }
                }
            }
            catch
            {
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ERROR: Cannot find - " + Name + " | Check file extension.");
            Console.ResetColor();

            return -1;
        }

        #region SigScanning

        public static int ScanPattern(int dll, string pattern, int offset, int extra, bool modeSubtract)
        {
            var tempOffset = BitConverter.ToInt32(ReadMemory(AobScan(dll, 0x1800000, pattern, 0) + offset, 4), 0) + extra;

            if (modeSubtract) tempOffset -= dll;

            return tempOffset;
        }

        internal static object ReadMemory<T>(object p)
        {
            throw new NotImplementedException();
        }

        static int AobScan(int dll, int range, string signature, int instance)
        {
            if (signature == string.Empty) return -1;

            var tempSignature = Regex.Replace(Regex.Replace(signature, @"\?+", "3F"), @"[^a-fA-F0-9]", "");

            var count = -1;

            byte[] searchRange = new byte[(tempSignature.Length / 2)];

            for (int i = 0; i <= searchRange.Length - 1; i++) searchRange[i] = byte.Parse(tempSignature.Substring(i * 2, 2), NumberStyles.HexNumber);

            byte[] readMemory = ReadMemory(dll, range);

            var temp1 = 0;
            var iEnd = searchRange.Length < 0x20 ? searchRange.Length : 0x20;

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

            var index = (iEnd - 1);

            while ((index >= 0))
            {
                sBytes[searchRange[index]] = (sBytes[searchRange[index]] | temp1);

                index -= 1;

                temp1 = (temp1 << 1);
            }

            var temp2 = 0;

            while ((temp2 <= (readMemory.Length - searchRange.Length)))
            {
                var last = searchRange.Length;

                temp1 = (searchRange.Length - 1);

                var temp3 = -1;

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

        #region Conversion

        public static float[] ConvertToFloatArray(byte[] bytes)
        {
            if (bytes.Length % 4 != 0)
                throw new ArgumentException();

            float[] floats = new float[bytes.Length / 4];

            for (var i = 0; i < floats.Length; i++)
                floats[i] = BitConverter.ToSingle(bytes, i * 4);

            return floats;
        }

        static T ByteArrayToStructure<T>(byte[] bytes) where T : struct
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

        static byte[] StructureToByteArray(object obj)
        {
            var length = Marshal.SizeOf(obj);

            byte[] array = new byte[length];

            var pointer = Marshal.AllocHGlobal(length);

            Marshal.StructureToPtr(obj, pointer, true);
            Marshal.Copy(pointer, array, 0, length);
            Marshal.FreeHGlobal(pointer);

            return array;
        }

        #endregion

        #region Other

        internal struct Flags
        {
            public const int PROCESS_VM_OPERATION = 0x0008;
            public const int PROCESS_VM_READ = 0x0010;
            public const int PROCESS_VM_WRITE = 0x0020;
        }

        internal class Imports
        {
            [DllImport("kernel32.dll")]
            public static extern IntPtr OpenProcess(int DesiredAccess, bool InheritHandle, int m_iProcessID);

            [DllImport("kernel32.dll")]
            public static extern bool ReadProcessMemory(int h_Process, int BaseAddress, byte[] buffer, int size, ref int BytesRead);

            [DllImport("kernel32.dll")]
            public static extern bool WriteProcessMemory(int h_Process, int BaseAddress, byte[] buffer, int size, out int BytesWritten);
        }

        #endregion
    }
}