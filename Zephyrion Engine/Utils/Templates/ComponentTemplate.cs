using ZephyrionEngine.Core;
using ZephyrionEngine.Utils.Enums;
using ZephyrionEngine.Utils.Etc;
using ZephyrionEngine.Utils.Interfaces;

namespace ZephyrionEngine.Utils.Templates;

public abstract class ComponentTemplate : UuidIdentifier, IInitialised, ISetup, ISceneable, IUpdateable, IRenderable
{
  internal ComponentGroup Group { get; init; }
  internal Node Parent { get; set; }
  public bool Initialised { get; set; }
  
  internal void ParentSetup(ComponentTemplate component) =>
    component.Parent = ZE.M.R.Node.GetByComponent(component)!;
  
  public virtual void Setup() { }
  public virtual void Initialisation() { }
  public virtual void Begin() { }
  public virtual void Enter() { }
  public virtual void Leave() { }
  public virtual void Update() { }
  public virtual void Render() { }
}