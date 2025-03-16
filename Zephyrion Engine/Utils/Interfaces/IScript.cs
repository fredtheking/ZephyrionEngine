namespace ZephyrionEngine.Utils.Interfaces;

public interface IScript
{
  /// <summary>
  /// Called in the end of a constructor.
  /// </summary>
  public virtual void Constructor(ZephyrionGame game) { }
  
  /// <summary>
  /// Called after successful constructors initialisations.
  /// </summary>
  public virtual void Initialisation(ZephyrionGame game) { }
  
  /// <summary>
  /// Called as 'LateInitialisation' method if you need to do something after main one.
  /// </summary>
  public virtual void Start(ZephyrionGame game) { }
  
  /// <summary>
  /// Called the frame before entering a new scene.
  /// </summary>
  public virtual void Enter(ZephyrionGame game) { }
  
  /// <summary>
  /// Called the frame before leaving a scene.
  /// </summary>
  public virtual void Leave(ZephyrionGame game) { }
  
  /// <summary>
  /// Called every frame to update.
  /// </summary>
  public virtual void Update(ZephyrionGame game) { }
  
  /// <summary>
  /// Called every frame to render.
  /// </summary>
  public virtual void Render(ZephyrionGame game) { }
}