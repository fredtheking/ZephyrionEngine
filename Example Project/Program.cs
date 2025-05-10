using System.Numerics;
using Raylib_cs;
using ZephyrionEngine;
using ZephyrionEngine.Components;
using ZephyrionEngine.Settings;
using ZephyrionEngine.Utils.Etc;

Zephyrion.Setup(new WindowSettings.Builder()
  .SetFlags(ConfigFlags.AlwaysRunWindow | ConfigFlags.ResizableWindow)
  .SetFps(-1)
  .Build()
);

var HelloObject = ZE.M.R.Node.Register("HelloObject", [
  new CTransform(new Vector2(100, 200)),
], []);


Zephyrion.Run();