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

        public static bool GlowEnabled = false;
        public static bool BhopEnabled = false;
        public static bool TriggerEnabled = false;
        public static bool NoflashEnabled = false;
        public static bool SkinchangerEnabled = false;
        public static bool FovchangerEnabled = false;
        public static bool NohandsEnabled = false;

        public static bool OverlayEnabled = false;
        public static bool CrosshairEnabled = false;

        public static bool Spacedown = false;
        public static bool LAltdown = false;

        //////////////////
        //Config Options//
        //////////////////
            
        public static bool LoadNoConfig = false;
        
        public static bool ChamsTeam = true;
        public static bool ChamsEnemy = true;

        public static bool GlowTeam = true;
        public static bool GlowEnemy = true;

        public static int Fov = 90;
        public static float Flash = 255;

        ///////////////
        //Glow Colors//
        ///////////////

        public static float TeamRed = 0;
        public static float TeamGreen = 0;
        public static float TeamBlue = 255;

        public static float EnemyRed = 255;
        public static float EnemyGreen = 0;
        public static float EnemyBlue = 0;

        ///////////////
        //SKINCHANGER//
        ///////////////

        public static int
        INVALID = -1,
        WEAPON_DEAGLE = 231,
        WEAPON_ELITE = 658,
        WEAPON_FIVESEVEN = 427,
        WEAPON_GLOCK = 38,
        WEAPON_AK47 = 282,
        WEAPON_AUG = 9,
        WEAPON_AWP = 475,
        WEAPON_FAMAS = 10,
        WEAPON_G3SG1 = 11,
        WEAPON_GALILAR = 13,
        WEAPON_M249 = 14,
        WEAPON_M4A1 = 309,
        WEAPON_MAC10 = 17,
        WEAPON_P90 = 19,
        WEAPON_UMP45 = 556,
        WEAPON_XM1014 = 25,
        WEAPON_BIZON = 26,
        WEAPON_MAG7 = 27,
        WEAPON_NEGEV = 28,
        WEAPON_SAWEDOFF = 29,
        WEAPON_TEC9 = 599,
        WEAPON_TASER = 31,
        WEAPON_HKP2000 = 32,
        WEAPON_MP7 = 33,
        WEAPON_MP9 = 34,
        WEAPON_NOVA = 537,
        WEAPON_P250 = 36,
        WEAPON_SCAR20 = 312,
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
        WEAPON_M4A1_SILENCER = 77,
        WEAPON_USP_SILENCER = 313,
        WEAPON_CZ75A = 350,
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
        GLOVE_SPECIALIST = 5034;
    }
}
