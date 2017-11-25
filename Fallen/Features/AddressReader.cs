#region

using System;
using Fallen.API;
using hazedumper;
using System.Threading;

#endregion

namespace Fallen.Features
{
    internal class AddressReader
    {
        internal void Run()
        {
            while (true)
            {
                ////////////////
                //LOCAL PLAYER//
                ////////////////

                LocalPlayer.Base = Memory.ProcessMemory.ReadMemory<int>(MainClass.ClientPointer + signatures.dwLocalPlayer);
                LocalPlayer.Team = Memory.ProcessMemory.ReadMemory<int>(LocalPlayer.Base + netvars.m_iTeamNum);
                LocalPlayer.ClientState = Memory.ProcessMemory.ReadMemory<int>(MainClass.EnginePointer + signatures.dwClientState);
                LocalPlayer.GlowBase = Memory.ProcessMemory.ReadMemory<int>(MainClass.ClientPointer + signatures.dwGlowObjectManager);
                LocalPlayer.JumpFlags = Memory.ProcessMemory.ReadMemory<int>(LocalPlayer.Base + netvars.m_fFlags);

                //////////////
                //MISC STUFF//
                //////////////

                LocalPlayer.GameState = Memory.ProcessMemory.ReadMemory<byte>(LocalPlayer.ClientState + 0x100);

                ////////////////
                //ENTITY STUFF//
                ////////////////

                for (var i = 0; i < 64; i++)
                {
                    var entity = Arrays.Entity[i];

                    entity.Base = Memory.ProcessMemory.ReadMemory<int>(MainClass.ClientPointer + signatures.dwEntityList + i * 0x10);

                    if (entity.Base != 0)
                    {
                        
                        entity.Team = Memory.ProcessMemory.ReadMemory<int>(entity.Base + netvars.m_iTeamNum);
                        entity.Health = Memory.ProcessMemory.ReadMemory<int>(entity.Base + netvars.m_iHealth);
                        entity.Dormant = Memory.ProcessMemory.ReadMemory<int>(entity.Base + 0xE9);
                        entity.GlowIndex = Memory.ProcessMemory.ReadMemory<int>(entity.Base + netvars.m_iGlowIndex);

                        Arrays.Entity[i] = entity;
                    }
                }
                Thread.Sleep(1);
            }
        }
    }
}