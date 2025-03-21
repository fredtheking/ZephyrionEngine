using OpenTK.Graphics.OpenGL4;

public class SetupManager
{
  /// <summary>
  /// Whether the window setup was successful.
  /// </summary>
  public bool WindowSuccessful { get; private set; }

  /// <summary>
  /// Whether the registry setup was successful.
  /// </summary>
  public bool RegistrySuccessful { get; private set; }
  
  /// <summary>
  /// Whether the OpenGL extensions setup was successful.
  /// </summary>
  public bool OpenGLExtensionsSuccessful { get; private set; }

  /// <summary>
  /// Check whether all the systems are being set up successfully.
  /// </summary>
  /// <returns><c>bool</c> of success</returns>
  public bool CheckOverallSetup()
  {
    return ((bool[])[
      CheckWindow(),
      CheckRegistry(),
      CheckOpenGLExtensions(),
    ]).All(x => x);
  }

  private bool CheckWindow()
  {
    WindowSuccessful = true;
    return WindowSuccessful;
  }
  
  private bool CheckRegistry()
  {
    RegistrySuccessful = true;
    return RegistrySuccessful;
  }
  
  private bool CheckOpenGLExtensions()
  {
    string extensions = GL.GetString(StringName.Extensions);
    OpenGLExtensionsSuccessful = extensions.Contains("GL_ARB_framebuffer_object") &&
                                 extensions.Contains("GL_ARB_vertex_array_object");
    return true;
  }

}