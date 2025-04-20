using Raylib_cs;
using ZephyrionEngine.Settings;
using ZephyrionEngine.Utils.Interfaces;

namespace ZephyrionEngine.Managers;

public class WindowManager : IRun, ISetup, IUpdateable
{
  public WindowSetting Settings { get; set; }
  public event Action Resized;
  public event Action Focused;
  public event Action Hidden;
  public event Action Fullscreen;
  public event Action Maximized;
  public event Action Minimized;
  
  public void Run()
  {
    while (!Raylib.WindowShouldClose())
    {
      ZephyrionGame.Pipeline.Update();
      ZephyrionGame.Pipeline.Render();
    }
  }

  public void Close()
  {
    if (Settings.SoundOn) Raylib.CloseAudioDevice();
    Raylib.CloseWindow();
  }

  public void Setup()
  {
    Raylib.SetConfigFlags(Settings.Flags);
    Raylib.InitWindow((int)Settings.Size.X, (int)Settings.Size.Y, Settings.Title);
    if (Settings.SoundOn) Raylib.InitAudioDevice();
  }

  public void Initialisation() { }

  public void Begin() { }

  public void Update()
  {
    if (Raylib.IsWindowResized()) Resized?.Invoke();
    if (Raylib.IsWindowFocused()) Focused?.Invoke();
    if (Raylib.IsWindowHidden()) Hidden?.Invoke();
    if (Raylib.IsWindowFullscreen()) Fullscreen?.Invoke();
    if (Raylib.IsWindowMaximized()) Maximized?.Invoke();
    if (Raylib.IsWindowMinimized()) Minimized?.Invoke();
  }
}