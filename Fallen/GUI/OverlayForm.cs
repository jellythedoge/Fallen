#region

using Fallen.API;
using FormOverlayExamples.Objects;
using Overlay;
using System;
using System.Threading;
using System.Threading.Tasks;

#endregion

namespace Fallen.GUI
{
    internal class OverlayForm
    {
        static int HitMark;

        private struct RECT
        {
            public static float Left;
            public static float Top;
            public static float Right;
            public static float Bottom;
            public static float WCenter;
            public static float HCenter;
        }

        public static void Run(IntPtr parentWindowHandle)
        {
            Console.SetWindowSize(Console.LargestWindowWidth / 2, Console.LargestWindowHeight / 2);

            var rendererOptions = new Direct2DRendererOptions()
            {
                AntiAliasing = true,
                Hwnd = MainClass.mProc_H,
                MeasureFps = true,
                VSync = false
            };

            var manager = new OverlayManager(parentWindowHandle, rendererOptions);

            var overlay = manager.Window;
            var gfx = manager.Graphics;

            var whiteSmoke = gfx.CreateBrush(0xF5, 0xF5, 0xF5, 100);

            var blackBrush = gfx.CreateBrush(0, 0, 0, 255);
            var redBrush = gfx.CreateBrush(255, 0, 0, 255);
            var greenBrush = gfx.CreateBrush(0, 255, 0, 255);
            var blueBrush = gfx.CreateBrush(0, 0, 255, 255);

            var font = gfx.CreateFont("Consolas", 22);

            RECT.Left = overlay.Width - overlay.Width;
            RECT.Top = overlay.Height - overlay.Height;
            RECT.Right = overlay.Width;
            RECT.Bottom = overlay.Height;
            RECT.WCenter = overlay.Width - overlay.Width / 2;
            RECT.HCenter = overlay.Height - overlay.Height / 2;

            while (true)
            {
                Thread.Sleep(50);
                gfx.BeginScene();
                gfx.ClearScene(gfx.CreateBrush(0, 0, 0, 0));

                if (Settings.Overlay.MenuON && !SDK.m_bIsScoped)
                {
                    gfx.FillRectangle(RECT.Left + 100, RECT.HCenter, 50, 50, blueBrush);
                }

                if (Settings.Overlay.Crosshair)
                {
                    gfx.FillEllipse(RECT.WCenter, RECT.HCenter, 3, 3, redBrush);
                }

                if (SDK.HitVal != SDK.HitAmmount || HitMark > 1)
                {
                    HitMarker();
                }

                gfx.EndScene();
            }

            Environment.Exit(0);
        }

        static async Task HitMarker()
        {
            HitMark = HitMark + 1;

            if (HitMark > 1)
            {
                HitMark = 0;
            }

            await Task.Delay(5);
        }
    }
}