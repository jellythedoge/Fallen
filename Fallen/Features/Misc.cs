using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using hazedumper;
using Fallen.API;
using Fallen.Features;
using System.Diagnostics;

namespace Fallen.Features
{
    internal class Misc
    {
        internal void Run()
        {
            var HitAmmount = 1;
            var player = new System.Media.SoundPlayer();

            while (true)
            {
                var FovCheck = Memory.ProcessMemory.ReadMemory<int>(LocalPlayer.Base + netvars.m_iFOV);
                var NohandsCheck = Memory.ProcessMemory.ReadMemory<int>(LocalPlayer.Base + 0x254);
                var HitVal = Memory.ProcessMemory.ReadMemory<int>(LocalPlayer.Base + 0xA2C8);
                bool EndFlash = (!Settings.Noflash.Enabled);
                
                ///////////////
                //FOV CHANGER//
                ///////////////

                if (Settings.Fovchanger.Enabled)
                {
                    if (!Memory.ProcessMemory.ReadMemory<bool>(LocalPlayer.Base + netvars.m_bIsScoped))
                    {
                        if (FovCheck != Settings.Fovchanger.Fov)
                        {
                            Memory.ProcessMemory.WriteMemory<int>(LocalPlayer.Base + netvars.m_iFOV, Settings.Fovchanger.Fov);
                        }
                    }
                }

                ////////////
                //NO FLASH//
                ////////////

                if (Settings.Noflash.Enabled || EndFlash)
                {
                    var FlashCheck = Memory.ProcessMemory.ReadMemory<float>(LocalPlayer.Base + netvars.m_flFlashMaxAlpha);

                    if (EndFlash)
                    {
                        if (FlashCheck == Settings.Noflash.Flash && FlashCheck != 255)
                        {
                            Memory.ProcessMemory.WriteMemory<float>(LocalPlayer.Base + netvars.m_flFlashMaxAlpha, 255);
                            Console.WriteLine("Flash one");
                        }
                    }
                    else
                    {
                        if (FlashCheck != Settings.Noflash.Flash && FlashCheck != 0)
                        {
                            Memory.ProcessMemory.WriteMemory<float>(LocalPlayer.Base + netvars.m_flFlashMaxAlpha, Settings.Noflash.Flash);
                            Console.WriteLine(Memory.ProcessMemory.ReadMemory<float>(LocalPlayer.Base + netvars.m_flFlashMaxAlpha)); 
                        }
                    }
                }

                ////////////
                //NO HANDS//
                ////////////

                if (Settings.Nohands.Enabled && NohandsCheck != 0)
                {
                    Memory.ProcessMemory.WriteMemory<int>(LocalPlayer.Base + 0x254, 0);
                }
                else if (!Settings.Nohands.Enabled && NohandsCheck != 317)
                {
                    Memory.ProcessMemory.WriteMemory<int>(LocalPlayer.Base + 0x254, 317);
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
                            player.Stream = Properties.Resources.cod;
                            player.Play();
                            HitAmmount = HitVal;
                        }
                    }
                    else if (Settings.Hitsound.Mode == 2)
                    {
                        if (HitAmmount != HitVal)
                        {
                            player.Stream = Properties.Resources.anime;
                            player.Play();
                            HitAmmount = HitVal;
                        }
                    }
                    else if (Settings.Hitsound.Mode == 3)
                    {
                        if (HitAmmount != HitVal)
                        {
                            player.Stream = Properties.Resources.bubble;
                            player.Play();
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