using ZephyrionEngine.Utils.Interfaces;

namespace ZephyrionEngine.Utils.Etc;

public static class Utilities
{
  private static string InitError(string objRefer) =>
    "Safe initialisation invocation failed. " + objRefer + " does not implement the 'IInitialised' or 'ISetup' interfaces. Consider adding both!";
  private const string INIT_ALREADY_DID = "Already initialised; call ignored.";
  /// <summary>
  /// Safely invokes initialisation. Prevents the object from having an invalid structure or being called multiple times.
  /// </summary>
  /// <param name="object">An object that implements both "IInitialised" and "ISetup" interfaces. Otherwise, a critical error is thrown.</param>
  public static void SafeInitialisationInvoke(dynamic @object)
  {
    if (@object is null or not IInitialised or not ISetup)
    {
      if (@object is UuidIdentifier identifier) 
        identifier.LogCritical(InitError("Current object"));
      else 
        ZE.M.D.Critical(InitError($"'{@object!.GetType()}' object"));
      return;
    }
    
    if (@object.Initialised)
    {
      if (@object is UuidIdentifier identifier) 
        identifier.LogInformation(INIT_ALREADY_DID);
      else
        ZE.M.D.Information(INIT_ALREADY_DID);
      return;
    }
    
    ((ISetup)@object).Initialisation();
    ((IInitialised)@object).Initialised = true;
  }
}