#region

using Fallen.Managers;
using Fallen.Other;
using System;
using System.Threading;

#endregion

namespace Fallen.Features
{
    internal class Glow
    {
        public static void Run()
        {
            while (true)
            {
                Thread.Sleep(5);

                for (var i = 0; i < 64; i++)
                {
                    if (Structs.Arrays.Entity[i].m_iBase == 0) continue;
                    if (Structs.Arrays.Entity[i].m_iBase == Structs.LocalPlayer.m_iBase)
                        continue;
                    if (Structs.Arrays.Entity[i].m_iHealth < 1) continue;
                    if (Structs.Arrays.Entity[i].m_iDormant == 1)
                        continue;

                    var cEntity = Memory.ReadMemory<int>(Structs.Base.ClientPointer + Offsets.dwEntityList + (i - 1) * 0x10);

                    var glowObject = new Structs.GlowObject();

                    if (Structs.Arrays.Entity[i].m_iTeam != Structs.LocalPlayer.m_iTeamNum)
                    {
                        if (Settings.GlowEnemy.Enabled)
                        {
                            glowObject = Memory.ReadMemory<Structs.GlowObject>(Structs.LocalPlayer.m_iGlowBase + Structs.Arrays.Entity[i].m_iGlowIndex * 0x38);

                            glowObject.r = Settings.GlowEnemy.Red / 255;
                            glowObject.g = Settings.GlowEnemy.Green / 255;
                            glowObject.b = Settings.GlowEnemy.Blue / 255;
                            glowObject.a = Settings.GlowEnemy.Alpha / 255;
                            glowObject.m_bRenderWhenOccluded = true;
                            glowObject.m_bRenderWhenUnoccluded = false;
                            glowObject.m_bFullBloom = Settings.GlowEnemy.ChamsEnabled;

                            if (Settings.GlowEnemy.ChamsEnabled && Structs.Arrays.Entity[i].m_iTeam != Structs.LocalPlayer.m_iTeamNum)
                            {
                                var chamsObject = new Structs.ChamsObject()
                                {
                                    r = Convert.ToByte(Settings.GlowEnemy.Red),
                                    g = Convert.ToByte(Settings.GlowEnemy.Green),
                                    b = Convert.ToByte(Settings.GlowEnemy.Blue),
                                    a = 254
                                };

                                Memory.WriteMemory<Structs.ChamsObject>(cEntity + 0x70, chamsObject);
                            }

                            Memory.WriteMemory<Structs.GlowObject>(Structs.LocalPlayer.m_iGlowBase + Structs.Arrays.Entity[i].m_iGlowIndex * 0x38, glowObject);
                        }
                    }

                    if (Structs.Arrays.Entity[i].m_iTeam == Structs.LocalPlayer.m_iTeamNum)
                    {
                        if (Settings.GlowTeam.Enabled)
                        {
                            glowObject = Memory.ReadMemory<Structs.GlowObject>(Structs.LocalPlayer.m_iGlowBase + Structs.Arrays.Entity[i].m_iGlowIndex * 0x38);

                            glowObject.r = Settings.GlowTeam.Red / 255;
                            glowObject.g = Settings.GlowTeam.Green / 255;
                            glowObject.b = Settings.GlowTeam.Blue / 255;
                            glowObject.a = Settings.GlowTeam.Alpha / 254;
                            glowObject.m_bRenderWhenOccluded = true;
                            glowObject.m_bRenderWhenUnoccluded = false;
                            glowObject.m_bFullBloom = Settings.GlowTeam.ChamsEnabled;

                            if (Settings.GlowTeam.ChamsEnabled && Structs.Arrays.Entity[i].m_iTeam == Structs.LocalPlayer.m_iTeamNum)
                            {
                                var ChamsObject = new Structs.ChamsObject()
                                {
                                    r = Convert.ToByte(Settings.GlowTeam.Red),
                                    g = Convert.ToByte(Settings.GlowTeam.Green),
                                    b = Convert.ToByte(Settings.GlowTeam.Blue),
                                    a = 254
                                };

                                Memory.WriteMemory<Structs.ChamsObject>(cEntity + 0x70, ChamsObject);
                            }

                            Memory.WriteMemory<Structs.GlowObject>(Structs.LocalPlayer.m_iGlowBase + Structs.Arrays.Entity[i].m_iGlowIndex * 0x38, glowObject);
                        }
                    }
                }
            }
        }
    }
}