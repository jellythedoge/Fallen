#region

using Fallen.API;
using Memory;
using System.Threading;

#endregion

namespace Fallen.Features
{
    internal class RCS
    {
        public static SDK.Vector3D CurrentViewAngles;
        public static SDK.Vector3D vPunch;
        public static SDK.Vector3D NewViewAngles;
        public static SDK.Vector3D OldAimPunch;

        public static int ShotsFired;

        public static void Run()
        {
            while (true)
            {
                // ///////////////////////
                // RECOIL CONTROL SYSTEM//
                // ///////////////////////

                ///TO DO
                ///Add smoothing and view angle reset!

                if (Settings.RCS.Enabled)
                {
                    vPunch = MemoryManager.ReadMemory<SDK.Vector3D>(SDK.LocalPlayer.m_iBase + Offsets.m_aimPunchAngle);
                    ShotsFired = MemoryManager.ReadMemory<int>(SDK.LocalPlayer.m_iBase + Offsets.m_iShotsFired);

                    CurrentViewAngles = MemoryManager.ReadMemory<SDK.Vector3D>(SDK.LocalPlayer.m_iClientState + Offsets.dwClientState_ViewAngles);

                    if (ShotsFired > 2 && SDK.HeldWeapon != "PISTOL")
                    {
                        NewViewAngles.x = ((CurrentViewAngles.x + OldAimPunch.x) - (vPunch.x * Settings.RCS.X));
                        NewViewAngles.y = ((CurrentViewAngles.y + OldAimPunch.y) - (vPunch.y * Settings.RCS.Y));
                        NewViewAngles.z = 0;

                        SDK.ClampAngle(NewViewAngles);

                        OldAimPunch.x = vPunch.x * Settings.RCS.X;
                        OldAimPunch.y = vPunch.y * Settings.RCS.Y;
                        OldAimPunch.z = 0;

                        MemoryManager.WriteMemory<SDK.Vector3D>(SDK.LocalPlayer.m_iClientState + Offsets.dwClientState_ViewAngles, NewViewAngles);
                    }
                    else
                    {
                        OldAimPunch.x = OldAimPunch.y = OldAimPunch.z = 0;
                    }
                }

                Thread.Sleep(1);
            }
        }
    }
}