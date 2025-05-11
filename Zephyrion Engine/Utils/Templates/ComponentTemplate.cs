using ZephyrionEngine.Utils.Etc;
using ZephyrionEngine.Utils.Interfaces;

namespace ZephyrionEngine.Utils.Templates;

public abstract class ComponentTemplate : UuidIdentifier, IInitialised, ISetup, ISceneable, IUpdateable, IRenderable
{
  public bool Initialised { get; set; }

  public virtual void Setup() { }
  public virtual void Initialisation() { }
  public virtual void Begin() { }
  public virtual void Enter() { }
  public virtual void Leave() { }
  public virtual void Update() { }
  public virtual void Render() { }
}