using System.Numerics;
using Raylib_cs;

namespace ZephyrionEngine.Settings;

public class WindowSettings
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

  private int _fps = 240;

  public int Fps
  {
    get => _fps;
    set
    {
      _fps = value;
      Raylib.SetTargetFPS(_fps);
    }
  }


  public class Builder
  {
    private readonly WindowSettings _settings = new();
  
    public Builder SetTitle(string title)
    {
      _settings.Title = title;
      return this;
    }
    
    public Builder SetTransparency(float transparency)
    {
      _settings.Transparency = transparency;
      return this;
    }
    
    public Builder SetBackgroundColor(Color backgroundColor)
    {
      _settings.BackgroundColor = backgroundColor;
      return this;
    }
    
    public Builder SetSoundOn(bool turned)
    {
      _settings.SoundOn = turned;
      return this;
    }
    
    /// <summary>
    /// Put "Vector2(-1, -1)" to center
    /// </summary>
    /// <param name="position">Start position of window. Pivot point is center</param>
    /// <returns></returns>
    public Builder SetPosition(Vector2 position)
    {
      _settings.Position = position;
      return this;
    }
    
    public Builder SetFlags(ConfigFlags flags)
    {
      _settings.Flags = flags;
      return this;
    }
    
    public Builder SetSize(Vector2 size)
    {
      _settings.Size = size;
      return this;
    }
    
    public Builder SetMinSize(Vector2 size)
    {
      _settings.MinSize = size;
      return this;
    }
    
    public Builder SetMaxSize(Vector2 size)
    {
      _settings.MaxSize = size;
      return this;
    }
    
    public Builder SetFps(int fps)
    {
      _settings.Fps = fps;
      return this;
    }

    public WindowSettings Build() => _settings;
  }
}