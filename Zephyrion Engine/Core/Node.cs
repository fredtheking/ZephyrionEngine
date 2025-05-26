using ZephyrionEngine.Components;
using ZephyrionEngine.Components.Core;
using ZephyrionEngine.Components.Physics;
using ZephyrionEngine.Utils.Enums;
using ZephyrionEngine.Utils.Etc;
using ZephyrionEngine.Utils.Interfaces;
using ZephyrionEngine.Utils.Templates;
using ZLinq;

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
  public T? TryGetComponent<T>() where T : ComponentTemplate =>
    (T?)Components.AsValueEnumerable().FirstOrDefault(c => c is T);

  public T GetComponent<T>() where T : ComponentTemplate
  {
    T? component = TryGetComponent<T>();
    if (component is not null) return component;
    throw new ArgumentNullException(nameof(component), "Component not found. try 'TryGetComponent' if you are not 100% sure.");
  }

  #endregion Component
  #region Children

  public bool HasChild(Node node) => Children.Contains(node);
  public void AddChildren(params Node[] nodes)
  {
    Action<Node> addition = node =>
    {
      Children.Add(node);
      node.Parents.Add(this);
    };
    
    foreach (Node node in nodes)
    {
      if (ZE.M.SYS.EngineStarted)
        ZE.M.PND.AddNodeInteraction(addition, node);
      else addition(node);
    }
  }
  public void RemoveChildren(params Node[] nodes)
  {
    Action<Node> removal = node =>
    {
      node.Parents.Remove(this);
      Children.Remove(node);
    };
    
    foreach (Node node in nodes)
    {
      if (ZE.M.SYS.EngineStarted)
        ZE.M.PND.AddNodeInteraction(removal, node);
      else removal(node);
    }
  }

  #endregion Children
  #region Parents
  
  public bool HasParent(Node node) => Parents.Contains(node);
  public void AddParents(params Node[] nodes)
  {
    Action<Node> addition = node =>
    {
      Parents.Add(node);
      node.Children.Add(this);
    };
    
    foreach (Node node in nodes)
    {
      if (ZE.M.SYS.EngineStarted)
        ZE.M.PND.AddNodeInteraction(addition, node);
      else addition(node);
    }
  }
  public void RemoveParents(params Node[] nodes)
  {
    Action<Node> removal = node =>
    {
      node.Children.Remove(this);
      Parents.Remove(node);
    };
    
    foreach (Node node in nodes)
    {
      if (ZE.M.SYS.EngineStarted)
        ZE.M.PND.AddNodeInteraction(removal, node);
      else removal(node);
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

    #endregion NodeFlagsSetup

    foreach (ComponentTemplate component in Components)
      component.Setup();
    foreach (Node child in Children)
      child.Setup();
  }
  public void Initialisation()
  {
    LogInformation("Ready!");
    foreach (ComponentTemplate component in Components)
      component.Initialisation();
    foreach (Node child in Children)
      child.Initialisation();
  }
  public void Begin()
  {
    foreach (ComponentTemplate component in Components)
      component.Begin();
    foreach (Node child in Children)
      child.Begin();
  }
  public void Update()
  {
    foreach (ComponentTemplate component in Components)
      component.Update();
    foreach (Node child in Children)
      child.Update();
  }
  public void Render()
  {
    foreach (ComponentTemplate component in Components)
      component.Render();
    foreach (Node child in Children)
      child.Render();
  }
  public void Enter()
  {
    foreach (ComponentTemplate component in Components)
      component.Enter();
    foreach (Node child in Children)
      child.Enter();
  }
  public void Leave()
  {
    foreach (ComponentTemplate component in Components)
      component.Leave();
    foreach (Node child in Children)
      child.Leave();
  }
  
  #endregion Inherited
  #endregion Methods
}