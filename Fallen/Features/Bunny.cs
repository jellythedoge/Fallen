#region

using Fallen.API;
using Memory;
using System.Threading;
using System.Threading.Tasks;

#endregion

namespace Fallen.Features
{
    internal class Bunny
    {
        internal async void Run()
        {
            bool bhopInitialized = false;
            var jumpsDone = 0;
            while (true)
            {
                Thread.Sleep(1);

                if (Settings.Bhop.Enabled)
                {
                    var flag = MemoryManager.ReadMemory<int>(SDK.LocalPlayer.m_iBase + 0x100);

                    //If user jumped, turn bhop, not possible when in chat or menu.
                    if (flag == 256 && !bhopInitialized)
                    {
                        bhopInitialized = true;
                        continue;
                    }
                    else if(!bhopInitialized && Settings.Bhop.Key)
                    {
                        bhopInitialized = false;
                        continue;
                    }
                    if (!Settings.Bhop.Key)
                        bhopInitialized = false;

                    if (flag == 257 && (Settings.Bhop.Key) || flag == 263 && (Settings.Bhop.Key))
                    {
                        if (Settings.Bhop.MaxJumps > jumpsDone || !Settings.Bhop.JumpLimit)
                        {
                            MemoryManager.WriteMemory<bool>(MainClass.ClientPointer + Offsets.dwForceJump, true);
                            jumpsDone++;
                            await Task.Delay(50);
                        }
                    }
                    else
                    {
                        MemoryManager.WriteMemory<bool>(MainClass.ClientPointer + Offsets.dwForceJump, false);
                    }

                    if (!Settings.Bhop.Key && Settings.Bhop.JumpLimit && jumpsDone > 1)
                    {
                        await Task.Delay(50);
                        jumpsDone = 0;
                    }
                }
            }
        }
    }
}
