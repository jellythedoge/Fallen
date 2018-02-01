#region

using Fallen.Features;
using Fallen.Managers;
using Fallen.Other;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;

#endregion

namespace Fallen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Memory.Initialize("csgo");

            Structs.Base.ClientPointer = Memory.GetModuleAddress("client.dll");
            Structs.Base.EnginePointer = Memory.GetModuleAddress("engine.dll");

            List<string> outdatedSignatures = Offsets.ScanPatterns();

            INI.INI.LoadConfig();

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

            var readerThread = new Thread(Reader.Run);
            var watcherThread = new Thread(Watcher.Run);

            var autopistolThread = new Thread(Autopistol.Run);
            var bunnyThread = new Thread(Bunny.Run);
            var glowThread = new Thread(Glow.Run);
            var miscThread = new Thread(Misc.Run);
            var radarThread = new Thread(Radar.Run);
            var rCSThread = new Thread(RCS.Run);
            var skinChangerThread = new Thread(Skinchanger.Run);
            var triggerThread = new Thread(Trigger.Run);

            readerThread.Start();
            watcherThread.Start();

            autopistolThread.Start();
            bunnyThread.Start();
            glowThread.Start();
            miscThread.Start();
            rCSThread.Start();
            skinChangerThread.Start();
            triggerThread.Start();
        }
    }
}














































































































































































































