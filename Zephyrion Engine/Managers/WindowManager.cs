using Raylib_cs;
using ZephyrionEngine.Core;
using ZephyrionEngine.Settings;
using ZephyrionEngine.Utils.Interfaces;

namespace ZephyrionEngine.Managers;

public class WindowManager : IScript, IRunGame
{
  public WindowSetting Settings { get; set; }
  public event Action<ZephyrionGame> Resized;
  public event Action<ZephyrionGame> Focused;
  public event Action<ZephyrionGame> Hidden;
  public event Action<ZephyrionGame> Fullscreen;
  public event Action<ZephyrionGame> Maximized;
  public event Action<ZephyrionGame> Minimized;
  
  public void Run(ZephyrionGame game)
  {
    while (!Raylib.WindowShouldClose())
    {
      game.Pipeline.Update(game);
      game.Pipeline.Render(game);
    }
  }

  public void Close(ZephyrionGame game)
  {
    if (Settings.SoundOn) Raylib.CloseAudioDevice();
    Raylib.CloseWindow();
  }

  public void Initialisation(ZephyrionGame game)
  {
    Raylib.SetConfigFlags(Settings.Flags);
    Raylib.InitWindow((int)Settings.Size.X, (int)Settings.Size.Y, Settings.Title);
    if (Settings.SoundOn) Raylib.InitAudioDevice();
  }

  public void Start(ZephyrionGame game)
  {
    
  }

  public void Update(ZephyrionGame game)
  {
    if (Raylib.IsWindowResized()) Resized?.Invoke(game);
    if (Raylib.IsWindowFocused()) Focused?.Invoke(game);
    if (Raylib.IsWindowHidden()) Hidden?.Invoke(game);
    if (Raylib.IsWindowFullscreen()) Fullscreen?.Invoke(game);
    if (Raylib.IsWindowMaximized()) Maximized?.Invoke(game);
    if (Raylib.IsWindowMinimized()) Minimized?.Invoke(game);
  }

  public void Render(ZephyrionGame game)
  {
    Raylib.DrawRectangleRec(new Rectangle(0, 0, 100 ,100), Color.White);
  }
}