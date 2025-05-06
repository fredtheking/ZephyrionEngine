using ZephyrionEngine.Core;
using ZephyrionEngine.Managers;
using ZephyrionEngine.Settings;

namespace ZephyrionEngine.Utils.Etc;

public static class ZE
{
  public static class M
  {
    public static DebugManager D { get; } = Zephyrion.Managers.Debug;
    public static SystemSetupManager SS { get; } = Zephyrion.Managers.SystemSetup;
    public static WindowManager W { get; } = Zephyrion.Managers.Window;
    public static PoolsManager PLS { get; } = Zephyrion.Managers.Pools;
    public static SceneManager S { get; } = Zephyrion.Managers.Scene;
    public static ProjectManager PRJ { get; } = Zephyrion.Managers.Project;
    internal static PendingChangesManager PND { get; } = Zephyrion.Managers.PendingChanges;
    
    public static void Setup() =>
      Zephyrion.Managers.Setup();
    public static void Initialisation() =>
      Zephyrion.Managers.Initialisation();
    public static void Begin() =>
      Zephyrion.Managers.Begin();
    public static void Update() =>
      Zephyrion.Managers.Update();
    public static void Render() =>
      Zephyrion.Managers.Render();
  }
  public static class S
  {
    public static WindowSettings W { get; set; } = Zephyrion.Settings.Window;
  }

  public static MainPipeline P = Zephyrion.Pipeline;

  public static void Run() =>
    Zephyrion.Run();

  public static void Setup() =>
    Zephyrion.Setup();
}