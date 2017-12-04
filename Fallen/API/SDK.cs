#region

using Memory;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Math;

#endregion

namespace Fallen.API
{
    /////////////////////
    //CSGO EXTERNAL SDK//
    /////////////////////

    #region Structs

    internal struct Entity
    {
        public int m_iBase;
        public int m_iDormant;
        public int m_iHealth;
        public int m_iTeam;
        public int m_iGlowIndex;
    }

    internal struct LocalPlayer
    {
        public static int m_iBase;
        public static int m_iTeam;
        public static int m_iClientState;
        public static int m_iGlowBase;
        public static int m_iJumpFlags;
    }

    internal class Arrays
    {
        public static Entity[] Entity = new Entity[64];
    }

    #endregion

    #region States

    public enum GameState
    {
        MENU = 0,
        GAME = 6
    }

    public enum Team
    {
        NONE,
        Spectator,
        Terrorist,
        Counter_Terrorist
    }

    public enum LifeState
    {
        Alive,
        Dead,
        Spectating
    }

    #endregion

    internal static class SDK
    {
        #region GlobalFunctions

        public static string HeldWeapon;
        public static bool m_bIsScoped;
        public static int HitAmmount;
        public static int HitVal;

        #region AddressReader

        public static async void AddressReader()
        {
            while (true)
            {
                ////////////////
                //LOCAL PLAYER//
                ////////////////

                LocalPlayer.m_iBase = MemoryManager.ReadMemory<int>(MainClass.ClientPointer + Offsets.dwLocalPlayer);
                LocalPlayer.m_iTeam = MemoryManager.ReadMemory<int>(LocalPlayer.m_iBase + Offsets.m_iTeamNum);
                LocalPlayer.m_iClientState = MemoryManager.ReadMemory<int>(MainClass.EnginePointer + Offsets.dwClientState);
                LocalPlayer.m_iGlowBase = MemoryManager.ReadMemory<int>(MainClass.ClientPointer + Offsets.dwGlowObjectManager);
                LocalPlayer.m_iJumpFlags = MemoryManager.ReadMemory<int>(LocalPlayer.m_iBase + Offsets.m_fFlags);

                ////////////////
                //ENTITY STUFF//
                ////////////////

                for (var i = 0; i < 64; i++)
                {
                    var Entity = Arrays.Entity[i];

                    Entity.m_iBase = MemoryManager.ReadMemory<int>(MainClass.ClientPointer + Offsets.dwEntityList + i * 0x10);

                    if (Entity.m_iBase > 0)
                    {
                        Entity.m_iTeam = MemoryManager.ReadMemory<int>(Entity.m_iBase + Offsets.m_iTeamNum);
                        Entity.m_iHealth = MemoryManager.ReadMemory<int>(Entity.m_iBase + Offsets.m_iHealth);
                        Entity.m_iDormant = MemoryManager.ReadMemory<int>(Entity.m_iBase + 0xE9);
                        Entity.m_iGlowIndex = MemoryManager.ReadMemory<int>(Entity.m_iBase + Offsets.m_iGlowIndex);

                        Arrays.Entity[i] = Entity;
                    }

                    #region WeaponINFO

                    m_bIsScoped = MemoryManager.ReadMemory<bool>(LocalPlayer.m_iBase + Offsets.m_bIsScoped);
                    HitVal = MemoryManager.ReadMemory<int>(LocalPlayer.m_iBase + 0xA2C8);

                    Weapon Weapon = new Weapon();

                    #region CurrentWeapon

                    // My Current Weapon
                    var CurrentWeapon = (MemoryManager.ReadMemory<int>(LocalPlayer.m_iBase + Offsets.m_hActiveWeapon + (i - 1) * 0x4)) & 0xFFF;

                    var WepBaseC = MemoryManager.ReadMemory<int>(MainClass.ClientPointer + Offsets.dwEntityList + (CurrentWeapon - 1) * 0x10);

                    Weapon.m_ICurrentWeapon = MemoryManager.ReadMemory<int>(WepBaseC + Offsets.m_iItemDefinitionIndex);

                    switch (Weapon.m_ICurrentWeapon)
                    {
                        #region RIFLE

                        case (int)WeaponIDs.WEAPON_AK47:
                            SDK.HeldWeapon = "RIFLE";
                            await Task.Delay(20);
                            break;

                        case (int)WeaponIDs.WEAPON_AUG:
                            SDK.HeldWeapon = "RIFLE";
                            await Task.Delay(20);
                            break;

                        case (int)WeaponIDs.WEAPON_AWP:
                            SDK.HeldWeapon = "RIFLE";
                            await Task.Delay(20);
                            break;

                        case (int)WeaponIDs.WEAPON_BIZON:
                            SDK.HeldWeapon = "RIFLE";
                            await Task.Delay(20);
                            break;

                        case (int)WeaponIDs.WEAPON_FAMAS:
                            SDK.HeldWeapon = "RIFLE";
                            await Task.Delay(20);
                            break;

                        case (int)WeaponIDs.WEAPON_G3SG1:
                            SDK.HeldWeapon = "RIFLE";
                            await Task.Delay(20);
                            break;

                        case (int)WeaponIDs.WEAPON_GALILAR:
                            SDK.HeldWeapon = "RIFLE";
                            await Task.Delay(20);
                            break;

                        case (int)WeaponIDs.WEAPON_M4A1:
                            SDK.HeldWeapon = "RIFLE";
                            await Task.Delay(20);
                            break;

                        case (int)WeaponIDs.WEAPON_SCAR20:
                            SDK.HeldWeapon = "RIFLE";
                            await Task.Delay(20);
                            break;

                        case (int)WeaponIDs.WEAPON_SG556:
                            SDK.HeldWeapon = "RIFLE";
                            await Task.Delay(20);
                            break;

                        case (int)WeaponIDs.WEAPON_SSG08:
                            SDK.HeldWeapon = "RIFLE";
                            await Task.Delay(20);
                            break;

                        case (int)WeaponIDs.WEAPON_M4A1_SILENCER:
                            SDK.HeldWeapon = "RIFLE";
                            await Task.Delay(20);
                            break;

                        #endregion

                        #region SMG

                        case (int)WeaponIDs.WEAPON_MAC10:
                            SDK.HeldWeapon = "SMG";
                            await Task.Delay(20);
                            break;

                        case (int)WeaponIDs.WEAPON_P90:
                            SDK.HeldWeapon = "SMG";
                            await Task.Delay(20);
                            break;

                        case (int)WeaponIDs.WEAPON_UMP45:
                            SDK.HeldWeapon = "SMG";
                            await Task.Delay(20);
                            break;

                        case (int)WeaponIDs.WEAPON_MP7:
                            SDK.HeldWeapon = "SMG";
                            await Task.Delay(20);
                            break;

                        case (int)WeaponIDs.WEAPON_MP9:
                            SDK.HeldWeapon = "SMG";
                            await Task.Delay(20);
                            break;

                        #endregion

                        #region HEAVY

                        case (int)WeaponIDs.WEAPON_NEGEV:
                            SDK.HeldWeapon = "HEAVY";
                            await Task.Delay(20);
                            break;

                        case (int)WeaponIDs.WEAPON_M249:
                            SDK.HeldWeapon = "HEAVY";
                            await Task.Delay(20);
                            break;

                        #endregion

                        #region PISTOL

                        case (int)WeaponIDs.WEAPON_DEAGLE:
                            SDK.HeldWeapon = "PISTOL";
                            await Task.Delay(20);
                            break;

                        case (int)WeaponIDs.WEAPON_ELITE:
                            SDK.HeldWeapon = "PISTOL";
                            await Task.Delay(20);
                            break;

                        case (int)WeaponIDs.WEAPON_FIVESEVEN:
                            SDK.HeldWeapon = "PISTOL";
                            await Task.Delay(20);
                            break;

                        case (int)WeaponIDs.WEAPON_GLOCK:
                            SDK.HeldWeapon = "PISTOL";
                            await Task.Delay(20);
                            break;

                        case (int)WeaponIDs.WEAPON_TEC9:
                            SDK.HeldWeapon = "PISTOL";
                            await Task.Delay(20);
                            break;

                        case (int)WeaponIDs.WEAPON_HKP2000:
                            SDK.HeldWeapon = "PISTOL";
                            await Task.Delay(20);
                            break;

                        case (int)WeaponIDs.WEAPON_USP_SILENCER:
                            SDK.HeldWeapon = "PISTOL";
                            await Task.Delay(20);
                            break;

                        case (int)WeaponIDs.WEAPON_CZ75A:
                            SDK.HeldWeapon = "PISTOL";
                            await Task.Delay(20);
                            break;

                        case (int)WeaponIDs.WEAPON_REVOLVER:
                            SDK.HeldWeapon = "PISTOL";
                            await Task.Delay(20);
                            break;

                        case (int)WeaponIDs.WEAPON_P250:
                            SDK.HeldWeapon = "PISTOL";
                            await Task.Delay(20);
                            break;

                        #endregion

                        #region SHOTGUN

                        case (int)WeaponIDs.WEAPON_XM1014:
                            SDK.HeldWeapon = "SHOTGUN";
                            await Task.Delay(20);
                            break;

                        case (int)WeaponIDs.WEAPON_MAG7:
                            SDK.HeldWeapon = "SHOTGUN";
                            await Task.Delay(20);
                            break;

                        case (int)WeaponIDs.WEAPON_SAWEDOFF:
                            SDK.HeldWeapon = "SHOTGUN";
                            await Task.Delay(20);
                            break;

                        case (int)WeaponIDs.WEAPON_NOVA:
                            SDK.HeldWeapon = "SHOTGUN";
                            await Task.Delay(20);
                            break;

                        #endregion

                        #region KNIFE

                        case (int)WeaponIDs.WEAPON_KNIFE:
                            SDK.HeldWeapon = "KNIFE";
                            await Task.Delay(20);
                            break;

                        #endregion

                        default:
                            await Task.Delay(20);
                            break;
                    }

                    #endregion

                    #endregion
                }
                Thread.Sleep(1);
            }
        }

