using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using Fallen.API;
using hazedumper;

namespace Fallen.Features
{
    internal class Bunny
    {
        internal void Run()
        {
            while (true)
            {
                if (Settings.Bhop.Enabled)
                {
                    var flag = MainClass.Memory.ReadInt(LocalPlayer.Base + 0x100);

                    if (flag == 257 && (Settings.Bhop.Key) || flag == 263 && (Settings.Bhop.Key))
                    {
                        MainClass.Memory.WriteInt(MainClass.ClientPointer + signatures.dwForceJump, 5);
                    }
                    else
                    {
                        MainClass.Memory.WriteInt(MainClass.ClientPointer + signatures.dwForceJump, 4);
                    }
                }
                Thread.Sleep(1);
            }
        }
    }
}
