
using Fallen.Other;
using System.Threading;

namespace Fallen.Managers
{
    internal class Reader
    {
        public static void Run()
        {
            while (true)
            {
                Thread.Sleep(5);

                Structs.LocalPlayer.m_iBase = Memory.ReadMemory<int>(Structs.Base.ClientPointer + Offsets.dwLocalPlayer);
                Structs.LocalPlayer.m_iTeamNum = Memory.ReadMemory<int>(Structs.LocalPlayer.m_iBase + Offsets.m_iTeamNum);
                Structs.LocalPlayer.m_iClientState = Memory.ReadMemory<int>(Structs.Base.EnginePointer + Offsets.dwClientState);
                Structs.LocalPlayer.m_iGlowBase = Memory.ReadMemory<int>(Structs.Base.ClientPointer + Offsets.dwGlowObjectManager);
                Structs.LocalPlayer.m_fFlags = Memory.ReadMemory<int>(Structs.LocalPlayer.m_iBase + Offsets.m_fFlags);
                Structs.LocalPlayer.m_iCrosshairID = Memory.ReadMemory<int>(Structs.LocalPlayer.m_iBase + Offsets.m_iCrosshairId);
                Structs.LocalPlayer.m_Lifestate = Memory.ReadMemory<int>(Structs.LocalPlayer.m_iBase + Offsets.m_lifeState);

                for (var i = 0; i < 64; i++)
                {
                    var entity = Structs.Arrays.Entity[i];

                    entity.m_iBase = Memory.ReadMemory<int>(Structs.Base.ClientPointer + Offsets.dwEntityList + (i - 1) * 0x10);

                    if (entity.m_iBase != 0)
                    {
                        var entityStruct = new Structs.Entity_t();

                        entityStruct = Memory.ReadMemory<Structs.Entity_t>(entity.m_iBase);

                        entity.m_VecOrigin = entityStruct.m_vecOrigin;
                        entity.m_VecMin = entityStruct.m_vecMins;
                        entity.m_VecMax = entityStruct.m_vecMaxs;

                        entity.m_iTeam = entityStruct.m_iTeamNum;
                        entity.m_iHealth = entityStruct.m_iHealth;
                        entity.m_iDormant = entityStruct.m_iDormant;
                        entity.m_iGlowIndex = entityStruct.m_iGlowIndex;

                        Structs.Arrays.Entity[i] = entity;
                    }
                }

                for (var i = 0; i < 16; i++)
                {
                    var ActiveWeapon = Memory.ReadMemory<int>(Structs.LocalPlayer.m_iBase + Offsets.m_hActiveWeapon + (i - 1) * 0x4) & 0xFFF;

                    var WeaponBase = Memory.ReadMemory<int>(Structs.Base.ClientPointer + Offsets.dwEntityList + (ActiveWeapon - 1) * 0x10);

                    var WeaponHandle = Memory.ReadMemory<int>(WeaponBase + Offsets.m_iItemDefinitionIndex);

                    switch (WeaponHandle)
                    {
                        #region RIFLE

                        case (int)Enums.ItemDefinitionIndex.WEAPON_AK47:
                            Structs.Weapons.WeaponClass = (int)Enums.WeaponClass.RIFLE;

                            break;

                        case (int)Enums.ItemDefinitionIndex.WEAPON_AUG:
                            Structs.Weapons.WeaponClass = (int)Enums.WeaponClass.RIFLE;

                            break;

                        case (int)Enums.ItemDefinitionIndex.WEAPON_AWP:
                            Structs.Weapons.WeaponClass = (int)Enums.WeaponClass.RIFLE;

                            break;

                        case (int)Enums.ItemDefinitionIndex.WEAPON_BIZON:
                            Structs.Weapons.WeaponClass = (int)Enums.WeaponClass.RIFLE;

                            break;

                        case (int)Enums.ItemDefinitionIndex.WEAPON_FAMAS:
                            Structs.Weapons.WeaponClass = (int)Enums.WeaponClass.RIFLE;

                            break;

                        case (int)Enums.ItemDefinitionIndex.WEAPON_G3SG1:
                            Structs.Weapons.WeaponClass = (int)Enums.WeaponClass.RIFLE;

                            break;

                        case (int)Enums.ItemDefinitionIndex.WEAPON_GALILAR:
                            Structs.Weapons.WeaponClass = (int)Enums.WeaponClass.RIFLE;

                            break;

                        case (int)Enums.ItemDefinitionIndex.WEAPON_M4A1:
                            Structs.Weapons.WeaponClass = (int)Enums.WeaponClass.RIFLE;

                            break;

                        case (int)Enums.ItemDefinitionIndex.WEAPON_SCAR20:
                            Structs.Weapons.WeaponClass = (int)Enums.WeaponClass.RIFLE;

                            break;

                        case (int)Enums.ItemDefinitionIndex.WEAPON_SG556:
                            Structs.Weapons.WeaponClass = (int)Enums.WeaponClass.RIFLE;

                            break;

                        case (int)Enums.ItemDefinitionIndex.WEAPON_SSG08:
                            Structs.Weapons.WeaponClass = (int)Enums.WeaponClass.RIFLE;

                            break;

                        case (int)Enums.ItemDefinitionIndex.WEAPON_M4A1_SILENCER:
                            Structs.Weapons.WeaponClass = (int)Enums.WeaponClass.RIFLE;

                            break;

                        #endregion

                        #region SMG

                        case (int)Enums.ItemDefinitionIndex.WEAPON_MAC10:
                            Structs.Weapons.WeaponClass = (int)Enums.WeaponClass.SMG;

                            break;

                        case (int)Enums.ItemDefinitionIndex.WEAPON_P90:
                            Structs.Weapons.WeaponClass = (int)Enums.WeaponClass.SMG;

                            break;

                        case (int)Enums.ItemDefinitionIndex.WEAPON_UMP45:
                            Structs.Weapons.WeaponClass = (int)Enums.WeaponClass.SMG;

                            break;

                        case (int)Enums.ItemDefinitionIndex.WEAPON_MP7:
                            Structs.Weapons.WeaponClass = (int)Enums.WeaponClass.SMG;

                            break;

                        case (int)Enums.ItemDefinitionIndex.WEAPON_MP9:
                            Structs.Weapons.WeaponClass = (int)Enums.WeaponClass.SMG;

                            break;

                        #endregion

                        #region HEAVY

                        case (int)Enums.ItemDefinitionIndex.WEAPON_NEGEV:
                            Structs.Weapons.WeaponClass = (int)Enums.WeaponClass.HEAVY;

                            break;

                        case (int)Enums.ItemDefinitionIndex.WEAPON_M249:
                            Structs.Weapons.WeaponClass = (int)Enums.WeaponClass.HEAVY;

                            break;

                        #endregion

                        #region PISTOL

                        case (int)Enums.ItemDefinitionIndex.WEAPON_DEAGLE:
                            Structs.Weapons.WeaponClass = (int)Enums.WeaponClass.PISTOL;

                            break;

                        case (int)Enums.ItemDefinitionIndex.WEAPON_ELITE:
                            Structs.Weapons.WeaponClass = (int)Enums.WeaponClass.PISTOL;

                            break;

                        case (int)Enums.ItemDefinitionIndex.WEAPON_FIVESEVEN:
                            Structs.Weapons.WeaponClass = (int)Enums.WeaponClass.PISTOL;

                            break;

                        case (int)Enums.ItemDefinitionIndex.WEAPON_GLOCK:
                            Structs.Weapons.WeaponClass = (int)Enums.WeaponClass.PISTOL;

                            break;

                        case (int)Enums.ItemDefinitionIndex.WEAPON_TEC9:
                            Structs.Weapons.WeaponClass = (int)Enums.WeaponClass.PISTOL;

                            break;

                        case (int)Enums.ItemDefinitionIndex.WEAPON_HKP2000:
                            Structs.Weapons.WeaponClass = (int)Enums.WeaponClass.PISTOL;

                            break;

                        case (int)Enums.ItemDefinitionIndex.WEAPON_USP_SILENCER:
                            Structs.Weapons.WeaponClass = (int)Enums.WeaponClass.PISTOL;

                            break;

                        case (int)Enums.ItemDefinitionIndex.WEAPON_P250:
                            Structs.Weapons.WeaponClass = (int)Enums.WeaponClass.PISTOL;

                            break;

                        #endregion

                        #region SHOTGUN

                        case (int)Enums.ItemDefinitionIndex.WEAPON_XM1014:
                            Structs.Weapons.WeaponClass = (int)Enums.WeaponClass.SHOTGUN;

                            break;

                        case (int)Enums.ItemDefinitionIndex.WEAPON_MAG7:
                            Structs.Weapons.WeaponClass = (int)Enums.WeaponClass.SHOTGUN;

                            break;

                        case (int)Enums.ItemDefinitionIndex.WEAPON_SAWEDOFF:
                            Structs.Weapons.WeaponClass = (int)Enums.WeaponClass.SHOTGUN;

                            break;

                        case (int)Enums.ItemDefinitionIndex.WEAPON_NOVA:
                            Structs.Weapons.WeaponClass = (int)Enums.WeaponClass.SHOTGUN;

                            break;

                        #endregion

                        #region KNIFE

                        case (int)Enums.ItemDefinitionIndex.WEAPON_KNIFE:
                            Structs.Weapons.WeaponClass = (int)Enums.WeaponClass.KNIFE;

                            break;

                        #endregion

                        #region OTHER

                        case (int)Enums.ItemDefinitionIndex.WEAPON_FLASHBANG:
                            Structs.Weapons.WeaponClass = (int)Enums.WeaponClass.OTHER;

                            break;

                        case (int)Enums.ItemDefinitionIndex.WEAPON_HEGRENADE:
                            Structs.Weapons.WeaponClass = (int)Enums.WeaponClass.OTHER;

                            break;

                        case (int)Enums.ItemDefinitionIndex.WEAPON_MOLOTOV:
                            Structs.Weapons.WeaponClass = (int)Enums.WeaponClass.OTHER;

                            break;

                        case (int)Enums.ItemDefinitionIndex.WEAPON_DECOY:
                            Structs.Weapons.WeaponClass = (int)Enums.WeaponClass.OTHER;

                            break;


                        case (int)Enums.ItemDefinitionIndex.WEAPON_INCGRENADE:
                            Structs.Weapons.WeaponClass = (int)Enums.WeaponClass.OTHER;

                            break;

                        #endregion

                        default:

                            break;
                    }
                }
            }
        }
    }
}
