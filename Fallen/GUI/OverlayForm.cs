using Fallen.API;
using Overlay;
using System;
using System.Drawing;
using System.Drawing.Text;
using System.Threading;
using System.Windows.Forms;

namespace Fallen.GUI
{
    public partial class OverlayForm : Form
    {
        private RECT rect;
        public const string WINDOW_NAME = "Counter-Strike: Global Offensive";
        private IntPtr handle = SDK.FindWindow(null, WINDOW_NAME);

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

            var WinSize = new Size(rect.Right - rect.Left, rect.Bottom - rect.Top);

            this.Size = WinSize;
            this.Top = rect.Top;
            this.Left = rect.Left;

            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;

            RenderOverlay(sender, e);

            SDK.GetWindowRect(handle, out rect);
        }

        public void RenderOverlay(object sender, PaintEventArgs e)
        {
            OverlayWindow overlay = new OverlayWindow(false);

            var gfx = overlay.Graphics;

            SDK.Vector2D window = new SDK.Vector2D(overlay.X, overlay.Y);

            while (true)
            {
                gfx.BeginScene();
                gfx.ClearScene();

                gfx.FillCircle(100, 100, 100, Color.Red);

                gfx.EndScene();
                Thread.Sleep(1000);
            }
        }
    }
}