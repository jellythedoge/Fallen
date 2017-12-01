#region

using Fallen.API;
using Memory;
using System.Threading;

#endregion

namespace Fallen.Features
{
    internal class Trigger
    {
        internal void Run()
        {
            while (true)
            {
                ///TO DO
                ///Add World2Screen and Raytrace and add VIS Check, not expected soon!

                if (Settings.Trigger.Enabled)
                {
                    var entityInCrossId = MemoryManager.ReadMemory<int>(LocalPlayer.m_iBase + Offsets.m_iCrosshairId);
                    if (entityInCrossId != 0)
                    {
                        var entityBase = MemoryManager.ReadMemory<int>(MainClass.ClientPointer + Offsets.dwEntityList + (entityInCrossId - 1) * 0x10);
                        var entityTeam = MemoryManager.ReadMemory<int>(entityBase + Offsets.m_iTeamNum);
                        if (!Settings.Trigger.Key)
                            Thread.Sleep(1);

                        if (Settings.Trigger.Key && entityTeam != LocalPlayer.m_iTeam)
                        {
                            MemoryManager.WriteMemory<bool>(MainClass.ClientPointer + Offsets.dwForceAttack, true);
                            Thread.Sleep(2);
                            MemoryManager.WriteMemory<bool>(MainClass.ClientPointer + Offsets.dwForceAttack, false);
                            Thread.Sleep(4);
                        }
                    }
                }
                Thread.Sleep(1);
            }
        }
    }
}