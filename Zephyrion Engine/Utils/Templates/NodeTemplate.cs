using ZephyrionEngine.Core;
using ZephyrionEngine.Utils.Etc;
using ZephyrionEngine.Utils.Interfaces;

namespace ZephyrionEngine.Utils.Templates;

public abstract class NodeTemplate : UuidIdentifier, IInitialised, IScript, ISceneable
{
  public bool Initialised { get; set; }
  public RefString Name { get; set; }
  public List<Node> Children { get; protected init; }
  
  public abstract void Setup(ZephyrionGame game);
  public abstract void Initialisation(ZephyrionGame game);
  public abstract void Start(ZephyrionGame game);
  public abstract void Update(ZephyrionGame game);
  public abstract void Render(ZephyrionGame game);
  
  public abstract void Enter(ZephyrionGame game);
  public abstract void Leave(ZephyrionGame game);
}