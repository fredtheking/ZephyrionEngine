using ZephyrionEngine.Utils.Enums;
using ZephyrionEngine.Utils.Templates;

namespace ZephyrionEngine.Components.Physics;

public class StaticbodyComponent : ComponentTemplate
{
  public StaticbodyComponent() : base()
  {
    Group = ComponentGroup.Physics;
  }
}