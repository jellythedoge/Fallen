using Fallen.Managers;
using System;
using System.Collections.Generic;

namespace Fallen.Other
{
    public static class Offsets
    {
        public static List<string> ScanPatterns()
        {
            List<string> outdatedSignatures = new List<string> { };

            // ////////////////////////////////////////////////////////////////////
            // TO ADD A NEW SIG DOUBLE THE QUESTION MARKS SUCH AS ???? = ????????//
            // ////////////////////////////////////////////////////////////////////

            #region SigScanner

            dwClientState = Memory.ScanPattern(Structs.Base.EnginePointer, "A1????????33D26A006A0033C989B0", 1, 0, true);
            {
                if (dwClientState == 0) outdatedSignatures.Add("dwClientState");

                Extensions.Information($"dwClientState: 0x{ dwClientState.ToString("X") }");
            }

            dwClientState_GetLocalPlayer = Memory.ScanPattern(Structs.Base.EnginePointer, "8B80????????40C3", 2, 0, false);
            {
                if (dwClientState_GetLocalPlayer == 0) outdatedSignatures.Add("dwClientState_GetLocalPlayer");

                Extensions.Information($"dwClientState_GetLocalPlayer: 0x{ dwClientState_GetLocalPlayer.ToString("X") }");
            }

            dwClientState_Map = Memory.ScanPattern(Structs.Base.EnginePointer, "05????????C3CCCCCCCCCCCCCCA1", 1, 0, false);
            {
                if (dwClientState_Map == 0) outdatedSignatures.Add("dwClientState_Map");

                Extensions.Information($"dwClientState_Map: 0x{ dwClientState_Map.ToString("X") }");
            }

            dwClientState_MapDirectory = Memory.ScanPattern(Structs.Base.EnginePointer, "05????????C3CCCCCCCCCCCCCC803D", 1, 0, false);
            {
                if (dwClientState_MapDirectory == 0) outdatedSignatures.Add("dwClientState_MapDirectory");

                Extensions.Information($"dwClientState_MapDirectory: 0x{ dwClientState_MapDirectory.ToString("X") }");
            }

            dwClientState_MaxPlayer = Memory.ScanPattern(Structs.Base.EnginePointer, "A1????????8B80????????C3CCCCCCCC558BEC8A4508", 7, 0, false);
            {
                if (dwClientState_MaxPlayer == 0) outdatedSignatures.Add("dwClientState_MaxPlayer");

                Extensions.Information($"dwClientState_MaxPlayer: 0x{ dwClientState_MaxPlayer.ToString("X") }");
            }

            dwClientState_PlayerInfo = Memory.ScanPattern(Structs.Base.EnginePointer, "8B89????????85C90F84????????8B01", 2, 0, false);
            {
                if (dwClientState_PlayerInfo == 0) outdatedSignatures.Add("dwClientState_PlayerInfo");

                Extensions.Information($"dwClientState_PlayerInfo: 0x{ dwClientState_PlayerInfo.ToString("X") }");
            }

            dwClientState_State = Memory.ScanPattern(Structs.Base.EnginePointer, "83B8??????????0F94C0C3", 2, 0, false);
            {
                if (dwClientState_State == 0) outdatedSignatures.Add("dwClientState_State");

                Extensions.Information($"dwClientState_State: 0x{ dwClientState_State.ToString("X") }");
            }

            dwClientState_ViewAngles = Memory.ScanPattern(Structs.Base.EnginePointer, "F30F1180????????D94604D905", 4, 0, false);
            {
                if (dwClientState_ViewAngles == 0) outdatedSignatures.Add("dwClientState_ViewAngles");

                Extensions.Information($"dwClientState_ViewAngles: 0x{ dwClientState_ViewAngles.ToString("X") }");
            }

            dwClientState_IsHLTV = Memory.ScanPattern(Structs.Base.EnginePointer, "80BF??????????0F84????????32DB", 2, 0, false);
            {
                if (dwClientState_IsHLTV == 0) outdatedSignatures.Add("dwClientState_IsHLTV");

                Extensions.Information($"dwClientState_IsHLTV: 0x{ dwClientState_IsHLTV.ToString("X") }");
            }

            dwEntityList = Memory.ScanPattern(Structs.Base.ClientPointer, "BB????????83FF010F8C????????3BF8", 1, 0, true);
            {
                if (dwEntityList == 0) outdatedSignatures.Add("dwEntityList");

                Extensions.Information($"dwEntityList: 0x{ dwEntityList.ToString("X") }");
            }

            dwForceAttack = Memory.ScanPattern(Structs.Base.ClientPointer, "890D????????8B0D????????8BF28BC183CE04", 2, 0, true);
            {
                if (dwForceAttack == 0) outdatedSignatures.Add("dwForceAttack");

                Extensions.Information($"dwForceAttack: 0x{ dwForceAttack.ToString("X") }");
            }

            dwForceAttack2 = Memory.ScanPattern(Structs.Base.ClientPointer, "890D????????8B0D????????8BF28BC183CE04", 2, 12, true);
            {
                if (dwForceAttack2 == 0) outdatedSignatures.Add("dwForceAttack2");

                Extensions.Information($"dwForceAttack2: 0x{ dwForceAttack2.ToString("X") }");
            }

            dwForceBackward = Memory.ScanPattern(Structs.Base.ClientPointer, "558BEC51538A5D08", 287, 0, true);
            {
                if (dwForceBackward == 0) outdatedSignatures.Add("dwForceBackward");

                Extensions.Information($"dwForceBackward: 0x{ dwForceBackward.ToString("X") }");
            }

            dwForceForward = Memory.ScanPattern(Structs.Base.ClientPointer, "558BEC51538A5D08", 245, 0, true);
            {
                if (dwForceBackward == 0) outdatedSignatures.Add("dwForceForward");

                Extensions.Information($"dwForceForward: 0x{ dwForceForward.ToString("X") }");
            }

            dwForceJump = Memory.ScanPattern(Structs.Base.ClientPointer, "8B0D????????8BD68BC183CA02", 2, 0, true);
            {
                if (dwForceJump == 0) outdatedSignatures.Add("dwForceJump");

                Extensions.Information($"dwForceJump: 0x{ dwForceJump.ToString("X") }");
            }

            dwForceLeft = Memory.ScanPattern(Structs.Base.ClientPointer, "558BEC51538A5D08", 465, 0, true);
            {
                if (dwForceLeft == 0) outdatedSignatures.Add("dwForceLeft");

                Extensions.Information($"dwForceLeft: 0x{ dwForceLeft.ToString("X") }");
            }

            dwForceRight = Memory.ScanPattern(Structs.Base.ClientPointer, "558BEC51538A5D08", 512, 0, true);
            {
                if (dwForceRight == 0) outdatedSignatures.Add("dwForceRight");

                Extensions.Information($"dwForceRight: 0x{ dwForceRight.ToString("X") }");
            }

            dwGameDir = Memory.ScanPattern(Structs.Base.EnginePointer, "68????????8D85????????5068????????68", 1, 0, true);
            {
                if (dwGameDir == 0) outdatedSignatures.Add("dwGameDir");

                Extensions.Information($"dwGameDir: 0x{ dwGameDir.ToString("X") }");
            }

            dwGameRulesProxy = Memory.ScanPattern(Structs.Base.ClientPointer, "A1????????85C00F84????????80B8???????????0F84????????0F1005", 1, 0, true);
            {
                if (dwGameRulesProxy == 0) outdatedSignatures.Add("dwGameRulesProxy");

                Extensions.Information($"dwGameRulesProxy: 0x{ dwGameRulesProxy.ToString("X") }");
            }

            dwGetAllClasses = Memory.ScanPattern(Structs.Base.ClientPointer, "A1????????C3CCCCCCCCCCCCCCCCCCCCA1????????B9", 1, 0, true);
            {
                if (dwGetAllClasses == 0) outdatedSignatures.Add("dwGetAllClasses");

                Extensions.Information($"dwGetAllClasses: 0x{ dwGetAllClasses.ToString("X") }");
            }

            dwGlobalVars = Memory.ScanPattern(Structs.Base.EnginePointer, "68????????68????????FF500885C0", 1, 0, true);
            {
                if (dwGlobalVars == 0) outdatedSignatures.Add("dwGlobalVars");

                Extensions.Information($"dwGlobalVars: 0x{ dwGlobalVars.ToString("X") }");
            }

            dwGlowObjectManager = Memory.ScanPattern(Structs.Base.ClientPointer, "A1????????A801754B", 1, 4, true);
            {
                if (dwGlowObjectManager == 0) outdatedSignatures.Add("dwGlowObjectManager");

                Extensions.Information($"dwGlowObjectManager: 0x{ dwGlowObjectManager.ToString("X") }");
            }

            dwInput = Memory.ScanPattern(Structs.Base.ClientPointer, "B9????????F30F110424FF5010", 1, 0, true);
            {
                if (dwInput == 0) outdatedSignatures.Add("dwInput");

                Extensions.Information($"dwInput: 0x{ dwInput.ToString("X") }");
            }

            dwLocalPlayer = Memory.ScanPattern(Structs.Base.ClientPointer, "A3????????C705????????????????E8????????59C36A??", 1, 16, true);
            {
                if (dwGameRulesProxy == 0) outdatedSignatures.Add("dwLocalPlayer");

                Extensions.Information($"dwLocalPlayer: 0x{ dwLocalPlayer.ToString("X") }");
            }

            dwMouseEnable = Memory.ScanPattern(Structs.Base.ClientPointer, "B9????????FF503485C07510", 1, 48, true);
            {
                if (dwMouseEnable == 0) outdatedSignatures.Add("dwMouseEnable");

                Extensions.Information($"dwMouseEnable: 0x{ dwMouseEnable.ToString("X") }");
            }

            dwMouseEnablePtr = Memory.ScanPattern(Structs.Base.ClientPointer, "B9????????FF503485C07510", 1, 0, true);
            {
                if (dwGameRulesProxy == 0) outdatedSignatures.Add("dwMouseEnablePtr");

                Extensions.Information($"dwMouseEnablePtr: 0x{ dwMouseEnablePtr.ToString("X") }");
            }

            dwPlayerResource = Memory.ScanPattern(Structs.Base.ClientPointer, "8B3D????????85FF0F84????????81C7", 2, 0, true);
            {
                if (dwPlayerResource == 0) outdatedSignatures.Add("dwPlayerResource");

                Extensions.Information($"dwPlayerResource: 0x{ dwPlayerResource.ToString("X") }");
            }

            #endregion SigScanner

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

        public const int m_ArmorValue = 0xB238;
        public const int m_Collision = 0x318;
        public const int m_CollisionGroup = 0x470;
        public const int m_Local = 0x2FAC;
        public const int m_MoveType = 0x258;
        public const int m_OriginalOwnerXuidHigh = 0x316C;
        public const int m_OriginalOwnerXuidLow = 0x3168;
        public const int m_aimPunchAngle = 0x301C;
        public const int m_aimPunchAngleVel = 0x3028;
        public const int m_bGunGameImmunity = 0x3894;
        public const int m_bHasDefuser = 0xB248;
        public const int m_bHasHelmet = 0xB22C;
        public const int m_bInReload = 0x3245;
        public const int m_bIsDefusing = 0x3888;
        public const int m_totalHitsOnServer = 0xA2C8;
        public const int m_bIsScoped = 0x387E;
        public const int m_bSpotted = 0x939;
        public const int m_bSpottedByMask = 0x97C;
        public const int m_dwBoneMatrix = 0x2698;
        public const int m_fAccuracyPenalty = 0x32B0;
        public const int m_fFlags = 0x100;
        public const int m_flFallbackWear = 0x3178;
        public const int m_flFlashDuration = 0xA2F8;
        public const int m_flFlashMaxAlpha = 0xA2F4;
        public const int m_flNextPrimaryAttack = 0x31D8;
        public const int m_hActiveWeapon = 0x2EE8;
        public const int m_hMyWeapons = 0x2DE8;
        public const int m_hObserverTarget = 0x3360;
        public const int m_hOwner = 0x29BC;
        public const int m_hOwnerEntity = 0x148;
        public const int m_iAccountID = 0x2FA8;
        public const int m_iClip1 = 0x3204;
        public const int m_iCompetitiveRanking = 0x1A44;
        public const int m_iCompetitiveWins = 0x1B48;
        public const int m_iCrosshairId = 0xB2A4;
        public const int m_iEntityQuality = 0x2F8C;
        public const int m_iFOVStart = 0x31D8;
        public const int m_iFOV = 0x31D4;
        public const int m_iGlowIndex = 0xA310;
        public const int m_iHealth = 0xFC;
        public const int m_iItemDefinitionIndex = 0x2F88;
        public const int m_iItemIDHigh = 0x2FA0;
        public const int m_iItemIDLow = 0x2FA4;
        public const int m_iObserverMode = 0x334C;
        public const int m_iShotsFired = 0xA2B0;
        public const int m_iState = 0x31F8;
        public const int m_iTeamNum = 0xF0;
        public const int m_lifeState = 0x25B;
        public const int m_nFallbackPaintKit = 0x3170;
        public const int m_nFallbackSeed = 0x3174;
        public const int m_nFallbackStatTrak = 0x317C;
        public const int m_nForceBone = 0x267C;
        public const int m_nTickBase = 0x3404;
        public const int m_rgflCoordinateFrame = 0x440;
        public const int m_szCustomName = 0x301C;
        public const int m_szLastPlaceName = 0x3588;
        public const int m_vecOrigin = 0x134;
        public const int m_vecMins = 0x320;
        public const int m_vecMaxs = 0x32C;
        public const int m_vecVelocity = 0x110;
        public const int m_vecViewOffset = 0x104;
        public const int m_viewPunchAngle = 0x3010;
        public const int m_szArmsModel = 0x38D7;
        public const int m_hViewModel = 0x32DC;
        public const int m_nModelIndex = 0x254;
        public const int m_flLowerBodyYawTarget = 0x39DC;
        public const int m_bBombTicking = 0x2970;
        public const int m_flC4Blow = 0x297C;
        public const int m_flTimerLength = 0x2980;
        public const int m_flDefuseLength = 0x2990;
        public const int m_flDefuseCountDown = 0x2994;
        public const int m_bBombDefused = 0x2998;
        public const int m_angEyeAngles = 0xB23C;

        #endregion Netvars

        #region Signatures

        public static int dwClientState;
        public static int dwClientState_GetLocalPlayer;
        public static int dwClientState_Map;
        public static int dwClientState_MapDirectory;
        public static int dwClientState_MaxPlayer;
        public static int dwClientState_PlayerInfo;
        public static int dwClientState_State;
        public static int dwClientState_ViewAngles;
        public static int dwClientState_IsHLTV;
        public static int dwEntityList;
        public static int dwForceAttack;
        public static int dwForceAttack2;
        public static int dwForceBackward;
        public static int dwForceForward;
        public static int dwForceJump;
        public static int dwForceLeft;
        public static int dwForceRight;
        public static int dwGameDir;
        public static int dwGameRulesProxy;
        public static int dwGetAllClasses;
        public static int dwGlobalVars;
        public static int dwGlowObjectManager;
        public static int dwInput;
        public static int dwInterfaceLinkList;
        public static int dwLocalPlayer;
        public static int dwMouseEnable;
        public static int dwMouseEnablePtr;
        public static int dwPlayerResource;

        public static int dwRadarBase;
        public static int dwSensitivity;
        public static int dwSensitivityPtr;
        public static int dwViewMatrix;
        public static int dwWeaponTable;
        public static int dwWeaponTableIndex;
        public static int dwYawPtr;
        public static int dwZoomSensitivityRatioPtr;
        public static int dwbSendPackets;
        public static int dwppDirect3DDevice9;
        public static int dwSetClanTag;
        public static int m_pStudioHdr;

        #endregion Signatures
    }
}