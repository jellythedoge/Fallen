#region

using Fallen.Other;
using System.Threading;
using System.Windows.Forms;

#endregion

namespace Fallen.Managers
{
    internal class Watcher
    {
        static bool GetAsyncKeyState(Keys key) => Imports.GetAsyncKeyState(key) != 0;

        public static void Run()
        {
            while (true)
            {
                Thread.Sleep(5);

                if (GetAsyncKeyState(Keys.Space)) Settings.Bhop.Key = true; else Settings.Bhop.Key = false;

                if (GetAsyncKeyState(Keys.LMenu)) Settings.Trigger.Key = true; else Settings.Trigger.Key = false;

                if (GetAsyncKeyState(Keys.LButton)) Settings.Autopistol.Key = true; else Settings.Autopistol.Key = false;
            }
        }
    }
}