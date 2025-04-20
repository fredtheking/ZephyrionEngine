using ZephyrionEngine.Utils.Interfaces;

namespace ZephyrionEngine.Managers;

public class ManagersDirectory : ISetup, IUpdateable, IRenderable
{
  public DebugManager Debug { get; } = new();
  public SystemSetupManager SystemSetup { get; } = new();
  public WindowManager Window { get; } = new();
  public PoolsManager Pools { get; } = new();
  public SceneManager Scene { get; } = new();
  public ProjectManager Project { get; } = new();
  
  public void Setup()
  {
    Window.Setup();
    Scene.Setup();
    
    Pools.Setup();
  }

  public void Initialisation()
  {
    Window.Initialisation();
    Scene.Initialisation();
    
    Pools.Initialisation();
  }

  public void Begin()
  {
    Window.Begin();
    Scene.Begin();
    
    Pools.Begin();
  }

  public void Update()
  {
    Window.Update();
    Scene.Update();
    
    Pools.Update();
  }

  public void Render()
  {
    Pools.Render();
  }
}