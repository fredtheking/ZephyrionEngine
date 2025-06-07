using ZephyrionEngine.Core;
using ZephyrionEngine.Utils.Enums;
using ZephyrionEngine.Utils.Etc;
using ZephyrionEngine.Utils.Interfaces;

namespace ZephyrionEngine.Utils.Templates;

public abstract class ComponentTemplate : UuidIdentifier, IInitialised, ISetup, ISceneable, IUpdateable, IRenderable
{
  #region Fields
  
  internal ComponentGroup Group { get; init; }
  internal Node Parent { get; set; } = null!;
  public bool Initialised { get; set; }
  
  #endregion Fields
  #region Methods

  internal T LinkInternalUseComponent<T>() where T : ComponentTemplate
  {
    if (Parent.TryGetComponent(out T component)) return component;
    throw new InvalidOperationException(
      $"No '{typeof(T).Name}' found in '{Parent.Name}' node for '{GetType().Name}'. " +
      $"Provide current node with one (or exclude requested component).");
  }

  #region Inherited
  
  public virtual void Setup() { }
  public virtual void Initialisation() { }
  public virtual void Begin() { }
  public virtual void Enter() { }
  public virtual void Leave() { }
  public virtual void Update() { }
  public virtual void Render() { }
  
  #endregion Inherited
  #endregion Methods
}