using Raylib_cs;
using ZephyrionEngine.Utils.Interfaces;

namespace ZephyrionEngine.Core;

public class MainPipeline : ISetup, IUpdateable, IRenderable
{
  public void Setup()
  {
    Zephyrion.Pools.Node.Register("Root");
    Zephyrion.Managers.Setup();
  }

  public void Initialisation()
  {
    Zephyrion.Managers.Initialisation();
  }

  public void Begin()
  {
    Zephyrion.Managers.Begin();
  }

  public void Update()
  {
    Zephyrion.Managers.Update();
  }

  public void Render()
  {
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Zephyrion.Settings.Window.BackgroundColor);
    
    Zephyrion.Managers.Render();
    Raylib.DrawFPS(10, 10);
    
    Raylib.EndDrawing();
  }
}