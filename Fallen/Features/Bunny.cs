using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using Fallen.API;

namespace Fallen.Features
{
    internal class Bunny
    {
        internal void Run()
        {
            while (true)
            {
                if (Settings.BhopEnabled)
                {
                    var flag = MainClass.Memory.ReadInt(LocalPlayer.Base + 0x100);

                    if (flag == 257 && (Settings.Spacedown) || flag == 263 && (Settings.Spacedown))
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
