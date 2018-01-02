#region

using Fallen.API;
using Memory;
using System;
using System.IO;
using System.Reflection;

#endregion

namespace Fallen.Features
{
    internal class ConsoleReader
    {
        internal void Run()
        {
            bool glow = true;

            while (true)
            {
                var input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "test":
                        Console.WriteLine(MemoryManager.ReadMemory<int>(SDK.LocalPlayer.m_iBase + Offsets.m_iHealth));
                        MemoryManager.WriteMemory<int>(Offsets.m_iHealth, 500);
                        break;

                    case "skins":
                    case "skinchanger":
                        if (!Settings.Skinchanger.Enabled)
                        {
                            Settings.Skinchanger.Enabled = !Settings.Skinchanger.Enabled;
                            Console.WriteLine("Skinchanger Changer On!");
                        }
                        else
                        {
                            Settings.Skinchanger.Enabled = !Settings.Skinchanger.Enabled;
                            Console.WriteLine("Skinchanger changer Off!");
                        }
                        break;

                    case "change flash":
                        Console.WriteLine("Enter a number between 0-255");
                        Settings.NoFlash.Flash = float.Parse(Console.ReadLine());
                        break;

                    case "change fov":
                        Console.WriteLine("Enter a number between 0-255");
                        Settings.Fovchanger.Fov = int.Parse(Console.ReadLine());
                        break;

                    case "NoFlash":
                        if (Settings.NoFlash.Enabled)
                            Console.WriteLine("NoFlash Off!");
                        else if (!Settings.NoFlash.Enabled)
                            Console.WriteLine("NoFlash On!");

                        Settings.NoFlash.Enabled = !Settings.NoFlash.Enabled;
                        break;

                    case "fov":
                        if (!Settings.Fovchanger.Enabled)
                        {
                            Settings.Fovchanger.Enabled = !Settings.Fovchanger.Enabled;
                            Console.WriteLine("Fov Changer On!");
                        }
                        else
                        {
                            Settings.Fovchanger.Enabled = !Settings.Fovchanger.Enabled;
                            Console.WriteLine("Fov changer Off!");
                        }
                        break;

                    case "glow":
                        MainClass.GlowCall();
                        if (!glow)
                        {
                            Console.WriteLine("Glow On!");
                            Settings.GlowEnemy.Enabled = true;
                            Settings.GlowTeam.Enabled = true;
                        }
                        else
                        {
                            Console.WriteLine("Glow Off!");
                            Settings.GlowEnemy.Enabled = false;
                            Settings.GlowTeam.Enabled = true;
                        }
                        break;

                    case "chams":
                        Settings.GlowTeam.ChamsEnabled = !Settings.GlowTeam.ChamsEnabled;
                        Settings.GlowEnemy.ChamsEnabled = !Settings.GlowEnemy.ChamsEnabled;
                        break;

                    case "trigger":
                        MainClass.TriggerCall();
                        if (Settings.Trigger.Enabled)
                            Console.WriteLine("Trigger On!");
                        else
                            Console.WriteLine("Trigger Off!");
                        break;

                    case "bhop":
                        MainClass.BunnyCall();
                        if (Settings.Bhop.Enabled)
                            Console.WriteLine("Bhop On!");
                        else
                            Console.WriteLine("Bhop Off!");
                        break;

                    case "help":
                    case "commands":
                        //Console.WriteLine("Available Commands are NoFlash, glow, fov, bhop, trigger, chams 'ENABLED AFTER GLOW', change fov, change Flash");
                        break;

                    case "clear":
                        Console.Clear();
                        Console.Title = "Fallen Sharp CSGO - " + File.GetLastWriteTime(Assembly.GetExecutingAssembly().Location);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("/////////////////////");
                        Console.WriteLine("//Fallen Sharp CSGO//");
                        Console.WriteLine("/////////////////////");
                        Console.WriteLine("");
                        Console.WriteLine("GlowE status - " + Settings.GlowEnemy.Enabled);
                        Console.WriteLine("GlowT status - " + Settings.GlowTeam.Enabled);
                        Console.WriteLine("ChamsE status - " + Settings.GlowEnemy.ChamsEnabled);
                        Console.WriteLine("ChamsT status - " + Settings.GlowTeam.ChamsEnabled);
                        Console.WriteLine("FOV status - " + Settings.Fovchanger.Enabled);
                        Console.WriteLine("Bhop status - " + Settings.Bhop.Enabled);
                        Console.WriteLine("NoFlash status - " + Settings.NoFlash.Enabled);
                        Console.WriteLine("NoHands status - " + Settings.Nohands.Enabled);
                        Console.WriteLine("Hitsound status - " + Settings.Hitsound.Enabled);
                        Console.WriteLine("Trigger status - " + Settings.Trigger.Enabled);
                        Console.WriteLine("Autopistol status - " + Settings.Autopistol.Enabled);
                        Console.WriteLine("Radar status - " + Settings.Radar.Enabled);
                        Console.WriteLine("Aimbot status - " + Settings.Aimbot.Enabled + " // DOES NOTHING AT THE MOMENT");
                        Console.WriteLine("RCS status - " + Settings.RCS.Enabled);
                        Console.WriteLine("Skinchanger status - " + Settings.Skinchanger.Enabled);
                        Console.WriteLine("");
                        break;

                    case "save":
                    case "save config":
                        INI.INI.SaveConfig();
                        Console.WriteLine("Config Saved!");
                        break;

                    case "load":
                    case "load config":
                        INI.INI.LoadConfig();
                        break;

                    case "exit":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid Input!");
                        break;
                }
            }
        }
    }
}