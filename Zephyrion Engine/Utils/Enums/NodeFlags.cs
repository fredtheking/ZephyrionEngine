namespace ZephyrionEngine.Utils.Enums;

public enum NodeFlags
{
  None = 0,
  Renderable = 1 << 0,
  Updateable = 1 << 1,
  Persistent = 1 << 2
}