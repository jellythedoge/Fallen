namespace Fallen.API
{
    internal struct Entity
    {
        public int Base;
        public int Dormant;
        public int GlowIndex;
        public int Health;
        public int Team;
    }

    internal struct LocalPlayer
    {
        public static int Base;
        public static int ClientState;
        public static int GlowBase;
        public static int JumpFlags;
        public static int Team;
    }

    internal struct Weapon
    {
        public int m_iBase;
        public int m_iXuIDLow;
        public int m_iTexture;
        public int m_iItemDefinitionIndex;
    };

    internal class Arrays
    {
        public static Entity[] Entity = new Entity[64];
    }
}