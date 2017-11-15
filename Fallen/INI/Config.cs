
#region

using System;
using Fallen.API;
using IniParser;
using System.IO;

#endregion

namespace Fallen.INI.INI
{
    internal class Ini
    {
		static bool LoadFailed;
		
        public static void LoadConfig()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Settings.ini");

            if (!File.Exists(path))
                using (var sw = File.AppendText(path))
                {
                    {
                        sw.WriteLine("");
                        Settings.LoadNoConfig = true;
                    }
                }

            if (Settings.LoadNoConfig)
            {
                Settings.LoadNoConfig = false;
                SaveConfig();
            }
			
			try
            {
                var parser = new FileIniDataParser();
                var data = parser.ReadFile("Settings.ini");
                //Keep ^^

                //Features
                var GlowTeam = data["GLOW TEAM"]["Enabled"];
                var ChamsTeam = data["GLOW TEAM"]["Chams"];
                var TeamRed = data["GLOW TEAM"]["Red"];
                var TeamGreen = data["GLOW TEAM"]["Green"];
                var TeamBlue = data["GLOW TEAM"]["Blue"];

                var GlowEnemy = data["GLOW ENEMY"]["Enabled"];
                var ChamsEnemy = data["GLOW ENEMY"]["Chams"];
                var EnemyRed = data["GLOW ENEMY"]["Red"];
                var EnemyGreen = data["GLOW ENEMY"]["Green"];
                var EnemyBlue = data["GLOW ENEMY"]["Blue"];

                var BhopEnabled = data["BUNNY"]["Enabled"];

                var NoflashEnabled = data["NO FLASH"]["Enabled"];
                var Flash = data["NO FLASH"]["Flash Amount"];

                var NohandsEnabled = data["NOHANDS"]["Enabled"];

                var FovchangerEnabled = data["FOV"]["Enabled"];
                var Fov = data["FOV"]["Fov"];

                var TriggerEnabled = data["TRIGGER"]["Enabled"];

                var OverlayEnabled = data["OVERLAY"]["Enabled"];
                var CrosshairEnabled = data["OVERLAY"]["Crosshair"];

                //Skinchanger
                var SkinchangerEnabled = data["SKINCHANGER"]["Enabled"];
                var DEAGLESkin = data["SKINCHANGER"]["DEAGLESkin"];
                var ELITESkin = data["SKINCHANGER"]["ELITESkin"];
                var FIVESEVENSkin = data["SKINCHANGER"]["FIVESEVENSkin"];
                var GLOCKSkin = data["SKINCHANGER"]["GLOCKSkin"];
                var AK47Skin = data["SKINCHANGER"]["AK47Skin"];
                var AUGSkin = data["SKINCHANGER"]["AUGSkin"];
                var AWPSkin = data["SKINCHANGER"]["AWPSkin"];
                var FAMASSkin = data["SKINCHANGER"]["FAMASSkin"];
                var G3SG1Skin = data["SKINCHANGER"]["G3SG1Skin"];
                var GALILSkin = data["SKINCHANGER"]["GALILSkin"];
                var M249Skin = data["SKINCHANGER"]["M249Skin"];
                var M4A1Skin = data["SKINCHANGER"]["M4A1Skin"];
                var MAC10Skin = data["SKINCHANGER"]["MAC10Skin"];


                //Get value ^^

                Settings.NohandsEnabled = bool.Parse(NohandsEnabled);

                Settings.WEAPON_DEAGLE = int.Parse(DEAGLESkin);

                Settings.TeamRed = int.Parse(TeamRed);
                Settings.TeamGreen = int.Parse(TeamGreen);
                Settings.TeamBlue = int.Parse(TeamBlue);

                Settings.EnemyRed = int.Parse(EnemyRed);
                Settings.EnemyGreen = int.Parse(EnemyGreen);
                Settings.EnemyBlue = int.Parse(EnemyBlue);

                Settings.FovchangerEnabled = bool.Parse(FovchangerEnabled);
                Settings.Fov = int.Parse(Fov);

                Settings.GlowTeam = bool.Parse(GlowTeam);
                Settings.ChamsTeam = bool.Parse(ChamsTeam);
                Settings.GlowEnemy = bool.Parse(GlowEnemy);
                Settings.ChamsEnemy = bool.Parse(ChamsEnemy);

                Settings.TriggerEnabled = bool.Parse(TriggerEnabled);

                Settings.OverlayEnabled = bool.Parse(OverlayEnabled);
                Settings.CrosshairEnabled = bool.Parse(CrosshairEnabled);

                Settings.NoflashEnabled = bool.Parse(NoflashEnabled);
                Settings.Flash = float.Parse(Flash);

                Settings.BhopEnabled = bool.Parse(BhopEnabled);
                //Load config ^^

                //Skinchanger
                Settings.SkinchangerEnabled = bool.Parse(SkinchangerEnabled);

                Settings.WEAPON_DEAGLE = int.Parse(DEAGLESkin);
                Settings.WEAPON_ELITE = int.Parse(ELITESkin);
                Settings.WEAPON_GLOCK = int.Parse(GLOCKSkin);
                Settings.WEAPON_AK47 = int.Parse(AK47Skin);
                Settings.WEAPON_AUG = int.Parse(AUGSkin);
                Settings.WEAPON_AWP = int.Parse(AWPSkin);
                Settings.WEAPON_FAMAS = int.Parse(FAMASSkin);
                Settings.WEAPON_G3SG1 = int.Parse(G3SG1Skin);
                Settings.WEAPON_GALILAR = int.Parse(GALILSkin);
                Settings.WEAPON_M249 = int.Parse(M249Skin);
                Settings.WEAPON_M4A1 = int.Parse(M4A1Skin);
                Settings.WEAPON_MAC10 = int.Parse(MAC10Skin);

                //Special save & load flags ^^
            }
            catch
            {
				Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Config cannot be Loaded!, Try to delete your old one!");
				Console.ForegroundColor = ConsoleColor.White;
				Console.WriteLine("");
				
				LoadFailed = true;
            }
			
