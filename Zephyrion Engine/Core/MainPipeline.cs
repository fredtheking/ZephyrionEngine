using Raylib_cs;
using ZephyrionEngine.Utils.Interfaces;

namespace ZephyrionEngine.Core;

public class MainPipeline : ISetup, IUpdateable, IRenderable
{
  public void Setup()
  {
    ZephyrionGame.Pools.Node.Register("Root");
    ZephyrionGame.Managers.Setup();
  }

  public void Initialisation()
  {
    ZephyrionGame.Managers.Initialisation();
  }

  public void Begin()
  {
    ZephyrionGame.Managers.Begin();
  }

  public void Update()
  {
    ZephyrionGame.Managers.Update();
  }

  public void Render()
  {
    Raylib.BeginDrawing();
    Raylib.ClearBackground(ZephyrionGame.Settings.Window.BackgroundColor);
    
    ZephyrionGame.Managers.Render();
    
    Raylib.EndDrawing();
  }
}