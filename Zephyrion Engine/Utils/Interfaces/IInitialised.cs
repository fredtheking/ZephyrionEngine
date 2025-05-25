namespace ZephyrionEngine.Utils.Interfaces;

public interface IInitialised
{
  /// <summary>
  /// Whether object is initialised
  /// </summary>
  public bool Initialised { get; internal set; }
}