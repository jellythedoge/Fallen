#region

using Fallen.API;
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
                        if (!Settings.SkinchangerEnabled)
                        {
                            Settings.SkinchangerEnabled = !Settings.SkinchangerEnabled;
                            Console.WriteLine("Skinchanger Changer On!");
                        }
                        else
                        {
                            Settings.SkinchangerEnabled = !Settings.SkinchangerEnabled;
                            Console.WriteLine("Skinchanger changer Off!");
                        }
                        break;

                    case "change flash":
                        Console.WriteLine("Enter a number between 0-255");
                        Settings.Flash = float.Parse(Console.ReadLine());
                        break;

                    case "change fov":
                        Console.WriteLine("Enter a number between 0-255");
                        Settings.Fov = int.Parse(Console.ReadLine());
                        break;

                    case "noflash":
                        if (Settings.NoflashEnabled)
                            Console.WriteLine("NoFlash Off!");
                        else if (!Settings.NoflashEnabled)
                            Console.WriteLine("NoFlash On!");

                        Settings.NoflashEnabled = !Settings.NoflashEnabled;
                        break;

                    case "fov":
                        if (!Settings.FovchangerEnabled)
                        {
                            Settings.FovchangerEnabled = !Settings.FovchangerEnabled;
                            Console.WriteLine("Fov Changer On!");
                        }
                        else
                        {
                            Settings.FovchangerEnabled = !Settings.FovchangerEnabled;
                            Console.WriteLine("Fov changer Off!");
                        }
                        break;

                    case "glow":
                        MainClass.GlowCall();
                        if (!Settings.GlowEnabled)
                            Console.WriteLine("Glow On!");
                        else
                            Console.WriteLine("Glow Off!");
                        break;

                    case "chams":
                        Settings.ChamsTeam = !Settings.ChamsTeam;
                        Settings.ChamsEnemy = !Settings.ChamsEnemy;
                        break;

                    case "trigger":
                        MainClass.TriggerCall();
                        if (Settings.TriggerEnabled)
                            Console.WriteLine("Trigger On!");
                        else
                            Console.WriteLine("Trigger Off!");
                        break;

                    case "bhop":
                        MainClass.BunnyCall();
                        if (Settings.BhopEnabled)
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
                        Console.WriteLine("");
                        Console.WriteLine("Glow status - " + Settings.GlowEnabled + " //STATUS NOT ALWAYS CORRECT");
                        Console.WriteLine("ChamsE status - " + Settings.ChamsEnemy);
                        Console.WriteLine("ChamsT status - " + Settings.ChamsTeam);
                        Console.WriteLine("Trigger status - " + Settings.TriggerEnabled);
                        Console.WriteLine("Bhop status - " + Settings.BhopEnabled);
                        Console.WriteLine("NoFlash status - " + Settings.NoflashEnabled);
                        Console.WriteLine("FOV status - " + Settings.FovchangerEnabled);
                        Console.WriteLine("Skinchanger status - " + Settings.SkinchangerEnabled);
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