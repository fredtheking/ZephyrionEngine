using System.Numerics;
using ZephyrionEngine.Utils.Etc;

namespace ZephyrionEngine.Utils.Settings;

public class WindowSettings
{
  public RefString Title { get; set; } = "Hello, Zephyrion!";
  public int Width { get; set; } = 800;
  public int Height { get; set; } = 600;
  public Vector2 StartPosition { get; set; } = new(-1, -1);
  
  public class Builder
  {
    private readonly WindowSettings _settings = new();
  
    public Builder SetTitle(string title)
    {
      _settings.Title = title;
      return this;
    }
    
    public Builder SetTitle(RefString title)
    {
      _settings.Title = title;
      return this;
    }
    
    public Builder SetWidth(int width)
    {
      _settings.Width = width;
      return this;
    }
    
    public Builder SetHeight(int height)
    {
      _settings.Height = height;
      return this;
    }
    
    /// <summary>
    /// Put "Vector2(-1, -1)" to center
    /// </summary>
    /// <param name="position">Start position of window. Pivot point is center</param>
    /// <returns></returns>
    public Builder SetStartPosition(Vector2 position)
    {
      _settings.StartPosition = position;
      return this;
    }

    public WindowSettings Build() => _settings;
  }
}