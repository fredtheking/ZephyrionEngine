using System.Numerics;
using ZephyrionEngine.Utils.Templates;

namespace ZephyrionEngine.Components;

public class CTransform : ComponentTemplate
{
  public Vector2 Position { get; set; }
  public float Rotation { get; set; }
  public Vector2 Scale { get; set; }

  public CTransform(Vector2? position = null, float? rotation = null, Vector2? scale = null)
  {
    Position = position ?? Vector2.Zero;
    Rotation = rotation ?? 0;
    Scale = scale ?? Vector2.One;
  }
}