using Raylib_cs;
using ZephyrionEngine;
using ZephyrionEngine.Settings;

Zephyrion.Setup(new WindowSettings.Builder()
  //.SetFps(-1)
  .SetFlags(ConfigFlags.AlwaysRunWindow)
  .Build());

Zephyrion.Pools.Node.Register("HelloWorldObject");

Zephyrion.Run();