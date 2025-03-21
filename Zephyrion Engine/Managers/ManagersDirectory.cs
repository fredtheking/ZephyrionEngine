namespace ZephyrionEngine.Managers;

public class ManagersDirectory
{
  public SetupManager Setup { get; } = new();
  public WindowManager Window { get; } = new();
  public ProjectManager Project { get; } = new();
}