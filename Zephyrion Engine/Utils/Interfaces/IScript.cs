namespace ZephyrionEngine.Utils.Interfaces;

public interface IScript
{
  /// <summary>
  /// Called before main initialisation. Not recommended to override as its purpose is to set up system.
  /// </summary>
  public void SystemSetup(ZephyrionGame game) { }

  /// <summary>
  /// Called after successful constructors initialisations.
  /// </summary>
  public void Initialisation(ZephyrionGame game);
  
  /// <summary>
  /// Called as 'LateInitialisation' method if you need to do something after main one.
  /// </summary>
  public void Start(ZephyrionGame game);
  
  /// <summary>
  /// Called the frame before entering a new scene.
  /// </summary>
  public void Enter(ZephyrionGame game) { }
  
  /// <summary>
  /// Called the frame before leaving a scene.
  /// </summary>
  public void Leave(ZephyrionGame game) { }
  
  /// <summary>
  /// Called every frame to update.
  /// </summary>
  public void Update(ZephyrionGame game, double deltaTime);
  
  /// <summary>
  /// Called every frame to render.
  /// </summary>
  public void Render(ZephyrionGame game);
}