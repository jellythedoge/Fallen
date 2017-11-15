using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using Fallen.API;
using Fallen.Features;


using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Drawing2D;

namespace Fallen.GUI
{
    public partial class OverlayForm : Form
    {

        ////////////
        //Booleans//
        ////////////

        public static bool Item1 = true;
        public static bool Item2 = false;
        public static bool Item3 = false;
        public static bool Item4 = false;
        public static bool Item5 = false;
        public static bool Item6 = false;
        public static bool Item7 = false;
        public static bool Item8 = false;
        public static bool Item9 = false;
        public static bool Item10 = false;
        public static bool Item11 = false;


        /////////////////
        //Render helper//
        /////////////////

        public Graphics Render;

        public SolidBrush CubeOn = new SolidBrush(Color.FromArgb(255, 0, 255, 0));
        public SolidBrush CubeOff = new SolidBrush(Color.FromArgb(255, 255, 0, 0));

        public SolidBrush CubeRed = new SolidBrush(Color.Red);
        public SolidBrush CubeGreen = new SolidBrush(Color.Green);
        public SolidBrush CubeBlue = new SolidBrush(Color.Blue);
        public SolidBrush CubeBlack = new SolidBrush(Color.Black);
        public SolidBrush CubeYellow = new SolidBrush(Color.Yellow);

        public Pen PenBlack = new Pen(Color.Black);

        Font SharpFont = new Font("Arial Bold", 15.0f);

        Pen Crosshair = new Pen(Color.FromArgb(255, 255, 0, 0));

        RECT rect;
        public const string WINDOW_NAME = "Counter-Strike: Global Offensive";
        IntPtr handle = FindWindow(null, WINDOW_NAME);

        public struct RECT
        {
            public int left, top, right, bottom;
        }

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr hwnd, out RECT lpRect);

        public OverlayForm()
        {
            InitializeComponent();
        }

        private void OverlayForm_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Wheat;
            this.TransparencyKey = Color.Wheat;
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            //Render.TextRenderingHint = TextRenderingHint.AntiAlias;

            int initialStyle = GetWindowLong(this.Handle, -20);
            SetWindowLong(this.Handle, -20, initialStyle | 0x80000 | 0x20);
        }

        private void OverlayForm_Paint(object sender, PaintEventArgs e)
        {
            ///////////////
            //Window Size//
            ///////////////

            var WinSize = new Size(rect.right - rect.left, rect.bottom - rect.top);

            this.Size = WinSize;
            this.Top = rect.top;
            this.Left = rect.left;
            this.Font = SharpFont;

            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;

            RenderOverlay(sender, e);

            GetWindowRect(handle, out rect);
        }

        public void RenderOverlay(object sender, PaintEventArgs e)
        {
            Render = e.Graphics;
            
            TextRenderer.DrawText(e.Graphics, "Fallen Sharp CSGO.", this.Font,
                new Rectangle(rect.left / 8, rect.top - 30, 200, 100), Color.FromArgb(255, 0, 200, 0));

            /////////////
            //Crosshair//
            /////////////

            if (Settings.CrosshairEnabled)
            {
                Render.DrawEllipse(Crosshair, rect.left + rect.right / 2 - 3, rect.top + rect.bottom / 2 - 3, 5, 5);
            }

            //////////////
            //TEST CLOSE//
            //////////////


        }
    }
}