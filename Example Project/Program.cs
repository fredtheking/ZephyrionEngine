using OpenTK.Mathematics;
using ZephyrionEngine;
using ZephyrionEngine.Settings;

ZephyrionGame game = new(
  new WindowSetting.Builder()
  .SetSize(new Vector2i(1280, 720))
  .SetStartPosition(new Vector2i(-1))
  .Build());

game.Run();