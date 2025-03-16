using OpenTK.Graphics.ES30;
using OpenTK.Windowing.Desktop;
using ZephyrionEngine;

public class ZephyrionGameWindow : GameWindow
{
  private ZephyrionGame Game;

  public ZephyrionGameWindow(ZephyrionGame game, GameWindowSettings gameWindowSettings,
    NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
  {
    Game = game;
    RenderFrame += args =>
    {
      GL.Clear(ClearBufferMask.ColorBufferBit);
      
      SwapBuffers();
    };
  }
}
