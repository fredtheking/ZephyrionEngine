namespace ZephyrionEngine.Utils.Enums;

[Flags]
public enum NodeFlags
{
  /// <summary>
  /// Dummy
  /// </summary>
  None = 0,
  /// <summary>
  /// Ability to call render method
  /// </summary>
  Renderable = 1 << 0,
  /// <summary>
  /// Ability to call update method
  /// </summary>
  Updateable = 1 << 1,
  /// <summary>
  /// Ability to save states between scenes (all internal variables and stuff)
  /// </summary>
  Persistent = 1 << 2,
  /// <summary>
  /// Whether it takes part in collision party (set automatically when adding any collision component)
  /// </summary>
  HasCollision = 1 << 3,
  /// <summary>
  /// Whether it takes part in physics party (set automatically when adding any physics-related component)
  /// </summary>
  HasPhysics = 1 << 4,
  /// <summary>
  /// Ability to behave as root node (convenient as it declares a starting point for calling all internal methods)
  /// </summary>
  IsRoot = 1 << 5,
  /// <summary>
  /// Ability to behave as scene node (convenient for scene manager for changing scenes)
  /// </summary>
  IsScene = 1 << 6,
  /// <summary>
  /// Ability to be automatically destroyed when leaving current scene (cleaning from pool entirely)
  /// </summary>
  DestroyOnLeave = 1 << 7,
}