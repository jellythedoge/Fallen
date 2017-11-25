#region

using Fallen.API;
using hazedumper;
using System.Threading;
using System;

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
                    if (Arrays.Entity[i].Base == 0)
                        continue;
                    if (Arrays.Entity[i].Base == LocalPlayer.Base)
                        continue;
                    if (Arrays.Entity[i].Health < 1)
                        continue;
                    if (Arrays.Entity[i].Dormant == 1)
                        continue;

                    if (Arrays.Entity[i].Team != LocalPlayer.Team)
                    {
                        if (Settings.Glow.GlowEnemy)
                        {
                            Memory.ProcessMemory.WriteMemory<float>(LocalPlayer.GlowBase + Arrays.Entity[i].GlowIndex * 0x38 + 0x4, Settings.Glow.EnemyRed / 255);
                            Memory.ProcessMemory.WriteMemory<float>(LocalPlayer.GlowBase + Arrays.Entity[i].GlowIndex * 0x38 + 0x8, Settings.Glow.EnemyGreen / 255);
                            Memory.ProcessMemory.WriteMemory<float>(LocalPlayer.GlowBase + Arrays.Entity[i].GlowIndex * 0x38 + 0xC, Settings.Glow.EnemyBlue / 255);
                            Memory.ProcessMemory.WriteMemory<float>(LocalPlayer.GlowBase + Arrays.Entity[i].GlowIndex * 0x38 + 0x10, (float) 100 / 255);
                            Memory.ProcessMemory.WriteMemory<bool>(LocalPlayer.GlowBase + Arrays.Entity[i].GlowIndex * 0x38 + 0x24, true);
                            Memory.ProcessMemory.WriteMemory<bool>(LocalPlayer.GlowBase + Arrays.Entity[i].GlowIndex * 0x38 + 0x25, false);

                            if (Settings.Glow.ChamsEnemy)
                            {
                                Memory.ProcessMemory.WriteMemory<bool>(LocalPlayer.GlowBase + Arrays.Entity[i].GlowIndex * 0x38 + 0x2C, true);

                                Memory.ProcessMemory.WriteMemory<bool>(LocalPlayer.Base + netvars.m_bSpotted, true);
                            }
                        }
                    }
                    else
                    {
                        if (Settings.Glow.GlowTeam)
                        {
                            Memory.ProcessMemory.WriteMemory<float>(LocalPlayer.GlowBase + Arrays.Entity[i].GlowIndex * 0x38 + 0x4, Settings.Glow.TeamRed / 255);
                            Memory.ProcessMemory.WriteMemory<float>(LocalPlayer.GlowBase + Arrays.Entity[i].GlowIndex * 0x38 + 0x8, Settings.Glow.TeamGreen / 255);
                            Memory.ProcessMemory.WriteMemory<float>(LocalPlayer.GlowBase + Arrays.Entity[i].GlowIndex * 0x38 + 0xC, Settings.Glow.TeamBlue / 255);
                            Memory.ProcessMemory.WriteMemory<float>(LocalPlayer.GlowBase + Arrays.Entity[i].GlowIndex * 0x38 + 0x10, (float) 100 / 255);
                            Memory.ProcessMemory.WriteMemory<bool>(LocalPlayer.GlowBase + Arrays.Entity[i].GlowIndex * 0x38 + 0x24, true);
                            Memory.ProcessMemory.WriteMemory<bool>(LocalPlayer.GlowBase + Arrays.Entity[i].GlowIndex * 0x38 + 0x25, false);

                            if (Settings.Glow.ChamsTeam)
                            {
                                Memory.ProcessMemory.WriteMemory<bool>(LocalPlayer.GlowBase + Arrays.Entity[i].GlowIndex * 0x38 + 0x2C, true);

                                Memory.ProcessMemory.WriteMemory<bool>(LocalPlayer.Base + netvars.m_bSpotted, true);
                            }
                        }
                    }
                }
                Thread.Sleep(30);
            }
        }
    }
}