using ZephyrionEngine.Core;
using ZephyrionEngine.Pools;
using ZephyrionEngine.Utils.Etc;
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
    Node.Root.Setup();
  }

  public void Initialisation()
  {
    Utilities.SafeInitialisationInvoke(Node.Root);
  }

  public void Begin()
  {
    Node.Root.Begin(); 
  }

  public void Update()
  {
    Node.Root.Update(); 
  }

  public void Render()
  {
    Node.Root.Render(); 
  }
  
  #endregion Inherited
  #endregion Methods
}