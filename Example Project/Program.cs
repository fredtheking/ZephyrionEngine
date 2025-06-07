using System.Numerics;
using Raylib_cs;
using ZephyrionEngine;
using ZephyrionEngine.Components.Core;
using ZephyrionEngine.Components.Graphics;
using ZephyrionEngine.Core;
using ZephyrionEngine.Settings;
using ZephyrionEngine.Utils.Enums;
using ZephyrionEngine.Utils.Etc;

Zephyrion.Setup(new WindowSettings.Builder()
  .SetFlags(ConfigFlags.AlwaysRunWindow | ConfigFlags.ResizableWindow)
  .SetFps(-1)
  .Build()
);

Node HelloObject = ZE.M.R.Node.RegisterAsScene("HelloObject", [], [
  new TransformComponent(new Vector2(100, 200), new Vector2(200)),
  new SpritePrimitiveComponent(PrimitiveShape.Rectangle, Color.DarkBlue),
]);

Zephyrion.Run();