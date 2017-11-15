#region

using Fallen.API;
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
                if (Settings.TriggerEnabled)
                {
                    var entityInCrossId = MainClass.Memory.ReadInt(LocalPlayer.Base + netvars.m_iCrosshairId);
                    if (entityInCrossId != 0)
                    {
                        var entityBase = MainClass.Memory.ReadInt(MainClass.ClientPointer + signatures.dwEntityList + (entityInCrossId - <enc 1>) * 0x10);
                        var entityTeam = MainClass.Memory.ReadInt(entityBase + netvars.m_iTeamNum);
                        if (!Settings.LAltdown)
                            Thread.Sleep(1);

                        if (Settings.LAltdown && entityTeam != LocalPlayer.Team)
                        {
                            MainClass.Memory.WriteInt(MainClass.ClientPointer + signatures.dwForceAttack, <enc 5>);
                            Thread.Sleep(2);
                            MainClass.Memory.WriteInt(MainClass.ClientPointer + signatures.dwForceAttack, <enc 4>);
                            Thread.Sleep(4);
                        }
                    }
                }
                Thread.Sleep(1);
            }
        }
    }
}