using Raylib_cs;
using System.Numerics;
using ZephyrionEngine;
using ZephyrionEngine.Settings;

ZephyrionGame game = new(
  new WindowSetting.Builder()
  .SetSize(new Vector2(1280, 720))
  .SetPosition(new Vector2(-1))
  .SetFlags(ConfigFlags.ResizableWindow)
  .SetTitle("Test app!!!")
  .SetBackgroundColor(Color.DarkGray)
  .Build());

game.Pools.Node.Register("Main");
game.Managers.Project.Load("proj.zpf");

game.Run();