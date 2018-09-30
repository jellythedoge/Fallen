#region

using Fallen.Other;
using System.Threading;
using System.Windows.Forms;

#endregion

namespace Fallen.Managers
{
    internal class Watcher
    {
        static bool IsKeyDown(Keys key) => (Imports.GetAsyncKeyState(key) & 0x8000) > 0;

        public static void Run()
        {
            while (true)
            {
                Thread.Sleep(5);

                Settings.Bhop.Key = IsKeyDown(Keys.Space);

                Settings.Trigger.Key = IsKeyDown(Keys.LMenu);

                Settings.Autopistol.Key = IsKeyDown(Keys.LButton);
            }
        }
    }
}