using ZephyrionEngine.Utils.Enums;
using ZephyrionEngine.Utils.Templates;

namespace ZephyrionEngine.Components.Physics;

public class ColliderComponent : ComponentTemplate
{
  public ColliderComponent()
  {
    Group = ComponentGroup.Physics;
  }
}