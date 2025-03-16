using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using ZephyrionEngine;
using ZephyrionEngine.Utils.Settings;

ZephyrionGame game = new(
  new WindowSettings.Builder()
  .SetSize(new Vector2i(1280, 720))
  .SetStartPosition(new Vector2i(-1))
  .Build());

game.Run();