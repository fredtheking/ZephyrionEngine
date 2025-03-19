using OpenTK.Mathematics;
using OpenTK.Windowing.Common;

namespace ZephyrionEngine.Settings;

public class WindowSetting
{
  public string Title { get; set; } = "Hello, Zephyrion!";
  public WindowBorder BorderMode { get; set; } = WindowBorder.Resizable;
  public WindowState State { get; set; } = WindowState.Normal;
  public Vector2i Size { get; set; } = new(800, 600);
  public Vector2i MinSize { get; set; } = new(-1);
  public Vector2i MaxSize { get; set; } = new(-1);
  public Vector2i StartPosition { get; set; } = new(-1, -1);
  
  public class Builder
  {
    private readonly WindowSetting _setting = new();
  
    public Builder SetTitle(string title)
    {
      _setting.Title = title;
      return this;
    }
    
    public Builder SetBorderMode(WindowBorder borderMode)
    {
      _setting.BorderMode = borderMode;
      return this;
    }
    
    public Builder SetState(WindowState state)
    {
      _setting.State = state;
      return this;
    }
    
    public Builder SetSize(Vector2i size)
    {
      _setting.Size = size;
      return this;
    }
    
    public Builder SetMinSize(Vector2i size)
    {
      _setting.MinSize = size;
      return this;
    }
    
    public Builder SetMaxSize(Vector2i size)
    {
      _setting.MaxSize = size;
      return this;
    }
    
    /// <summary>
    /// Put "Vector2(-1, -1)" to center
    /// </summary>
    /// <param name="position">Start position of window. Pivot point is center</param>
    /// <returns></returns>
    public Builder SetStartPosition(Vector2i position)
    {
      _setting.StartPosition = position;
      return this;
    }

    public WindowSetting Build() => _setting;
  }
}