using ZephyrionEngine.Core;

namespace ZephyrionEngine.Pools;

public class NodePool
{
  public List<Node> All = [];

  public void Register(string name, params Node[] children)
  {
    All.Add(new(name, children));
  }
}