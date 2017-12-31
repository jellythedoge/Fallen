using Memory;
using System;
using System.Collections.Generic;

namespace Fallen.API
{
    public static class Offsets
    {
        public static List<string> ScanPatterns()
        {
            List<string> outdatedSignatures = new List<string> { };

            //////////////////////////////////////////////////////////////////////
            //TO ADD A NEW SIG DOUBLE THE QUESTION MARKS SUCH AS ???? = ????????//
            //////////////////////////////////////////////////////////////////////

            #region SigScanner

            dwClientState = MemoryManager.ScanPattern(MainClass.EnginePointer, "A1????????33D26A006A0033C989B0", 1, 0, true);
            {
                if (dwClientState == 0) outdatedSignatures.Add("dwClientState");

                SDK.Log($"dwClientState: 0x{ dwClientState.ToString("X") }", true);
            }

            dwClientState_GetLocalPlayer = MemoryManager.ScanPattern(MainClass.EnginePointer, "8B80????????40C3", 2, 0, false);
            {
                if (dwClientState_GetLocalPlayer == 0) outdatedSignatures.Add("dwClientState_GetLocalPlayer");

                SDK.Log($"dwClientState_GetLocalPlayer: 0x{ dwClientState_GetLocalPlayer.ToString("X") }", true);
            }

            dwClientState_Map = MemoryManager.ScanPattern(MainClass.EnginePointer, "05????????C3CCCCCCCCCCCCCCA1", 1, 0, false);
            {
                if (dwClientState_Map == 0) outdatedSignatures.Add("dwClientState_Map");

                SDK.Log($"dwClientState_Map: 0x{ dwClientState_Map.ToString("X") }", true);
            }

            dwClientState_MapDirectory = MemoryManager.ScanPattern(MainClass.EnginePointer, "05????????C3CCCCCCCCCCCCCC803D", 1, 0, false);
            {
                if (dwClientState_MapDirectory == 0) outdatedSignatures.Add("dwClientState_MapDirectory");

                SDK.Log($"dwClientState_MapDirectory: 0x{ dwClientState_MapDirectory.ToString("X") }", true);
            }

            dwClientState_MaxPlayer = MemoryManager.ScanPattern(MainClass.EnginePointer, "A1????????8B80????????C3CCCCCCCC558BEC8A4508", 7, 0, false);
            {
                if (dwClientState_MaxPlayer == 0) outdatedSignatures.Add("dwClientState_MaxPlayer");

                SDK.Log($"dwClientState_MaxPlayer: 0x{ dwClientState_MaxPlayer.ToString("X") }", true);
            }

            dwClientState_PlayerInfo = MemoryManager.ScanPattern(MainClass.EnginePointer, "8B89????????85C90F84????????8B01", 2, 0, false);
            {
                if (dwClientState_PlayerInfo == 0) outdatedSignatures.Add("dwClientState_PlayerInfo");

                SDK.Log($"dwClientState_PlayerInfo: 0x{ dwClientState_PlayerInfo.ToString("X") }", true);
            }

            dwClientState_State = MemoryManager.ScanPattern(MainClass.EnginePointer, "83B8??????????0F94C0C3", 2, 0, false);
            {
                if (dwClientState_State == 0) outdatedSignatures.Add("dwClientState_State");

                SDK.Log($"dwClientState_State: 0x{ dwClientState_State.ToString("X") }", true);
            }

            dwClientState_ViewAngles = MemoryManager.ScanPattern(MainClass.EnginePointer, "F30F1180????????D94604D905", 4, 0, false);
            {
                if (dwClientState_ViewAngles == 0) outdatedSignatures.Add("dwClientState_ViewAngles");

                SDK.Log($"dwClientState_ViewAngles: 0x{ dwClientState_ViewAngles.ToString("X") }", true);
            }

            dwClientState_IsHLTV = MemoryManager.ScanPattern(MainClass.EnginePointer, "80BF??????????0F84????????32DB", 2, 0, false);
            {
                if (dwClientState_IsHLTV == 0) outdatedSignatures.Add("dwClientState_IsHLTV");

                SDK.Log($"dwClientState_IsHLTV: 0x{ dwClientState_IsHLTV.ToString("X") }", true);
            }

            dwEntityList = MemoryManager.ScanPattern(MainClass.ClientPointer, "BB????????83FF010F8C????????3BF8", 1, 0, true);
            {
                if (dwEntityList == 0) outdatedSignatures.Add("dwEntityList");

                SDK.Log($"dwEntityList: 0x{ dwEntityList.ToString("X") }", true);
            }

            dwForceAttack = MemoryManager.ScanPattern(MainClass.ClientPointer, "890D????????8B0D????????8BF28BC183CE04", 2, 0, true);
            {
                if (dwForceAttack == 0) outdatedSignatures.Add("dwForceAttack");

                SDK.Log($"dwForceAttack: 0x{ dwForceAttack.ToString("X") }", true);
            }

            dwForceAttack2 = MemoryManager.ScanPattern(MainClass.ClientPointer, "890D????????8B0D????????8BF28BC183CE04", 2, 12, true);
            {
                if (dwForceAttack2 == 0) outdatedSignatures.Add("dwForceAttack2");

                SDK.Log($"dwForceAttack2: 0x{ dwForceAttack2.ToString("X") }", true);
            }

            dwForceBackward = MemoryManager.ScanPattern(MainClass.ClientPointer, "558BEC51538A5D08", 287, 0, true);
            {
                if (dwForceBackward == 0) outdatedSignatures.Add("dwForceBackward");

                SDK.Log($"dwForceBackward: 0x{ dwForceBackward.ToString("X") }", true);
            }

            dwForceForward = MemoryManager.ScanPattern(MainClass.ClientPointer, "558BEC51538A5D08", 245, 0, true);
            {
                if (dwForceBackward == 0) outdatedSignatures.Add("dwForceForward");

                SDK.Log($"dwForceForward: 0x{ dwForceForward.ToString("X") }", true);
            }

            dwForceJump = MemoryManager.ScanPattern(MainClass.ClientPointer, "8B0D????????8BD68BC183CA02", 2, 0, true);
            {
                if (dwForceJump == 0) outdatedSignatures.Add("dwForceJump");

                SDK.Log($"dwForceJump: 0x{ dwForceJump.ToString("X") }", true);
            }

            dwForceLeft = MemoryManager.ScanPattern(MainClass.ClientPointer, "558BEC51538A5D08", 465, 0, true);
            {
                if (dwForceLeft == 0) outdatedSignatures.Add("dwForceLeft");

                SDK.Log($"dwForceLeft: 0x{ dwForceLeft.ToString("X") }", true);
            }

            dwForceRight = MemoryManager.ScanPattern(MainClass.ClientPointer, "558BEC51538A5D08", 512, 0, true);
            {
                if (dwForceRight == 0) outdatedSignatures.Add("dwForceRight");

                SDK.Log($"dwForceRight: 0x{ dwForceRight.ToString("X") }", true);
            }

            dwGameDir = MemoryManager.ScanPattern(MainClass.EnginePointer, "68????????8D85????????5068????????68", 1, 0, true);
            {
                if (dwGameDir == 0) outdatedSignatures.Add("dwGameDir");

                SDK.Log($"dwGameDir: 0x{ dwGameDir.ToString("X") }", true);
            }

            dwGameRulesProxy = MemoryManager.ScanPattern(MainClass.ClientPointer, "A1????????85C00F84????????80B8???????????0F84????????0F1005", 1, 0, true);
            {
                if (dwGameRulesProxy == 0) outdatedSignatures.Add("dwGameRulesProxy");

                SDK.Log($"dwGameRulesProxy: 0x{ dwGameRulesProxy.ToString("X") }", true);
            }

            dwGetAllClasses = MemoryManager.ScanPattern(MainClass.ClientPointer, "A1????????C3CCCCCCCCCCCCCCCCCCCCA1????????B9", 1, 0, true);
            {
                if (dwGetAllClasses == 0) outdatedSignatures.Add("dwGetAllClasses");

                SDK.Log($"dwGetAllClasses: 0x{ dwGetAllClasses.ToString("X") }", true);
            }

            dwGlobalVars = MemoryManager.ScanPattern(MainClass.EnginePointer, "68????????68????????FF500885C0", 1, 0, true);
            {
                if (dwGlobalVars == 0) outdatedSignatures.Add("dwGlobalVars");

                SDK.Log($"dwGlobalVars: 0x{ dwGlobalVars.ToString("X") }", true);
            }

            dwGlowObjectManager = MemoryManager.ScanPattern(MainClass.ClientPointer, "A1????????A801754B", 1, 4, true);
            {
                if (dwGlowObjectManager == 0) outdatedSignatures.Add("dwGlowObjectManager");

                SDK.Log($"dwGlowObjectManager: 0x{ dwGlowObjectManager.ToString("X") }", true);
            }

            dwInput = MemoryManager.ScanPattern(MainClass.ClientPointer, "B9????????F30F110424FF5010", 1, 0, true);
            {
                if (dwInput == 0) outdatedSignatures.Add("dwInput");

                SDK.Log($"dwInput: 0x{ dwInput.ToString("X") }", true);
            }

            dwLocalPlayer = MemoryManager.ScanPattern(MainClass.ClientPointer, "A3????????C705????????????????E8????????59C36A??", 1, 16, true);
            {
                if (dwGameRulesProxy == 0) outdatedSignatures.Add("dwLocalPlayer");

                SDK.Log($"dwLocalPlayer: 0x{ dwLocalPlayer.ToString("X") }", true);
            }

            dwMouseEnable = MemoryManager.ScanPattern(MainClass.ClientPointer, "B9????????FF503485C07510", 1, 48, true);
            {
                if (dwMouseEnable == 0) outdatedSignatures.Add("dwMouseEnable");

                SDK.Log($"dwMouseEnable: 0x{ dwMouseEnable.ToString("X") }", true);
            }

            dwMouseEnablePtr = MemoryManager.ScanPattern(MainClass.ClientPointer, "B9????????FF503485C07510", 1, 0, true);
            {
                if (dwGameRulesProxy == 0) outdatedSignatures.Add("dwMouseEnablePtr");

                SDK.Log($"dwMouseEnablePtr: 0x{ dwMouseEnablePtr.ToString("X") }", true);
            }

            dwPlayerResource = MemoryManager.ScanPattern(MainClass.ClientPointer, "8B3D????????85FF0F84????????81C7", 2, 0, true);
            {
                if (dwPlayerResource == 0) outdatedSignatures.Add("dwPlayerResource");

                SDK.Log($"dwPlayerResource: 0x{ dwPlayerResource.ToString("X") }", true);
            }

            #endregion WorkingSigs

            ///
            ///TO DO
            ///
            ///Add the signatures below to the scanning List, not important but meh

            /*

            dwRadarBase

            dwSensitivity

            dwSensitivityPtr

            dwViewMatrix

            dwWeaponTable

            dwWeaponTableIndex

            dwYawPtr

            dwZoomSensitivityRatioPtr

            dwbSendPackets

            dwppDirect3DDevice9

            dwSetClanTag

            m_pStudioHdr

            */

            Console.Clear();
            return outdatedSignatures;
        }

