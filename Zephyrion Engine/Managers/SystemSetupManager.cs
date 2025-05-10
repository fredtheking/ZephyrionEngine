public class SystemSetupManager
{
  internal SystemSetupManager() { }
  
  /// <summary>
  /// Whether the registry setup was successful.
  /// </summary>
  public bool RegistrySuccessful { get; private set; }

  /// <summary>
  /// Check whether all the systems are being set up successfully.
  /// </summary>
  /// <returns><c>bool</c> of success</returns>
  public bool CheckOverallSetup()
  {
    return ((bool[])[
      CheckRegistry(),
    ]).All(x => x);
  }
  
  private bool CheckRegistry()
  {
    RegistrySuccessful = true;
    return RegistrySuccessful;
  }
}