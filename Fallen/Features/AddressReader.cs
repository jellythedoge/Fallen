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

                LocalPlayer.Base = MainClass.Memory.ReadInt(MainClass.ClientPointer + signatures.dwLocalPlayer);
                LocalPlayer.Team = MainClass.Memory.ReadInt(LocalPlayer.Base + netvars.m_iTeamNum);
                LocalPlayer.ClientState = MainClass.Memory.ReadInt(MainClass.EnginePointer + signatures.dwClientState);
                LocalPlayer.GlowBase = MainClass.Memory.ReadInt(MainClass.ClientPointer + signatures.dwGlowObjectManager);
                LocalPlayer.JumpFlags = MainClass.Memory.ReadInt(LocalPlayer.Base + netvars.m_fFlags);

                ////////////////
                //ENTITY STUFF//
                ////////////////

                for (var i = 0; i < 64; i++)
                {
                    var entity = Arrays.Entity[i];

                    entity.Base = MainClass.Memory.ReadInt(MainClass.ClientPointer + signatures.dwEntityList + i * 0x10);

                    if (entity.Base != 0)
                    {
                        
                        entity.Team = MainClass.Memory.ReadInt(entity.Base + netvars.m_iTeamNum);
                        entity.Health = MainClass.Memory.ReadInt(entity.Base + netvars.m_iHealth);
                        entity.Dormant = MainClass.Memory.ReadInt(entity.Base + 0xE9);
                        entity.GlowIndex = MainClass.Memory.ReadInt(entity.Base + netvars.m_iGlowIndex);

                        Arrays.Entity[i] = entity;
                    }
                }
                Thread.Sleep(1);
            }
        }
    }
}