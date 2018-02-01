#region

using Fallen.Other;
using IniParser;
using System;
using System.IO;

#endregion

namespace Fallen.INI
{
    internal class INI
    {
        static bool LoadFailed;

        public static void LoadConfig()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Settings.ini");
            var loadNoConfig = false;

            if (!File.Exists(path))
                using (var sw = File.AppendText(path))
                {
                    {
                        sw.WriteLine("");
                        loadNoConfig = true;
                    }
                }

            if (loadNoConfig)
            {
                loadNoConfig = false;
                SaveConfig();
            }

            try
            {
                var parser = new FileIniDataParser();
                var data = parser.ReadFile("Settings.ini");
                // Keep ^^

                // Features
                Settings.GlowTeam.Enabled = bool.Parse(data["GLOW TEAM"]["Enabled"]);
                Settings.GlowTeam.ChamsEnabled = bool.Parse(data["GLOW TEAM"]["Chams"]);
                Settings.GlowTeam.Alpha = float.Parse(data["GLOW TEAM"]["Alpha"]);
                Settings.GlowTeam.Red = float.Parse(data["GLOW TEAM"]["Red"]);
                Settings.GlowTeam.Green = float.Parse(data["GLOW TEAM"]["Green"]);
                Settings.GlowTeam.Blue = float.Parse(data["GLOW TEAM"]["Blue"]);

                Settings.GlowEnemy.Enabled = bool.Parse(data["GLOW ENEMY"]["Enabled"]);
                Settings.GlowEnemy.ChamsEnabled = bool.Parse(data["GLOW ENEMY"]["Chams"]);
                Settings.GlowEnemy.Alpha = float.Parse(data["GLOW ENEMY"]["Alpha"]);
                Settings.GlowEnemy.Red = float.Parse(data["GLOW ENEMY"]["Red"]);
                Settings.GlowEnemy.Green = float.Parse(data["GLOW ENEMY"]["Green"]);
                Settings.GlowEnemy.Blue = float.Parse(data["GLOW ENEMY"]["Blue"]);

                Settings.Bhop.Enabled = bool.Parse(data["BUNNY"]["Enabled"]);
                Settings.Bhop.JumpLimit = bool.Parse(data["BUNNY"]["JumpLimit"]);
                Settings.Bhop.MaxJumps = int.Parse(data["BUNNY"]["MaxJumps"]);

                Settings.NoFlash.Enabled = bool.Parse(data["NO FLASH"]["Enabled"]);

                Settings.NoFlash.Flash = float.Parse(data["NO FLASH"]["Flash Amount"]);

                Settings.NoFlash.Enabled = bool.Parse(data["NOHANDS"]["Enabled"]);

                Settings.Fovchanger.Enabled = bool.Parse(data["FOV"]["Enabled"]);
                Settings.Fovchanger.Fov = int.Parse(data["FOV"]["Fov"]);

                Settings.Hitsound.Enabled = bool.Parse(data["HITSOUND"]["Enabled"]);
                Settings.Hitsound.Mode = int.Parse(data["HITSOUND"]["Mode"]);

                Settings.Trigger.Enabled = bool.Parse(data["TRIGGER"]["Enabled"]);

                Settings.Autopistol.Enabled = bool.Parse(data["AUTOPISTOL"]["Enabled"]);
                Settings.Autopistol.AnyGun = bool.Parse(data["AUTOPISTOL"]["AnyGun"]);

                Settings.Radar.Enabled = bool.Parse(data["RADAR"]["Enabled"]);

                Settings.Aimbot.Enabled = bool.Parse(data["AIMBOT"]["Enabled"]);

                Settings.RCS.Enabled = bool.Parse(data["RCS"]["Enabled"]);
                Settings.RCS.X = float.Parse(data["RCS"]["X"]);
                Settings.RCS.Y = float.Parse(data["RCS"]["Y"]);

                Settings.Skinchanger.Enabled = bool.Parse(data["SKINCHANGER"]["Enabled"]);
                Settings.Skinchanger.WEAPON_DEAGLE = int.Parse(data["SKINCHANGER"]["DEAGLESkin"]);
                Settings.Skinchanger.WEAPON_ELITE = int.Parse(data["SKINCHANGER"]["ELITESkin"]);
                Settings.Skinchanger.WEAPON_FIVESEVEN = int.Parse(data["SKINCHANGER"]["FIVESEVENSkin"]);
                Settings.Skinchanger.WEAPON_GLOCK = int.Parse(data["SKINCHANGER"]["GLOCKSkin"]);
                Settings.Skinchanger.WEAPON_AK47 = int.Parse(data["SKINCHANGER"]["AK47Skin"]);
                Settings.Skinchanger.WEAPON_AUG = int.Parse(data["SKINCHANGER"]["AUGSkin"]);
                Settings.Skinchanger.WEAPON_AWP = int.Parse(data["SKINCHANGER"]["AWPSkin"]);
                Settings.Skinchanger.WEAPON_FAMAS = int.Parse(data["SKINCHANGER"]["FAMASSkin"]);
                Settings.Skinchanger.WEAPON_G3SG1 = int.Parse(data["SKINCHANGER"]["G3SG1Skin"]);
                Settings.Skinchanger.WEAPON_GALILAR = int.Parse(data["SKINCHANGER"]["GALILSkin"]);
                Settings.Skinchanger.WEAPON_M249 = int.Parse(data["SKINCHANGER"]["M249Skin"]);
                Settings.Skinchanger.WEAPON_M4A1 = int.Parse(data["SKINCHANGER"]["M4A1Skin"]);
                Settings.Skinchanger.WEAPON_MAC10 = int.Parse(data["SKINCHANGER"]["MAC10Skin"]);
                Settings.Skinchanger.WEAPON_P90 = int.Parse(data["SKINCHANGER"]["P90Skin"]);
                Settings.Skinchanger.WEAPON_UMP45 = int.Parse(data["SKINCHANGER"]["UMP45Skin"]);
                Settings.Skinchanger.WEAPON_XM1014 = int.Parse(data["SKINCHANGER"]["XM1014Skin"]);
                Settings.Skinchanger.WEAPON_BIZON = int.Parse(data["SKINCHANGER"]["BIZONSkin"]);
                Settings.Skinchanger.WEAPON_BIZON = int.Parse(data["SKINCHANGER"]["BIZONSkin"]);
                Settings.Skinchanger.WEAPON_MAG7 = int.Parse(data["SKINCHANGER"]["MAG7Skin"]);
                Settings.Skinchanger.WEAPON_NEGEV = int.Parse(data["SKINCHANGER"]["NEGEVSkin"]);
                Settings.Skinchanger.WEAPON_SAWEDOFF = int.Parse(data["SKINCHANGER"]["SAWEDOFFSkin"]);
                Settings.Skinchanger.WEAPON_TEC9 = int.Parse(data["SKINCHANGER"]["TEC9Skin"]);
                Settings.Skinchanger.WEAPON_HKP2000 = int.Parse(data["SKINCHANGER"]["HKP2000Skin"]);
                Settings.Skinchanger.WEAPON_MP7 = int.Parse(data["SKINCHANGER"]["MP7Skin"]);
                Settings.Skinchanger.WEAPON_MP9 = int.Parse(data["SKINCHANGER"]["MP9Skin"]);
                Settings.Skinchanger.WEAPON_NOVA = int.Parse(data["SKINCHANGER"]["NOVASkin"]);
                Settings.Skinchanger.WEAPON_P250 = int.Parse(data["SKINCHANGER"]["P250Skin"]);
                Settings.Skinchanger.WEAPON_SCAR20 = int.Parse(data["SKINCHANGER"]["SCAR20Skin"]);
                Settings.Skinchanger.WEAPON_SG556 = int.Parse(data["SKINCHANGER"]["SG556Skin"]);
                Settings.Skinchanger.WEAPON_SSG08 = int.Parse(data["SKINCHANGER"]["SSG08Skin"]);
                // Load config ^^
            }
            catch
            {
                Extensions.Error("Config cannot be Loaded!, Try to delete your old one!");
                Extensions.Error("IF YOU DONT HAVE A CONFIG STOP BITCHING AT ME ON UC!!!");
                Console.WriteLine("");

                LoadFailed = true;
            }

