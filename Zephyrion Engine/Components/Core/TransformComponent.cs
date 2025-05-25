using System.Numerics;
using ZephyrionEngine.Utils.Enums;
using ZephyrionEngine.Utils.Templates;

namespace ZephyrionEngine.Components.Core;

public class TransformComponent : ComponentTemplate
{
  #region Fields
  public Vector2 Position { get; set; }
  public Vector2 Size { get; set; }
  public float Rotation { get; set; }
  #endregion
  #region Constructors
  public TransformComponent(Vector2? position = null, Vector2? size = null, float? rotation = null)
  {
    Group = ComponentGroup.Core;
    Position = position ?? Vector2.Zero;
    Rotation = rotation ?? 0;
    Size = size ?? Vector2.One * 20;
  }
  #endregion
}