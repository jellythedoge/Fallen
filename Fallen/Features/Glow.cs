#region

using Fallen.API;
using Memory;
using System.Threading;

#endregion

namespace Fallen.Features
{
    internal class Glow
    {
        internal void Run()
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

                    if (Arrays.Entity[i].m_iTeam != LocalPlayer.m_iTeam)
                    {
                        if (Settings.GlowEnemy.Enabled)
                        {
                            MemoryManager.WriteMemory<float>(LocalPlayer.m_iGlowBase + Arrays.Entity[i].m_iGlowIndex * 0x38 + 0x10, Settings.GlowEnemy.Alpha / 255);
                            MemoryManager.WriteMemory<float>(LocalPlayer.m_iGlowBase + Arrays.Entity[i].m_iGlowIndex * 0x38 + 0x4, Settings.GlowEnemy.Red / 255);
                            MemoryManager.WriteMemory<float>(LocalPlayer.m_iGlowBase + Arrays.Entity[i].m_iGlowIndex * 0x38 + 0x8, Settings.GlowEnemy.Green / 255);
                            MemoryManager.WriteMemory<float>(LocalPlayer.m_iGlowBase + Arrays.Entity[i].m_iGlowIndex * 0x38 + 0xC, Settings.GlowEnemy.Blue / 255);
                            MemoryManager.WriteMemory<bool>(LocalPlayer.m_iGlowBase + Arrays.Entity[i].m_iGlowIndex * 0x38 + 0x24, true);
                            MemoryManager.WriteMemory<bool>(LocalPlayer.m_iGlowBase + Arrays.Entity[i].m_iGlowIndex * 0x38 + 0x25, false);

                            if (Settings.GlowEnemy.ChamsEnabled)
                            {
                                MemoryManager.WriteMemory<bool>(LocalPlayer.m_iGlowBase + Arrays.Entity[i].m_iGlowIndex * 0x38 + 0x2C, true);
                            }
                        }
                    }
                    else
                    {
                        if (Settings.GlowTeam.Enabled)
                        {
                            MemoryManager.WriteMemory<float>(LocalPlayer.m_iGlowBase + Arrays.Entity[i].m_iGlowIndex * 0x38 + 0x10, Settings.GlowTeam.Alpha / 255);
                            MemoryManager.WriteMemory<float>(LocalPlayer.m_iGlowBase + Arrays.Entity[i].m_iGlowIndex * 0x38 + 0x4, Settings.GlowTeam.Red / 255);
                            MemoryManager.WriteMemory<float>(LocalPlayer.m_iGlowBase + Arrays.Entity[i].m_iGlowIndex * 0x38 + 0x8, Settings.GlowTeam.Green / 255);
                            MemoryManager.WriteMemory<float>(LocalPlayer.m_iGlowBase + Arrays.Entity[i].m_iGlowIndex * 0x38 + 0xC, Settings.GlowTeam.Blue / 255);
                            MemoryManager.WriteMemory<bool>(LocalPlayer.m_iGlowBase + Arrays.Entity[i].m_iGlowIndex * 0x38 + 0x24, true);
                            MemoryManager.WriteMemory<bool>(LocalPlayer.m_iGlowBase + Arrays.Entity[i].m_iGlowIndex * 0x38 + 0x25, false);

                            if (Settings.GlowTeam.ChamsEnabled)
                            {
                                MemoryManager.WriteMemory<bool>(LocalPlayer.m_iGlowBase + Arrays.Entity[i].m_iGlowIndex * 0x38 + 0x2C, true);
                            }
                        }
                    }
                }
                Thread.Sleep(30);
            }
        }
    }
}