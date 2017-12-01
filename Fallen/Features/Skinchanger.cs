#region

using Fallen.API;
using Memory;
using System.Threading;

#endregion

/////////////////////////////
//Didnt make this ported/////
//from a C++ thread//////////
/////////////////////////////

namespace Fallen.Features
{
    internal class Skinchanger
    {
        public static bool bWasActive = false;

        private static int KnifeModel = (int)SDK.WeaponIDs.WEAPON_KNIFE_KARAMBIT;

        public static void Run()
        {
            while (true)
            {
                if (Settings.Skinchanger.Enabled)
                {
                    // Save That We Used The Skinchanger
                    bWasActive = true;

                    int OverrideTexture;

                    int StatTrak;

                    int ItemDefinition;

                    for (var i = 1; i < 16; ++i)
                    {
                        // Create A New Weapon Object
                        SDK.Weapon Weapon = new SDK.Weapon();

                        // My Weapons
                        var MyWeapons = (MemoryManager.ReadMemory<int>(LocalPlayer.m_iBase + Offsets.m_hMyWeapons + (i - 1) * 0x4)) & 0xFFF;

                        // Get Baseadress of my Weapons
                        Weapon.m_iBase = MemoryManager.ReadMemory<int>(MainClass.ClientPointer + Offsets.dwEntityList + (MyWeapons - 1) * 0x10);

                        // Get The WeaponID
                        Weapon.m_iItemDefinitionIndex = MemoryManager.ReadMemory<int>(Weapon.m_iBase + Offsets.m_iItemDefinitionIndex);

                        // Get EntityID Of WeaponOwner
                        Weapon.m_iXuIDLow = MemoryManager.ReadMemory<int>(Weapon.m_iBase + Offsets.m_OriginalOwnerXuidLow);

                        // Get Weapon Skin
                        Weapon.m_iTexture = MemoryManager.ReadMemory<int>(Weapon.m_iBase + Offsets.m_nFallbackPaintKit);

                        switch (Weapon.m_iItemDefinitionIndex)
                        {
                            #region RIFLES

                            case (int)SDK.WeaponIDs.WEAPON_AK47:
                                OverrideTexture = Settings.Skinchanger.WEAPON_AK47;
                                StatTrak = -1;
                                ItemDefinition = (int)SDK.WeaponIDs.WEAPON_AK47;
                                break;

                            case (int)SDK.WeaponIDs.WEAPON_AUG:
                                OverrideTexture = Settings.Skinchanger.WEAPON_AUG;
                                StatTrak = -1;
                                ItemDefinition = (int)SDK.WeaponIDs.WEAPON_AUG;
                                break;

                            case (int)SDK.WeaponIDs.WEAPON_AWP:
                                OverrideTexture = Settings.Skinchanger.WEAPON_AWP;
                                StatTrak = -1;
                                ItemDefinition = (int)SDK.WeaponIDs.WEAPON_AWP;
                                break;

                            case (int)SDK.WeaponIDs.WEAPON_BIZON:
                                OverrideTexture = Settings.Skinchanger.WEAPON_BIZON;
                                StatTrak = -1;
                                ItemDefinition = (int)SDK.WeaponIDs.WEAPON_BIZON;
                                break;

                            case (int)SDK.WeaponIDs.WEAPON_FAMAS:
                                OverrideTexture = Settings.Skinchanger.WEAPON_FAMAS;
                                StatTrak = -1;
                                ItemDefinition = (int)SDK.WeaponIDs.WEAPON_FAMAS;
                                break;

                            case (int)SDK.WeaponIDs.WEAPON_G3SG1:
                                OverrideTexture = Settings.Skinchanger.WEAPON_G3SG1;
                                StatTrak = -1;
                                ItemDefinition = (int)SDK.WeaponIDs.WEAPON_G3SG1;
                                break;

                            case (int)SDK.WeaponIDs.WEAPON_GALILAR:
                                OverrideTexture = Settings.Skinchanger.WEAPON_GALILAR;
                                StatTrak = -1;
                                ItemDefinition = (int)SDK.WeaponIDs.WEAPON_GALILAR;
                                break;

                            case (int)SDK.WeaponIDs.WEAPON_M4A1:
                                OverrideTexture = Settings.Skinchanger.WEAPON_M4A1;
                                StatTrak = -1;
                                ItemDefinition = (int)SDK.WeaponIDs.WEAPON_M4A1;
                                break;

                            case (int)SDK.WeaponIDs.WEAPON_SCAR20:
                                OverrideTexture = Settings.Skinchanger.WEAPON_SCAR20;
                                StatTrak = -1;
                                ItemDefinition = (int)SDK.WeaponIDs.WEAPON_SCAR20;
                                break;

                            case (int)SDK.WeaponIDs.WEAPON_SG556:
                                OverrideTexture = Settings.Skinchanger.WEAPON_SG556;
                                StatTrak = -1;
                                ItemDefinition = (int)SDK.WeaponIDs.WEAPON_SG556;
                                break;

                            case (int)SDK.WeaponIDs.WEAPON_SSG08:
                                OverrideTexture = Settings.Skinchanger.WEAPON_SSG08;
                                StatTrak = -1;
                                ItemDefinition = (int)SDK.WeaponIDs.WEAPON_SSG08;
                                break;

                            case (int)SDK.WeaponIDs.WEAPON_M4A1_SILENCER:
                                OverrideTexture = Settings.Skinchanger.WEAPON_M4A1_SILENCER;
                                StatTrak = -1;
                                ItemDefinition = (int)SDK.WeaponIDs.WEAPON_M4A1_SILENCER;
                                break;

                            #endregion

                            #region SMG

                            case (int)SDK.WeaponIDs.WEAPON_MAC10:
                                OverrideTexture = Settings.Skinchanger.WEAPON_MAC10;
                                StatTrak = -1;
                                ItemDefinition = (int)SDK.WeaponIDs.WEAPON_MAC10;
                                break;

                            case (int)SDK.WeaponIDs.WEAPON_P90:
                                OverrideTexture = Settings.Skinchanger.WEAPON_P90;
                                StatTrak = -1;
                                ItemDefinition = (int)SDK.WeaponIDs.WEAPON_P90;
                                break;

                            case (int)SDK.WeaponIDs.WEAPON_UMP45:
                                OverrideTexture = Settings.Skinchanger.WEAPON_UMP45;
                                StatTrak = -1;
                                ItemDefinition = (int)SDK.WeaponIDs.WEAPON_UMP45;
                                break;

                            case (int)SDK.WeaponIDs.WEAPON_MP7:
                                OverrideTexture = Settings.Skinchanger.WEAPON_MP7;
                                StatTrak = -1;
                                ItemDefinition = (int)SDK.WeaponIDs.WEAPON_MP7;
                                break;

                            case (int)SDK.WeaponIDs.WEAPON_MP9:
                                OverrideTexture = Settings.Skinchanger.WEAPON_MP9;
                                StatTrak = -1;
                                ItemDefinition = (int)SDK.WeaponIDs.WEAPON_MP9;
                                break;

                            #endregion

                            #region HEAVY

                            case (int)SDK.WeaponIDs.WEAPON_NEGEV:
                                OverrideTexture = Settings.Skinchanger.WEAPON_NEGEV;
                                StatTrak = -1;
                                ItemDefinition = (int)SDK.WeaponIDs.WEAPON_NEGEV;
                                break;

                            case (int)SDK.WeaponIDs.WEAPON_M249:
                                OverrideTexture = Settings.Skinchanger.WEAPON_M249;
                                StatTrak = -1;
                                ItemDefinition = (int)SDK.WeaponIDs.WEAPON_M249;
                                break;

                            #endregion

                            #region PISTOLS

                            case (int)SDK.WeaponIDs.WEAPON_DEAGLE:
                                OverrideTexture = Settings.Skinchanger.WEAPON_DEAGLE;
                                StatTrak = -1;
                                ItemDefinition = (int)SDK.WeaponIDs.WEAPON_DEAGLE;
                                break;

                            case (int)SDK.WeaponIDs.WEAPON_ELITE:
                                OverrideTexture = Settings.Skinchanger.WEAPON_ELITE;
                                StatTrak = -1;
                                ItemDefinition = (int)SDK.WeaponIDs.WEAPON_ELITE;
                                break;

                            case (int)SDK.WeaponIDs.WEAPON_FIVESEVEN:
                                OverrideTexture = Settings.Skinchanger.WEAPON_FIVESEVEN;
                                StatTrak = -1;
                                ItemDefinition = (int)SDK.WeaponIDs.WEAPON_FIVESEVEN;
                                break;

                            case (int)SDK.WeaponIDs.WEAPON_GLOCK:
                                OverrideTexture = Settings.Skinchanger.WEAPON_GLOCK;
                                StatTrak = -1;
                                ItemDefinition = (int)SDK.WeaponIDs.WEAPON_GLOCK;
                                break;

                            case (int)SDK.WeaponIDs.WEAPON_TEC9:
                                OverrideTexture = Settings.Skinchanger.WEAPON_TEC9;
                                StatTrak = -1;
                                ItemDefinition = (int)SDK.WeaponIDs.WEAPON_TEC9;
                                break;

                            case (int)SDK.WeaponIDs.WEAPON_HKP2000:
                                OverrideTexture = Settings.Skinchanger.WEAPON_HKP2000;
                                StatTrak = -1;
                                ItemDefinition = (int)SDK.WeaponIDs.WEAPON_HKP2000;
                                break;

                            case (int)SDK.WeaponIDs.WEAPON_USP_SILENCER:
                                OverrideTexture = Settings.Skinchanger.WEAPON_USP_SILENCER;
                                StatTrak = -1;
                                ItemDefinition = (int)SDK.WeaponIDs.WEAPON_USP_SILENCER;
                                break;

                            case (int)SDK.WeaponIDs.WEAPON_CZ75A:
                                OverrideTexture = Settings.Skinchanger.WEAPON_CZ75A;
                                StatTrak = -1;
                                ItemDefinition = (int)SDK.WeaponIDs.WEAPON_CZ75A;
                                break;

                            case (int)SDK.WeaponIDs.WEAPON_REVOLVER:
                                OverrideTexture = Settings.Skinchanger.WEAPON_REVOLVER;
                                StatTrak = -1;
                                ItemDefinition = (int)SDK.WeaponIDs.WEAPON_REVOLVER;
                                break;

                            case (int)SDK.WeaponIDs.WEAPON_P250:
                                OverrideTexture = Settings.Skinchanger.WEAPON_P250;
                                StatTrak = -1;
                                ItemDefinition = (int)SDK.WeaponIDs.WEAPON_P250;
                                break;

                            #endregion

                            #region SHOTGUNS

                            case (int)SDK.WeaponIDs.WEAPON_XM1014:
                                OverrideTexture = Settings.Skinchanger.WEAPON_XM1014;
                                StatTrak = -1;
                                ItemDefinition = (int)SDK.WeaponIDs.WEAPON_XM1014;
                                break;

                            case (int)SDK.WeaponIDs.WEAPON_MAG7:
                                OverrideTexture = Settings.Skinchanger.WEAPON_MAG7;
                                StatTrak = -1;
                                ItemDefinition = (int)SDK.WeaponIDs.WEAPON_MAG7;
                                break;

                            case (int)SDK.WeaponIDs.WEAPON_SAWEDOFF:
                                OverrideTexture = Settings.Skinchanger.WEAPON_SAWEDOFF;
                                StatTrak = -1;
                                ItemDefinition = (int)SDK.WeaponIDs.WEAPON_SAWEDOFF;
                                break;

                            case (int)SDK.WeaponIDs.WEAPON_NOVA:
                                OverrideTexture = Settings.Skinchanger.WEAPON_NOVA;
                                StatTrak = -1;
                                ItemDefinition = (int)SDK.WeaponIDs.WEAPON_NOVA;
                                break;

                            #endregion

                            default:
                                OverrideTexture = 1337;
                                StatTrak = 1337;
                                ItemDefinition = 1337;
                                break;
                        }

                        if (SDK.HeldWeapon == "KNIFE")
                        {
                        }

                        // Check If The Weapon Doesn't Have The Skin Yet
                        if (Weapon.m_iTexture != OverrideTexture && OverrideTexture != 1337)
                        {
                            #region SETSKIN

                            // Set New Item Values
                            MemoryManager.WriteMemory<int>(Weapon.m_iBase + Offsets.m_iItemIDLow, -1);
                            MemoryManager.WriteMemory<int>(Weapon.m_iBase + Offsets.m_nFallbackPaintKit, OverrideTexture);
                            MemoryManager.WriteMemory<int>(Weapon.m_iBase + Offsets.m_nFallbackSeed, 661);
                            MemoryManager.WriteMemory<int>(Weapon.m_iBase + Offsets.m_nFallbackStatTrak, StatTrak);
                            MemoryManager.WriteMemory<float>(Weapon.m_iBase + Offsets.m_flFallbackWear, 0.00001f);
                            MemoryManager.WriteMemory<int>(Weapon.m_iBase + Offsets.m_iAccountID, Weapon.m_iXuIDLow);
                            MemoryManager.WriteMemory<int>(Weapon.m_iBase + Offsets.m_iItemDefinitionIndex, ItemDefinition);

                            #endregion

                            // Force Textures To Reload
                            SDK.ForceFullUpdate();
                        }
                    }
                }
                else if (!Settings.Skinchanger.Enabled && bWasActive)
                {
                    // If Skinchanger Was Active & Is Now Inactive Force Textures To Reload
                    SDK.ForceFullUpdate();

                    bWasActive = false;
                }
                // (-.-)Zzz...
                Thread.Sleep(3);
            }
        }
    }
}