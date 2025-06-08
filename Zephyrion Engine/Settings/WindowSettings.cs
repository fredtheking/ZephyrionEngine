using System.Numerics;
using Raylib_cs;
using ZephyrionEngine.Utils.Etc;

namespace ZephyrionEngine.Settings;

public class WindowSettings
{
  #region Fields
  
  public string Title { get; set; } = "Hello, Zephyrion!";

  private float _transparency = 1f;
  public float Transparency
  {
    get => _transparency;
    set
    {
      _transparency = value;
      ZE.M.PND.Add(() => Raylib.SetWindowOpacity(_transparency));
    }
  }

  public Color BackgroundColor { get; set; } = Color.Black;
  public bool SoundOn { get; set; } = true;
  
  private Vector2 _position = new(-1, -1);
  public Vector2 Position
  {
    get => _position;
    set
    {
      ZE.M.PND.Add(() =>
      {
        Vector2 newPos = value == new Vector2(-1) ? new Vector2(Raylib.GetRenderWidth()/2, Raylib.GetRenderHeight()/2) : value;
        _position = newPos;
        Raylib.SetWindowPosition((int)newPos.X, (int)newPos.Y);
      });
    }
  }
  
  public ConfigFlags Flags { get; set; } = ConfigFlags.AlwaysRunWindow | ConfigFlags.VSyncHint;
  
  private Vector2 _size = new(800, 600);
  public Vector2 Size
  {
    get => _size;
    set
    {
      _size = value;
      if (!ZE.M.SYS.EngineStarted) return;
      ZE.M.PND.Add(() => Raylib.SetWindowSize((int)_size.X, (int)_size.Y));
    }
  }
  
  private Vector2 _minSize = new(-1);
  public Vector2 MinSize
  {
    get => _minSize;
    set
    {
      _minSize = value;
      ZE.M.PND.Add(() => Raylib.SetWindowMinSize((int)_minSize.X, (int)_minSize.Y));
    }
  }
  
  private Vector2 _maxSize = new(-1);
  public Vector2 MaxSize
  {
    get => _maxSize;
    set
    {
      _maxSize = value;
      ZE.M.PND.Add(() => Raylib.SetWindowMaxSize((int)_maxSize.X, (int)_maxSize.Y));
    }
  }
  
  private int _fps = 240;
  public int Fps
  {
    get => _fps;
    set
    {
      if (_fps == value) return;
      _fps = value;
      ZE.M.PND.Add(() => Raylib.SetTargetFPS(_fps));
    }
  }
  
  #endregion Fields
  #region Builder

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
    public Builder SetPosition(int x, int y) =>
      SetPosition(new Vector2(x, y));
    public Builder SetPosition(int xy) =>
      SetPosition(new Vector2(xy));
    
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
    public Builder SetSize(int width, int height) =>
      SetSize(new Vector2(width, height));
    public Builder SetSize(int widthXheight) =>
      SetSize(new Vector2(widthXheight));
    
    public Builder SetMinSize(Vector2 size)
    {
      _settings.MinSize = size;
      return this;
    }
    public Builder SetMinSize(int width, int height) =>
      SetMinSize(new Vector2(width, height));
    public Builder SetMinSize(int widthXheight) =>
      SetMinSize(new Vector2(widthXheight));
    
    public Builder SetMaxSize(Vector2 size)
    {
      _settings.MaxSize = size;
      return this;
    }
    public Builder SetMaxSize(int width, int height) =>
      SetMaxSize(new Vector2(width, height));
    
    public Builder SetFps(int fps)
    {
      _settings.Fps = fps;
      return this;
    }

    public WindowSettings Build() => _settings;
  }
  
  #endregion Builder
}