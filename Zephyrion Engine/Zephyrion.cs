using ZephyrionEngine.Core;
using ZephyrionEngine.Managers;
using ZephyrionEngine.Pools;
using ZephyrionEngine.Settings;

namespace ZephyrionEngine;

public static class Zephyrion
{
  public static ManagersDirectory Managers { get; } = new();
  public static SettingsDirectory Settings { get; } = new();
  public static PoolsDirectory Pools { get; } = new();
  public static MainPipeline Pipeline { get; } = new();

  public static void Setup(WindowSettings? window = null)
  {
    Settings.Window = window ?? new WindowSettings();
  }
  
  public static void Run()
  {
    if (Managers.SystemSetup.CheckOverallSetup())
    {
      Managers.Debug.Separator(ConsoleColor.DarkYellow, "Setting up Zephyrion engine...");
      
      Pipeline.Setup();
      
      Managers.Debug.Separator(ConsoleColor.Yellow, "Engine started! Opening window...");
      
      Pipeline.Initialisation();
      Pipeline.Begin();
      
      Managers.Debug.Separator(ConsoleColor.Green, "Initialisation ended. Enjoy!");

      Managers.Window.Run();
      Managers.Window.Close();
      
      Managers.Debug.Separator(ConsoleColor.Green, "Terminating program. See you soon!");
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