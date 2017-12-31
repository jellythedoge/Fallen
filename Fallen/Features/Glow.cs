#region

using Fallen.API;
using Memory;
using System.Threading;
using System.Drawing;
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
                    if (Arrays.Entity[i].m_iBase == 0)
                        continue;
                    if (Arrays.Entity[i].m_iBase == LocalPlayer.m_iBase)
                        continue;
                    if (Arrays.Entity[i].m_iHealth < 1)
                        continue;
                    if (Arrays.Entity[i].m_iDormant == 1)
                        continue;

                    int cEntity = MemoryManager.ReadMemory<int>(MainClass.ClientPointer + Offsets.dwEntityList + (i - 1) * 16);

                    SDK.GlowObject GlowObject = new SDK.GlowObject();
                    SDK.ChamsObject ChamsObject = new SDK.ChamsObject();

                    if (Arrays.Entity[i].m_iTeam != LocalPlayer.m_iTeam)
                    {
                        if (Settings.GlowEnemy.Enabled)
                        {
                            GlowObject = MemoryManager.ReadMemory<SDK.GlowObject>(LocalPlayer.m_iGlowBase + Arrays.Entity[i].m_iGlowIndex * 0x38);

                            GlowObject.r = Settings.GlowEnemy.Red / 255;
                            GlowObject.g = Settings.GlowEnemy.Green / 255;
                            GlowObject.b = Settings.GlowEnemy.Blue / 255;
                            GlowObject.a = Settings.GlowEnemy.Alpha / 255;
                            GlowObject.m_bRenderWhenOccluded = true;
                            GlowObject.m_bRenderWhenUnoccluded = false;
                            GlowObject.m_bFullBloom = Settings.GlowEnemy.ChamsEnabled;

                            if (Settings.GlowEnemy.ChamsEnabled)
                            {
                                GlowObject.m_bFullBloom = Settings.GlowEnemy.ChamsEnabled;

                                ChamsObject.r = Convert.ToByte(Settings.GlowEnemy.Red);
                                ChamsObject.g = Convert.ToByte(Settings.GlowEnemy.Green);
                                ChamsObject.b = Convert.ToByte(Settings.GlowEnemy.Blue);
                                ChamsObject.a = 254;

                                MemoryManager.WriteMemory<SDK.ChamsObject>(cEntity + 0x70, ChamsObject);

                            }
                            else
                            {
                                GlowObject.m_bFullBloom = Settings.GlowEnemy.ChamsEnabled;
                            }

                            MemoryManager.WriteMemory<SDK.GlowObject>(LocalPlayer.m_iGlowBase + Arrays.Entity[i].m_iGlowIndex * 0x38, GlowObject);
                        }
                    }

                    if (Arrays.Entity[i].m_iTeam == LocalPlayer.m_iTeam)
                    {
                        if (Settings.GlowTeam.Enabled)
                        {
                            GlowObject = MemoryManager.ReadMemory<SDK.GlowObject>(LocalPlayer.m_iGlowBase + Arrays.Entity[i].m_iGlowIndex * 0x38);

                            GlowObject.r = Settings.GlowTeam.Red / 255;
                            GlowObject.g = Settings.GlowEnemy.Green / 255;
                            GlowObject.b = Settings.GlowTeam.Blue / 255;
                            GlowObject.a = Settings.GlowTeam.Alpha / 254;
                            GlowObject.m_bRenderWhenOccluded = true;
                            GlowObject.m_bRenderWhenUnoccluded = false;

                            if (Settings.GlowTeam.ChamsEnabled)
                            {
                                GlowObject.m_bFullBloom = Settings.GlowTeam.ChamsEnabled;

                                ChamsObject.r = Convert.ToByte(Settings.GlowTeam.Red);
                                ChamsObject.g = Convert.ToByte(Settings.GlowTeam.Green);
                                ChamsObject.b = Convert.ToByte(Settings.GlowTeam.Blue);
                                ChamsObject.a = 254;


                                MemoryManager.WriteMemory<SDK.ChamsObject>(cEntity + 0x70, ChamsObject);

                            }
                            else
                            {
                                GlowObject.m_bFullBloom = Settings.GlowTeam.ChamsEnabled;
                            }

                            MemoryManager.WriteMemory<SDK.GlowObject>(LocalPlayer.m_iGlowBase + Arrays.Entity[i].m_iGlowIndex * 0x38, GlowObject);
                        }
                    }


                }
                Thread.Sleep(1);
            }
        }
    }
}