using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Fallen.Other
{
    internal class Imports
    {
        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(Keys vKey);
    }
}
