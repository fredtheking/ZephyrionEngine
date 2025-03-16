using OpenTK.Mathematics;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using ZephyrionEngine.Utils.Interfaces;
using ZephyrionEngine.Utils.Settings;
using Monitor = OpenTK.Windowing.GraphicsLibraryFramework.Monitor;

namespace ZephyrionEngine;

public class ZephyrionGame : IScript
{
  public ZGameWindow GameWindow;
  public SetupHelper Settings;

  public ZephyrionGame(WindowSettings? window = null)
  {
    Settings = new(this)
    {
      Window = window ?? new WindowSettings()
    };

    NativeWindowSettings nativeWindow = new NativeWindowSettings
    {
      Title = Settings.Window.Title,
      WindowBorder = Settings.Window.BorderMode,
      WindowState = Settings.Window.State,
      ClientSize = Settings.Window.Size,
    };
    
    if (Settings.Window.MinSize != -Vector2i.One) nativeWindow.MinimumClientSize = Settings.Window.MinSize;
    if (Settings.Window.MaxSize != -Vector2i.One) nativeWindow.MaximumClientSize = Settings.Window.MaxSize;
    if (Settings.Window.StartPosition == -Vector2i.One)
    {
      unsafe
      {
        VideoMode* mode = GLFW.GetVideoMode(GLFW.GetPrimaryMonitor());
        nativeWindow.Location = new Vector2i((mode->Width - Settings.Window.Size.X) / 2, (mode->Height - Settings.Window.Size.Y) / 2);
      }
    }
    
    GameWindow = new ZGameWindow(this, GameWindowSettings.Default, nativeWindow);
  }
  
  public void Run()
  {
    if (Settings.CheckSetup())
    {
      Console.WriteLine("Starting Zephyrion engine...");
      
      Console.WriteLine("Engine started!");

      GameWindow.Run();
    }
    else
    {
      Console.WriteLine("\tDear Programmer,\n" +
                        "Thank you for using ZephyrionEngine! I hope you have the best time using it! Despite my best efforts, the engine may not be perfect. If you find any bugs, please let me know on Engine's Github page!\n\n" +
                        "I believe you are a newbie, so there are some errors you need to take care of before starting your project:");
      
      if (!Settings.SetupWindow) Console.WriteLine("\t- Window Setup: Looks like you need to provide WindowSettings builder class.");
      if (!Settings.SetupRegistry) Console.WriteLine("\t- Registry Setup: This Engine uses registry to store all the game data. Consider creating one.");
      
      Console.WriteLine("\nIf you have any questions, you are open to visit the documentation on GitHub. Rebuild as soon as you fix the errors.\n" +
                        "Engine's Github: https://github.com/TaswellFan\n" +
                        "Documentation: https://github.com/TaswellFan");
    }
  }
}