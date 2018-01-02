#region

using Fallen.API;
using Memory;
using System.Threading;

#endregion

// ///////////////////////////
// Didnt make this ported/////
// from a C++ thread//////////
// ///////////////////////////

namespace Fallen.Features
{
    internal class Skinchanger
    {
        public static bool bWasActive;

        static int KnifeModel = (int)SDK.WeaponIDs.WEAPON_KNIFE_KARAMBIT;

        public static void Run()
        {
            while (true)
            {
                if (Settings.Skinchanger.Enabled)
                {
                    // Save That We Used The Skinchanger
                    bWasActive = true;

                    int overrideTexture;

                    int statTrak;

                    int itemDefinition;

                    for (var i = 1; i < 16; ++i)
                    {
                        // Create A New Weapon Object
                        var weapon = new SDK.Weapon();

                        // My Weapons
                        var myWeapons = (MemoryManager.ReadMemory<int>(SDK.LocalPlayer.m_iBase + Offsets.m_hMyWeapons + (i - 1) * 0x4)) & 0xFFF;

                        // Get Baseadress of my Weapons
                        weapon.m_iBase = MemoryManager.ReadMemory<int>(MainClass.ClientPointer + Offsets.dwEntityList + (myWeapons - 1) * 0x10);

                        // Get The WeaponID
                        weapon.m_iItemDefinitionIndex = MemoryManager.ReadMemory<int>(weapon.m_iBase + Offsets.m_iItemDefinitionIndex);

                        // Get EntityID Of WeaponOwner
                        weapon.m_iXuIDLow = MemoryManager.ReadMemory<int>(weapon.m_iBase + Offsets.m_OriginalOwnerXuidLow);

                        // Get Weapon Skin
                        weapon.m_iTexture = MemoryManager.ReadMemory<int>(weapon.m_iBase + Offsets.m_nFallbackPaintKit);

                        switch (weapon.m_iItemDefinitionIndex)
                        {
                            #region RIFLES

                            case (int)SDK.WeaponIDs.WEAPON_AK47:
                                overrideTexture = Settings.Skinchanger.WEAPON_AK47;
                                statTrak = -1;
                                itemDefinition = (int)SDK.WeaponIDs.WEAPON_AK47;
                                break;

                            case (int)SDK.WeaponIDs.WEAPON_AUG:
                                overrideTexture = Settings.Skinchanger.WEAPON_AUG;
                                statTrak = -1;
                                itemDefinition = (int)SDK.WeaponIDs.WEAPON_AUG;
                                break;

                            case (int)SDK.WeaponIDs.WEAPON_AWP:
                                overrideTexture = Settings.Skinchanger.WEAPON_AWP;
                                statTrak = -1;
                                itemDefinition = (int)SDK.WeaponIDs.WEAPON_AWP;
                                break;

                            case (int)SDK.WeaponIDs.WEAPON_BIZON:
                                overrideTexture = Settings.Skinchanger.WEAPON_BIZON;
                                statTrak = -1;
                                itemDefinition = (int)SDK.WeaponIDs.WEAPON_BIZON;
                                break;

                            case (int)SDK.WeaponIDs.WEAPON_FAMAS:
                                overrideTexture = Settings.Skinchanger.WEAPON_FAMAS;
                                statTrak = -1;
                                itemDefinition = (int)SDK.WeaponIDs.WEAPON_FAMAS;
                                break;

                            case (int)SDK.WeaponIDs.WEAPON_G3SG1:
                                overrideTexture = Settings.Skinchanger.WEAPON_G3SG1;
                                statTrak = -1;
                                itemDefinition = (int)SDK.WeaponIDs.WEAPON_G3SG1;
                                break;

                            case (int)SDK.WeaponIDs.WEAPON_GALILAR:
                                overrideTexture = Settings.Skinchanger.WEAPON_GALILAR;
                                statTrak = -1;
                                itemDefinition = (int)SDK.WeaponIDs.WEAPON_GALILAR;
                                break;

                            case (int)SDK.WeaponIDs.WEAPON_M4A1:
                                overrideTexture = Settings.Skinchanger.WEAPON_M4A1;
                                statTrak = -1;
                                itemDefinition = (int)SDK.WeaponIDs.WEAPON_M4A1;
                                break;

                            case (int)SDK.WeaponIDs.WEAPON_SCAR20:
                                overrideTexture = Settings.Skinchanger.WEAPON_SCAR20;
                                statTrak = -1;
                                itemDefinition = (int)SDK.WeaponIDs.WEAPON_SCAR20;
                                break;

                            case (int)SDK.WeaponIDs.WEAPON_SG556:
                                overrideTexture = Settings.Skinchanger.WEAPON_SG556;
                                statTrak = -1;
                                itemDefinition = (int)SDK.WeaponIDs.WEAPON_SG556;
                                break;

                            case (int)SDK.WeaponIDs.WEAPON_SSG08:
                                overrideTexture = Settings.Skinchanger.WEAPON_SSG08;
                                statTrak = -1;
                                itemDefinition = (int)SDK.WeaponIDs.WEAPON_SSG08;
                                break;

                            case (int)SDK.WeaponIDs.WEAPON_M4A1_SILENCER:
                                overrideTexture = Settings.Skinchanger.WEAPON_M4A1_SILENCER;
                                statTrak = -1;
                                itemDefinition = (int)SDK.WeaponIDs.WEAPON_M4A1_SILENCER;
                                break;

                            #endregion

                            #region SMG

                            case (int)SDK.WeaponIDs.WEAPON_MAC10:
                                overrideTexture = Settings.Skinchanger.WEAPON_MAC10;
                                statTrak = -1;
                                itemDefinition = (int)SDK.WeaponIDs.WEAPON_MAC10;
                                break;

                            case (int)SDK.WeaponIDs.WEAPON_P90:
                                overrideTexture = Settings.Skinchanger.WEAPON_P90;
                                statTrak = -1;
                                itemDefinition = (int)SDK.WeaponIDs.WEAPON_P90;
                                break;

                            case (int)SDK.WeaponIDs.WEAPON_UMP45:
                                overrideTexture = Settings.Skinchanger.WEAPON_UMP45;
                                statTrak = -1;
                                itemDefinition = (int)SDK.WeaponIDs.WEAPON_UMP45;
                                break;

                            case (int)SDK.WeaponIDs.WEAPON_MP7:
                                overrideTexture = Settings.Skinchanger.WEAPON_MP7;
                                statTrak = -1;
                                itemDefinition = (int)SDK.WeaponIDs.WEAPON_MP7;
                                break;

                            case (int)SDK.WeaponIDs.WEAPON_MP9:
                                overrideTexture = Settings.Skinchanger.WEAPON_MP9;
                                statTrak = -1;
                                itemDefinition = (int)SDK.WeaponIDs.WEAPON_MP9;
                                break;

                            #endregion

                            #region HEAVY

                            case (int)SDK.WeaponIDs.WEAPON_NEGEV:
                                overrideTexture = Settings.Skinchanger.WEAPON_NEGEV;
                                statTrak = -1;
                                itemDefinition = (int)SDK.WeaponIDs.WEAPON_NEGEV;
                                break;

                            case (int)SDK.WeaponIDs.WEAPON_M249:
                                overrideTexture = Settings.Skinchanger.WEAPON_M249;
                                statTrak = -1;
                                itemDefinition = (int)SDK.WeaponIDs.WEAPON_M249;
                                break;

                            #endregion

                            #region PISTOLS

                            case (int)SDK.WeaponIDs.WEAPON_DEAGLE:
                                overrideTexture = Settings.Skinchanger.WEAPON_DEAGLE;
                                statTrak = -1;
                                itemDefinition = (int)SDK.WeaponIDs.WEAPON_DEAGLE;
                                break;

                            case (int)SDK.WeaponIDs.WEAPON_ELITE:
                                overrideTexture = Settings.Skinchanger.WEAPON_ELITE;
                                statTrak = -1;
                                itemDefinition = (int)SDK.WeaponIDs.WEAPON_ELITE;
                                break;

                            case (int)SDK.WeaponIDs.WEAPON_FIVESEVEN:
                                overrideTexture = Settings.Skinchanger.WEAPON_FIVESEVEN;
                                statTrak = -1;
                                itemDefinition = (int)SDK.WeaponIDs.WEAPON_FIVESEVEN;
                                break;

                            case (int)SDK.WeaponIDs.WEAPON_GLOCK:
                                overrideTexture = Settings.Skinchanger.WEAPON_GLOCK;
                                statTrak = -1;
                                itemDefinition = (int)SDK.WeaponIDs.WEAPON_GLOCK;
                                break;

                            case (int)SDK.WeaponIDs.WEAPON_TEC9:
                                overrideTexture = Settings.Skinchanger.WEAPON_TEC9;
                                statTrak = -1;
                                itemDefinition = (int)SDK.WeaponIDs.WEAPON_TEC9;
                                break;

                            case (int)SDK.WeaponIDs.WEAPON_HKP2000:
                                overrideTexture = Settings.Skinchanger.WEAPON_HKP2000;
                                statTrak = -1;
                                itemDefinition = (int)SDK.WeaponIDs.WEAPON_HKP2000;
                                break;

                            case (int)SDK.WeaponIDs.WEAPON_USP_SILENCER:
                                overrideTexture = Settings.Skinchanger.WEAPON_USP_SILENCER;
                                statTrak = -1;
                                itemDefinition = (int)SDK.WeaponIDs.WEAPON_USP_SILENCER;
                                break;

                            case (int)SDK.WeaponIDs.WEAPON_CZ75A:
                                overrideTexture = Settings.Skinchanger.WEAPON_CZ75A;
                                statTrak = -1;
                                itemDefinition = (int)SDK.WeaponIDs.WEAPON_CZ75A;
                                break;

                            case (int)SDK.WeaponIDs.WEAPON_REVOLVER:
                                overrideTexture = Settings.Skinchanger.WEAPON_REVOLVER;
                                statTrak = -1;
                                itemDefinition = (int)SDK.WeaponIDs.WEAPON_REVOLVER;
                                break;

                            case (int)SDK.WeaponIDs.WEAPON_P250:
                                overrideTexture = Settings.Skinchanger.WEAPON_P250;
                                statTrak = -1;
                                itemDefinition = (int)SDK.WeaponIDs.WEAPON_P250;
                                break;

                            #endregion

                            #region SHOTGUNS

                            case (int)SDK.WeaponIDs.WEAPON_XM1014:
                                overrideTexture = Settings.Skinchanger.WEAPON_XM1014;
                                statTrak = -1;
                                itemDefinition = (int)SDK.WeaponIDs.WEAPON_XM1014;
                                break;

                            case (int)SDK.WeaponIDs.WEAPON_MAG7:
                                overrideTexture = Settings.Skinchanger.WEAPON_MAG7;
                                statTrak = -1;
                                itemDefinition = (int)SDK.WeaponIDs.WEAPON_MAG7;
                                break;

                            case (int)SDK.WeaponIDs.WEAPON_SAWEDOFF:
                                overrideTexture = Settings.Skinchanger.WEAPON_SAWEDOFF;
                                statTrak = -1;
                                itemDefinition = (int)SDK.WeaponIDs.WEAPON_SAWEDOFF;
                                break;

                            case (int)SDK.WeaponIDs.WEAPON_NOVA:
                                overrideTexture = Settings.Skinchanger.WEAPON_NOVA;
                                statTrak = -1;
                                itemDefinition = (int)SDK.WeaponIDs.WEAPON_NOVA;
                                break;

                            #endregion

                            default:
                                overrideTexture = 1337;
                                statTrak = 1337;
                                itemDefinition = 1337;
                                break;
                        }

                        if (SDK.HeldWeapon == "KNIFE")
                        {
                        }

                        // Check If The Weapon Doesn't Have The Skin Yet
                        if (weapon.m_iTexture != overrideTexture && overrideTexture != 1337)
                        {
                            #region SETSKIN

                            // Set New Item Values
                            MemoryManager.WriteMemory<int>(weapon.m_iBase + Offsets.m_iItemIDLow, -1);
                            MemoryManager.WriteMemory<int>(weapon.m_iBase + Offsets.m_nFallbackPaintKit, overrideTexture);
                            MemoryManager.WriteMemory<int>(weapon.m_iBase + Offsets.m_nFallbackSeed, 661);
                            MemoryManager.WriteMemory<int>(weapon.m_iBase + Offsets.m_nFallbackStatTrak, statTrak);
                            MemoryManager.WriteMemory<float>(weapon.m_iBase + Offsets.m_flFallbackWear, 0.000000001f);
                            MemoryManager.WriteMemory<int>(weapon.m_iBase + Offsets.m_iAccountID, weapon.m_iXuIDLow);
                            MemoryManager.WriteMemory<int>(weapon.m_iBase + Offsets.m_iItemDefinitionIndex, itemDefinition);

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