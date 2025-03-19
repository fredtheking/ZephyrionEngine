using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Desktop;
using ZephyrionEngine;

public class ZephyrionGameWindow : GameWindow
{
  private ZephyrionGame Game;

  public ZephyrionGameWindow(ZephyrionGame game, GameWindowSettings gameWindowSettings,
    NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
  {
    Game = game;
    UpdateFrame += args => Game.Pipeline.Update(Game, args.Time);
    RenderFrame += args =>
    {
      GL.Clear(ClearBufferMask.ColorBufferBit);
      Game.Pipeline.Render(Game);
      SwapBuffers();
    };
  }
}
