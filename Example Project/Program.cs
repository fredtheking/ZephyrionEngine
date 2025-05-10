using Raylib_cs;
using ZephyrionEngine;
using ZephyrionEngine.Settings;
using ZephyrionEngine.Utils.Templates;

Zephyrion.Setup(new WindowSettings.Builder()
  .SetFps(-1)
  .SetFlags(ConfigFlags.AlwaysRunWindow | ConfigFlags.ResizableWindow)
  .Build());

var HelloObject = Zephyrion.Managers.Registry.Node.Register("HelloWorldObject");
HelloObject.AddComponent(new ComponentTemplate());

Zephyrion.Run();