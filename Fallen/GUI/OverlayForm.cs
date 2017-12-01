using Fallen.API;
using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

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

        private Font SharpFont = new Font("Arial Bold", 15.0f);

        private Pen Crosshair = new Pen(Color.FromArgb(255, 255, 0, 0));

        private RECT rect;
        public const string WINDOW_NAME = "Counter-Strike: Global Offensive";
        private IntPtr handle = SDK.FindWindow(null, WINDOW_NAME);

        public struct RECT
        {
            public int left, top, right, bottom;
        }

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

            int initialStyle = SDK.GetWindowLong(this.Handle, -20);
            SDK.SetWindowLong(this.Handle, -20, initialStyle | 0x80000 | 0x20);
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

            SDK.GetWindowRect(handle, out rect);
        }

        public void RenderOverlay(object sender, PaintEventArgs e)
        {
            Render = e.Graphics;

            TextRenderer.DrawText(e.Graphics, "Fallen Sharp CSGO.", this.Font,
                new Rectangle(rect.left / 8, rect.top - 30, 200, 100), Color.FromArgb(255, 0, 200, 0));

            /////////////
            //Crosshair//
            /////////////

            if (Settings.Overlay.Crosshair)
            {
                Render.DrawEllipse(Crosshair, rect.left + rect.right / 2 - 3, rect.top + rect.bottom / 2 - 3, 5, 5);
            }

            //////////////
            //TEST CLOSE//
            //////////////
        }
    }
}