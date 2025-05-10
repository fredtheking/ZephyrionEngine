namespace ZephyrionEngine.Utils.Interfaces;

public interface IInitialised
{
  public bool Initialised { get; protected set; }

  public void InitOnce(Action action)
  {
    action();
    Initialised = true;
  }
}