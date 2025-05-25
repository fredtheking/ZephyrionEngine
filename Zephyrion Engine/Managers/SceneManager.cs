using ZephyrionEngine.Core;
using ZephyrionEngine.Utils.Interfaces;

namespace ZephyrionEngine.Managers;

public class SceneManager : ISetup, IUpdateable, ISceneable
{
  #region Fields
  
  public Node Current { get; private set; }
  public bool Changed { get; private set; }
  
  #endregion Fields
  #region Constructors
  
  internal SceneManager() { }
  
  #endregion Constructors
  #region Methods
  #region Inherited
  
  public void Setup()
  {
    
  }

  public void Initialisation()
  {
    
  }

  public void Begin()
  {
    
  }

  public void Update()
  {
    
  }

  public void Enter()
  {
    
  }

  public void Leave()
  {
    
  }
  
  #endregion Inherited
  #endregion Methods
}