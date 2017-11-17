using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fallen.API
{
    internal class Settings
    {
        ///////////////////
        //Feature Toggles//
        ///////////////////

        public struct Glow
        {
            public static bool GlowTeam = true;
            public static bool GlowEnemy = true;

            public static bool ChamsTeam = true;
            public static bool ChamsEnemy = true;

            public static float TeamRed = 0;
            public static float TeamGreen = 0;
            public static float TeamBlue = 255;

            public static float EnemyRed = 255;
            public static float EnemyGreen = 0;
            public static float EnemyBlue = 0;
        }

        public struct Bhop
        {
            public static bool Enabled = false;
            public static bool Key = false;
        }

        public struct Trigger
        {
            public static bool Enabled = false;
            public static bool Key = false;
        }

        public struct Noflash
        {
            public static bool Enabled = false;
            public static float Flash = 255;
        }

        public struct Fovchanger
        {
            public static bool Enabled = false;
            public static int Fov = 90;
        }

        public struct Nohands
        {
            public static bool Enabled = false;
        }

        public struct Overlay
        {
            public static bool Enabled = false;
            public static bool Crosshair = false;
        }

        public struct Hitsound
        {
            public static bool Enabled = false;
            public static int Mode = 1;
        }

        public struct Skinchanger
        {
            public static bool Enabled = false;

            public static int INVALID = -1;
            public static int WEAPON_DEAGLE = 231;
            public static int WEAPON_ELITE = 658;
            public static int WEAPON_FIVESEVEN = 427;
            public static int WEAPON_GLOCK = 38;
            public static int WEAPON_AK47 = 282;
            public static int WEAPON_AUG = 9;
            public static int WEAPON_AWP = 475;
            public static int WEAPON_FAMAS = 10;
            public static int WEAPON_G3SG1 = 11;
            public static int WEAPON_GALILAR = 13;
            public static int WEAPON_M249 = 14;
            public static int WEAPON_M4A1 = 309;
            public static int WEAPON_MAC10 = 17;
            public static int WEAPON_P90 = 19;
            public static int WEAPON_UMP45 = 556;
            public static int WEAPON_XM1014 = 25;
            public static int WEAPON_BIZON = 26;
            public static int WEAPON_MAG7 = 27;
            public static int WEAPON_NEGEV = 28;
            public static int WEAPON_SAWEDOFF = 29;
            public static int WEAPON_TEC9 = 599;
            public static int WEAPON_TASER = 31;
            public static int WEAPON_HKP2000 = 32;
            public static int WEAPON_MP7 = 33;
            public static int WEAPON_MP9 = 34;
            public static int WEAPON_NOVA = 537;
            public static int WEAPON_P250 = 36;
            public static int WEAPON_SCAR20 = 312;
            public static int WEAPON_SG556 = 39;
            public static int WEAPON_SSG08 = 40;
            public static int WEAPON_KNIFE = 42;
            public static int WEAPON_FLASHBANG = 43;
            public static int WEAPON_HEGRENADE = 44;
            public static int WEAPON_SMOKEGRENADE = 45;
            public static int WEAPON_MOLOTOV = 46;
            public static int WEAPON_DECOY = 47;
            public static int WEAPON_INCGRENADE = 48;
            public static int WEAPON_C4 = 49;
            public static int WEAPON_KNIFE_T = 59;
            public static int WEAPON_M4A1_SILENCER = 77;
            public static int WEAPON_USP_SILENCER = 313;
            public static int WEAPON_CZ75A = 350;
            public static int WEAPON_REVOLVER = 64;
            public static int WEAPON_KNIFE_BAYONET = 500;
            public static int WEAPON_KNIFE_FLIP = 505;
            public static int WEAPON_KNIFE_GUT = 506;
            public static int WEAPON_KNIFE_KARAMBIT = 507;
            public static int WEAPON_KNIFE_M9_BAYONET = 508;
            public static int WEAPON_KNIFE_TACTICAL = 509;
            public static int WEAPON_KNIFE_FALCHION = 512;
            public static int WEAPON_KNIFE_SURVIVAL_BOWIE = 514;
            public static int WEAPON_KNIFE_BUTTERFLY = 515;
            public static int WEAPON_KNIFE_PUSH = 516;
            public static int GLOVE_STUDDED_BLOODHOUND = 5027;
            public static int GLOVE_T_SIDE = 5028;
            public static int GLOVE_CT_SIDE = 5029;
            public static int GLOVE_SPORTY = 5030;
            public static int GLOVE_SLICK = 5031;
            public static int GLOVE_LEATHER_WRAP = 5032;
            public static int GLOVE_MOTORCYCLE = 5033;
            public static int GLOVE_SPECIALIST = 5034;
        }
    }
}
