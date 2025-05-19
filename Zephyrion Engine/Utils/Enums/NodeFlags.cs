namespace ZephyrionEngine.Utils.Enums;

[Flags]
public enum NodeFlags : ulong
{
  /// <summary>
  /// Ability to behave as root node (declared as starting point for tree update)
  /// </summary>
  IsRoot = 1UL << 0,
  /// <summary>
  /// Ability to call update method
  /// </summary>
  IsUpdateable = 1UL << 1,
  /// <summary>
  /// Ability to call render method
  /// </summary>
  IsRenderable = 1UL << 2,
  /// <summary>
  /// Keeps internal state between scene changes (e.g., variables, flags, etc.)
  /// </summary>
  IsPersistent = 1UL << 3,
  /// <summary>
  /// Ability to behave as scene node (for scene manager to change scenes)
  /// </summary>
  IsScene = 1UL << 4,
  /// <summary>
  /// Ability to take part in collision party (set automatically when adding any collision component)
  /// </summary>
  HasCollisions = 1UL << 5,
  /// <summary>
  /// Ability to take part in physics party (set automatically when adding any physics-related component)
  /// </summary>
  HasPhysics = 1UL << 6,
  /// <summary>
  /// Tag to show that object has no "Transform" component (TransformComponent)
  /// </summary>
  NonSpatial = 1UL << 7,
  /// <summary>
  /// Ability to be automatically destroyed when leaving current scene (cleaning from pool entirely)
  /// </summary>
  DestroyOnLeave = 1UL << 8,
}