        #region Netvars

        public const Int32 m_ArmorValue = 0xB238;
        public const Int32 m_Collision = 0x318;
        public const Int32 m_CollisionGroup = 0x470;
        public const Int32 m_Local = 0x2FAC;
        public const Int32 m_MoveType = 0x258;
        public const Int32 m_OriginalOwnerXuidHigh = 0x316C;
        public const Int32 m_OriginalOwnerXuidLow = 0x3168;
        public const Int32 m_aimPunchAngle = 0x301C;
        public const Int32 m_aimPunchAngleVel = 0x3028;
        public const Int32 m_bGunGameImmunity = 0x3894;
        public const Int32 m_bHasDefuser = 0xB248;
        public const Int32 m_bHasHelmet = 0xB22C;
        public const Int32 m_bInReload = 0x3245;
        public const Int32 m_bIsDefusing = 0x3888;
        public const Int32 m_totalHitsOnServer = 0xA2C8;
        public const Int32 m_bIsScoped = 0x387E;
        public const Int32 m_bSpotted = 0x939;
        public const Int32 m_bSpottedByMask = 0x97C;
        public const Int32 m_dwBoneMatrix = 0x2698;
        public const Int32 m_fAccuracyPenalty = 0x32B0;
        public const Int32 m_fFlags = 0x100;
        public const Int32 m_flFallbackWear = 0x3178;
        public const Int32 m_flFlashDuration = 0xA2F8;
        public const Int32 m_flFlashMaxAlpha = 0xA2F4;
        public const Int32 m_flNextPrimaryAttack = 0x31D8;
        public const Int32 m_hActiveWeapon = 0x2EE8;
        public const Int32 m_hMyWeapons = 0x2DE8;
        public const Int32 m_hObserverTarget = 0x3360;
        public const Int32 m_hOwner = 0x29BC;
        public const Int32 m_hOwnerEntity = 0x148;
        public const Int32 m_iAccountID = 0x2FA8;
        public const Int32 m_iClip1 = 0x3204;
        public const Int32 m_iCompetitiveRanking = 0x1A44;
        public const Int32 m_iCompetitiveWins = 0x1B48;
        public const Int32 m_iCrosshairId = 0xB2A4;
        public const Int32 m_iEntityQuality = 0x2F8C;
        public const Int32 m_iFOVStart = 0x31D8;
        public const Int32 m_iFOV = 0x31D4;
        public const Int32 m_iGlowIndex = 0xA310;
        public const Int32 m_iHealth = 0xFC;
        public const Int32 m_iItemDefinitionIndex = 0x2F88;
        public const Int32 m_iItemIDHigh = 0x2FA0;
        public const Int32 m_iItemIDLow = 0x2FA4;
        public const Int32 m_iObserverMode = 0x334C;
        public const Int32 m_iShotsFired = 0xA2B0;
        public const Int32 m_iState = 0x31F8;
        public const Int32 m_iTeamNum = 0xF0;
        public const Int32 m_lifeState = 0x25B;
        public const Int32 m_nFallbackPaintKit = 0x3170;
        public const Int32 m_nFallbackSeed = 0x3174;
        public const Int32 m_nFallbackStatTrak = 0x317C;
        public const Int32 m_nForceBone = 0x267C;
        public const Int32 m_nTickBase = 0x3404;
        public const Int32 m_rgflCoordinateFrame = 0x440;
        public const Int32 m_szCustomName = 0x301C;
        public const Int32 m_szLastPlaceName = 0x3588;
        public const Int32 m_vecOrigin = 0x134;
        public const Int32 m_vecVelocity = 0x110;
        public const Int32 m_vecViewOffset = 0x104;
        public const Int32 m_viewPunchAngle = 0x3010;
        public const Int32 m_szArmsModel = 0x38D7;
        public const Int32 m_hViewModel = 0x32DC;
        public const Int32 m_nModelIndex = 0x254;
        public const Int32 m_flLowerBodyYawTarget = 0x39DC;
        public const Int32 m_angEyeAngles = 0xB23C;

