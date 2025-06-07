using Raylib_cs;
using ZephyrionEngine.Components.Core;
using ZephyrionEngine.Materials;
using ZephyrionEngine.Utils.Enums;
using ZephyrionEngine.Utils.Etc;
using ZephyrionEngine.Utils.Templates;

namespace ZephyrionEngine.Components.Graphics;

public class SpriteTextureComponent : ComponentTemplate
{
  #region Fields

  public TransformComponent ParentTransform;
  public TransformComponent Transform = new();
  public MaterialComponent ParentMaterialCollection;
  public TextureComponent Texture;
  public Color Color;

  private string requestTextureName;

  #endregion Fields
  #region Constructors

  public SpriteTextureComponent(string textureName, Color color) =>
    (Group, Color, requestTextureName) = (ComponentGroup.Graphics, color, textureName);
  
  #endregion
  #region Methods

  public override void Initialisation()
  {
    ParentTransform = LinkInternalUseComponent<TransformComponent>();
    ParentMaterialCollection = LinkInternalUseComponent<MaterialComponent>();
    
    // TODO: finish this class??
  }

  public override void Render()
  {
    //Rectangle rec = new(ParentTransform.Position + Transform.Position,
    //  ParentTransform.Size + Transform.Size);
    //
    //Raylib.DrawTextureEx(Texture.);
  }

  #endregion Methods
}