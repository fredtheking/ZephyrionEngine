using System.Numerics;
using Raylib_cs;
using ZephyrionEngine.Utils.Enums;
using ZephyrionEngine.Utils.Etc;
using ZephyrionEngine.Utils.Templates;

namespace ZephyrionEngine.Components.Core;

public class TransformComponent : ComponentTemplate
{
  #region Fields
  
  public Vector2 Position { get; set; }
  public Vector2 Size { get; set; }
  public float Rotation { get; set; }

  public float Left => Position.X;
  public float Right => Position.X + Size.X;
  public float Top => Position.Y;
  public float Bottom => Position.Y + Size.Y;
  public Vector2 Center => Position + Size / 2;
  public Vector2 TopLeft => Position;
  public Vector2 TopRight => new(Right, Top);
  public Vector2 BottomLeft => new(Left, Bottom);
  public Vector2 BottomRight => new(Right, Bottom);
  public Rectangle Rec => new(Position, Size);

  #endregion
  #region Constructors
  
  public TransformComponent(Vector2? position = null, Vector2? size = null, float? rotation = null)
  {
    Group = ComponentGroup.Core;
    Position = position ?? Vector2.Zero;
    Size = size ?? Vector2.One * Utilities.UNIT;
    Rotation = rotation ?? 0;
  }

  public TransformComponent()
  {
    Group = ComponentGroup.Core;
    Position = Vector2.Zero;
    Size = Vector2.Zero;
    Rotation = 0;
  }

  #endregion
}