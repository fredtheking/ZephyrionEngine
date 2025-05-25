namespace ZephyrionEngine.Managers;

internal class PendingChangesManager
{
  #region Fields
  
  private List<Action> All { get; } = [];
  
  #endregion Fields
  #region Methods
  
  public void Add(Action action) =>
    All.Add(action);

  public void Apply()
  {
    foreach (Action action in All)
      action();
    All.Clear();
  }
  
  #endregion Methods
}