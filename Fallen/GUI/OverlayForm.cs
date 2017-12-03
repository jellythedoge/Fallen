#region

using FormOverlayExamples.Objects;
using Overlay;
using System;
using System.Threading;

#endregion

namespace Fallen.GUI
{
    internal class OverlayForm
    {
        public static void Run(IntPtr parentWindowHandle)
        {
            Console.SetWindowSize(Console.LargestWindowWidth / 2, Console.LargestWindowHeight / 2);

            var rendererOptions = new Direct2DRendererOptions()
            {
                AntiAliasing = true,
                Hwnd = IntPtr.Zero,
                MeasureFps = true,
                VSync = false
            };

            OverlayManager manager = new OverlayManager(parentWindowHandle, rendererOptions);

            var overlay = manager.Window;
            var gfx = manager.Graphics;

            var whiteSmoke = gfx.CreateBrush(0xF5, 0xF5, 0xF5, 100);

            var blackBrush = gfx.CreateBrush(0, 0, 0, 255);
            var redBrush = gfx.CreateBrush(255, 0, 0, 255);
            var greenBrush = gfx.CreateBrush(0, 255, 0, 255);
            var blueBrush = gfx.CreateBrush(0, 0, 255, 255);

            var font = gfx.CreateFont("Consolas", 22);

            while (true)
            {
                Thread.Sleep(1000);
                gfx.BeginScene();
                gfx.ClearScene(gfx.CreateBrush(0, 0, 0, 0));
                
                gfx.FillRectangle(100, 100, 100, 100, blueBrush);

                gfx.EndScene();

                Console.WriteLine("End scene");
            }
            Environment.Exit(0);
        }
    }
}