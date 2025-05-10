using ZephyrionEngine.Utils.Etc;
using ZephyrionEngine.Utils.Interfaces;

namespace ZephyrionEngine.Utils.Templates;

public class ComponentTemplate : UuidIdentifier, IInitialised, ISetup, ISceneable, IUpdateable, IRenderable
{
  public bool Initialised { get; set; }
  
  
  public void Setup()
  {
    throw new NotImplementedException();
  }

  public void Initialisation()
  {
    throw new NotImplementedException();
  }

  public void Begin()
  {
    throw new NotImplementedException();
  }

  public void Enter()
  {
    throw new NotImplementedException();
  }

  public void Leave()
  {
    throw new NotImplementedException();
  }

  public void Update()
  {
    throw new NotImplementedException();
  }

  public void Render()
  {
    throw new NotImplementedException();
  }
}