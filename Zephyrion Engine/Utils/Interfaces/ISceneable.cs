namespace ZephyrionEngine.Utils.Interfaces;

public interface ISceneable
{
  /// <summary>
  /// Called the frame before entering a new scene.
  /// </summary>
  public void Enter();
  
  /// <summary>
  /// Called the frame before leaving current scene.
  /// </summary>
  public void Leave();
}