using OpenTK.Windowing.GraphicsLibraryFramework;
using ZephyrionEngine.Utils.Interfaces;

namespace ZephyrionEngine.Core;

public class MainPipeline : IScript
{
  public void Initialisation(ZephyrionGame game)
  {
    game.Managers.Window.It.KeyDown += args =>
    {
      if (args.Key == Keys.Escape) 
        game.Managers.Window.It.Close();
    };
  }

  public void Start(ZephyrionGame game)
  {
    
  }

  public void Update(ZephyrionGame game, double deltaTime)
  {
    
  }

  public void Render(ZephyrionGame game)
  {
    
  }
}