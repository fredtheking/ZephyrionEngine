namespace ZephyrionEngine.Utils.Interfaces;

public interface ISceneable
{
  /// <summary>
  /// Called the frame before entering a new scene.
  /// </summary>
  public void Enter(ZephyrionGame game);
  
  /// <summary>
  /// Called the frame before leaving a scene.
  /// </summary>
  public void Leave(ZephyrionGame game);
}