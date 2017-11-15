#region

using System;
using System.Runtime.InteropServices;
using static Fallen.API.DLLImports;
using Fallen.GUI;

#endregion

namespace Fallen.API
{
    internal class Hotkeys
    {
        public static IntPtr HookProc(int code, IntPtr WParam, IntPtr lParam)
        {
            var VKCode = Marshal.ReadInt32(lParam);
            var OverlayForm = new OverlayForm();

            //Toggles
            if (WParam == (IntPtr)WMKeydown && VKCode == VKRarrow)
            {
            }

            //Save/Load config
            if (WParam == (IntPtr)WMKeydown && VKCode == VkF1)
            {
                //INI.INI.Ini.SaveConfig();
            }

            if (WParam == (IntPtr)WMKeydown && VKCode == VkF5)
            {
                //INI.INI.Ini.LoadConfig();
            }

            //ForceUpdate
            if (WParam == (IntPtr)WMKeydown && VKCode == VkF4)
            {
                MainClass.Memory.WriteInt(LocalPlayer.ClientState + 0x174, -1);
                Console.WriteLine("ForceUpdated!");
            }

            //Bunny
            if (WParam == (IntPtr)WMKeydown && VKCode == 0x20 && Settings.BhopEnabled)
            {
                Settings.Spacedown = true; //True
            }
            else if (WParam == (IntPtr)WMKeyup && VKCode == 0x20)
            {
                Settings.Spacedown = false; //False
            }

            //TriggerKey
            if (WParam == (IntPtr)VkLmenu && Settings.TriggerEnabled)
            {
                Settings.LAltdown = true; //True
            }
            else if (WParam == (IntPtr)WMKeyup && VKCode == 0xA4)
            {
                Settings.LAltdown = false; //False
            }

            //Panic
            if (WParam == (IntPtr)WMKeydown && VKCode == VkF12)
            {
                Environment.Exit(0);
            }

            return CallNextHookEx(Hhook, code, (int)WParam, lParam);
        }
    }
}