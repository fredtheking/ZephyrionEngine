namespace ZephyrionEngine.Utils.Etc;

public class UuidIdentifier
{
  public string Uuid { get; protected set; }
  public string ShortUuid { get; protected set; }
  
  private const int UUID_LENGTH = 3;

  public UuidIdentifier()
  {
    Uuid = Guid.NewGuid().ToString();
    ShortUuid = Uuid[new Range(0, UUID_LENGTH)] + ".." + Uuid[new Range(Uuid.Length - UUID_LENGTH, Uuid.Length)];
  }
}