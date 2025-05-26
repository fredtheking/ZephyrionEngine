using ZLinq;

namespace ZephyrionEngine.Managers;

internal class SystemSetupManager
{
  #region Fields
  
  internal bool EngineStarted;
  
  /// <summary>
  /// Whether the registry setup was successful.
  /// </summary>
  public bool RegistrySuccessful { get; private set; }
  
  #endregion Fields
  #region Methods

  /// <summary>
  /// Check whether all the systems are being set up successfully.
  /// </summary>
  /// <returns><c>bool</c> of success</returns>
  public bool CheckOverallSetup() =>
    ((bool[])[
      CheckRegistry(),
    ]).All(x => x);
  
  private bool CheckRegistry()
  {
    RegistrySuccessful = true;
    return RegistrySuccessful;
  }
  
  #endregion Methods
}