			if (!LoadFailed)
			{
				Console.WriteLine("Config Loaded!");
			}
			else
			{
				LoadFailed = false;
			}
		}

        public static void SaveConfig()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Settings.ini");

            if (!File.Exists(path))
                using (var sw = File.AppendText(path))
                {
                    {
                        sw.WriteLine("");
                    }
                }

            var parser = new FileIniDataParser();
            var data = parser.ReadFile("Settings.ini");
            //Keep ^^

            data["GLOW TEAM"]["Enabled"] = Settings.GlowTeam.ToString();
            data["GLOW TEAM"]["Chams"] = Settings.ChamsTeam.ToString();
            data["GLOW TEAM"]["Red"] = Settings.TeamRed.ToString();
            data["GLOW TEAM"]["Green"] = Settings.TeamGreen.ToString();
            data["GLOW TEAM"]["Blue"] = Settings.TeamBlue.ToString();

            data["GLOW ENEMY"]["Enabled"] = Settings.GlowEnemy.ToString();
            data["GLOW ENEMY"]["Chams"] = Settings.ChamsEnemy.ToString();
            data["GLOW ENEMY"]["Red"] = Settings.EnemyRed.ToString();
            data["GLOW ENEMY"]["Green"] = Settings.EnemyGreen.ToString();
            data["GLOW ENEMY"]["Blue"] = Settings.EnemyBlue.ToString();

            data["FOV"]["Enabled"] = Settings.FovchangerEnabled.ToString();
            data["FOV"]["Fov"] = Settings.Fov.ToString();

            data["BUNNY"]["Enabled"] = Settings.BhopEnabled.ToString();

            data["NO FLASH"]["Enabled"] = Settings.NoflashEnabled.ToString();
            data["NO FLASH"]["Flash Amount"] = Settings.Flash.ToString();

            data["NOHANDS"]["Enabled"] = Settings.NohandsEnabled.ToString();

            data["TRIGGER"]["Enabled"] = Settings.TriggerEnabled.ToString();

            data["OVERLAY"]["Enabled"] = Settings.OverlayEnabled.ToString();
            data["OVERLAY"]["Crosshair"] = Settings.CrosshairEnabled.ToString();

            data["SKINCHANGER"]["Enabled"] = Settings.SkinchangerEnabled.ToString();
            data["SKINCHANGER"]["DEAGLESkin"] = Settings.WEAPON_DEAGLE.ToString();
            data["SKINCHANGER"]["ELITESkin"] = Settings.WEAPON_ELITE.ToString();
            data["SKINCHANGER"]["FIVESEVENSkin"] = Settings.WEAPON_FIVESEVEN.ToString();
            data["SKINCHANGER"]["GLOCKSkin"] = Settings.WEAPON_GLOCK.ToString();
            data["SKINCHANGER"]["AK47Skin"] = Settings.WEAPON_AK47.ToString();
            data["SKINCHANGER"]["AUGSkin"] = Settings.WEAPON_AUG.ToString();
            data["SKINCHANGER"]["AWPSkin"] = Settings.WEAPON_AWP.ToString();
            data["SKINCHANGER"]["FAMASSkin"] = Settings.WEAPON_FAMAS.ToString();
            data["SKINCHANGER"]["G3SG1Skin"] = Settings.WEAPON_G3SG1.ToString();
            data["SKINCHANGER"]["GALILSkin"] = Settings.WEAPON_GALILAR.ToString();
            data["SKINCHANGER"]["M249Skin"] = Settings.WEAPON_M249.ToString();
            data["SKINCHANGER"]["M4A1Skin"] = Settings.WEAPON_M4A1.ToString();
            data["SKINCHANGER"]["MAC10Skin"] = Settings.WEAPON_MAC10.ToString();

            //Get value ^^

            parser.WriteFile("Settings.ini", data);
            //Save config ^^
        }
    }
}