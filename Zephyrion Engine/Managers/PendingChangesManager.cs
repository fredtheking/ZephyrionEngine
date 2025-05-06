namespace ZephyrionEngine.Managers;

public class PendingChangesManager
{
  private List<Action> All { get; } = [];

  public void Add(Action action) =>
    All.Add(action);

  public void Apply()
  {
    foreach (Action action in All)
      action();
    All.Clear();
  }
}