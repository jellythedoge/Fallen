#region

using Fallen.API;
using Fallen.Features;
using Memory;
using System;
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

        static void Main(string[] args)
        {
            ProcessMemory.Initialize("csgo");

            ClientPointer = ProcessMemory.GetModuleAdress("client");
            EnginePointer = ProcessMemory.GetModuleAdress("engine");

            Initialize();

            Application.Run();
        }

        [STAThread]
        public static void Initialize()
        {

            //////////////////////
            //INITIALIZE MESSAGE//
            //////////////////////

            INI.INI.Ini.LoadConfig();

            Console.Title = "Fallen Sharp CSGO - " + File.GetLastWriteTime(Assembly.GetExecutingAssembly().Location);
            Console.ForegroundColor = ConsoleColor.White;
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

            AddressReaderCall();
            ConsoleReaderCall();
            GlowCall();
            TriggerCall();
            BunnyCall();
            SkinchangerCall();
            MischacksCall();

            SDK.KeyboardProc();

            if (Settings.Overlay.Enabled)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new GUI.OverlayForm());
            }
        }

        /////////////////
        //ADRESS READER//
        /////////////////

        public static void AddressReaderCall()
        {
            var AddressReader = new AddressReader();

            var AddressReaderThread = new Thread(AddressReader.Run);
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
        
        ////////////////
        //BUNNY THREAD//
        ////////////////

        public static void BunnyCall()
        {
            var Bunny = new Bunny();

            var BunnyThread = new Thread(Bunny.Run);
            BunnyThread.Start();
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
    }
}