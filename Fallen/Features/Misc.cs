#region

using Fallen.API;
using Memory;
using System;
using System.Threading;

#endregion

namespace Fallen.Features
{
    internal class Misc
    {
        internal async void Run()
        {
            dynamic sound = new System.Media.SoundPlayer();

            while (true)
            {
                var fovCheck = MemoryManager.ReadMemory<int>(SDK.LocalPlayer.m_iBase + Offsets.m_iFOV);
                var nohandsCheck = MemoryManager.ReadMemory<int>(SDK.LocalPlayer.m_iBase + 0x254);
                var endFlash = (!Settings.NoFlash.Enabled);

                // /////////////
                // FOV CHANGER//
                // /////////////

                if (Settings.Fovchanger.Enabled)
                {
                    if (!SDK.m_bIsScoped)
                    {
                        if (fovCheck != Settings.Fovchanger.Fov)
                        {
                            MemoryManager.WriteMemory<int>(SDK.LocalPlayer.m_iBase + Offsets.m_iFOV, Settings.Fovchanger.Fov);
                        }
                    }
                }

                // //////////
                // NO FLASH//
                // //////////

                if (Settings.NoFlash.Enabled || endFlash)
                {
                    var flashCheck = MemoryManager.ReadMemory<float>(SDK.LocalPlayer.m_iBase + Offsets.m_flFlashMaxAlpha);

                    if (endFlash)
                    {
                        if (flashCheck == Settings.NoFlash.Flash && flashCheck != 255)
                        {
                            MemoryManager.WriteMemory<float>(SDK.LocalPlayer.m_iBase + Offsets.m_flFlashMaxAlpha, 255);
                            Console.WriteLine("Flash one");
                        }
                    }
                    else
                    {
                        if (flashCheck != Settings.NoFlash.Flash && flashCheck != 0)
                        {
                            MemoryManager.WriteMemory<float>(SDK.LocalPlayer.m_iBase + Offsets.m_flFlashMaxAlpha, Settings.NoFlash.Flash);
                            Console.WriteLine(MemoryManager.ReadMemory<float>(SDK.LocalPlayer.m_iBase + Offsets.m_flFlashMaxAlpha));
                        }
                    }
                }

                // //////////
                // NO HANDS//
                // //////////

                if (Settings.Nohands.Enabled && nohandsCheck != 0)
                {
                    MemoryManager.WriteMemory<int>(SDK.LocalPlayer.m_iBase + 0x254, 0);
                }
                else if (!Settings.Nohands.Enabled && nohandsCheck != 317)
                {
                    // MemoryManager.WriteMemory<int>(SDK.LocalPlayer.Base + 0x254, 317);
                }

                // ///////////
                // HIT SOUND//
                // ///////////

                if (Settings.Hitsound.Enabled)
                {
                    if (Settings.Hitsound.Mode == 1)
                    {
                        if (SDK.HitAmmount != SDK.HitVal)
                        {
                            sound.Stream = Properties.Resources.cod;
                            sound.Play();
                            SDK.HitAmmount = SDK.HitVal;
                        }
                    }
                    else if (Settings.Hitsound.Mode == 2)
                    {
                        if (SDK.HitAmmount != SDK.HitVal)
                        {
                            sound.Stream = Properties.Resources.anime;
                            sound.Play();
                            SDK.HitAmmount = SDK.HitVal;
                        }
                    }
                    else if (Settings.Hitsound.Mode == 3)
                    {
                        if (SDK.HitAmmount != SDK.HitVal)
                        {
                            sound.Stream = Properties.Resources.bubble;
                            sound.Play();
                            SDK.HitAmmount = SDK.HitVal;
                        }
                    }
                    else
                    {
                        Settings.Hitsound.Mode = 1;
                    }
                }

                Thread.Sleep(10);
            }
        }
    }
}