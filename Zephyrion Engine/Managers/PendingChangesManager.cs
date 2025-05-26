using ZephyrionEngine.Core;

namespace ZephyrionEngine.Managers;

internal class PendingChangesManager
{
  #region Fields
  
  private List<Action> All { get; } = [];
  private List<(Action<Node>, Node)> Nodes { get; } = [];
  
  #endregion Fields
  #region Methods
  
  public void Add(Action action) =>
    All.Add(action);
  
  public void AddNodeInteraction(Action<Node> action, Node node) =>
    Nodes.Add((action, node));

  public void Apply()
  {
    foreach (Action action in All)
      action();
    foreach ((Action<Node>, Node) valueTuple in Nodes)
      valueTuple.Item1(valueTuple.Item2);
    All.Clear();
  }
  
  #endregion Methods
}