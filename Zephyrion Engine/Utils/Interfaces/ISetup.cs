namespace ZephyrionEngine.Utils.Interfaces;

public interface ISetup
{
  /// <summary>
  /// Called before main initialisation. Not recommended to override as its mostly system setup, and you can easily break something.
  /// </summary>
  internal void Setup();

  /// <summary>
  /// Called after constructors initialisations.
  /// </summary>
  public void Initialisation();

  /// <summary>
  /// Called if you need to do something after main initialisation. Secondary name - 'LateInitialisation'
  /// </summary>
  public void Begin();
}