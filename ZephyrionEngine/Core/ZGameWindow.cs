using OpenTK.Graphics.ES30;
using OpenTK.Windowing.Desktop;
using ZephyrionEngine;

public class ZGameWindow : GameWindow
{
  private ZephyrionGame Game;

  public ZGameWindow(ZephyrionGame game, GameWindowSettings gameWindowSettings,
    NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
  {
    Game = game;
    RenderFrame += args =>
    {
      GL.Clear(ClearBufferMask.ColorBufferBit);
      
      SwapBuffers();
    };
  }

  public override void Run()
  {
    base.Run();
    Console.WriteLine("Hi!");
  }
}
