#region

using Fallen.API;
using hazedumper;
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
                        Console.WriteLine(MainClass.Memory.ReadInt(LocalPlayer.Base + netvars.m_iHealth));
                        MainClass.Memory.WriteInt(netvars.m_iHealth, 500);
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
                        Settings.Noflash.Flash = float.Parse(Console.ReadLine());
                        break;

                    case "change fov":
                        Console.WriteLine("Enter a number between 0-255");
                        Settings.Fovchanger.Fov = int.Parse(Console.ReadLine());
                        break;

                    case "noflash":
                        if (Settings.Noflash.Enabled)
                            Console.WriteLine("NoFlash Off!");
                        else if (!Settings.Noflash.Enabled)
                            Console.WriteLine("NoFlash On!");

                        Settings.Noflash.Enabled = !Settings.Noflash.Enabled;
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
                            Settings.Glow.GlowEnemy = true;
                            Settings.Glow.GlowTeam = true;
                        }
                        else
                        {
                            Console.WriteLine("Glow Off!");
                            Settings.Glow.GlowEnemy = false;
                            Settings.Glow.GlowTeam = true;
                        }
                        break;

                    case "chams":
                        Settings.Glow.ChamsTeam = !Settings.Glow.ChamsTeam;
                        Settings.Glow.ChamsEnemy = !Settings.Glow.ChamsEnemy;
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
                        //Console.WriteLine("Available Commands are noFlash, glow, fov, bhop, trigger, chams 'ENABLED AFTER GLOW', change fov, change Flash");
                        break;

                    case "clear":
                        Console.Title = "Fallen Sharp CSGO - " + File.GetLastWriteTime(Assembly.GetExecutingAssembly().Location);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Clear();
                        Console.WriteLine("/////////////////////");
                        Console.WriteLine("//Fallen Sharp CSGO//");
                        Console.WriteLine("/////////////////////");
                        Console.WriteLine("");
                        Console.WriteLine("GlowE status - " + Settings.Glow.GlowEnemy);
                        Console.WriteLine("GlowT status - " + Settings.Glow.GlowTeam);
                        Console.WriteLine("ChamsE status - " + Settings.Glow.ChamsEnemy);
                        Console.WriteLine("ChamsT status - " + Settings.Glow.ChamsTeam);
                        Console.WriteLine("Trigger status - " + Settings.Trigger.Enabled);
                        Console.WriteLine("Bhop status - " + Settings.Bhop.Enabled);
                        Console.WriteLine("NoFlash status - " + Settings.Noflash.Enabled);
                        Console.WriteLine("FOV status - " + Settings.Fovchanger.Enabled);
                        Console.WriteLine("Skinchanger status - " + Settings.Skinchanger.Enabled);
                        break;

                    case "save":
                    case "save config":
                        INI.INI.Ini.SaveConfig();
                        Console.WriteLine("Config Saved!");
                        break;

                    case "load":
                    case "load config":
                        INI.INI.Ini.LoadConfig();
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