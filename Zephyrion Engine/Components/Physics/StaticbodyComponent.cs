﻿using ZephyrionEngine.Utils.Enums;
using ZephyrionEngine.Utils.Templates;

namespace ZephyrionEngine.Components.Physics;

public class StaticbodyComponent : ComponentTemplate
{
  public StaticbodyComponent()
  {
    Group = ComponentGroup.Physics;
  }
}