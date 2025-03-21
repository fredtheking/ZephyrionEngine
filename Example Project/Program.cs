using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using ZephyrionEngine;
using ZephyrionEngine.Core;
using ZephyrionEngine.Settings;

ZephyrionGame game = new(
  new WindowSetting.Builder()
  .SetSize(new Vector2i(1280, 720))
  .SetStartPosition(new Vector2i(-1))
  .SetBorderMode(WindowBorder.Resizable)
  .SetTitle("Test app!!!")
  .Build());

game.Pools.Node.Register("Main");
game.Managers.Project.Load("proj.zpf");

game.Run();