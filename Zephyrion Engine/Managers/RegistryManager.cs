using ZephyrionEngine.Pools;
using ZephyrionEngine.Utils.Interfaces;

namespace ZephyrionEngine.Managers;

public class RegistryManager : ISetup, IUpdateable, IRenderable
{
  #region Fields
  
  public NodePool Node = new();
  
  #endregion Fields
  #region Constructors
  
  internal RegistryManager() { }
  
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

  public void Render()
  {
    
  }
  
  #endregion Inherited
  #endregion Methods
}