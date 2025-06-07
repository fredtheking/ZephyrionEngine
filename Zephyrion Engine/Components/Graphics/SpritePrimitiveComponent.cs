using Raylib_cs;
using ZephyrionEngine.Components.Core;
using ZephyrionEngine.Materials;
using ZephyrionEngine.Utils.Enums;
using ZephyrionEngine.Utils.Etc;
using ZephyrionEngine.Utils.Templates;

namespace ZephyrionEngine.Components.Graphics;

public class SpritePrimitiveComponent : ComponentTemplate
{
  #region Fields

  public TransformComponent ParentTransform;
  public TransformComponent Transform = new();
  public PrimitiveShape Shape;
  public Color Color;

  #endregion Fields
  #region Constructors

  public SpritePrimitiveComponent(PrimitiveShape shape, Color color) =>
    (Group, Shape, Color) = (ComponentGroup.Graphics, shape, color);
  
  #endregion
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
      Raylib.DrawRectangleRec(rec, Color);
    else if (Shape is PrimitiveShape.Circle) 
      Raylib.DrawRectangleRounded(rec, 1, Utilities.SEGMENTS, Color);
  }

  #endregion Methods
}