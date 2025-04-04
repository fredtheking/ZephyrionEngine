using System.Numerics;
using Raylib_cs;

namespace ZephyrionEngine.Settings;

public class WindowSetting
{
  public string Title { get; set; } = "Hello, Zephyrion!";
  public float Transparency { get; set; } = 1f;
  public Color BackgroundColor { get; set; } = Color.Black;
  public bool SoundOn { get; set; } = true;
  public Vector2 Position { get; set; } = new(-1, -1);
  public ConfigFlags Flags { get; set; } = ConfigFlags.AlwaysRunWindow | ConfigFlags.VSyncHint;
  public Vector2 Size { get; set; } = new(800, 600);
  public Vector2 MinSize { get; set; } = new(-1);
  public Vector2 MaxSize { get; set; } = new(-1);

  public class Builder
  {
    private readonly WindowSetting _setting = new();
  
    public Builder SetTitle(string title)
    {
      _setting.Title = title;
      return this;
    }
    
    public Builder SetTransparency(float transparency)
    {
      _setting.Transparency = transparency;
      return this;
    }
    
    public Builder SetBackgroundColor(Color backgroundColor)
    {
      _setting.BackgroundColor = backgroundColor;
      return this;
    }
    
    public Builder SetSoundOn(bool turned)
    {
      _setting.SoundOn = turned;
      return this;
    }
    
    /// <summary>
    /// Put "Vector2(-1, -1)" to center
    /// </summary>
    /// <param name="position">Start position of window. Pivot point is center</param>
    /// <returns></returns>
    public Builder SetPosition(Vector2 position)
    {
      _setting.Position = position;
      return this;
    }
    
    public Builder SetFlags(ConfigFlags flags)
    {
      _setting.Flags = flags;
      return this;
    }
    
    public Builder SetSize(Vector2 size)
    {
      _setting.Size = size;
      return this;
    }
    
    public Builder SetMinSize(Vector2 size)
    {
      _setting.MinSize = size;
      return this;
    }
    
    public Builder SetMaxSize(Vector2 size)
    {
      _setting.MaxSize = size;
      return this;
    }

    public WindowSetting Build() => _setting;
  }
}