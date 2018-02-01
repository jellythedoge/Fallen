using Fallen.Managers;
using Fallen.Other;
using System.Threading;

namespace Fallen.Features
{
    internal class Autopistol
    {
        public static void Run()
        {
            while (true)
            {
                Thread.Sleep(5);

                if (Settings.Autopistol.Enabled) continue;

                if (Settings.Autopistol.Key && Checks.IsPistol() || Settings.Autopistol.Key && Settings.Autopistol.AnyGun)
                {
                    Memory.WriteMemory<bool>(Structs.Base.ClientPointer + Offsets.dwForceAttack, true);
                    Thread.Sleep(15);
                    Memory.WriteMemory<bool>(Structs.Base.ClientPointer + Offsets.dwForceAttack, false);
                }
            }
        }
    }
}