#region

using Fallen.API;
using Memory;
using System;
using System.Threading;
using System.Threading.Tasks;

#endregion

namespace Fallen.Features
{
    internal class Misc
    {
        internal async void Run()
        {
            var HitAmmount = MemoryManager.ReadMemory<int>(LocalPlayer.m_iBase + 0xA2C8);
            dynamic Sound = new System.Media.SoundPlayer();

            while (true)
            {
                var FovCheck = MemoryManager.ReadMemory<int>(LocalPlayer.m_iBase + Offsets.m_iFOV);
                var NohandsCheck = MemoryManager.ReadMemory<int>(LocalPlayer.m_iBase + 0x254);
                var HitVal = MemoryManager.ReadMemory<int>(LocalPlayer.m_iBase + 0xA2C8);
                bool EndFlash = (!Settings.NoFlash.Enabled);

                ///////////////
                //FOV CHANGER//
                ///////////////

                if (Settings.Fovchanger.Enabled)
                {
                    if (!MemoryManager.ReadMemory<bool>(LocalPlayer.m_iBase + Offsets.m_bIsScoped))
                    {
                        if (FovCheck != Settings.Fovchanger.Fov)
                        {
                            MemoryManager.WriteMemory<int>(LocalPlayer.m_iBase + Offsets.m_iFOV, Settings.Fovchanger.Fov);
                        }
                    }
                }

                ////////////
                //NO FLASH//
                ////////////

                if (Settings.NoFlash.Enabled || EndFlash)
                {
                    var FlashCheck = MemoryManager.ReadMemory<float>(LocalPlayer.m_iBase + Offsets.m_flFlashMaxAlpha);

                    if (EndFlash)
                    {
                        if (FlashCheck == Settings.NoFlash.Flash && FlashCheck != 255)
                        {
                            MemoryManager.WriteMemory<float>(LocalPlayer.m_iBase + Offsets.m_flFlashMaxAlpha, 255);
                            Console.WriteLine("Flash one");
                        }
                    }
                    else
                    {
                        if (FlashCheck != Settings.NoFlash.Flash && FlashCheck != 0)
                        {
                            MemoryManager.WriteMemory<float>(LocalPlayer.m_iBase + Offsets.m_flFlashMaxAlpha, Settings.NoFlash.Flash);
                            Console.WriteLine(MemoryManager.ReadMemory<float>(LocalPlayer.m_iBase + Offsets.m_flFlashMaxAlpha));
                        }
                    }
                }

                ////////////
                //NO HANDS//
                ////////////

                if (Settings.Nohands.Enabled && NohandsCheck != 0)
                {
                    MemoryManager.WriteMemory<int>(LocalPlayer.m_iBase + 0x254, 0);
                }
                else if (!Settings.Nohands.Enabled && NohandsCheck != 317)
                {
                    // MemoryManager.WriteMemory<int>(LocalPlayer.Base + 0x254, 317);
                }

                ///////////////
                //AUTO PISTOL//
                ///////////////

                if (Settings.Autopistol.Enabled)
                {
                    if (Settings.Autopistol.Key && SDK.HeldWeapon == "PISTOL" || Settings.Autopistol.Key && Settings.Autopistol.AnyGun)
                    {
                        MemoryManager.WriteMemory<bool>(MainClass.ClientPointer + Offsets.dwForceAttack, true);
                        await Task.Delay(10);
                        MemoryManager.WriteMemory<bool>(MainClass.ClientPointer + Offsets.dwForceAttack, false);
                    }
                }

                /////////////
                //HIT SOUND//
                /////////////

                if (Settings.Hitsound.Enabled)
                {
                    if (Settings.Hitsound.Mode == 1)
                    {
                        if (HitAmmount != HitVal)
                        {
                            Sound.Stream = Properties.Resources.cod;
                            Sound.Play();
                            HitAmmount = HitVal;
                        }
                    }
                    else if (Settings.Hitsound.Mode == 2)
                    {
                        if (HitAmmount != HitVal)
                        {
                            Sound.Stream = Properties.Resources.anime;
                            Sound.Play();
                            HitAmmount = HitVal;
                        }
                    }
                    else if (Settings.Hitsound.Mode == 3)
                    {
                        if (HitAmmount != HitVal)
                        {
                            Sound.Stream = Properties.Resources.bubble;
                            Sound.Play();
                            HitAmmount = HitVal;
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