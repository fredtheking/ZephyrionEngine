using ZephyrionEngine.Utils.Enums;
using ZephyrionEngine.Utils.Etc;
using ZephyrionEngine.Utils.Interfaces;
using ZephyrionEngine.Utils.Templates;

namespace ZephyrionEngine.Core;

public class Node : UuidIdentifier, IInitialised, ISetup, IUpdateable, IRenderable, ISceneable
{
  public bool Initialised { get; set; }
  public string Name;
  public NodeFlags Flags { get; set; }
  public List<Node> Parents { get; } = [];
  public List<Node> Children { get; }
  public List<ComponentTemplate> Components { get; } = [];

  public bool HasFlag(NodeFlags flags) => (Flags & flags) != 0;
  public void AddFlag(NodeFlags flags) => ZE.M.PND.Add(() => Flags |= flags);
  public void RemoveFlag(NodeFlags flags) => ZE.M.PND.Add(() => Flags &= ~flags);

  public bool HasComponent(ComponentTemplate component) => Components.Contains(component);
  public void AddComponent(ComponentTemplate component) => ZE.M.PND.Add(() => Components.Add(component));
  
  public Node(string name, Node[] children)
  {
    Name = name;
    Children = children.ToList();
    
    foreach (Node child in Children)
      child.Parents.Add(this);
  }

  public void Setup()
  {
    
  }
  public void Initialisation()
  {
    
  }
  public void Begin()
  {
    
  }
  public void Update()
  {
    
  }
  public void Render()
  {
    
  }

  public void Enter()
  {
    
  }
  public void Leave()
  {
    
  }
}