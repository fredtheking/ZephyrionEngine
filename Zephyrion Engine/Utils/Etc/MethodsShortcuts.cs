using ZephyrionEngine.Core;
using ZephyrionEngine.Managers;
using ZephyrionEngine.Settings;
using ZephyrionEngine.Utils.Interfaces;

namespace ZephyrionEngine.Utils.Etc;

/// <summary>
/// Compact version of main class.
/// </summary>
public static class ZE
{
  /// <summary>
  /// Represents word "Managers"
  /// </summary>
  public static class M
  {
    /// <summary>
    /// Represents word "Debug"
    /// </summary>
    public static DebugManager D { get; } = Zephyrion.Managers.Debug;
    /// <summary>
    /// Represents word "Window"
    /// </summary>
    public static WindowManager W { get; } = Zephyrion.Managers.Window;
    /// <summary>
    /// Represents word "Registry"
    /// </summary>
    public static RegistryManager R { get; } = Zephyrion.Managers.Registry;
    /// <summary>
    /// Represents word "Scene"
    /// </summary>
    public static SceneManager SCN { get; } = Zephyrion.Managers.Scene;
    /// <summary>
    /// Represents word "Project"
    /// </summary>
    public static ProjectManager PRJ { get; } = Zephyrion.Managers.Project;
    /// <summary>
    /// Represents word "SystemSetup"
    /// </summary>
    internal static SystemSetupManager SYS { get; } = Zephyrion.Managers.SystemSetup;
    /// <summary>
    /// Represents word "PendingChanges"
    /// </summary>
    internal static PendingChangesManager PND { get; } = Zephyrion.Managers.PendingChanges;
    
    public static void Setup() => Zephyrion.Managers.Setup();
    public static void Initialisation() => Zephyrion.Managers.Initialisation();
    public static void Begin() => Zephyrion.Managers.Begin();
    public static void Update() => Zephyrion.Managers.Update();
    public static void Render() => Zephyrion.Managers.Render();
  }
  
  /// <summary>
  /// Represents word "Settings"
  /// </summary>
  public static class S
  {
    /// <summary>
    /// Represents word "Window"
    /// </summary>
    public static WindowSettings W { get; set; } = Zephyrion.Settings.Window;
  }
  
  /// <summary>
  /// Represents word "Pipeline"
  /// </summary>
  public static MainPipeline P = Zephyrion.Pipeline;
  public static void Run() => Zephyrion.Run();
  public static void Setup() => Zephyrion.Setup();
}