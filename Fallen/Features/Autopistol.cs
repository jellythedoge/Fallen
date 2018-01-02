using Fallen.API;
using Memory;
using System.Threading;
using System.Threading.Tasks;

namespace Fallen.Features
{
    internal class Autopistol
    {
        public static async void Run()
        {
            // /////////////
            // AUTO PISTOL//
            // /////////////

            while (true)
            {
                Thread.Sleep(1);

                if (Settings.Autopistol.Enabled)
                {
                    if (Settings.Autopistol.Key && SDK.HeldWeapon == "PISTOL" || Settings.Autopistol.Key && Settings.Autopistol.AnyGun)
                    {
                        MemoryManager.WriteMemory<bool>(MainClass.ClientPointer + Offsets.dwForceAttack, true);
                        await Task.Delay(1);
                        MemoryManager.WriteMemory<bool>(MainClass.ClientPointer + Offsets.dwForceAttack, false);
                    }
                }
            }
        }
    }
}