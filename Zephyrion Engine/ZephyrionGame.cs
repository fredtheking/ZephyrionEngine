using ZephyrionEngine.Core;
using ZephyrionEngine.Managers;
using ZephyrionEngine.Pools;
using ZephyrionEngine.Settings;
using ZephyrionEngine.Utils.Interfaces;

namespace ZephyrionEngine;

public class ZephyrionGame : IRun
{
  public ManagersDirectory Managers { get; } = new();
  public SettingsDirectory Settings { get; } = new();
  public PoolsDirectory Pools { get; } = new();
  public MainPipeline Pipeline { get; } = new();

  public ZephyrionGame(WindowSetting? window = null)
  {
    Settings.Window = Managers.Window.Settings = window ?? new WindowSetting();
  }

  private void Init()
  {
    Pipeline.Setup(this);
    Pipeline.Initialisation(this);
    Pipeline.Start(this);
  }
  
  public void Run()
  {
    if (Managers.Setup.CheckOverallSetup())
    {
      Managers.Debug.Separator(ConsoleColor.DarkYellow, "Setting up Zephyrion engine...");
      
      Pipeline.Setup(this);
      
      Managers.Debug.Separator(ConsoleColor.Yellow, "Engine started! Opening window...");
      
      Pipeline.Initialisation(this);
      Pipeline.Start(this);
      
      Managers.Debug.Separator(ConsoleColor.Green, "Initialisation ended. Enjoy!");

      Managers.Window.Run(this);
      Managers.Window.Close(this);
    }
    else
    {
      Console.WriteLine("\tDear Programmer,\n" +
                        "Thank you for using ZephyrionEngine! I hope you have the best time using it! Despite my best efforts, the engine may not be perfect. If you find any bugs, please let me know on Engine's Github page!\n\n" +
                        "I believe you are a newbie, so there are some errors you need to take care of before starting your project:");
      
      if (!Managers.Setup.RegistrySuccessful) Console.WriteLine("\t- Registry Setup: This Engine uses registry to store all the game data. Consider creating one.");
      
      Console.WriteLine("\nIf you have any questions, you are open to visit the documentation on GitHub. Rebuild as soon as you fix the errors.\n" +
                        "Engine's Github: https://github.com/TaswellFan/ZephyrionEngine\n" +
                        "Documentation: https://github.com/TaswellFan");
    }
  }
}