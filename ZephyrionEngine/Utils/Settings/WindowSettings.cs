using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using ZephyrionEngine.Utils.Etc;

namespace ZephyrionEngine.Utils.Settings;

public class WindowSettings
{
  public RefString Title { get; set; } = "Hello, Zephyrion!";
  public WindowBorder BorderMode { get; set; } = WindowBorder.Resizable;
  public WindowState State { get; set; } = WindowState.Normal;
  public Vector2i Size { get; set; } = new(800, 600);
  public Vector2i MinSize { get; set; } = new(-1);
  public Vector2i MaxSize { get; set; } = new(-1);
  public Vector2i StartPosition { get; set; } = new(-1, -1);
  
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
    
    public Builder SetBorderMode(WindowBorder borderMode)
    {
      _settings.BorderMode = borderMode;
      return this;
    }
    
    public Builder SetState(WindowState state)
    {
      _settings.State = state;
      return this;
    }
    
    public Builder SetSize(Vector2i size)
    {
      _settings.Size = size;
      return this;
    }
    
    public Builder SetMinSize(Vector2i size)
    {
      _settings.MinSize = size;
      return this;
    }
    
    public Builder SetMaxSize(Vector2i size)
    {
      _settings.MaxSize = size;
      return this;
    }
    
    /// <summary>
    /// Put "Vector2(-1, -1)" to center
    /// </summary>
    /// <param name="position">Start position of window. Pivot point is center</param>
    /// <returns></returns>
    public Builder SetStartPosition(Vector2i position)
    {
      _settings.StartPosition = position;
      return this;
    }

    public WindowSettings Build() => _settings;
  }
}