using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Fallen.API;
using Fallen.Features;
using System.Diagnostics;

namespace Fallen.Features
{
    internal class Misc
    {
        internal void Run()
        {
            while (true)
            {
                var FovCheck = MainClass.Memory.ReadInt(LocalPlayer.Base + netvars.m_iFOV);
                var NohandsCheck = MainClass.Memory.ReadInt(LocalPlayer.Base + 0x254);
                bool EndFlash = (!Settings.NoflashEnabled);
                
                var Entity = new Entity();

                //-<swap>

                ///////////////
                //FOV CHANGER//
                ///////////////

                if (Settings.FovchangerEnabled)
                {
                    if (!MainClass.Memory.ReadBool(LocalPlayer.Base + netvars.m_bIsScoped))
                    {
                        if (FovCheck != Settings.Fov)
                        {
                            MainClass.Memory.WriteInt(LocalPlayer.Base + netvars.m_iFOV, Settings.Fov);
                        }
                    }
                }
                //-<block>

                ////////////
                //NO FLASH//
                ////////////

                if (Settings.NoflashEnabled || EndFlash)
                {
                    var FlashCheck = MainClass.Memory.ReadFloat(LocalPlayer.Base + netvars.m_flFlashMaxAlpha);

                    if (EndFlash)
                    {
                        if (FlashCheck == Settings.Flash && FlashCheck != 255)
                        {
                            MainClass.Memory.WriteFloat(LocalPlayer.Base + netvars.m_flFlashMaxAlpha, 255);
                            Console.WriteLine("Flash one");
                        }
                    }
                    else
                    {
                        if (FlashCheck != Settings.Flash && FlashCheck != 0)
                        {
                            MainClass.Memory.WriteFloat(LocalPlayer.Base + netvars.m_flFlashMaxAlpha, Settings.Flash);
                            Console.WriteLine(MainClass.Memory.ReadFloat(LocalPlayer.Base + netvars.m_flFlashMaxAlpha)); 
                        }
                    }
                }
                //-<block>

                ////////////
                //NO HANDS//
                ////////////

                if (Settings.NohandsEnabled && NohandsCheck != 0)
                {
                    MainClass.Memory.WriteInt(LocalPlayer.Base + 0x254, 0);
                }
                else if (!Settings.NohandsEnabled && NohandsCheck != 255)
                {
                    MainClass.Memory.WriteInt(LocalPlayer.Base + 0x254, 255);
                }
                //-<block>

                //-<swap/>

                Thread.Sleep(10);
            }
        }
    }
}