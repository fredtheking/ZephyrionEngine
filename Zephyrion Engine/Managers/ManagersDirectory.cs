using ZephyrionEngine.Utils.Interfaces;

namespace ZephyrionEngine.Managers;

public class ManagersDirectory : ISetup, IUpdateable, IRenderable
{
  public DebugManager Debug { get; } = new();
  public SystemSetupManager SystemSetup { get; } = new();
  public WindowManager Window { get; } = new();
  public RegistryManager Registry { get; } = new();
  public SceneManager Scene { get; } = new();
  public ProjectManager Project { get; } = new();
  internal PendingChangesManager PendingChanges { get; } = new();
  
  public void Setup()
  { 
    Window.Setup();
    Scene.Setup();
    
    Registry.Setup();
  }

  public void Initialisation()
  {
    Window.Initialisation();
    Scene.Initialisation();
    
    Registry.Initialisation();
  }

  public void Begin()
  {
    Window.Begin();
    Scene.Begin();
    
    Registry.Begin();
  }

  public void Update()
  {
    Window.Update();
    Scene.Update();
    
    Registry.Update();
  }

  public void Render()
  {
    Registry.Render();
  }
}