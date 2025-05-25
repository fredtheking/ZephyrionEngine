using Raylib_cs;
using ZephyrionEngine.Materials;
using ZephyrionEngine.Utils.Enums;
using ZephyrionEngine.Utils.Templates;

namespace ZephyrionEngine.Components.Graphics;

public class SpriteComponent : ComponentTemplate
{
  #region Constructors
  
  public static SpriteComponent Primitive(Color color) =>
    new SpriteComponent(SpriteDrawType.Primitive, color);
  public static SpriteComponent Texture(TextureComponent texture) =>
    new SpriteComponent(SpriteDrawType.Texture, texture);
  
  internal SpriteComponent(SpriteDrawType drawType, params object[] args)
  {
    Group = ComponentGroup.Graphics;
    switch (drawType)
    {
      case SpriteDrawType.Primitive:
        Color color = (Color)args[0];
        ConstructorPrimitive(color);
        break;
      case SpriteDrawType.Texture:
        TextureComponent texture = (TextureComponent)args[0];
        ConstructorTexture(texture);
        break;
      default:
        throw new ArgumentOutOfRangeException(nameof(drawType), "Unknown sprite draw type");
    }
  }

  public SpriteComponent(Color color)
  {
    Group = ComponentGroup.Graphics;
    ConstructorPrimitive(color);  
  }
  public SpriteComponent(TextureComponent texture)
  {
    Group = ComponentGroup.Graphics;
    ConstructorTexture(texture);
  }

  private void ConstructorPrimitive(Color color)
  {
    
  }

  private void ConstructorTexture(TextureComponent texture)
  {
    
  }
  
  #endregion
}