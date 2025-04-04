namespace ZephyrionEngine.Managers;

public class ManagersDirectory
{
  public DebugManager Debug { get; } = new();
  public SetupManager Setup { get; } = new();
  public WindowManager Window { get; } = new();
  public ProjectManager Project { get; } = new();
}