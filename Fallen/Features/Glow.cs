#region

using Fallen.API;
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
                    if (Settings.GlowEnabled)
                        continue;
                    //-<swap>
                    if (Arrays.Entity[i].Base == 0)
                        continue;
                    if (Arrays.Entity[i].Base == LocalPlayer.Base)
                        continue;
                    if (Arrays.Entity[i].Health < 1)
                        continue;
                    if (Arrays.Entity[i].Dormant == 1)
                        continue;
                    //-<swap/>

                    if (Arrays.Entity[i].Team != LocalPlayer.Team)
                    {
                        if (Settings.GlowEnemy)
                        {
                            //-<swap>

                            MainClass.Memory.WriteFloat(LocalPlayer.GlowBase + Arrays.Entity[i].GlowIndex * 0x38 + 0x4, Settings.EnemyRed / 255);
                            MainClass.Memory.WriteFloat(LocalPlayer.GlowBase + Arrays.Entity[i].GlowIndex * 0x38 + 0x8, Settings.EnemyGreen / 255);
                            MainClass.Memory.WriteFloat(LocalPlayer.GlowBase + Arrays.Entity[i].GlowIndex * 0x38 + 0xC, Settings.EnemyBlue / 255);
                            MainClass.Memory.WriteFloat(LocalPlayer.GlowBase + Arrays.Entity[i].GlowIndex * 0x38 + 0x10, (float) 200 / 255);
                            MainClass.Memory.WriteBool(LocalPlayer.GlowBase + Arrays.Entity[i].GlowIndex * 0x38 + 0x24, true);
                            MainClass.Memory.WriteBool(LocalPlayer.GlowBase + Arrays.Entity[i].GlowIndex * 0x38 + 0x25, false);
                            
                            //-<swap/>

                            if (Settings.ChamsEnemy)
                            {
                                MainClass.Memory.WriteBool(LocalPlayer.GlowBase + Arrays.Entity[i].GlowIndex * 0x38 + 0x2C, true);

                                MainClass.Memory.WriteBool(LocalPlayer.Base + netvars.m_bSpotted, true);
                            }
                        }
                    }
                    else
                    {
                        if (Settings.GlowTeam)
                        {
                            //-<swap>

                            MainClass.Memory.WriteFloat(LocalPlayer.GlowBase + Arrays.Entity[i].GlowIndex * 0x38 + 0x4, Settings.TeamRed / 255);
                            MainClass.Memory.WriteFloat(LocalPlayer.GlowBase + Arrays.Entity[i].GlowIndex * 0x38 + 0x8, Settings.TeamGreen / 255);
                            MainClass.Memory.WriteFloat(LocalPlayer.GlowBase + Arrays.Entity[i].GlowIndex * 0x38 + 0xC, Settings.TeamBlue / 255);
                            MainClass.Memory.WriteFloat(LocalPlayer.GlowBase + Arrays.Entity[i].GlowIndex * 0x38 + 0x10, (float) 200 / 255);
                            MainClass.Memory.WriteBool(LocalPlayer.GlowBase + Arrays.Entity[i].GlowIndex * 0x38 + 0x24, true);
                            MainClass.Memory.WriteBool(LocalPlayer.GlowBase + Arrays.Entity[i].GlowIndex * 0x38 + 0x25, false);

                            //-<swap/>

                            if (Settings.ChamsTeam)
                            {
                                MainClass.Memory.WriteBool(LocalPlayer.GlowBase + Arrays.Entity[i].GlowIndex * 0x38 + 0x2C, true);

                                MainClass.Memory.WriteBool(LocalPlayer.Base + netvars.m_bSpotted, true);
                            }
                        }
                    }
                }
                Thread.Sleep(30);
            }
        }
    }
}