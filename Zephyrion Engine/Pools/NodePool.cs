using ZephyrionEngine.Core;

namespace ZephyrionEngine.Pools;

public class NodePool
{
  public List<Node> All = [];

  public Node Register(string name, params Node[] children)
  {
    Node newNode = new Node(name, children);
    All.Add(newNode);
    return newNode;
  }

  public Node? GetByName(string name) =>
    All.Find(x => x.Name == name);
  
  public Node? GetByUuid(string uuid) =>
    All.Find(x => x.Uuid == uuid);
}