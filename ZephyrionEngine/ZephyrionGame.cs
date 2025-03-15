using ZephyrionEngine.Utils;
using ZephyrionEngine.Utils.Interfaces;
using ZephyrionEngine.Utils.Settings;

namespace ZephyrionEngine;

public class ZephyrionGame : IScript
{
  public SetupHelper Settings;

  public ZephyrionGame(WindowSettings? window = null)
  {
    Settings = new(this)
    {
      Window = window ?? new WindowSettings()
    };
  }
  
  public void Run()
  {
    if (Settings.CheckSetup())
    {
      Console.WriteLine("Starting Zephyrion engine...");
      
      Console.WriteLine("Engine started!");
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