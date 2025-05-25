using ZephyrionEngine.Utils.Enums;
using ZephyrionEngine.Utils.Etc;
using ZephyrionEngine.Utils.Interfaces;
using ZephyrionEngine.Utils.Templates;

namespace ZephyrionEngine.Components.Core;

public class MaterialComponent : ComponentTemplate
{
  #region Fields
  
  public List<MaterialTemplate> Materials;
    
  #endregion
  #region Constructors
  
  public MaterialComponent(params MaterialTemplate[] materials)
  {
    Group = ComponentGroup.Core;
    Materials = materials.ToList();
  }
  
  #endregion
  #region Methods
  #region Existance
  public bool HasMaterial(MaterialTemplate material) => Materials.Contains(material);
  public void AddMaterials(params MaterialTemplate[] materials)
  {
    foreach (MaterialTemplate material in materials)
      ZE.M.PND.Add(() => Materials.Add(material));
  }
  public void RemoveMaterials(params MaterialTemplate[] materials)
  {
    foreach (MaterialTemplate material in materials)
      ZE.M.PND.Add(() => Materials.Remove(material));
  }
  #endregion
  #endregion
}