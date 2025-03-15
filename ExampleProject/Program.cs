using ZephyrionEngine;
using ZephyrionEngine.Utils.Settings;

ZephyrionGame game = new(new WindowSettings.Builder()
  .SetWidth(1920)
  .SetHeight(1080)
  .SetTitle("Testing...")
  .Build());

game.Run();