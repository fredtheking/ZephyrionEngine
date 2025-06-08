using ZephyrionEngine.Core;
using ZephyrionEngine.Managers;
using ZephyrionEngine.Pools;
using ZephyrionEngine.Settings;
using ZephyrionEngine.Utils.Etc;

namespace ZephyrionEngine;

public static class Zephyrion
{
  public static ManagersDirectory Managers { get; } = new();
  public static SettingsDirectory Settings { get; } = new();
  public static MainPipeline Pipeline { get; } = new();

  public static void Setup(WindowSettings? window = null)
  {
    Settings.Window = window ?? new WindowSettings();
  }
  
  public static void Run()
  {
    if (Managers.SystemSetup.CheckOverallSetup())
    {
      Managers.Debug.Separator(ConsoleColor.DarkYellow, "Hello, world! Setting engine up.");

      Pipeline.Setup();
      Managers.PendingChanges.Apply();  // Apply setup changes
      
      Managers.Debug.Separator(ConsoleColor.Yellow, "Engine started. Booting up initialisation.");
      
      Pipeline.Initialisation();
      Pipeline.Begin();

      Managers.SystemSetup.EngineStarted = true;
      Managers.Debug.Separator(ConsoleColor.Green, "Initialisation ended. Runtime process started.");

      Pipeline.Run();
      
      Managers.Debug.Separator(ConsoleColor.DarkRed, "Terminating program...");
      
      Pipeline.Close();
      
      Managers.Debug.Separator(ConsoleColor.DarkYellow, "Goodbye, world.");
    }
    else
    {
      Console.WriteLine("\tDear Programmer,\n" +
                        "Thank you for using ZephyrionEngine! I hope you have the best time using it! Despite my best efforts, the engine may not be perfect. If you find any bugs, please let me know on Engine's Github page!\n\n" +
                        "I believe you are a newbie, so there are some errors you need to take care of before starting your project:");
      
      if (!Managers.SystemSetup.RegistrySuccessful) Console.WriteLine("\t- Registry Setup: This Engine uses registry to store all the game data. Consider creating one.");
      
      Console.WriteLine("\nIf you have any questions, you are open to visit the documentation on GitHub. Rebuild as soon as you fix the errors.\n" +
                        "Engine's Github: https://github.com/TaswellFan/ZephyrionEngine\n" +
                        "Documentation: https://github.com/TaswellFan");
    }
  }
}