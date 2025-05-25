using ZephyrionEngine.Core;
using ZephyrionEngine.Utils.Enums;
using ZephyrionEngine.Utils.Etc;
using ZephyrionEngine.Utils.Templates;

namespace ZephyrionEngine.Pools;

public class NodePool
{
  #region Fields
  
  public List<Node> All { get; internal set; } = [];
  public Node Root { get; internal set; } = new("Root", [], [], NodeFlag.IsRoot | NodeFlag.IsUpdateable | NodeFlag.IsRenderable | NodeFlag.IsPersistent);
  
  #endregion Fields
  #region Constructors
  
  internal NodePool() { }
  
  #endregion Constructors
  #region Methods
  
  public Node Register(string name, Node[] children, ComponentTemplate[] components, NodeFlag? flags = null)
  {
    Node newNode = new(name, children, components, flags);
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
  
  #endregion Methods
}