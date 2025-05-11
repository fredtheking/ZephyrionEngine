using ZephyrionEngine.Utils.Enums;
using ZephyrionEngine.Utils.Etc;
using ZephyrionEngine.Utils.Interfaces;
using ZephyrionEngine.Utils.Templates;

namespace ZephyrionEngine.Core;

public class Node : UuidIdentifier, IInitialised, ISetup, IUpdateable, IRenderable, ISceneable, IBinaryFlags<NodeFlags>
{
  public bool Initialised { get; set; }
  public string Name;
  public NodeFlags Flags { get; set; }
  public List<Node> Parents { get; } = [];
  public List<Node> Children { get; }
  public List<ComponentTemplate> Components { get; }
  public List<MaterialTemplate> Materials { get; } = [];

  
  
  public Node(string name, Node[] children, ComponentTemplate[] components, NodeFlags? flags = null)
  {
    Name = name;
    Components = components.ToList();
    Children = children.ToList();
    if (flags is not null) Flags = flags.Value;
    
    foreach (Node child in Children)
      child.Parents.Add(this);
  }
  
  
  
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
  
  public bool HasMaterial(MaterialTemplate material) => Materials.Contains(material);
  public void AddMaterials(params MaterialTemplate[] materials)
  {
    foreach (MaterialTemplate material in materials)
      ZE.M.PND.Add(() => Materials.Add(material));
  }
  public void RemoveMaterials(params MaterialTemplate[] materials)
  {
    foreach (MaterialTemplate material in materials)
      ZE.M.PND.Add(() => Materials.Remove(material));
  }

  public void AddFlag(NodeFlags flag) => ((IBinaryFlags<NodeFlags>)this).AddFlag(flag);
  public bool HasFlag(NodeFlags flag) => ((IBinaryFlags<NodeFlags>)this).HasFlag(flag);
  public void RemoveFlag(NodeFlags flag) => ((IBinaryFlags<NodeFlags>)this).RemoveFlag(flag);

  
  
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