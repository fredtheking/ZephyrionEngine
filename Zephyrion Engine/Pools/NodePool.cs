using ZephyrionEngine.Core;
using ZephyrionEngine.Utils.Etc;
using ZephyrionEngine.Utils.Templates;

namespace ZephyrionEngine.Pools;

public class NodePool
{
  public List<Node> All = [];

  internal NodePool() { }

  public Node Register(string name, ComponentTemplate[] components, Node[] children)
  {
    Node newNode = new Node(name, components, children);
    All.Add(newNode);
    return newNode;
  }

  public Node? GetByName(string name)
  {
    Node[] founded = All.Where(x => x.Name == name).ToArray();
    if (founded.Length > 1) ZE.M.D.Warning("Found more than one Node with the same name. Returning the first one anyway.");
    return founded.FirstOrDefault();
  }
  
  public Node? GetByUuid(string uuid) =>
    All.Find(x => x.Uuid == uuid);
}