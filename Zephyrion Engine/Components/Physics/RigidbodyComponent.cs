using ZephyrionEngine.Utils.Enums;
using ZephyrionEngine.Utils.Templates;

namespace ZephyrionEngine.Components.Physics;

public class RigidbodyComponent : ComponentTemplate
{
  public RigidbodyComponent() : base()
  {
    Group = ComponentGroup.Physics;
  }
}