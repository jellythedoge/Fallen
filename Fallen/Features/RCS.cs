#region

using Fallen.Managers;
using Fallen.Other;
using System.Threading;

#endregion

namespace Fallen.Features
{
    internal class RCS
    {
        public static Maths.Vector3D CurrentViewAngles;
        public static Maths.Vector3D vPunch;
        public static Maths.Vector3D NewViewAngles;
        public static Maths.Vector3D OldAimPunch;

        public static int ShotsFired;

        public static void Run()
        {
            while (true)
            {
                Thread.Sleep(5);

                // ///////////////////////
                // RECOIL CONTROL SYSTEM//
                // ///////////////////////

                ///TO DO
                ///Add smoothing and view angle reset!

                if (Settings.RCS.Enabled)
                {
                    vPunch = Memory.ReadMemory<Maths.Vector3D>(Structs.LocalPlayer.m_iBase + Offsets.m_aimPunchAngle);
                    ShotsFired = Memory.ReadMemory<int>(Structs.LocalPlayer.m_iBase + Offsets.m_iShotsFired);

                    CurrentViewAngles = Memory.ReadMemory<Maths.Vector3D>(Structs.LocalPlayer.m_iClientState + Offsets.dwClientState_ViewAngles);

                    if (ShotsFired > 2)
                    {
                        NewViewAngles.x = ((CurrentViewAngles.x + OldAimPunch.x) - (vPunch.x * Settings.RCS.X));
                        NewViewAngles.y = ((CurrentViewAngles.y + OldAimPunch.y) - (vPunch.y * Settings.RCS.Y));
                        NewViewAngles.z = 0;

                        Maths.ClampAngle(NewViewAngles);

                        OldAimPunch.x = vPunch.x * Settings.RCS.X;
                        OldAimPunch.y = vPunch.y * Settings.RCS.Y;
                        OldAimPunch.z = 0;

                        Memory.WriteMemory<Maths.Vector3D>(Structs.LocalPlayer.m_iClientState + Offsets.dwClientState_ViewAngles, NewViewAngles);
                    }
                    else
                    {
                        OldAimPunch.x = OldAimPunch.y = OldAimPunch.z = 0;
                    }
                }
            }
        }
    }
}