using ZephyrionEngine;
using ZephyrionEngine.Utils.Settings;

public class SetupManager
{
  /// <summary>
  /// Whether the window setup was successful.
  /// </summary>
  public bool WindowSuccessful { get; private set; }

  /// <summary>
  /// Whether the registry setup was successful.
  /// </summary>
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