#region

using Fallen.Managers;
using Fallen.Other;
using System.Threading;

#endregion

namespace Fallen.Features
{
    internal class Bunny
    {
        public static void Run()
        {
            var bhopInitialized = false;
            var jumpsDone = 0;
            while (true)
            {
                Thread.Sleep(5);

                if (!Settings.Bhop.Enabled) continue;

                var flag = Structs.LocalPlayer.m_fFlags;

                // If user jumped, turn bhop, not possible when in chat or menu.
                if (flag == 256 && !bhopInitialized)
                {
                    bhopInitialized = true;
                    continue;
                }
                else if (!bhopInitialized && Settings.Bhop.Key)
                {
                    bhopInitialized = false;
                    continue;
                }

                if (!Settings.Bhop.Key) bhopInitialized = false;

                if (flag == 257 && (Settings.Bhop.Key) || flag == 263 && (Settings.Bhop.Key))
                {
                    if (Settings.Bhop.MaxJumps > jumpsDone || !Settings.Bhop.JumpLimit)
                    {
                        Memory.WriteMemory<bool>(Structs.Base.ClientPointer + Offsets.dwForceJump, true);
                        jumpsDone++;
                        Thread.Sleep(50);
                    }
                }
                else
                {
                    Memory.WriteMemory<bool>(Structs.Base.ClientPointer + Offsets.dwForceJump, false);
                }

                if (!Settings.Bhop.Key && Settings.Bhop.JumpLimit && jumpsDone > 1)
                {
                    Thread.Sleep(50);
                    jumpsDone = 0;
                }
            }
        }
    }
}