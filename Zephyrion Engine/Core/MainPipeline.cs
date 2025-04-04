using Raylib_cs;
using ZephyrionEngine.Utils.Interfaces;

namespace ZephyrionEngine.Core;

public class MainPipeline : IScript
{
  public void Setup(ZephyrionGame game)
  {
    
  }

  public void Initialisation(ZephyrionGame game)
  {
    game.Managers.Window.Initialisation(game);
  }

  public void Start(ZephyrionGame game)
  {
    
  }

  public void Update(ZephyrionGame game)
  {
    game.Managers.Window.Update(game);
  }

  public void Render(ZephyrionGame game)
  {
    Raylib.BeginDrawing();
    Raylib.ClearBackground(game.Settings.Window.BackgroundColor);
    
    game.Managers.Window.Render(game);
    
    Raylib.EndDrawing();
  }
}