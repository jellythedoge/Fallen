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
        public static ProcessMemory Memory = new ProcessMemory("csgo");

        static void Main(string[] args)
        {
            Memory.StartProcess();

            ClientPointer = Memory.DllImageAddress("client.dll");
            EnginePointer = Memory.DllImageAddress("engine.dll");

            DLLImports.SetHook();

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
            //-<swap>
            Console.WriteLine("Glow status - " + Settings.GlowEnabled + " //STATUS NOT ALWAYS CORRECT");
            Console.WriteLine("ChamsE status - " + Settings.ChamsEnemy);
            Console.WriteLine("ChamsT status - " + Settings.ChamsTeam);
            Console.WriteLine("Trigger status - " + Settings.TriggerEnabled);
            Console.WriteLine("Bhop status - " + Settings.BhopEnabled);
            Console.WriteLine("NoFlash status - " + Settings.NoflashEnabled);
            Console.WriteLine("FOV status - " + Settings.FovchangerEnabled);
            Console.WriteLine("Skinchanger status - " + Settings.SkinchangerEnabled);
            //-<swap/>

            //-<swap>
            AddressReaderCall();
            ConsoleReaderCall();
            GlowCall();
            TriggerCall();
            BunnyCall();
            SkinchangerCall();
            MischacksCall();
            //-<swap/>

            if (Settings.OverlayEnabled)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new GUI.OverlayForm());
            }
        }

        /////////////////
        //ADRESS READER//
        /////////////////

        //-<swap>

        public static void AddressReaderCall()
        {
            var AddressReader = new AddressReader();

            var AddressReaderThread = new Thread(AddressReader.Run);
            AddressReaderThread.Start();
        }

        //-<block>

        //////////////////
        //CONSOLE READER//
        //////////////////

        public static void ConsoleReaderCall()
        {
            var ConsoleReader = new ConsoleReader();

            var ConsoleReaderThread = new Thread(ConsoleReader.Run);
            ConsoleReaderThread.Start();
        }

        //-<block>

        ///////////////
        //GLOW THREAD//
        ///////////////

        public static void GlowCall()
        {
            var Glow = new Glow();

            var GlowThread = new Thread(Glow.Run);
            GlowThread.Start();
        }

        //-<block>

        //////////////////
        //TRIGGER THREAD//
        //////////////////

        public static void TriggerCall()
        {
            var Trigger = new Trigger();

            var TriggerThread = new Thread(Trigger.Run);
            TriggerThread.Start();
        }

        //-<block>

        ////////////////
        //BUNNY THREAD//
        ////////////////

        public static void BunnyCall()
        {
            var Bunny = new Bunny();

            var BunnyThread = new Thread(Bunny.Run);
            BunnyThread.Start();
        }

        //-<block>

        //////////////////////
        //SKINCHANGER THREAD//
        //////////////////////

        public static void SkinchangerCall()
        {
            var Skinchanger = new Skinchanger();

            var SkinchangerThread = new Thread(Skinchanger.Run);
            SkinchangerThread.Start();
        }

        //-<block>

        ///////////////
        //MISC THREAD//
        ///////////////

        public static void MischacksCall()
        {
            var Misc = new Misc();

            var MiscThread = new Thread(Misc.Run);
            MiscThread.Start();
        }

        //-<swap/>
    }
}