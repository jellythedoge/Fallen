using Fallen.Managers;

namespace Fallen.Other
{
    internal class Checks
    {
        public static bool IsPistol()
        {
            if (Structs.Weapons.WeaponClass == (int)Enums.WeaponClass.PISTOL) return true; else return false;
        }

        public static bool m_bIsScoped() => Memory.ReadMemory<bool>(Structs.LocalPlayer.m_iBase + Offsets.m_bIsScoped);

        public static bool IsMyTeam()
        {
            for (var i = 0; i < 64; i++)
            {
                if (Structs.Arrays.Entity[i].m_iTeam == Structs.LocalPlayer.m_iTeamNum) return true; else return false;
            }

            return false;
        }

        public static bool EnemyInCross()
        {
            try
            {
                var entityInCrossId = Memory.ReadMemory<int>(Structs.LocalPlayer.m_iBase + Offsets.m_iCrosshairId);
                if (entityInCrossId != 0)
                {
                    var entityTeam = Memory.ReadMemory<int>(Structs.Arrays.Entity[entityInCrossId - 1].m_iBase + Offsets.m_iTeamNum);

                    if (Structs.LocalPlayer.m_iTeamNum != entityTeam) return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}