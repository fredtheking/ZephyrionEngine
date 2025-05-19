using ZephyrionEngine.Utils.Interfaces;
using ZephyrionEngine.Utils.Templates;

namespace ZephyrionEngine.Components;

public class IncludeMaterialComponent<TMaterial> : ComponentTemplate 
  where TMaterial : MaterialTemplate
{
  public TMaterial Material;

  public IncludeMaterialComponent(TMaterial material) => 
    Material = material;
}