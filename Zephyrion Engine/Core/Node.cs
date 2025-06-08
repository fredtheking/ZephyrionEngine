using System.Diagnostics.CodeAnalysis;
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
    foreach (ComponentTemplate component in components)
      component.Parent = this;
  }

  #endregion Constructors
  #region Methods
  #region Existance
  #region Component
  
  public bool HasComponent(ComponentTemplate component) => Components.Contains(component);
  public void AddComponents(params ComponentTemplate[] components)
  {
    foreach (ComponentTemplate component in components)
      ZE.M.PND.Add(() =>
      {
        Components.Add(component);
      });
  }
  public void RemoveComponents(params ComponentTemplate[] components)
  {
    foreach (ComponentTemplate component in components)
      ZE.M.PND.Add(() => Components.Remove(component));
  }
  public bool TryGetComponent<T>([NotNull] out T component) where T : ComponentTemplate
  {
    T? c = (T?)Components.AsValueEnumerable().FirstOrDefault(c => c is T);
    if (c is not null)
    {
      component = c;
      return true;
    }

    component = null;
    return false;
  }

  public T GetComponent<T>() where T : ComponentTemplate
  {
    if (TryGetComponent(out T component))
      return component;
    throw new ArgumentNullException(nameof(component), "Component not found. try 'TryGetComponent' if you are not 100% sure.");
  }

  #endregion Component
  #region Children

  public bool HasChild(Node node) => Children.Contains(node);
  public void AddChildren(params Node[] nodes) =>
    ZE.M.PND.Add(() => ImmediateAddChildren(nodes));
  internal void ImmediateAddChildren(params Node[] nodes)
  {
    foreach (Node node in nodes)
    {
      node.Parents.Add(this);
      Children.Add(node);
    }
  }
  public void RemoveChildren(params Node[] nodes) =>
    ZE.M.PND.Add(() => ImmediateRemoveChildren(nodes));

  internal void ImmediateRemoveChildren(params Node[] nodes)
  {
    foreach (Node node in nodes)
    {
      node.Leave();
      node.Parents.Remove(this);
      Children.Remove(node);
    }
  }

  #endregion Children
  #region Parents
  
  public bool HasParent(Node node) => Parents.Contains(node);
  public void AddParents(params Node[] nodes) =>
    ZE.M.PND.Add(() => ImmediatelyAddParents(nodes));
  internal void ImmediatelyAddParents(params Node[] nodes)
  {
    foreach (Node node in nodes)
    {
      node.Children.Add(this);
      Parents.Add(node);
    }
  }
  public void RemoveParents(params Node[] nodes) =>
    ZE.M.PND.Add(() => ImmediatelyRemoveParents(nodes));
  public void ImmediatelyRemoveParents(params Node[] nodes)
  {
    foreach (Node node in nodes)
    {
      node.Leave();
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

    #endregion NodeFlagsSetup
    foreach (ComponentTemplate component in Components)
      component.Setup();
    foreach (Node child in Children)
      child.Setup();
  }
  public void Initialisation()
  {
    foreach (ComponentTemplate component in Components)
      Utilities.SafeInitialisationInvoke(component);
    LogInformation($"'{Name}' is initialised successfully!");
    foreach (Node child in Children)
      Utilities.SafeInitialisationInvoke(child);
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
    #region RootParentsCheck

    if (Flags.Has(NodeFlag.IsRoot) && Parents.Count > 0)
    {
      Parents.Clear();
      LogWarning("Root node cannot have parents!");
    }

    #endregion RootParentsCheck
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