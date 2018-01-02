#region

using Fallen.API;
using Memory;
using System;
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
                    if (SDK.Arrays.Entity[i].m_iBase == 0)
                        continue;
                    if (SDK.Arrays.Entity[i].m_iBase == SDK.LocalPlayer.m_iBase)
                        continue;
                    if (SDK.Arrays.Entity[i].m_iHealth < 1)
                        continue;
                    if (SDK.Arrays.Entity[i].m_iDormant == 1)
                        continue;

                    int cEntity = MemoryManager.ReadMemory<int>(MainClass.ClientPointer + Offsets.dwEntityList + (i - 1) * 16);

                    SDK.GlowObject GlowObject = new SDK.GlowObject();

                    if (SDK.Arrays.Entity[i].m_iTeam != SDK.LocalPlayer.m_iTeam)
                    {
                        if (Settings.GlowEnemy.Enabled)
                        {
                            GlowObject = MemoryManager.ReadMemory<SDK.GlowObject>(SDK.LocalPlayer.m_iGlowBase + SDK.Arrays.Entity[i].m_iGlowIndex * 0x38);

                            GlowObject.r = Settings.GlowEnemy.Red / 255;
                            GlowObject.g = Settings.GlowEnemy.Green / 255;
                            GlowObject.b = Settings.GlowEnemy.Blue / 255;
                            GlowObject.a = Settings.GlowEnemy.Alpha / 255;
                            GlowObject.m_bRenderWhenOccluded = true;
                            GlowObject.m_bRenderWhenUnoccluded = false;
                            GlowObject.m_bFullBloom = Settings.GlowEnemy.ChamsEnabled;

                            if (Settings.GlowEnemy.ChamsEnabled && SDK.Arrays.Entity[i].m_iTeam != SDK.LocalPlayer.m_iTeam)
                            {
                                SDK.ChamsObject ChamsObject = new SDK.ChamsObject()
                                {
                                    r = Convert.ToByte(Settings.GlowEnemy.Red),
                                    g = Convert.ToByte(Settings.GlowEnemy.Green),
                                    b = Convert.ToByte(Settings.GlowEnemy.Blue),
                                    a = 254
                                };

                                MemoryManager.WriteMemory<SDK.ChamsObject>(cEntity + 0x70, ChamsObject);
                            }

                            MemoryManager.WriteMemory<SDK.GlowObject>(SDK.LocalPlayer.m_iGlowBase + SDK.Arrays.Entity[i].m_iGlowIndex * 0x38, GlowObject);
                        }
                    }

                    if (SDK.Arrays.Entity[i].m_iTeam == SDK.LocalPlayer.m_iTeam)
                    {
                        if (Settings.GlowTeam.Enabled)
                        {
                            GlowObject = MemoryManager.ReadMemory<SDK.GlowObject>(SDK.LocalPlayer.m_iGlowBase + SDK.Arrays.Entity[i].m_iGlowIndex * 0x38);

                            GlowObject.r = Settings.GlowTeam.Red / 255;
                            GlowObject.g = Settings.GlowEnemy.Green / 255;
                            GlowObject.b = Settings.GlowTeam.Blue / 255;
                            GlowObject.a = Settings.GlowTeam.Alpha / 254;
                            GlowObject.m_bRenderWhenOccluded = true;
                            GlowObject.m_bRenderWhenUnoccluded = false;
                            GlowObject.m_bFullBloom = Settings.GlowTeam.ChamsEnabled;

                            if (Settings.GlowTeam.ChamsEnabled && SDK.Arrays.Entity[i].m_iTeam == SDK.LocalPlayer.m_iTeam)
                            {
                                SDK.ChamsObject ChamsObject = new SDK.ChamsObject()
                                {
                                    r = Convert.ToByte(Settings.GlowTeam.Red),
                                    g = Convert.ToByte(Settings.GlowTeam.Green),
                                    b = Convert.ToByte(Settings.GlowTeam.Blue),
                                    a = 254
                                };

                                MemoryManager.WriteMemory<SDK.ChamsObject>(cEntity + 0x70, ChamsObject);
                            }

                            MemoryManager.WriteMemory<SDK.GlowObject>(SDK.LocalPlayer.m_iGlowBase + SDK.Arrays.Entity[i].m_iGlowIndex * 0x38, GlowObject);
                        }
                    }
                }
                Thread.Sleep(1);
            }
        }
    }
}