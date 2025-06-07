using Raylib_cs;
using ZephyrionEngine.Components.Core;
using ZephyrionEngine.Utils.Enums;
using ZephyrionEngine.Utils.Etc;
using ZephyrionEngine.Utils.Templates;

namespace ZephyrionEngine.Components.Graphics;

public class BorderComponent : ComponentTemplate
{
  #region Fields
  
  public TransformComponent ParentTransform;
  public TransformComponent Transform = new();
  public PrimitiveShape Shape { get; set; }
  public float Thickness { get; set; }
  public Color Color { get; set; }
  
  #endregion Fields
  #region Constructors

  public BorderComponent(PrimitiveShape shape, float thickness, Color color) =>
    (Shape, Thickness, Color) = (shape, thickness, color);
  
  #endregion Constructors
  #region Methods
  
  public override void Initialisation()
  {
    ParentTransform = LinkInternalUseComponent<TransformComponent>();
  }

  public override void Render()
  {
    Rectangle rec = new(ParentTransform.Position + Transform.Position,
      ParentTransform.Size + Transform.Size);
    
    if (Shape is PrimitiveShape.Rectangle)
      Raylib.DrawRectangleLinesEx(rec, Thickness, Color);
    else if (Shape is PrimitiveShape.Circle)
      Raylib.DrawRectangleRoundedLinesEx(rec, 1, Utilities.SEGMENTS, Thickness, Color);
  }
  
  #endregion Methods
}