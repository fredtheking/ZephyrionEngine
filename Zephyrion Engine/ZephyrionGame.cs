using OpenTK.Mathematics;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using ZephyrionEngine.Core;
using ZephyrionEngine.Managers;
using ZephyrionEngine.Pools;
using ZephyrionEngine.Settings;

namespace ZephyrionEngine;

public class ZephyrionGame
{
  public ManagersDirectory Managers { get; } = new();
  public SettingsDirectory Settings { get; } = new();
  public PoolsDirectory Pools { get; } = new();
  public MainPipeline Pipeline { get; } = new();

  public ZephyrionGame(WindowSetting? window = null)
  {
    Settings.Window = window ?? new WindowSetting();

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
    
    Managers.Window.It = new ZephyrionGameWindow(this, GameWindowSettings.Default, nativeWindow);
    
    Pipeline.SystemSetup(this);
    Pipeline.Initialisation(this);
    Pipeline.Start(this);
  }
  
  public void Run()
  {
    if (Managers.Setup.CheckOverallSetup())
    {
      Console.WriteLine("Starting Zephyrion engine...");
      
      Console.WriteLine("Engine started! Opening window...");

      Managers.Window.It.Run();
    }
    else
    {
      Console.WriteLine("\tDear Programmer,\n" +
                        "Thank you for using ZephyrionEngine! I hope you have the best time using it! Despite my best efforts, the engine may not be perfect. If you find any bugs, please let me know on Engine's Github page!\n\n" +
                        "I believe you are a newbie, so there are some errors you need to take care of before starting your project:");
      
      if (!Managers.Setup.WindowSuccessful) Console.WriteLine("\t- Window Setup: Looks like you need to provide WindowSettings builder class.");
      if (!Managers.Setup.RegistrySuccessful) Console.WriteLine("\t- Registry Setup: This Engine uses registry to store all the game data. Consider creating one.");
      if (!Managers.Setup.OpenGLExtensionsSuccessful) Console.WriteLine("\t- OpenGL Extensions Setup: Honestly, no idea what you can do here. Cry?");
      
      Console.WriteLine("\nIf you have any questions, you are open to visit the documentation on GitHub. Rebuild as soon as you fix the errors.\n" +
                        "Engine's Github: https://github.com/TaswellFan/ZephyrionEngine\n" +
                        "Documentation: https://github.com/TaswellFan");
    }
  }
}