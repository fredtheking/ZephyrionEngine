using ZephyrionEngine.Components;
using ZephyrionEngine.Components.Core;
using ZephyrionEngine.Components.Physics;
using ZephyrionEngine.Utils.Enums;
using ZephyrionEngine.Utils.Etc;
using ZephyrionEngine.Utils.Interfaces;
using ZephyrionEngine.Utils.Templates;

namespace ZephyrionEngine.Core;

public class Node : UuidIdentifier, IInitialised, ISetup, IUpdateable, IRenderable, ISceneable
{
  #region Fields
  
  public bool Initialised { get; set; }
  public string Name;
  public NodeFlags Flags { get; set; }
  public List<Node> Parents { get; } = [];
  public List<Node> Children { get; }
  public List<ComponentTemplate> Components { get; }
  
  #endregion Fields
  #region Constructors

  public Node(string name, Node[] children, ComponentTemplate[] components, NodeFlag? flags = null)
  {
    Name = name;
    Components = components.ToList();
    Children = children.ToList();
    Flags = new NodeFlags(flags ?? NodeFlag.None);
    
    foreach (Node child in Children)
      child.Parents.Add(this);
  }

  #endregion Constructors
  #region Methods
  #region Existance
  #region Component
  
  public bool HasComponent(ComponentTemplate component) => Components.Contains(component);
  public void AddComponents(params ComponentTemplate[] components)
  {
    foreach (ComponentTemplate component in components)
      ZE.M.PND.Add(() => Components.Add(component));
  }
  public void RemoveComponents(params ComponentTemplate[] components)
  {
    foreach (ComponentTemplate component in components)
      ZE.M.PND.Add(() => Components.Remove(component));
  }
  
  #endregion Component
  #region Children

  public bool HasChild(Node node) => Children.Contains(node);
  public void AddChildren(params Node[] nodes)
  {
    foreach (Node node in nodes)
    {
      Children.Add(node);
      node.Parents.Add(this);
    }
  }
  public void RemoveChildren(params Node[] nodes)
  {
    foreach (Node node in nodes)
    {
      node.Parents.Remove(this);
      Children.Remove(node);
    }
  }

  #endregion Children
  #region Parents
  
  public bool HasParent(Node node) => Parents.Contains(node);
  public void AddParents(params Node[] nodes)
  {
    foreach (Node node in nodes)
    {
      Parents.Add(node);
      node.Children.Add(this);
    }
  }
  public void RemoveParents(params Node[] nodes)
  {
    foreach (Node node in nodes)
    {
      node.Children.Remove(this);
      Parents.Remove(node);
    }
  }
  
  #endregion Parents
  #endregion Existance
  #region Inherited
  
  public void Setup()
  {
    #region NodeFlagsSetup

    if (!Components.Exists(c => c is TransformComponent)) 
      Flags.Add(NodeFlag.NonSpatial);
    if (Components.Exists(c => c is ColliderComponent))
      Flags.Add(NodeFlag.HasCollisions);
    if (Components.Exists(c => c.Group.HasFlag(ComponentGroup.Physics)))
      Flags.Add(NodeFlag.HasPhysics);
    if (Components.Exists(c => c is MaterialComponent))
      Flags.Add(NodeFlag.HasMaterials);

    #endregion
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
  
  #endregion Inherited
  #endregion Methods
}