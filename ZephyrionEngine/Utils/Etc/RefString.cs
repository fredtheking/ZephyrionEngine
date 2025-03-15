namespace ZephyrionEngine.Utils.Etc;

public class RefString
{
  public string Value { get; set; }

  public RefString(string value) => Value = value;

  public static implicit operator string(RefString refUnit) => refUnit.Value;
  public static implicit operator RefString(string value) => new(value);
}