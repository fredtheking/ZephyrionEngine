using ZephyrionEngine;
using ZephyrionEngine.Utils.Settings;

public class SetupManager
{
  public bool WindowSuccessful { get; private set; }
  public bool RegistrySuccessful { get; private set; }


  public bool CheckSetup()
  {
    return ((bool[])[
      CheckWindow(),
      CheckRegistry()
    ]).All(x => x);
  }

  private bool CheckWindow()
  {
    return true;
  }
  
  private bool CheckRegistry()
  {
    return true;
  }
}