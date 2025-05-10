using System.ComponentModel;
using System.Numerics;
using Raylib_cs;
using ZephyrionEngine.Settings;
using ZephyrionEngine.Utils.Etc;
using ZephyrionEngine.Utils.Interfaces;

namespace ZephyrionEngine.Managers;

public class WindowManager : IRun, IClose, ISetup, IUpdateable
{
  public event Action? Resized;
  public event Action? Focused;
  public event Action? Hidden;
  public event Action? Fullscreen;
  public event Action? Maximized;
  public event Action? Minimized;
  
  internal WindowManager() { }
  
  public void Run()
  {
    while (!Raylib.WindowShouldClose())
    {
      ZE.P.Update();
      ZE.M.PND.Apply();
      ZE.P.Render();
    }
  }

  public void Close()
  {
    if (ZE.S.W.SoundOn) Raylib.CloseAudioDevice();
    Raylib.CloseWindow();
  }

  public void Setup()
  {
    WindowSettings window = ZE.S.W;
    
    Raylib.SetConfigFlags(window.Flags);
    Raylib.InitWindow((int)window.Size.X, (int)window.Size.Y, window.Title);
    Raylib.SetTargetFPS(window.Fps);
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