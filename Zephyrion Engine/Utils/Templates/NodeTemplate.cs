using ZephyrionEngine.Core;
using ZephyrionEngine.Utils.Etc;
using ZephyrionEngine.Utils.Interfaces;

namespace ZephyrionEngine.Utils.Templates;

public class NodeTemplate : UuidIdentifier, IInitialised, IScript
{
  public bool Initialised { get; set; }
  public RefString Name { get; set; }
  public List<Node> Children { get; protected init; }

  public virtual void SystemSetup(ZephyrionGame game)
  {
    
  }

  public virtual void Initialisation(ZephyrionGame game)
  {
    
  }

  public virtual void Start(ZephyrionGame game)
  {
    
  }

  public virtual void Update(ZephyrionGame game, double deltaTime)
  {
    
  }

  public virtual void Render(ZephyrionGame game)
  {
    
  }
}