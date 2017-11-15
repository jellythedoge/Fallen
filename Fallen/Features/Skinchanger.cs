#region

using Fallen.API;
using System.Threading;
using System.Threading.Tasks;
using static Fallen.API.Weapons;

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

        public static void Run()
        {
            while (true)
            {
                if (Settings.SkinchangerEnabled)
                {
                    //-<swap>

                    // Save That We Used The Skinchanger
                    bWasActive = true;

                    int OverrideTexture;

                    int StatTrak;

                    int ItemDefinition;

                    //-<swap/>

                    for (var i = 1; i < 16; ++i)
                    {
                        // Create A New Weapon Object
                        Weapon Weapon = new Weapon();

                        // Get Adress To Current Weapon Out Of Array Of Currently Equipped Weapons
                        int iCurWeaponAdress = (MainClass.Memory.ReadInt(LocalPlayer.Base + netvars.m_hMyWeapons + (i - 1) * 0x4)) & 0xFFF;

                        // Get Baseadress of The Current Weapon
                        Weapon.m_iBase = MainClass.Memory.ReadInt(MainClass.ClientPointer + signatures.dwEntityList + (iCurWeaponAdress - 1) * 0x10);

                        // Get The WeaponID
                        Weapon.m_iItemDefinitionIndex = MainClass.Memory.ReadInt(Weapon.m_iBase + netvars.m_iItemDefinitionIndex);

                        // Get EntityID Of WeaponOwner
                        Weapon.m_iXuIDLow = MainClass.Memory.ReadInt(Weapon.m_iBase + netvars.m_OriginalOwnerXuidLow);

                        // Get Weapon Skin
                        Weapon.m_iTexture = MainClass.Memory.ReadInt(Weapon.m_iBase + netvars.m_nFallbackPaintKit);

                        switch (Weapon.m_iItemDefinitionIndex)
                        {
                            //-<swap>

                            case (int)WeaponIDs.WEAPON_DEAGLE:
                                OverrideTexture = Settings.WEAPON_DEAGLE;
                                StatTrak = -1;
                                ItemDefinition = (int)WeaponIDs.WEAPON_DEAGLE;
                                break;

                            //-<block>

                            case (int)WeaponIDs.WEAPON_ELITE:
                                OverrideTexture = Settings.WEAPON_ELITE;
                                StatTrak = -1;
                                ItemDefinition = (int)WeaponIDs.WEAPON_ELITE;
                                break;

                            //-<block>

                            case (int)WeaponIDs.WEAPON_FIVESEVEN:
                                OverrideTexture = Settings.WEAPON_FIVESEVEN;
                                StatTrak = -1;
                                ItemDefinition = (int)WeaponIDs.WEAPON_FIVESEVEN;
                                break;

                            //-<block>

                            case (int)WeaponIDs.WEAPON_GLOCK:
                                OverrideTexture = Settings.WEAPON_GLOCK;
                                StatTrak = -1;
                                ItemDefinition = (int)WeaponIDs.WEAPON_GLOCK;
                                break;

                            //-<block>

                            case (int)WeaponIDs.WEAPON_AK47:
                                OverrideTexture = Settings.WEAPON_AK47;
                                StatTrak = -1;
                                ItemDefinition = (int)WeaponIDs.WEAPON_AK47;
                                break;

                            //-<block>

                            case (int)WeaponIDs.WEAPON_AUG:
                                OverrideTexture = Settings.WEAPON_AUG;
                                StatTrak = -1;
                                ItemDefinition = (int)WeaponIDs.WEAPON_AUG;
                                break;

                            //-<block>

                            case (int)WeaponIDs.WEAPON_AWP:
                                OverrideTexture = Settings.WEAPON_AWP;
                                StatTrak = -1;
                                ItemDefinition = (int)WeaponIDs.WEAPON_AWP;
                                break;

                            //-<block>

                            case (int)WeaponIDs.WEAPON_FAMAS:
                                OverrideTexture = Settings.WEAPON_FAMAS;
                                StatTrak = -1;
                                ItemDefinition = (int)WeaponIDs.WEAPON_FAMAS;
                                break;

                            //-<block>

                            case (int)WeaponIDs.WEAPON_G3SG1:
                                OverrideTexture = Settings.WEAPON_G3SG1;
                                StatTrak = -1;
                                ItemDefinition = (int)WeaponIDs.WEAPON_G3SG1;
                                break;

                            //-<block>

                            case (int)WeaponIDs.WEAPON_GALILAR:
                                OverrideTexture = Settings.WEAPON_GALILAR;
                                StatTrak = -1;
                                ItemDefinition = (int)WeaponIDs.WEAPON_GALILAR;
                                break;

                            //-<block>

                            case (int)WeaponIDs.WEAPON_M249:
                                OverrideTexture = Settings.WEAPON_M249;
                                StatTrak = -1;
                                ItemDefinition = (int)WeaponIDs.WEAPON_M249;
                                break;

                            //-<block>

                            case (int)WeaponIDs.WEAPON_M4A1:
                                OverrideTexture = Settings.WEAPON_M4A1;
                                StatTrak = -1;
                                ItemDefinition = (int)WeaponIDs.WEAPON_M4A1;
                                break;

                            //-<block>

                            case (int)WeaponIDs.WEAPON_MAC10:
                                OverrideTexture = Settings.WEAPON_MAC10;
                                StatTrak = -1;
                                ItemDefinition = (int)WeaponIDs.WEAPON_MAC10;
                                break;

                            //-<block>

                            case (int)WeaponIDs.WEAPON_P90:
                                OverrideTexture = Settings.WEAPON_P90;
                                StatTrak = -1;
                                ItemDefinition = (int)WeaponIDs.WEAPON_P90;
                                break;

                            //-<block>

                            case (int)WeaponIDs.WEAPON_UMP45:
                                OverrideTexture = Settings.WEAPON_UMP45;
                                StatTrak = -1;
                                ItemDefinition = (int)WeaponIDs.WEAPON_UMP45;
                                break;

                            //-<block>

                            case (int)WeaponIDs.WEAPON_XM1014:
                                OverrideTexture = Settings.WEAPON_XM1014;
                                StatTrak = -1;
                                ItemDefinition = (int)WeaponIDs.WEAPON_XM1014;
                                break;

                            //-<block>

                            case (int)WeaponIDs.WEAPON_BIZON:
                                OverrideTexture = Settings.WEAPON_BIZON;
                                StatTrak = -1;
                                ItemDefinition = (int)WeaponIDs.WEAPON_BIZON;
                                break;

                            //-<block>

                            case (int)WeaponIDs.WEAPON_MAG7:
                                OverrideTexture = Settings.WEAPON_MAG7;
                                StatTrak = -1;
                                ItemDefinition = (int)WeaponIDs.WEAPON_MAG7;
                                break;

                            //-<block>

                            case (int)WeaponIDs.WEAPON_NEGEV:
                                OverrideTexture = Settings.WEAPON_NEGEV;
                                StatTrak = -1;
                                ItemDefinition = (int)WeaponIDs.WEAPON_NEGEV;
                                break;

                            //-<block>

                            case (int)WeaponIDs.WEAPON_SAWEDOFF:
                                OverrideTexture = Settings.WEAPON_SAWEDOFF;
                                StatTrak = -1;
                                ItemDefinition = (int)WeaponIDs.WEAPON_SAWEDOFF;
                                break;

                            //-<block>

                            //-<block>

                            case (int)WeaponIDs.WEAPON_TEC9:
                                OverrideTexture = Settings.WEAPON_TEC9;
                                StatTrak = -1;
                                ItemDefinition = (int)WeaponIDs.WEAPON_TEC9;
                                break;

                            //-<block>

                            case (int)WeaponIDs.WEAPON_HKP2000:
                                OverrideTexture = Settings.WEAPON_HKP2000;
                                StatTrak = -1;
                                ItemDefinition = (int)WeaponIDs.WEAPON_HKP2000;
                                break;

                            //-<block>

                            case (int)WeaponIDs.WEAPON_MP7:
                                OverrideTexture = Settings.WEAPON_MP7;
                                StatTrak = -1;
                                ItemDefinition = (int)WeaponIDs.WEAPON_MP7;
                                break;

                            //-<block>

                            case (int)WeaponIDs.WEAPON_MP9:
                                OverrideTexture = Settings.WEAPON_MP9;
                                StatTrak = -1;
                                ItemDefinition = (int)WeaponIDs.WEAPON_MP9;
                                break;

                            //-<block>

                            case (int)WeaponIDs.WEAPON_NOVA:
                                OverrideTexture = Settings.WEAPON_NOVA;
                                StatTrak = -1;
                                ItemDefinition = (int)WeaponIDs.WEAPON_NOVA;
                                break;

                            //-<block>

                            case (int)WeaponIDs.WEAPON_P250:
                                OverrideTexture = Settings.WEAPON_P250;
                                StatTrak = -1;
                                ItemDefinition = (int)WeaponIDs.WEAPON_P250;
                                break;

                            //-<block>

                            case (int)WeaponIDs.WEAPON_SCAR20:
                                OverrideTexture = Settings.WEAPON_SCAR20;
                                StatTrak = -1;
                                ItemDefinition = (int)WeaponIDs.WEAPON_SCAR20;
                                break;

                            //-<block>

                            case (int)WeaponIDs.WEAPON_SG556:
                                OverrideTexture = Settings.WEAPON_SG556;
                                StatTrak = -1;
                                ItemDefinition = (int)WeaponIDs.WEAPON_SG556;
                                break;

                            //-<block>

                            case (int)WeaponIDs.WEAPON_SSG08:
                                OverrideTexture = Settings.WEAPON_SSG08;
                                StatTrak = -1;
                                ItemDefinition = (int)WeaponIDs.WEAPON_SSG08;
                                break;

                            //-<block>

                            case (int)WeaponIDs.WEAPON_M4A1_SILENCER:
                                OverrideTexture = Settings.WEAPON_M4A1_SILENCER;
                                StatTrak = -1;
                                ItemDefinition = (int)WeaponIDs.WEAPON_M4A1_SILENCER;
                                break;

                            //-<block>

                            case (int)WeaponIDs.WEAPON_USP_SILENCER:
                                OverrideTexture = Settings.WEAPON_USP_SILENCER;
                                StatTrak = -1;
                                ItemDefinition = (int)WeaponIDs.WEAPON_USP_SILENCER;
                                break;

                            //-<block>

                            case (int)WeaponIDs.WEAPON_CZ75A:
                                OverrideTexture = Settings.WEAPON_CZ75A;
                                StatTrak = -1;
                                ItemDefinition = (int)WeaponIDs.WEAPON_CZ75A;
                                break;

                            //-<block>

                            case (int)WeaponIDs.WEAPON_REVOLVER:
                                OverrideTexture = Settings.WEAPON_REVOLVER;
                                StatTrak = -1;
                                ItemDefinition = (int)WeaponIDs.WEAPON_REVOLVER;
                                break;

                            //-<swap/>
                            
                            default:
                                OverrideTexture = 1337;
                                StatTrak = 1337;
                                ItemDefinition = 1337;
                                break;
                        }

                        // Check If The Weapon Doesn't Have The Skin Yet
                        if (Weapon.m_iTexture != OverrideTexture && OverrideTexture != 1337)
                        {
                            //-<swap>

                            // Set New Item Values
                            MainClass.Memory.WriteInt(Weapon.m_iBase + netvars.m_iItemIDLow, -1);
                            MainClass.Memory.WriteInt(Weapon.m_iBase + netvars.m_nFallbackPaintKit, OverrideTexture);
                            MainClass.Memory.WriteInt(Weapon.m_iBase + netvars.m_nFallbackSeed, 661);
                            MainClass.Memory.WriteInt(Weapon.m_iBase + netvars.m_nFallbackStatTrak, StatTrak);
                            MainClass.Memory.WriteFloat(Weapon.m_iBase + netvars.m_flFallbackWear, 0.00001f);
                            MainClass.Memory.WriteInt(Weapon.m_iBase + netvars.m_iAccountID, Weapon.m_iXuIDLow);
                            MainClass.Memory.WriteInt(Weapon.m_iBase + netvars.m_iItemDefinitionIndex, ItemDefinition);

                            //-<swap/>

                            // Force Textures To Reload
                            ForceFullUpdate();
                        }
                    }
                }
                else if (!Settings.SkinchangerEnabled && bWasActive)
                {
                    // If Skinchanger Was Active & Is Now Inactive Force Textures To Reload
                    ForceFullUpdate();

                    bWasActive = false;
                }
                // (-.-)Zzz...
                Thread.Sleep(5);
            }
        }

        internal static void ForceFullUpdate()
        {
            MainClass.Memory.WriteInt(LocalPlayer.ClientState + 0x174, -1);
            Task.Delay(100000);
        }
    }
}