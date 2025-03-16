using ZephyrionEngine;
using ZephyrionEngine.Utils.Settings;

public class SetupHelper(ZephyrionGame game)
{
  public WindowSettings Window { get; set; }
  public bool SetupWindow { get; private set; }
  public bool SetupRegistry { get; private set; }
  
  public bool CheckSetup()
  {
    SetupWindow = true;
    SetupRegistry = true;
    
    return SetupWindow && SetupRegistry;
  }
}