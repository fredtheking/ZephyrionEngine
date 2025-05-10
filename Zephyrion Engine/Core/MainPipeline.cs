using Raylib_cs;
using ZephyrionEngine.Utils.Etc;
using ZephyrionEngine.Utils.Interfaces;

namespace ZephyrionEngine.Core;

public class MainPipeline : ISetup, IUpdateable, IRenderable, IRun, IClose
{
  internal MainPipeline() { }

  public void Setup()
  {
    ZE.M.R.Node.Register("Root", [], []);
    ZE.M.Setup();
  }

  public void Initialisation()
  {
    ZE.M.Initialisation();
  }

  public void Begin()
  {
    ZE.M.Begin();
  }
  
  public void Run()
  {
    ZE.M.W.Run();
  }
  
  public void Close()
  {
    ZE.M.W.Close();
  }

  public void Update()
  {
    ZE.M.Update();
  }

  public void Render()
  {
    Raylib.BeginDrawing();
    Raylib.ClearBackground(ZE.S.W.BackgroundColor);
    
    ZE.M.Render();
    Raylib.DrawFPS(10, 10);
    
    Raylib.EndDrawing();
  }
}