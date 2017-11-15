#region

using System;
using System.Runtime.InteropServices;
using static Fallen.API.Hotkeys;

#endregion

namespace Fallen.API
{
    internal class DLLImports
    {
        //-<swap>

        public const int VkF1 = 0x70;
        public const int VkF2 = 0x71;
        public const int VkF3 = 0x72;
        public const int VkF4 = 0x73;
        public const int VkF5 = 0x74;
        public const int VkF6 = 0x75;
        public const int VkF7 = 0x76;
        public const int VkF8 = 0x77;
        public const int VkF9 = 0x78;
        public const int VkF10 = 0x79;
        public const int VkF11 = 0x7a;
        public const int VkF12 = 0x7b;
        public const int VKRarrow = 0x27;
        public const int VKLarrow = 0x25;
        public const int VKUarrow = 0x26;
        public const int VKDarrow = 0x28;
        public const int VkLmenu = 0x104;
        public const int WHKeyboardLl = 13;
        public const int WMKeydown = 0x100;
        public const int WMKeyup = 0x101;

        //-<swap/>

        public static IntPtr Hhook = IntPtr.Zero;

        private static readonly LowLevelKeyboardProc Proc = HookProc;

        //-<swap>

        [DllImport("user32.dll")]
        public static extern IntPtr CallNextHookEx(IntPtr idHook, int nCode, int wParam, IntPtr lParam);

        //-<block>

        [DllImport("user32.dll")]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, UIntPtr dwExtraInfo);

        //-<block>

        [DllImport("kernel32.dll")]
        private static extern IntPtr LoadLibrary(string lpFileName);

        //-<block>

        [DllImport("user32.dll")]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc callback, IntPtr hInstance, uint threadId);

        //-<block>

        [DllImport("user32.dll")]
        private static extern bool UnhookWindowsHookEx(IntPtr hInstance);

        //-<block>

        public static void SetHook()
        {
            var hInstance = LoadLibrary("User32");
            Hhook = SetWindowsHookEx(WHKeyboardLl, Proc, hInstance, 0);
        }

        //-<block>

        public static void UnHook()
        {
            UnhookWindowsHookEx(Hhook);
        }

        //-<block>

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        //-<swap/>
    }
}