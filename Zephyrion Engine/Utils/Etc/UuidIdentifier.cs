namespace ZephyrionEngine.Utils.Etc;

public abstract class UuidIdentifier
{
  /// <summary>
  /// Simple UUID. Example: 9a5242b7-0abc-4930-a118-8ddfb5e6a5b4
  /// </summary>
  public string Uuid { get; }
  /// <summary>
  /// Shorter form of UUID. Used for showing in debugger. Example: 9a5..5b4
  /// </summary>
  public string ShortUuid { get; }
  
  private const int UUID_LENGTH = 3;

  public UuidIdentifier()
  {
    Uuid = Guid.NewGuid().ToString();
    ShortUuid = Uuid[new Range(0, UUID_LENGTH)] + ".." + Uuid[new Range(Uuid.Length - UUID_LENGTH, Uuid.Length)];
  }
  
  public void LogInformation(string message) =>
    ZE.M.D.Print("info", message, ConsoleColor.White, null, this);
 
  public void LogWarning(string message) =>
    ZE.M.D.Print("warn", message, ConsoleColor.Yellow, null, this);
 
  public void LogError(string message) =>
    ZE.M.D.Print("error", message, ConsoleColor.Red, null, this);
 
  public void LogCritical(string message) =>
    ZE.M.D.Print("crit", message, ConsoleColor.Black, ConsoleColor.Red, this);
}