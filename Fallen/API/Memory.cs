#region

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

using Fallen.API;

#endregion

namespace Memory
{
    internal class ProcessMemory
    {
        ////////////////////
        //Public Mem Class//
        ////////////////////

        // Fields
        protected int BaseAddress;

        public Process[] MyProcess;
        public ProcessModule MyProcessModule;
        public int ProcessHandle;
        public string ProcessName;

        public ProcessMemory(string pProcessName)
        {
            ProcessName = pProcessName;
        }

        public bool StartProcess()
        {
            if (ProcessName != "")
            {
                MyProcess = Process.GetProcessesByName(ProcessName);
                if (MyProcess.Length == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ProcessName + " IS NOT RUNNING OR HAS NOT BEEN FOUND!. ", "Process Not Found");
                    Console.ReadKey();
                    Environment.Exit(0);
                    return false;
                }
                ProcessHandle = OpenProcess(2035711, false, MyProcess[0].Id);
                if (ProcessHandle == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ProcessName + " IS NOT RUNNING OR HAS NOT BEEN FOUND!. ", "Process Not Found");
                    Console.ReadKey();
                    Environment.Exit(0);
                    return false;
                }
                return true;
            }
            Console.WriteLine("Define process name first!");
            return false;
        }

        public string CutString(string mystring)
        {
            var chArray = mystring.ToCharArray();
            var str = "";
            for (var i = 0; i < mystring.Length; i++)
            {
                if (chArray[i] == ' ' && chArray[i + 1] == ' ')
                    return str;
                if (chArray[i] == '\0')
                    return str;
                str = str + chArray[i];
            }
            return mystring.TrimEnd('0');
        }

        public int DllImageAddress(string dllname)
        {
            var modules = MyProcess[0].Modules;

            foreach (ProcessModule procmodule in modules)
                if (dllname == procmodule.ModuleName)
                    return (int)procmodule.BaseAddress;
            return -1;
        }

        public int ImageAddress()
        {
            BaseAddress = 0;
            MyProcessModule = MyProcess[0].MainModule;
            BaseAddress = (int)MyProcessModule.BaseAddress;
            return BaseAddress;
        }

        public int ImageAddress(int pOffset)
        {
            BaseAddress = 0;
            MyProcessModule = MyProcess[0].MainModule;
            BaseAddress = (int)MyProcessModule.BaseAddress;
            return pOffset + BaseAddress;
        }

        #region Pointers

        public int Pointer(bool addToImageAddress, int pOffset)
        {
            return ReadInt(ImageAddress(pOffset));
        }

        public int Pointer(string module, int pOffset)
        {
            return ReadInt(DllImageAddress(module) + pOffset);
        }

        public int Pointer(bool addToImageAddress, int pOffset, int pOffset2)
        {
            if (addToImageAddress)
                return ReadInt(ImageAddress() + pOffset) + pOffset2;
            return ReadInt(pOffset) + pOffset2;
        }

        public int Pointer(string module, int pOffset, int pOffset2)
        {
            return ReadInt(DllImageAddress(module) + pOffset) + pOffset2;
        }

        public int Pointer(bool addToImageAddress, int pOffset, int pOffset2, int pOffset3)
        {
            return ReadInt(ReadInt(ImageAddress(pOffset)) + pOffset2) + pOffset3;
        }

        public int Pointer(string module, int pOffset, int pOffset2, int pOffset3)
        {
            return ReadInt(ReadInt(DllImageAddress(module) + pOffset) + pOffset2) + pOffset3;
        }

        public int Pointer(bool addToImageAddress, int pOffset, int pOffset2, int pOffset3, int pOffset4)
        {
            return ReadInt(ReadInt(ReadInt(ImageAddress(pOffset)) + pOffset2) + pOffset3) + pOffset4;
        }

        public int Pointer(string module, int pOffset, int pOffset2, int pOffset3, int pOffset4)
        {
            return ReadInt(ReadInt(ReadInt(DllImageAddress(module) + pOffset) + pOffset2) + pOffset3) + pOffset4;
        }

        public int Pointer(bool addToImageAddress, int pOffset, int pOffset2, int pOffset3, int pOffset4, int pOffset5)
        {
            return ReadInt(ReadInt(ReadInt(ReadInt(ImageAddress(pOffset)) + pOffset2) + pOffset3) + pOffset4) + pOffset5;
        }

        public int Pointer(string module, int pOffset, int pOffset2, int pOffset3, int pOffset4, int pOffset5)
        {
            return ReadInt(ReadInt(ReadInt(ReadInt(DllImageAddress(module) + pOffset) + pOffset2) + pOffset3) + pOffset4) + pOffset5;
        }

        public int Pointer(bool addToImageAddress, int pOffset, int pOffset2, int pOffset3, int pOffset4, int pOffset5, int pOffset6)
        {
            return ReadInt(ReadInt(ReadInt(ReadInt(ReadInt(ImageAddress(pOffset)) + pOffset2) + pOffset3) + pOffset4) + pOffset5) + pOffset6;
        }

        public int Pointer(string module, int pOffset, int pOffset2, int pOffset3, int pOffset4, int pOffset5, int pOffset6)
        {
            return ReadInt(ReadInt(ReadInt(ReadInt(ReadInt(DllImageAddress(module) + pOffset) + pOffset2) + pOffset3) + pOffset4) + pOffset5) + pOffset6;
        }

        #endregion

        #region ReadMem

        public byte ReadByte(int pOffset)
        {
            var buffer = new byte[1];
            ReadProcessMemory(ProcessHandle, pOffset, buffer, 1, 0);
            return buffer[0];
        }

        public byte ReadByte(bool addToImageAddress, int pOffset)
        {
            var buffer = new byte[1];
            var lpBaseAddress = addToImageAddress ? ImageAddress(pOffset) : pOffset;
            ReadProcessMemory(ProcessHandle, lpBaseAddress, buffer, 1, 0);
            return buffer[0];
        }

        public byte ReadByte(string module, int pOffset)
        {
            var buffer = new byte[1];
            ReadProcessMemory(ProcessHandle, DllImageAddress(module) + pOffset, buffer, 1, 0);
            return buffer[0];
        }

        public float ReadFloat(int pOffset)
        {
            return BitConverter.ToSingle(ReadMem(pOffset, 4), 0);
        }

        public float ReadFloat(bool addToImageAddress, int pOffset)
        {
            return BitConverter.ToSingle(ReadMem(pOffset, 4, addToImageAddress), 0);
        }

        public float ReadFloat(string module, int pOffset)
        {
            return BitConverter.ToSingle(ReadMem(DllImageAddress(module) + pOffset, 4), 0);
        }

        public virtual bool ReadBool(int pOffset)
        {
            return BitConverter.ToBoolean(ReadMem(pOffset, 4), 0);
        }

        public virtual bool ReadBool(bool addToImageAddress, int pOffset)
        {
            return BitConverter.ToBoolean(ReadMem(pOffset, 4, addToImageAddress), 0);
        }

        public virtual bool ReadBool(string module, int pOffset)
        {
            return BitConverter.ToBoolean(ReadMem(DllImageAddress(module) + pOffset, 4), 0);
        }

        public virtual double ReadDouble(int pOffset)
        {
            return BitConverter.ToDouble(ReadMem(pOffset, 8), 0);
        }

        public virtual double ReadDouble(bool addToImageAddress, int pOffset)
        {
            return BitConverter.ToDouble(ReadMem(pOffset, 8, addToImageAddress), 0);
        }

        public virtual double ReadDouble(string module, int pOffset)
        {
            return BitConverter.ToDouble(ReadMem(DllImageAddress(module) + pOffset, 8), 0);
        }

        public virtual Char ReadChar(int pOffset)
        {
            return BitConverter.ToChar(ReadMem(pOffset, 4), 0);
        }

        public virtual Char ReadChar(bool addToImageAddress, int pOffset)
        {
            return BitConverter.ToChar(ReadMem(pOffset, 4, addToImageAddress), 0);
        }

        public virtual Char ReadChar(string module, int pOffset)
        {
            return BitConverter.ToChar(ReadMem(DllImageAddress(module) + pOffset, 4), 0);
        }

        //DEMO READ CHAR/

        public int ReadInt(int pOffset)
        {
            return BitConverter.ToInt32(ReadMem(pOffset, 4), 0);
        }

        public int ReadInt(bool addToImageAddress, int pOffset)
        {
            return BitConverter.ToInt32(ReadMem(pOffset, 4, addToImageAddress), 0);
        }

        public int ReadInt(string module, int pOffset)
        {
            return BitConverter.ToInt32(ReadMem(DllImageAddress(module) + pOffset, 4), 0);
        }

        public byte[] ReadMem(int pOffset, int pSize)
        {
            var buffer = new byte[pSize];
            ReadProcessMemory(ProcessHandle, pOffset, buffer, pSize, 0);
            return buffer;
        }

        public byte[] ReadMem(int pOffset, int pSize, bool addToImageAddress)
        {
            var buffer = new byte[pSize];
            var lpBaseAddress = addToImageAddress ? ImageAddress(pOffset) : pOffset;
            ReadProcessMemory(ProcessHandle, lpBaseAddress, buffer, pSize, 0);
            return buffer;
        }

        public short ReadShort(int pOffset)
        {
            return BitConverter.ToInt16(ReadMem(pOffset, 2), 0);
        }

        public short ReadShort(bool addToImageAddress, int pOffset)
        {
            return BitConverter.ToInt16(ReadMem(pOffset, 2, addToImageAddress), 0);
        }

        public short ReadShort(string module, int pOffset)
        {
            return BitConverter.ToInt16(ReadMem(DllImageAddress(module) + pOffset, 2), 0);
        }

        public string ReadStringAscii(int pOffset, int pSize)
        {
            return CutString(Encoding.ASCII.GetString(ReadMem(pOffset, pSize)));
        }

        public string ReadStringAscii(bool addToImageAddress, int pOffset, int pSize)
        {
            return CutString(Encoding.ASCII.GetString(ReadMem(pOffset, pSize, addToImageAddress)));
        }

        public string ReadStringAscii(string module, int pOffset, int pSize)
        {
            return CutString(Encoding.ASCII.GetString(ReadMem(DllImageAddress(module) + pOffset, pSize)));
        }

        public string ReadStringUnicode(int pOffset, int pSize)
        {
            return CutString(Encoding.Unicode.GetString(ReadMem(pOffset, pSize)));
        }

        public string ReadStringUnicode(bool addToImageAddress, int pOffset, int pSize)
        {
            return CutString(Encoding.Unicode.GetString(ReadMem(pOffset, pSize, addToImageAddress)));
        }

        public string ReadStringUnicode(string module, int pOffset, int pSize)
        {
            return CutString(Encoding.Unicode.GetString(ReadMem(DllImageAddress(module) + pOffset, pSize)));
        }

        public uint ReadUInt(int pOffset)
        {
            return BitConverter.ToUInt32(ReadMem(pOffset, 4), 0);
        }

        public uint ReadUInt(bool addToImageAddress, int pOffset)
        {
            return BitConverter.ToUInt32(ReadMem(pOffset, 4, addToImageAddress), 0);
        }

        public uint ReadUInt(string module, int pOffset)
        {
            return BitConverter.ToUInt32(ReadMem(DllImageAddress(module) + pOffset, 4), 0);
        }

        #endregion

        #region WriteMem

        public void WriteByte(int pOffset, byte pBytes)
        {
            WriteMem(pOffset, BitConverter.GetBytes(pBytes));
        }

        public void WriteByte(bool addToImageAddress, int pOffset, byte pBytes)
        {
            WriteMem(pOffset, BitConverter.GetBytes(pBytes), addToImageAddress);
        }

        public void WriteByte(string module, int pOffset, byte pBytes)
        {
            WriteMem(DllImageAddress(module) + pOffset, BitConverter.GetBytes(pBytes));
        }

        public void WriteDouble(int pOffset, double pBytes)
        {
            WriteMem(pOffset, BitConverter.GetBytes(pBytes));
        }

        public void WriteDouble(bool addToImageAddress, int pOffset, double pBytes)
        {
            WriteMem(pOffset, BitConverter.GetBytes(pBytes), addToImageAddress);
        }

        public void WriteDouble(string module, int pOffset, double pBytes)
        {
            WriteMem(DllImageAddress(module) + pOffset, BitConverter.GetBytes(pBytes));
        }

        public void WriteFloat(int pOffset, float pBytes)
        {
            WriteMem(pOffset, BitConverter.GetBytes(pBytes));
        }

        public void WriteFloat(bool addToImageAddress, int pOffset, float pBytes)
        {
            WriteMem(pOffset, BitConverter.GetBytes(pBytes), addToImageAddress);
        }

        public void WriteFloat(string module, int pOffset, float pBytes)
        {
            WriteMem(DllImageAddress(module) + pOffset, BitConverter.GetBytes(pBytes));
        }

        public void WriteBool(int pOffset, bool pBytes)
        {
            WriteMem(pOffset, BitConverter.GetBytes(pBytes));
        }

        public void WriteBool(bool addToImageAddress, int pOffset, bool pBytes)
        {
            WriteMem(pOffset, BitConverter.GetBytes(pBytes), addToImageAddress);
        }

        public void WriteBool(string module, int pOffset, bool pBytes)
        {
            WriteMem(DllImageAddress(module) + pOffset, BitConverter.GetBytes(pBytes));
        }

        public void WriteChar(int pOffset, char pBytes)
        {
            WriteMem(pOffset, BitConverter.GetBytes(pBytes));
        }

        public void WriteChar(bool addToImageAddress, int pOffset, char pBytes)
        {
            WriteMem(pOffset, BitConverter.GetBytes(pBytes), addToImageAddress);
        }

        public void WriteChar(string module, int pOffset, char pBytes)
        {
            WriteMem(DllImageAddress(module) + pOffset, BitConverter.GetBytes(pBytes));
        }

        public void WriteInt(int pOffset, int pBytes)
        {
            WriteMem(pOffset, BitConverter.GetBytes(pBytes));
        }

        public void WriteInt(bool addToImageAddress, int pOffset, int pBytes)
        {
            WriteMem(pOffset, BitConverter.GetBytes(pBytes), addToImageAddress);
        }

        public void WriteInt(string module, int pOffset, int pBytes)
        {
            WriteMem(DllImageAddress(module) + pOffset, BitConverter.GetBytes(pBytes));
        }

        public void WriteMem(int pOffset, byte[] pBytes)
        {
            WriteProcessMemory(ProcessHandle, pOffset, pBytes, pBytes.Length, 0);
        }

        public void WriteMem(int pOffset, byte[] pBytes, bool addToImageAddress)
        {
            var lpBaseAddress = addToImageAddress ? ImageAddress(pOffset) : pOffset;
            WriteProcessMemory(ProcessHandle, lpBaseAddress, pBytes, pBytes.Length, 0);
        }

        public void WriteShort(int pOffset, short pBytes)
        {
            WriteMem(pOffset, BitConverter.GetBytes(pBytes));
        }

        public void WriteShort(bool addToImageAddress, int pOffset, short pBytes)
        {
            WriteMem(pOffset, BitConverter.GetBytes(pBytes), addToImageAddress);
        }

        public void WriteShort(string module, int pOffset, short pBytes)
        {
            WriteMem(DllImageAddress(module) + pOffset, BitConverter.GetBytes(pBytes));
        }

        public void WriteStringAscii(int pOffset, string pBytes)
        {
            WriteMem(pOffset, Encoding.ASCII.GetBytes(pBytes + "\0"));
        }

        public void WriteStringAscii(bool addToImageAddress, int pOffset, string pBytes)
        {
            WriteMem(pOffset, Encoding.ASCII.GetBytes(pBytes + "\0"), addToImageAddress);
        }

        public void WriteStringAscii(string module, int pOffset, string pBytes)
        {
            WriteMem(DllImageAddress(module) + pOffset, Encoding.ASCII.GetBytes(pBytes + "\0"));
        }

        public void WriteStringUnicode(int pOffset, string pBytes)
        {
            WriteMem(pOffset, Encoding.Unicode.GetBytes(pBytes + "\0"));
        }

        public void WriteStringUnicode(bool addToImageAddress, int pOffset, string pBytes)
        {
            WriteMem(pOffset, Encoding.Unicode.GetBytes(pBytes + "\0"), addToImageAddress);
        }

        public void WriteStringUnicode(string module, int pOffset, string pBytes)
        {
            WriteMem(DllImageAddress(module) + pOffset, Encoding.Unicode.GetBytes(pBytes + "\0"));
        }

        public void WriteUInt(int pOffset, uint pBytes)
        {
            WriteMem(pOffset, BitConverter.GetBytes(pBytes));
        }

        public void WriteUInt(bool addToImageAddress, int pOffset, uint pBytes)
        {
            WriteMem(pOffset, BitConverter.GetBytes(pBytes), addToImageAddress);
        }

        public void WriteUInt(string module, int pOffset, uint pBytes)
        {
            WriteMem(DllImageAddress(module) + pOffset, BitConverter.GetBytes(pBytes));
        }

        #endregion

        #region SigScanning

        //Nothing Here Yet.....

        #endregion

        #region DLLIMPORTS

        ///////////////
        //DLL IMPORTs//
        ///////////////

        [DllImport("kernel32.dll")]
        public static extern bool CloseHandle(int hObject);

        [DllImport("kernel32.dll")]
        public static extern int OpenProcess(uint dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        public static extern int FindWindowByCaption(int zeroOnly, string lpWindowName);

        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(int hProcess, int lpBaseAddress, byte[] buffer, int size, int lpNumberOfBytesRead);

        [DllImport("kernel32.dll")]
        public static extern bool VirtualProtectEx(int hProcess, int lpAddress, int dwSize, uint flNewProtect, out uint lpflOldProtect);

        [DllImport("kernel32.dll")]
        public static extern bool WriteProcessMemory(int hProcess, int lpBaseAddress, byte[] buffer, int size, int lpNumberOfBytesWritten);

        #endregion

        #region ProcessAccessFlags

        [Flags]
        public enum ProcessAccessFlags : uint
        {
            All = 2035711,
            CreateThread = 2,
            DupHandle = 64,
            QueryInformation = 1024,
            SetInformation = 512,
            Synchronize = 1048576,
            Terminate = 1,
            VmOperation = 8,
            VmRead = 16,
            VmWrite = 32
        }

        #endregion
    }
}