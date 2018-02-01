#region

using Fallen.Managers;
using Fallen.Other;
using System.Threading;

#endregion

namespace Fallen.Features
{
    internal class Trigger
    {
        public static void Run()
        {
            while (true)
            {
                Thread.Sleep(5);

                if (Settings.Trigger.Enabled)
                {
                    if (Settings.Trigger.Key && Checks.EnemyInCross())
                    {
                        Memory.WriteMemory<bool>(Structs.Base.ClientPointer + Offsets.dwForceAttack, true);
                        Thread.Sleep(15);
                        Memory.WriteMemory<bool>(Structs.Base.ClientPointer + Offsets.dwForceAttack, false);
                    }
                }
            }
        }
    }
}