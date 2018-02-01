#region

using Fallen.Managers;
using Fallen.Other;
using System.Threading;

#endregion

namespace Fallen.Features
{
    internal class Skinchanger
    {
        public static void Run()
        {
            while (true)
            {
                Thread.Sleep(3);

                if (Settings.Skinchanger.Enabled) continue;

                int overrideTexture;

                int statTrak;

                int itemDefinition;

                for (var i = 1; i < 16; ++i)
                {
                    var MyWeapons = Memory.ReadMemory<int>(Structs.LocalPlayer.m_iBase + Offsets.m_hMyWeapons + (i - 1) * 0x4) & 0xFFF;

                    Structs.Weapons.m_iBase = Memory.ReadMemory<int>(Structs.Base.ClientPointer + Offsets.dwEntityList + (MyWeapons - 1) * 0x10);

                    Structs.Weapons.m_iItemDefinitionIndex = Memory.ReadMemory<int>(Structs.Weapons.m_iBase + Offsets.m_iItemDefinitionIndex);

                    Structs.Weapons.m_iXuIDLow = Memory.ReadMemory<int>(Structs.Weapons.m_iBase + Offsets.m_OriginalOwnerXuidLow);

                    Structs.Weapons.m_iTexture = Memory.ReadMemory<int>(Structs.Weapons.m_iBase + Offsets.m_nFallbackPaintKit);

                    switch (Structs.Weapons.m_iItemDefinitionIndex)
                    {
                        #region RIFLES

                        case (int)Enums.ItemDefinitionIndex.WEAPON_AK47:
                            overrideTexture = Settings.Skinchanger.WEAPON_AK47;
                            statTrak = -1;
                            itemDefinition = (int)Enums.ItemDefinitionIndex.WEAPON_AK47;
                            break;

                        case (int)Enums.ItemDefinitionIndex.WEAPON_AUG:
                            overrideTexture = Settings.Skinchanger.WEAPON_AUG;
                            statTrak = -1;
                            itemDefinition = (int)Enums.ItemDefinitionIndex.WEAPON_AUG;
                            break;

                        case (int)Enums.ItemDefinitionIndex.WEAPON_AWP:
                            overrideTexture = Settings.Skinchanger.WEAPON_AWP;
                            statTrak = -1;
                            itemDefinition = (int)Enums.ItemDefinitionIndex.WEAPON_AWP;
                            break;

                        case (int)Enums.ItemDefinitionIndex.WEAPON_BIZON:
                            overrideTexture = Settings.Skinchanger.WEAPON_BIZON;
                            statTrak = -1;
                            itemDefinition = (int)Enums.ItemDefinitionIndex.WEAPON_BIZON;
                            break;

                        case (int)Enums.ItemDefinitionIndex.WEAPON_FAMAS:
                            overrideTexture = Settings.Skinchanger.WEAPON_FAMAS;
                            statTrak = -1;
                            itemDefinition = (int)Enums.ItemDefinitionIndex.WEAPON_FAMAS;
                            break;

                        case (int)Enums.ItemDefinitionIndex.WEAPON_G3SG1:
                            overrideTexture = Settings.Skinchanger.WEAPON_G3SG1;
                            statTrak = -1;
                            itemDefinition = (int)Enums.ItemDefinitionIndex.WEAPON_G3SG1;
                            break;

                        case (int)Enums.ItemDefinitionIndex.WEAPON_GALILAR:
                            overrideTexture = Settings.Skinchanger.WEAPON_GALILAR;
                            statTrak = -1;
                            itemDefinition = (int)Enums.ItemDefinitionIndex.WEAPON_GALILAR;
                            break;

                        case (int)Enums.ItemDefinitionIndex.WEAPON_M4A1:
                            overrideTexture = Settings.Skinchanger.WEAPON_M4A1;
                            statTrak = -1;
                            itemDefinition = (int)Enums.ItemDefinitionIndex.WEAPON_M4A1;
                            break;

                        case (int)Enums.ItemDefinitionIndex.WEAPON_SCAR20:
                            overrideTexture = Settings.Skinchanger.WEAPON_SCAR20;
                            statTrak = -1;
                            itemDefinition = (int)Enums.ItemDefinitionIndex.WEAPON_SCAR20;
                            break;

                        case (int)Enums.ItemDefinitionIndex.WEAPON_SG556:
                            overrideTexture = Settings.Skinchanger.WEAPON_SG556;
                            statTrak = -1;
                            itemDefinition = (int)Enums.ItemDefinitionIndex.WEAPON_SG556;
                            break;

                        case (int)Enums.ItemDefinitionIndex.WEAPON_SSG08:
                            overrideTexture = Settings.Skinchanger.WEAPON_SSG08;
                            statTrak = -1;
                            itemDefinition = (int)Enums.ItemDefinitionIndex.WEAPON_SSG08;
                            break;

                        case (int)Enums.ItemDefinitionIndex.WEAPON_M4A1_SILENCER:
                            overrideTexture = Settings.Skinchanger.WEAPON_M4A1_SILENCER;
                            statTrak = -1;
                            itemDefinition = (int)Enums.ItemDefinitionIndex.WEAPON_M4A1_SILENCER;
                            break;

                        #endregion

                        #region SMG

                        case (int)Enums.ItemDefinitionIndex.WEAPON_MAC10:
                            overrideTexture = Settings.Skinchanger.WEAPON_MAC10;
                            statTrak = -1;
                            itemDefinition = (int)Enums.ItemDefinitionIndex.WEAPON_MAC10;
                            break;

                        case (int)Enums.ItemDefinitionIndex.WEAPON_P90:
                            overrideTexture = Settings.Skinchanger.WEAPON_P90;
                            statTrak = -1;
                            itemDefinition = (int)Enums.ItemDefinitionIndex.WEAPON_P90;
                            break;

                        case (int)Enums.ItemDefinitionIndex.WEAPON_UMP45:
                            overrideTexture = Settings.Skinchanger.WEAPON_UMP45;
                            statTrak = -1;
                            itemDefinition = (int)Enums.ItemDefinitionIndex.WEAPON_UMP45;
                            break;

                        case (int)Enums.ItemDefinitionIndex.WEAPON_MP7:
                            overrideTexture = Settings.Skinchanger.WEAPON_MP7;
                            statTrak = -1;
                            itemDefinition = (int)Enums.ItemDefinitionIndex.WEAPON_MP7;
                            break;

                        case (int)Enums.ItemDefinitionIndex.WEAPON_MP9:
                            overrideTexture = Settings.Skinchanger.WEAPON_MP9;
                            statTrak = -1;
                            itemDefinition = (int)Enums.ItemDefinitionIndex.WEAPON_MP9;
                            break;

                        #endregion

                        #region HEAVY

                        case (int)Enums.ItemDefinitionIndex.WEAPON_NEGEV:
                            overrideTexture = Settings.Skinchanger.WEAPON_NEGEV;
                            statTrak = -1;
                            itemDefinition = (int)Enums.ItemDefinitionIndex.WEAPON_NEGEV;
                            break;

                        case (int)Enums.ItemDefinitionIndex.WEAPON_M249:
                            overrideTexture = Settings.Skinchanger.WEAPON_M249;
                            statTrak = -1;
                            itemDefinition = (int)Enums.ItemDefinitionIndex.WEAPON_M249;
                            break;

                        #endregion

                        #region PISTOLS

                        case (int)Enums.ItemDefinitionIndex.WEAPON_DEAGLE:
                            overrideTexture = Settings.Skinchanger.WEAPON_DEAGLE;
                            statTrak = -1;
                            itemDefinition = (int)Enums.ItemDefinitionIndex.WEAPON_DEAGLE;
                            break;

                        case (int)Enums.ItemDefinitionIndex.WEAPON_ELITE:
                            overrideTexture = Settings.Skinchanger.WEAPON_ELITE;
                            statTrak = -1;
                            itemDefinition = (int)Enums.ItemDefinitionIndex.WEAPON_ELITE;
                            break;

                        case (int)Enums.ItemDefinitionIndex.WEAPON_FIVESEVEN:
                            overrideTexture = Settings.Skinchanger.WEAPON_FIVESEVEN;
                            statTrak = -1;
                            itemDefinition = (int)Enums.ItemDefinitionIndex.WEAPON_FIVESEVEN;
                            break;

                        case (int)Enums.ItemDefinitionIndex.WEAPON_GLOCK:
                            overrideTexture = Settings.Skinchanger.WEAPON_GLOCK;
                            statTrak = -1;
                            itemDefinition = (int)Enums.ItemDefinitionIndex.WEAPON_GLOCK;
                            break;

                        case (int)Enums.ItemDefinitionIndex.WEAPON_TEC9:
                            overrideTexture = Settings.Skinchanger.WEAPON_TEC9;
                            statTrak = -1;
                            itemDefinition = (int)Enums.ItemDefinitionIndex.WEAPON_TEC9;
                            break;

                        case (int)Enums.ItemDefinitionIndex.WEAPON_HKP2000:
                            overrideTexture = Settings.Skinchanger.WEAPON_HKP2000;
                            statTrak = -1;
                            itemDefinition = (int)Enums.ItemDefinitionIndex.WEAPON_HKP2000;
                            break;

                        case (int)Enums.ItemDefinitionIndex.WEAPON_USP_SILENCER:
                            overrideTexture = Settings.Skinchanger.WEAPON_USP_SILENCER;
                            statTrak = -1;
                            itemDefinition = (int)Enums.ItemDefinitionIndex.WEAPON_USP_SILENCER;
                            break;

                        case (int)Enums.ItemDefinitionIndex.WEAPON_CZ75A:
                            overrideTexture = Settings.Skinchanger.WEAPON_CZ75A;
                            statTrak = -1;
                            itemDefinition = (int)Enums.ItemDefinitionIndex.WEAPON_CZ75A;
                            break;

                        case (int)Enums.ItemDefinitionIndex.WEAPON_REVOLVER:
                            overrideTexture = Settings.Skinchanger.WEAPON_REVOLVER;
                            statTrak = -1;
                            itemDefinition = (int)Enums.ItemDefinitionIndex.WEAPON_REVOLVER;
                            break;

                        case (int)Enums.ItemDefinitionIndex.WEAPON_P250:
                            overrideTexture = Settings.Skinchanger.WEAPON_P250;
                            statTrak = -1;
                            itemDefinition = (int)Enums.ItemDefinitionIndex.WEAPON_P250;
                            break;

                        #endregion

                        #region SHOTGUNS

                        case (int)Enums.ItemDefinitionIndex.WEAPON_XM1014:
                            overrideTexture = Settings.Skinchanger.WEAPON_XM1014;
                            statTrak = -1;
                            itemDefinition = (int)Enums.ItemDefinitionIndex.WEAPON_XM1014;
                            break;

                        case (int)Enums.ItemDefinitionIndex.WEAPON_MAG7:
                            overrideTexture = Settings.Skinchanger.WEAPON_MAG7;
                            statTrak = -1;
                            itemDefinition = (int)Enums.ItemDefinitionIndex.WEAPON_MAG7;
                            break;

                        case (int)Enums.ItemDefinitionIndex.WEAPON_SAWEDOFF:
                            overrideTexture = Settings.Skinchanger.WEAPON_SAWEDOFF;
                            statTrak = -1;
                            itemDefinition = (int)Enums.ItemDefinitionIndex.WEAPON_SAWEDOFF;
                            break;

                        case (int)Enums.ItemDefinitionIndex.WEAPON_NOVA:
                            overrideTexture = Settings.Skinchanger.WEAPON_NOVA;
                            statTrak = -1;
                            itemDefinition = (int)Enums.ItemDefinitionIndex.WEAPON_NOVA;
                            break;

                        #endregion

                        default:
                            overrideTexture = 1337;
                            statTrak = 1337;
                            itemDefinition = 1337;
                            break;
                    }

                    if (Structs.Weapons.m_iTexture != overrideTexture && overrideTexture != 1337)
                    {
                        Memory.WriteMemory<int>(Structs.Weapons.m_iBase + Offsets.m_iItemIDLow, -1);
                        Memory.WriteMemory<int>(Structs.Weapons.m_iBase + Offsets.m_nFallbackPaintKit, overrideTexture);
                        Memory.WriteMemory<int>(Structs.Weapons.m_iBase + Offsets.m_nFallbackSeed, 661);
                        Memory.WriteMemory<int>(Structs.Weapons.m_iBase + Offsets.m_nFallbackStatTrak, statTrak);
                        Memory.WriteMemory<float>(Structs.Weapons.m_iBase + Offsets.m_flFallbackWear, 0.000000001f);
                        Memory.WriteMemory<int>(Structs.Weapons.m_iBase + Offsets.m_iAccountID, Structs.Weapons.m_iXuIDLow);
                        Memory.WriteMemory<int>(Structs.Weapons.m_iBase + Offsets.m_iItemDefinitionIndex, itemDefinition);

                        Extensions.cl_fullupdate();
                    }
                }
            }
        }
    }
}