            if (!LoadFailed) Extensions.Information("Config Loaded!");
            else LoadFailed = false;
        }

        public static void SaveConfig()
        {
            var Path = "Settings.ini";

            if (!File.Exists(Path)) File.Create(Path);

            var parser = new FileIniDataParser();
            var data = parser.ReadFile("Settings.ini");
            // Keep ^^

            data["GLOW TEAM"]["Enabled"] = Settings.GlowTeam.Enabled.ToString();
            data["GLOW TEAM"]["Chams"] = Settings.GlowTeam.ChamsEnabled.ToString();
            data["GLOW TEAM"]["Alpha"] = Settings.GlowTeam.Alpha.ToString();
            data["GLOW TEAM"]["Red"] = Settings.GlowTeam.Red.ToString();
            data["GLOW TEAM"]["Green"] = Settings.GlowTeam.Green.ToString();
            data["GLOW TEAM"]["Blue"] = Settings.GlowTeam.Blue.ToString();

            data["GLOW ENEMY"]["Enabled"] = Settings.GlowEnemy.Enabled.ToString();
            data["GLOW ENEMY"]["Chams"] = Settings.GlowEnemy.ChamsEnabled.ToString();
            data["GLOW ENEMY"]["Alpha"] = Settings.GlowEnemy.Alpha.ToString();
            data["GLOW ENEMY"]["Red"] = Settings.GlowEnemy.Red.ToString();
            data["GLOW ENEMY"]["Green"] = Settings.GlowEnemy.Green.ToString();
            data["GLOW ENEMY"]["Blue"] = Settings.GlowEnemy.Blue.ToString();

            data["FOV"]["Enabled"] = Settings.Fovchanger.Enabled.ToString();
            data["FOV"]["Fov"] = Settings.Fovchanger.Fov.ToString();

            data["BUNNY"]["Enabled"] = Settings.Bhop.Enabled.ToString();
            data["BUNNY"]["JumpLimit"] = Settings.Bhop.JumpLimit.ToString();
            data["BUNNY"]["MaxJumps"] = Settings.Bhop.MaxJumps.ToString();

            data["NO FLASH"]["Enabled"] = Settings.NoFlash.Enabled.ToString();
            data["NO FLASH"]["Flash Amount"] = Settings.NoFlash.Flash.ToString();

            data["NOHANDS"]["Enabled"] = Settings.NoFlash.Enabled.ToString();

            data["HITSOUND"]["Enabled"] = Settings.Hitsound.Enabled.ToString();
            data["HITSOUND"]["Mode"] = Settings.Hitsound.Mode.ToString();

            data["TRIGGER"]["Enabled"] = Settings.Trigger.Enabled.ToString();

            data["AUTOPISTOL"]["Enabled"] = Settings.Autopistol.Enabled.ToString();
            data["AUTOPISTOL"]["AnyGun"] = Settings.Autopistol.AnyGun.ToString();

            data["RADAR"]["Enabled"] = Settings.Radar.Enabled.ToString();

            data["AIMBOT"]["Enabled"] = Settings.Aimbot.Enabled.ToString();

            data["RCS"]["Enabled"] = Settings.RCS.Enabled.ToString();
            data["RCS"]["X"] = Settings.RCS.X.ToString();
            data["RCS"]["Y"] = Settings.RCS.Y.ToString();

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
            data["SKINCHANGER"]["P90Skin"] = Settings.Skinchanger.WEAPON_P90.ToString();
            data["SKINCHANGER"]["UMP45Skin"] = Settings.Skinchanger.WEAPON_UMP45.ToString();
            data["SKINCHANGER"]["XM1014Skin"] = Settings.Skinchanger.WEAPON_XM1014.ToString();
            data["SKINCHANGER"]["BIZONSkin"] = Settings.Skinchanger.WEAPON_BIZON.ToString();
            data["SKINCHANGER"]["MAG7Skin"] = Settings.Skinchanger.WEAPON_MAG7.ToString();
            data["SKINCHANGER"]["NEGEVSkin"] = Settings.Skinchanger.WEAPON_NEGEV.ToString();
            data["SKINCHANGER"]["SAWEDOFFSkin"] = Settings.Skinchanger.WEAPON_SAWEDOFF.ToString();
            data["SKINCHANGER"]["TEC9Skin"] = Settings.Skinchanger.WEAPON_TEC9.ToString();
            data["SKINCHANGER"]["HKP2000Skin"] = Settings.Skinchanger.WEAPON_HKP2000.ToString();
            data["SKINCHANGER"]["MP7Skin"] = Settings.Skinchanger.WEAPON_MP7.ToString();
            data["SKINCHANGER"]["MP9Skin"] = Settings.Skinchanger.WEAPON_MP9.ToString();
            data["SKINCHANGER"]["NOVASkin"] = Settings.Skinchanger.WEAPON_NOVA.ToString();
            data["SKINCHANGER"]["P250Skin"] = Settings.Skinchanger.WEAPON_P250.ToString();
            data["SKINCHANGER"]["SCAR20Skin"] = Settings.Skinchanger.WEAPON_SCAR20.ToString();
            data["SKINCHANGER"]["SG556Skin"] = Settings.Skinchanger.WEAPON_SG556.ToString();
            data["SKINCHANGER"]["SSG08Skin"] = Settings.Skinchanger.WEAPON_SSG08.ToString();

            // Get value ^^

            parser.WriteFile("Settings.ini", data);
            // Save config ^^
        }
    }
}