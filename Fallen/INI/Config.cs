
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
            bool LoadNoConfig = false;

            if (!File.Exists(path))
                using (var sw = File.AppendText(path))
                {
                    {
                        sw.WriteLine("");
                        LoadNoConfig = true;
                    }
                }

            if (LoadNoConfig)
            {
                LoadNoConfig = false;
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

                var HitsoundEnabled = data["HITSOUND"]["Enabled"];
                var Hitsound = data["HITSOUND"]["Mode"];

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

                Settings.Nohands.Enabled = bool.Parse(NohandsEnabled);

                Settings.Glow.TeamRed = int.Parse(TeamRed);
                Settings.Glow.TeamGreen = int.Parse(TeamGreen);
                Settings.Glow.TeamBlue = int.Parse(TeamBlue);

                Settings.Glow.EnemyRed = int.Parse(EnemyRed);
                Settings.Glow.EnemyGreen = int.Parse(EnemyGreen);
                Settings.Glow.EnemyBlue = int.Parse(EnemyBlue);

                Settings.Fovchanger.Enabled = bool.Parse(FovchangerEnabled);
                Settings.Fovchanger.Fov = int.Parse(Fov);

                Settings.Glow.GlowTeam = bool.Parse(GlowTeam);
                Settings.Glow.ChamsTeam = bool.Parse(ChamsTeam);
                Settings.Glow.GlowEnemy = bool.Parse(GlowEnemy);
                Settings.Glow.ChamsEnemy = bool.Parse(ChamsEnemy);

                Settings.Hitsound.Enabled = bool.Parse(HitsoundEnabled);
                Settings.Hitsound.Mode = int.Parse(Hitsound);

                Settings.Trigger.Enabled = bool.Parse(TriggerEnabled);

                Settings.Overlay.Enabled = bool.Parse(OverlayEnabled);
                Settings.Overlay.Crosshair = bool.Parse(CrosshairEnabled);

                Settings.Noflash.Enabled = bool.Parse(NoflashEnabled);
                Settings.Noflash.Flash = float.Parse(Flash);

                Settings.Bhop.Enabled = bool.Parse(BhopEnabled);
                //Load config ^^

                //Skinchanger
                Settings.Skinchanger.Enabled = bool.Parse(SkinchangerEnabled);

                Settings.Skinchanger.WEAPON_DEAGLE = int.Parse(DEAGLESkin);
                Settings.Skinchanger.WEAPON_ELITE = int.Parse(ELITESkin);
                Settings.Skinchanger.WEAPON_GLOCK = int.Parse(GLOCKSkin);
                Settings.Skinchanger.WEAPON_AK47 = int.Parse(AK47Skin);
                Settings.Skinchanger.WEAPON_AUG = int.Parse(AUGSkin);
                Settings.Skinchanger.WEAPON_AWP = int.Parse(AWPSkin);
                Settings.Skinchanger.WEAPON_FAMAS = int.Parse(FAMASSkin);
                Settings.Skinchanger.WEAPON_G3SG1 = int.Parse(G3SG1Skin);
                Settings.Skinchanger.WEAPON_GALILAR = int.Parse(GALILSkin);
                Settings.Skinchanger.WEAPON_M249 = int.Parse(M249Skin);
                Settings.Skinchanger.WEAPON_M4A1 = int.Parse(M4A1Skin);
                Settings.Skinchanger.WEAPON_MAC10 = int.Parse(MAC10Skin);

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

            data["GLOW TEAM"]["Enabled"] = Settings.Glow.GlowTeam.ToString();
            data["GLOW TEAM"]["Chams"] = Settings.Glow.ChamsTeam.ToString();
            data["GLOW TEAM"]["Red"] = Settings.Glow.TeamRed.ToString();
            data["GLOW TEAM"]["Green"] = Settings.Glow.TeamGreen.ToString();
            data["GLOW TEAM"]["Blue"] = Settings.Glow.TeamBlue.ToString();

            data["GLOW ENEMY"]["Enabled"] = Settings.Glow.GlowEnemy.ToString();
            data["GLOW ENEMY"]["Chams"] = Settings.Glow.ChamsEnemy.ToString();
            data["GLOW ENEMY"]["Red"] = Settings.Glow.EnemyRed.ToString();
            data["GLOW ENEMY"]["Green"] = Settings.Glow.EnemyGreen.ToString();
            data["GLOW ENEMY"]["Blue"] = Settings.Glow.EnemyBlue.ToString();

            data["FOV"]["Enabled"] = Settings.Fovchanger.Enabled.ToString();
            data["FOV"]["Fov"] = Settings.Fovchanger.Fov.ToString();

            data["BUNNY"]["Enabled"] = Settings.Bhop.Enabled.ToString();

            data["NO FLASH"]["Enabled"] = Settings.Noflash.Enabled.ToString();
            data["NO FLASH"]["Flash Amount"] = Settings.Noflash.Flash.ToString();

            data["NOHANDS"]["Enabled"] = Settings.Noflash.Enabled.ToString();

            data["HITSOUND"]["Enabled"] = Settings.Hitsound.Enabled.ToString();
            data["HITSOUND"]["Mode"] = Settings.Hitsound.Mode.ToString();

            data["TRIGGER"]["Enabled"] = Settings.Trigger.Enabled.ToString();

            data["OVERLAY"]["Enabled"] = Settings.Overlay.Enabled.ToString();
            data["OVERLAY"]["Crosshair"] = Settings.Overlay.Crosshair.ToString();

            data["SKINCHANGER"]["Enabled"] = Settings.Skinchanger.Enabled.ToString();
            data["SKINCHANGER"]["DEAGLESkin"] = Settings.Skinchanger.WEAPON_DEAGLE.ToString();
            data["SKINCHANGER"]["ELITESkin"] = Settings.Skinchanger.WEAPON_ELITE.ToString();
            data["SKINCHANGER"]["FIVESEVENSkin"] = Settings.Skinchanger.WEAPON_FIVESEVEN.ToString();
            data["SKINCHANGER"]["GLOCKSkin"] = Settings.Skinchanger.WEAPON_GLOCK.ToString();
            data["SKINCHANGER"]["AK47Skin"] = Settings.Skinchanger.WEAPON_AK47.ToString();
            data["SKINCHANGER"]["AUGSkin"] = Settings.Skinchanger.WEAPON_AUG.ToString();
            data["SKINCHANGER"]["AWPSkin"] = Settings.Skinchanger.WEAPON_AWP.ToString();
            data["SKINCHANGER"]["FAMASSkin"] = Settings.Skinchanger.WEAPON_FAMAS.ToString();
            data["SKINCHANGER"]["G3SG1Skin"] = Settings.Skinchanger.WEAPON_G3SG1.ToString();
            data["SKINCHANGER"]["GALILSkin"] = Settings.Skinchanger.WEAPON_GALILAR.ToString();
            data["SKINCHANGER"]["M249Skin"] = Settings.Skinchanger.WEAPON_M249.ToString();
            data["SKINCHANGER"]["M4A1Skin"] = Settings.Skinchanger.WEAPON_M4A1.ToString();
            data["SKINCHANGER"]["MAC10Skin"] = Settings.Skinchanger.WEAPON_MAC10.ToString();

            //Get value ^^

            parser.WriteFile("Settings.ini", data);
            //Save config ^^
        }
    }
}