namespace ZephyrionEngine.Utils.Etc;

public class UuidIdentifier
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
}