        #endregion

        public static async Task ForceFullUpdate()
        {
            MemoryManager.WriteMemory<int>(LocalPlayer.m_iClientState + 0x174, -1);

            await Task.Delay(1000);
        }

        public static Random Rand = new Random();
        private static IntPtr handle;

        #endregion

        #region Logging

        public static void Log(string text, bool newLine)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine(text);
        }

        public static void Error(string text, bool newLine)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(text);
        }

        #endregion

        #region HotKeys

        public static bool KeyPressed(Keys key) => GetAsyncKeyState(key) != 0;

        public static async void KeyboardProc()
        {
            while (true)
            {
                #region FeatureToggles

                if (KeyPressed(Keys.F1))
                {
                    INI.INI.SaveConfig();
                    await Task.Delay(400);
                }

                if (KeyPressed(Keys.F2))
                {
                    INI.INI.LoadConfig();
                    await Task.Delay(400);
                }

                if (KeyPressed(Keys.F4))
                {
                    ForceFullUpdate();
                    await Task.Delay(400);
                }

                ///Overlay MENU stuff
                ///

                if (KeyPressed(Keys.Insert))
                {
                    Settings.Overlay.MenuON = !Settings.Overlay.MenuON;
                    Thread.Sleep(400);
                }

                #endregion

                #region FeatureConstants

                if (KeyPressed(Keys.Space))
                {
                    if (!Settings.Bhop.Key)
                        Settings.Bhop.Key = true;
                }
                else
                {
                    if (Settings.Bhop.Key)
                        Settings.Bhop.Key = false;
                }

                if (KeyPressed(Keys.LMenu))
                {
                    if (!Settings.Trigger.Key)
                        Settings.Trigger.Key = true;
                }
                else
                {
                    if (Settings.Trigger.Key)
                        Settings.Trigger.Key = false;
                }

                if (KeyPressed(Keys.LButton))
                {
                    if (!Settings.Autopistol.Key)
                        Settings.Autopistol.Key = true;
                }
                else
                {
                    if (Settings.Autopistol.Key)
                        Settings.Autopistol.Key = false;
                }

                #endregion

                Thread.Sleep(10);
            }
        }

        #endregion

        #region Weapons

        internal struct Weapon
        {
            public int m_iBase;
            public int m_iXuIDLow;
            public int m_iTexture;
            public int m_iItemDefinitionIndex;
            public int m_ICurrentWeapon;
        };

        #region IDS

        public enum WeaponIDs
        {
            INVALID = -1,
            WEAPON_DEAGLE = 1,
            WEAPON_ELITE = 2,
            WEAPON_FIVESEVEN = 3,
            WEAPON_GLOCK = 4,
            WEAPON_AK47 = 7,
            WEAPON_AUG = 8,
            WEAPON_AWP = 9,
            WEAPON_FAMAS = 10,
            WEAPON_G3SG1 = 11,
            WEAPON_GALILAR = 13,
            WEAPON_M249 = 14,
            WEAPON_M4A1 = 16,
            WEAPON_MAC10 = 17,
            WEAPON_P90 = 19,
            WEAPON_UMP45 = 24,
            WEAPON_XM1014 = 25,
            WEAPON_BIZON = 26,
            WEAPON_MAG7 = 27,
            WEAPON_NEGEV = 28,
            WEAPON_SAWEDOFF = 29,
            WEAPON_TEC9 = 30,
            WEAPON_TASER = 31,
            WEAPON_HKP2000 = 32,
            WEAPON_MP7 = 33,
            WEAPON_MP9 = 34,
            WEAPON_NOVA = 35,
            WEAPON_P250 = 36,
            WEAPON_SCAR20 = 38,
            WEAPON_SG556 = 39,
            WEAPON_SSG08 = 40,
            WEAPON_KNIFE = 42,
            WEAPON_FLASHBANG = 43,
            WEAPON_HEGRENADE = 44,
            WEAPON_SMOKEGRENADE = 45,
            WEAPON_MOLOTOV = 46,
            WEAPON_DECOY = 47,
            WEAPON_INCGRENADE = 48,
            WEAPON_C4 = 49,
            WEAPON_KNIFE_T = 59,
            WEAPON_M4A1_SILENCER = 60,
            WEAPON_USP_SILENCER = 61,
            WEAPON_CZ75A = 63,
            WEAPON_REVOLVER = 64,
            WEAPON_KNIFE_BAYONET = 500,
            WEAPON_KNIFE_FLIP = 505,
            WEAPON_KNIFE_GUT = 506,
            WEAPON_KNIFE_KARAMBIT = 507,
            WEAPON_KNIFE_M9_BAYONET = 508,
            WEAPON_KNIFE_TACTICAL = 509,
            WEAPON_KNIFE_FALCHION = 512,
            WEAPON_KNIFE_SURVIVAL_BOWIE = 514,
            WEAPON_KNIFE_BUTTERFLY = 515,
            WEAPON_KNIFE_PUSH = 516,
            GLOVE_STUDDED_BLOODHOUND = 5027,
            GLOVE_T_SIDE = 5028,
            GLOVE_CT_SIDE = 5029,
            GLOVE_SPORTY = 5030,
            GLOVE_SLICK = 5031,
            GLOVE_LEATHER_WRAP = 5032,
            GLOVE_MOTORCYCLE = 5033,
            GLOVE_SPECIALIST = 5034
        }

        #endregion

        #endregion

        #region Math

        #region VECTOR

        public struct QAngle
        {
            public float x;
            public float y;
            public float z;

            public QAngle(float x, float y, float z)
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }
        };

        public struct Vector3D
        {
            public float x;
            public float y;
            public float z;

            public Vector3D(float x, float y, float z)
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }

            public static Vector3D operator +(Vector3D v1, Vector3D v2)
            {
                return new Vector3D(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
            }

            public static Vector3D operator -(Vector3D v1, Vector3D v2)
            {
                return new Vector3D(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
            }

            public static Vector3D operator *(Vector3D v1, Vector3D v2)
            {
                return new Vector3D(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z);
            }

            public static Vector3D operator /(Vector3D v1, Vector3D v2)
            {
                return new Vector3D(v1.x / v2.x, v1.y / v2.y, v1.z / v2.z);
            }

            public float VectorDistance(Vector3D v1, Vector3D v2)
            {
                return (float)Sqrt(Pow(v1.x - v2.x, 2) + Pow(v1.y - v2.y, 2) + Pow(v1.z - v2.z, 2));
            }

            public Vector3D VectorClone()
            {
                return new Vector3D(this.x, this.y, this.z);
            }
        };

        public struct Vector2D
        {
            public float x;
            public float y;

            public Vector2D(float x, float y)
            {
                this.x = x;
                this.y = y;
            }

            public static Vector2D operator +(Vector2D v1, Vector2D v2)
            {
                return new Vector2D(v1.x + v2.x, v1.y + v2.y);
            }

            public static Vector2D operator -(Vector2D v1, Vector2D v2)
            {
                return new Vector2D(v1.x - v2.x, v1.y - v2.y);
            }

            public static Vector2D operator *(Vector2D v1, Vector2D v2)
            {
                return new Vector2D(v1.x * v2.x, v1.y * v2.y);
            }

            public static Vector2D operator /(Vector2D v1, Vector2D v2)
            {
                return new Vector2D(v1.x / v2.x, v1.y / v2.y);
            }

            public float VectorDistance(Vector2D v1, Vector2D v2)
            {
                return (float)Sqrt(Pow(v1.x - v2.x, 2) + Pow(v1.y - v2.y, 2));
            }

            public Vector2D VectorClone()
            {
                return new Vector2D(this.x, this.y);
            }
        };

        #endregion

        #region ANGLES

        public static Vector3D ClampAngle(Vector3D angle)
        {
            while (angle.y > 180) angle.y -= 360;
            while (angle.y < -180) angle.y += 360;

            if (angle.x > 89.0f) angle.x = 89.0f;
            if (angle.x < -89.0f) angle.x = -89.0f;

            angle.z = 0f;

            return angle;
        }

        public static Vector3D NormalizeAngle(Vector3D angle)
        {
            while (angle.x < -180.0f) angle.x += 360.0f;
            while (angle.x > 180.0f) angle.x -= 360.0f;

            while (angle.x < -180.0f) angle.y += 360.0f;
            while (angle.x > 180.0f) angle.y -= 360.0f;

            while (angle.z < -180.0f) angle.z += 360.0f;
            while (angle.z > 180.0f) angle.z -= 360.0f;

            return angle;
        }

        #endregion

        #endregion

        #region Structs && Other

        public static IntPtr Open_pHandel(string processName)
        {
            Process[] proc = Process.GetProcessesByName(processName);
            if (proc.Length == 0)
            {
                handle = IntPtr.Zero;
                return handle;
            }
            else if (proc.Length > 1)
            {
                throw new Exception("More then one process found.");
            }
            else
            {
                handle = proc[0].MainWindowHandle;
                return handle;
            }
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct GlowObject
        {
            [FieldOffset(0x00)]
            public int EntityPointer;
            [FieldOffset(0x4)]
            public float r;
            [FieldOffset(0x8)]
            public float g;
            [FieldOffset(0xC)]
            public float b;
            [FieldOffset(0x10)]
            public float a;
            [FieldOffset(0x14)]
            public int jnk1;
            [FieldOffset(0x18)]
            public int jnk2;
            [FieldOffset(0x1C)]
            public float BloomAmount;
            [FieldOffset(0x20)]
            public int jnk3;

            [FieldOffset(0x24)]
            public bool m_bRenderWhenOccluded;
            [FieldOffset(0x25)]
            public bool m_bRenderWhenUnoccluded;
            [FieldOffset(0x2C)]
            public bool m_bFullBloom;
        };

        #endregion

        #region DLLImports

        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(Keys vKey);

        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        #endregion
    }
}