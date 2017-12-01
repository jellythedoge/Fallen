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
                    if (Arrays.Entity[i].m_iBase == 0)
                        continue;
                    if (Arrays.Entity[i].m_iBase == LocalPlayer.m_iBase)
                        continue;
                    if (Arrays.Entity[i].m_iHealth < 1)
                        continue;
                    if (Arrays.Entity[i].m_iDormant == 1)
                        continue;

                    if (Settings.Radar.Enabled)
                    {
                        if (Arrays.Entity[i].m_iTeam != LocalPlayer.m_iTeam)
                        {
                            MemoryManager.WriteMemory<int>(Arrays.Entity[i].m_iBase + Offsets.m_bSpotted, 1);
                        }
                    }

                    Thread.Sleep(150);
                }
            }
        }
    }
}