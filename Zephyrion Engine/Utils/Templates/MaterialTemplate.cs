using ZephyrionEngine.Utils.Etc;
using ZephyrionEngine.Utils.Interfaces;

namespace ZephyrionEngine.Utils.Templates;

public abstract class MaterialTemplate : UuidIdentifier, IInitialised, ISetup, ISceneable
{
  public bool Initialised { get; set; }
  
  public void Setup() { }
  public void Initialisation() { }
  public void Begin() { }
  public void Enter() { }
  public void Leave() { }
}