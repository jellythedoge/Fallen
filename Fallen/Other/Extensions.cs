using Fallen.Managers;
using System;
using System.Threading.Tasks;

namespace Fallen.Other
{
    internal class Extensions
    {
        public static async Task cl_fullupdate()
        {
            Memory.WriteMemory<int>(Structs.LocalPlayer.m_iClientState + 0x174, -1);

            await Task.Delay(1000);
        }

        public static void Information(string text)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine(text);

            Console.ResetColor();
        }

        public static void Error(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(text);

            Console.ResetColor();
        }
    }
}
