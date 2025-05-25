using ZephyrionEngine.Utils.Interfaces;

namespace ZephyrionEngine.Utils.Etc;

public abstract class UuidIdentifier
{
  #region Fields
  
  /// <summary>
  /// Simple UUID. Example: 9a5242b7-0abc-4930-a118-8ddfb5e6a5b4
  /// </summary>
  public string Uuid { get; }
  /// <summary>
  /// Shorter form of UUID. Used for showing in debugger. Example: 9a5..5b4
  /// </summary>
  public string ShortUuid { get; }
  private HashSet<string> OnceMessages { get; } = [];
  private const int UUID_LENGTH = 3;
  
  #endregion Fields
  #region Constructors

  protected UuidIdentifier()
  {
    Uuid = Guid.NewGuid().ToString();
    ShortUuid = Uuid[..UUID_LENGTH] + ".." + Uuid[^UUID_LENGTH..];
  }
  
  #endregion Constructors
  #region Methods

  private void LogWrapper(string message, bool once, Action printCall)
  {
    if (!OnceMessages.Contains(message)) printCall();
    if (once) OnceMessages.Add(message);
  }
  
  public void LogInformation(string message, bool once = false) =>
    LogWrapper(message, once, () => ZE.M.D.Print((once ? "[once] " : "") + "info", message, ConsoleColor.White, null, this));
 
  public void LogWarning(string message, bool once = false) =>
    LogWrapper(message, once, () => ZE.M.D.Print((once ? "[once] " : "") + "warn", message, ConsoleColor.Yellow, null, this));
 
  public void LogError(string message, bool once = false) =>
    LogWrapper(message, once, () => ZE.M.D.Print((once ? "[once] " : "") + "error", message, ConsoleColor.Red, null, this));
 
  public void LogCritical(string message, bool once = false) =>
    LogWrapper(message, once, () => ZE.M.D.Print((once ? "[once] " : "") + "crit", message, ConsoleColor.Black, ConsoleColor.Red, this));
  
  #endregion Methods
}