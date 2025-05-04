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

  public Node? GetByName(string name)
  {
    Node? node = All.Find(x => x.Name == name);
    return node;
  }
}