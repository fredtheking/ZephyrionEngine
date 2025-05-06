using System.ComponentModel;
using System.Numerics;
using Raylib_cs;
using ZephyrionEngine.Settings;
using ZephyrionEngine.Utils.Interfaces;

namespace ZephyrionEngine.Managers;

public class WindowManager : IRun, ISetup, IUpdateable
{
  public event Action? Resized;
  public event Action? Focused;
  public event Action? Hidden;
  public event Action? Fullscreen;
  public event Action? Maximized;
  public event Action? Minimized;
  
  public void Run()
  {
    while (!Raylib.WindowShouldClose())
    {
      Zephyrion.Pipeline.Update();
      Zephyrion.Managers.PendingChanges.Apply();
      Zephyrion.Pipeline.Render();
    }
  }

  public void Close()
  {
    if (Zephyrion.Settings.Window.SoundOn) Raylib.CloseAudioDevice();
    Raylib.CloseWindow();
  }

  public void Setup()
  {
    WindowSettings window = Zephyrion.Settings.Window;
    
    Raylib.SetConfigFlags(window.Flags);
    Raylib.InitWindow((int)window.Size.X, (int)window.Size.Y, window.Title);
    Raylib.SetTargetFPS(Zephyrion.Settings.Window.Fps);
    if (window.SoundOn) Raylib.InitAudioDevice();
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