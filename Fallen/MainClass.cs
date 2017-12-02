#region

using Fallen.API;
using Fallen.Features;
using Memory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;

using System.Windows.Forms;

#endregion

namespace Fallen
{
    internal class MainClass
    {
        public static int ClientPointer;
        public static int EnginePointer;
        public static IntPtr mProc_H;

        private static void Main(string[] args)
        {
            MemoryManager.Initialize("csgo");

            ClientPointer = MemoryManager.GetModuleAdress("client");
            EnginePointer = MemoryManager.GetModuleAdress("engine");
            mProc_H = MemoryManager.m_pProcessHandle;

            List<string> outdatedSignatures = Offsets.ScanPatterns();

            Initialize();

            Application.Run();
        }

        [STAThread]
        public static void Initialize()
        {
            //////////////////////
            //INITIALIZE MESSAGE//
            //////////////////////

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

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

            AddressReaderCall();
            ConsoleReaderCall();
            GlowCall();
            TriggerCall();
            AimbotCall();
            BunnyCall();
            SkinchangerCall();
            RadarCall();
            MischacksCall();
            KeyProcCall();
            GUICall();
        }

        /////////////////
        //ADRESS READER//
        /////////////////

        public static void AddressReaderCall()
        {
            var AddressReaderThread = new Thread(SDK.AddressReader);
            AddressReaderThread.Start();
        }

        //////////////////
        //CONSOLE READER//
        //////////////////

        public static void ConsoleReaderCall()
        {
            var ConsoleReader = new ConsoleReader();

            var ConsoleReaderThread = new Thread(ConsoleReader.Run);
            ConsoleReaderThread.Start();
        }

        ///////////////
        //GLOW THREAD//
        ///////////////

        public static void GlowCall()
        {
            var Glow = new Glow();

            var GlowThread = new Thread(Glow.Run);
            GlowThread.Start();
        }

        //////////////////
        //TRIGGER THREAD//
        //////////////////

        public static void TriggerCall()
        {
            var Trigger = new Trigger();

            var TriggerThread = new Thread(Trigger.Run);
            TriggerThread.Start();
        }

        /////////////////////////
        //RECOIL CONTROL THREAD//
        /////////////////////////

        public static void AimbotCall()
        {
            var RCS = new RCS();

            var RCSThread = new Thread(RCS.Run);
            RCSThread.Start();
        }

        ////////////////
        //BUNNY THREAD//
        ////////////////

        public static void BunnyCall()
        {
            var Bunny = new Bunny();

            var BunnyThread = new Thread(Bunny.Run);
            BunnyThread.Start();
        }

        ////////////////
        //RADAR THREAD//
        ////////////////

        public static void RadarCall()
        {
            var Radar = new Radar();

            var RadarThread = new Thread(Radar.Run);
            RadarThread.Start();
        }

        //////////////////////
        //SKINCHANGER THREAD//
        //////////////////////

        public static void SkinchangerCall()
        {
            var Skinchanger = new Skinchanger();

            var SkinchangerThread = new Thread(Skinchanger.Run);
            SkinchangerThread.Start();
        }

        ///////////////
        //MISC THREAD//
        ///////////////

        public static void MischacksCall()
        {
            var Misc = new Misc();

            var MiscThread = new Thread(Misc.Run);
            MiscThread.Start();
        }

        //?//////////////
        //KEYPROC THEAD//
        /////////////////

        public static void KeyProcCall()
        {
            var KeyPROCThread = new Thread(SDK.KeyboardProc);
            KeyPROCThread.Start();
        }

        //////////////
        //GUI THREAD//
        //////////////

        public static void GUICall()
        {
            GUI.OverlayForm.Run(mProc_H);
        }
    }
}