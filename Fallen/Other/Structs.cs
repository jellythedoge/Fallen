using System.Runtime.InteropServices;

namespace Fallen.Other
{
    internal class Structs
    {
        internal struct Base
        {
            public static int ClientPointer;
            public static int EnginePointer;
        }

        internal struct LocalPlayer
        {
            public static int m_iBase;
            public static int m_iTeamNum;
            public static int m_iClientState;
            public static int m_iGlowBase;
            public static int m_fFlags;
            public static int m_hActiveWeapon;
            public static int m_iCrosshairID;
            public static int m_Lifestate;

            public static Maths.QAngle m_angEyeAngles;
            public static Maths.Vector3D m_VecOrigin;
        }

        internal struct Entity
        {
            public int m_iID;
            public int m_iBase;
            public int m_iDormant;
            public int m_iHealth;
            public int m_iTeam;
            public int m_iGlowIndex;

            public Maths.Vector3D m_VecOrigin;
            public Maths.Vector3D m_VecMin;
            public Maths.Vector3D m_VecMax;

            internal class Arrays
            {
                public static Entity[] Entity = new Entity[64];
            }
        }

        internal struct Weapons
        {
            public static int m_iBase;
            public static int m_iXuIDLow;
            public static int m_iTexture;
            public static int m_iItemDefinitionIndex;
            public static int m_hActiveWeapon;

            public static int WeaponClass;
        };

        internal class Arrays
        {
            public static Entity[] Entity = new Entity[64];
        }

        [StructLayout(LayoutKind.Explicit)]
        internal struct LocalPlayer_t
        {
            [FieldOffset(Offsets.m_iTeamNum)]
            public int m_iTeamNum;

            [FieldOffset(Offsets.m_bIsScoped)]
            public int m_bIsScoped;
        }

        [StructLayout(LayoutKind.Explicit)]
        internal struct Entity_t
        {
            [FieldOffset(Offsets.m_vecOrigin)]
            public Maths.Vector3D m_vecOrigin;

            [FieldOffset(Offsets.m_vecMins)]
            public Maths.Vector3D m_vecMins;

            [FieldOffset(Offsets.m_vecMaxs)]
            public Maths.Vector3D m_vecMaxs;

            [FieldOffset(Offsets.m_iTeamNum)]
            public int m_iTeamNum;

            [FieldOffset(Offsets.m_iHealth)]
            public int m_iHealth;

            [FieldOffset(0xE9)]
            public int m_iDormant;

            [FieldOffset(Offsets.m_iGlowIndex)]
            public int m_iGlowIndex;
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

            [FieldOffset(0x24)]
            public bool m_bRenderWhenOccluded;

            [FieldOffset(0x25)]
            public bool m_bRenderWhenUnoccluded;

            [FieldOffset(0x2C)]
            public bool m_bFullBloom;
        };

        public struct ChamsObject
        {
            public byte r;

            public byte g;

            public byte b;

            public byte a;
        }
    }
}