        #endregion Netvars

        #region Signatures

        public static Int32 dwClientState = 0x0;
        public static Int32 dwClientState_GetLocalPlayer = 0x0;
        public static Int32 dwClientState_Map = 0x0;
        public static Int32 dwClientState_MapDirectory = 0x0;
        public static Int32 dwClientState_MaxPlayer = 0x0;
        public static Int32 dwClientState_PlayerInfo = 0x0;
        public static Int32 dwClientState_State = 0x0;
        public static Int32 dwClientState_ViewAngles = 0x0;
        public static Int32 dwClientState_IsHLTV = 0x0;
        public static Int32 dwEntityList = 0x0;
        public static Int32 dwForceAttack = 0x0;
        public static Int32 dwForceAttack2 = 0x0;
        public static Int32 dwForceBackward = 0x0;
        public static Int32 dwForceForward = 0x0;
        public static Int32 dwForceJump = 0x0;
        public static Int32 dwForceLeft = 0x0;
        public static Int32 dwForceRight = 0x0;
        public static Int32 dwGameDir = 0x0;
        public static Int32 dwGameRulesProxy = 0x0;
        public static Int32 dwGetAllClasses = 0x0;
        public static Int32 dwGlobalVars = 0x0;
        public static Int32 dwGlowObjectManager = 0x0;
        public static Int32 dwInput = 0x0;
        public static Int32 dwInterfaceLinkList = 0x0;
        public static Int32 dwLocalPlayer = 0x0;
        public static Int32 dwMouseEnable = 0x0;
        public static Int32 dwMouseEnablePtr = 0x0;
        public static Int32 dwPlayerResource = 0x0;

        public static Int32 dwRadarBase = 0x0;
        public static Int32 dwSensitivity = 0x0;
        public static Int32 dwSensitivityPtr = 0x0;
        public static Int32 dwViewMatrix = 0x0;
        public static Int32 dwWeaponTable = 0x0;
        public static Int32 dwWeaponTableIndex = 0x0;
        public static Int32 dwYawPtr = 0x0;
        public static Int32 dwZoomSensitivityRatioPtr = 0x0;
        public static Int32 dwbSendPackets = 0x0;
        public static Int32 dwppDirect3DDevice9 = 0x0;
        public static Int32 dwSetClanTag = 0x0;
        public static Int32 m_pStudioHdr = 0x0;

        #endregion Signatures
    }
}