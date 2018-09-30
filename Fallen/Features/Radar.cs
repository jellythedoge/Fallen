#region

using Fallen.Managers;
using Fallen.Other;
using System.Threading;

#endregion

namespace Fallen.Features
{
    internal class Radar
    {
        public static void Run()
        {
            while (true)
            {
                Thread.Sleep(150);

                for (var i = 0; i < 64; i++)
                {
                    if (Structs.Arrays.Entity[i].m_iBase == 0) continue;
                    if (Structs.Arrays.Entity[i].m_iBase == Structs.LocalPlayer.m_iBase)
                        continue;
                    if (Structs.Arrays.Entity[i].m_iHealth < 1) continue;
                    if (Structs.Arrays.Entity[i].m_iDormant == 1)
                        continue;

                    if (!Settings.Radar.Enabled) continue;

                    if (!Checks.IsMyTeam())
                    {
                        Memory.WriteMemory<int>(Structs.Arrays.Entity[i].m_iBase + Offsets.m_bSpotted, 1);
                    }
                }
            }
        }
    }
}