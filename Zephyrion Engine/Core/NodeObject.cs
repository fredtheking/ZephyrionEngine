using ZephyrionEngine.Utils.Etc;
using ZephyrionEngine.Utils.Interfaces;

namespace ZephyrionEngine.Core;

public class NodeObject : UuidIdentifier, IInitialised, IScript
{
  public bool Initialised { get; set; }
  public RefString Name { get; set; }
  public List<NodeObject> Parents { get; set; }
  public List<NodeObject> Children { get; set; }

  public NodeObject(string name, List<NodeObject> children)
  {
    Name = name;
    Children = children;
  }

  public void SystemSetup(ZephyrionGame game)
  {
    
  }

  public void Initialisation(ZephyrionGame game)
  {
    
  }

  public void Start(ZephyrionGame game)
  {
    
  }

  public void Update(ZephyrionGame game, double deltaTime)
  {
    
  }

  public void Render(ZephyrionGame game)
  {
    
  }

  public void Enter(ZephyrionGame game)
  {
    
  }

  public void Leave(ZephyrionGame game)
  {
    
  }
}