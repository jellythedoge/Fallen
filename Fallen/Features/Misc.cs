#region

using Fallen.Managers;
using Fallen.Other;
using System.Media;
using System.Threading;

#endregion

namespace Fallen.Features
{
    internal class Misc
    {
        public static void Run()
        {
            var currentHits = Memory.ReadMemory<int>(Structs.LocalPlayer.m_iBase + Offsets.m_totalHitsOnServer);

            var sound = new SoundPlayer();

            while (true)
            {
                Thread.Sleep(5);

                var hitsOnServer = Memory.ReadMemory<int>(Structs.LocalPlayer.m_iBase + Offsets.m_totalHitsOnServer);
                var currentFOV = Memory.ReadMemory<int>(Structs.LocalPlayer.m_iBase + Offsets.m_iFOV);
                var currentHands = Memory.ReadMemory<int>(Structs.LocalPlayer.m_iBase + 0x254);
                var endFlash = (!Settings.NoFlash.Enabled);

                // /////////////
                // FOV CHANGER//
                // /////////////

                if (Settings.Fovchanger.Enabled)
                {
                    if (!Checks.m_bIsScoped())
                    {
                        if (currentFOV != Settings.Fovchanger.Fov)
                        {
                            Memory.WriteMemory<int>(Structs.LocalPlayer.m_iBase + Offsets.m_iFOV, Settings.Fovchanger.Fov);
                        }
                    }
                }

                // //////////
                // NO FLASH//
                // //////////

                if (Settings.NoFlash.Enabled || endFlash)
                {
                    var flashCheck = Memory.ReadMemory<float>(Structs.LocalPlayer.m_iBase + Offsets.m_flFlashMaxAlpha);

                    if (endFlash)
                    {
                        if (flashCheck == Settings.NoFlash.Flash && flashCheck != 255)
                        {
                            Memory.WriteMemory<float>(Structs.LocalPlayer.m_iBase + Offsets.m_flFlashMaxAlpha, 255);
                        }
                    }
                    else
                    {
                        if (flashCheck != Settings.NoFlash.Flash && flashCheck != 0)
                        {
                            Memory.WriteMemory<float>(Structs.LocalPlayer.m_iBase + Offsets.m_flFlashMaxAlpha, Settings.NoFlash.Flash);
                        }
                    }
                }

                // //////////
                // NO HANDS//
                // //////////

                if (Settings.Nohands.Enabled && currentHands != 0)
                {
                    Memory.WriteMemory<int>(Structs.LocalPlayer.m_iBase + 0x254, 0);
                }
                else if (!Settings.Nohands.Enabled && currentHands != 317)
                {
                    // Memory.WriteMemory<int>(Structs.LocalPlayer.Base + 0x254, 317);
                }

                // ///////////
                // HIT SOUND//
                // ///////////

                if (Settings.Hitsound.Enabled && currentHits != hitsOnServer)
                {
                    if (hitsOnServer > currentHits)
                    {
                        if (Settings.Hitsound.Mode == 1)
                        {
                            sound.Stream = Properties.Resources.cod; sound.Play();
                        }
                        else if (Settings.Hitsound.Mode == 2)
                        {
                            sound.Stream = Properties.Resources.anime; sound.Play();
                        }
                        else if (Settings.Hitsound.Mode == 3)
                        {
                            sound.Stream = Properties.Resources.bubble; sound.Play();
                        }
                        else
                        {
                            Settings.Hitsound.Mode = 1;
                        }
                    }

                    currentHits = hitsOnServer;
                }
            }
        }
    }
}