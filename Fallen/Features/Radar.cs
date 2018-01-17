#region

using Fallen.API;
using Memory;
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
                for (var i = 0; i < 64; i++)
                {
                    if (SDK.Arrays.Entity[i].m_iBase == 0) continue;
                    if (SDK.Arrays.Entity[i].m_iBase == SDK.LocalPlayer.m_iBase)
                        continue;
                    if (SDK.Arrays.Entity[i].m_iHealth < 1) continue;
                    if (SDK.Arrays.Entity[i].m_iDormant == 1)
                        continue;

                    if (Settings.Radar.Enabled)
                    {
                        if (SDK.Arrays.Entity[i].m_iTeam != SDK.LocalPlayer.m_iTeam)
                        {
                            MemoryManager.WriteMemory<int>(SDK.Arrays.Entity[i].m_iBase + Offsets.m_bSpotted, 1);
                        }
                    }

                    Thread.Sleep(150);
                }
            }
        }
    }
}