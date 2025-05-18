using System.Numerics;
using ImGuiNET;
using Raylib_cs;
using rlImGui_cs;

namespace Level_Editor.Utils;

public enum EditorSceneNames
{
  Menu,
  Editor
}

public class EditorWindow 
{
  public Action<EditorWindow>? Global;
  public Dictionary<EditorSceneNames, Action<EditorWindow>>? MainLoopEvents;
  public EditorSceneNames currentScene;
  public RenderTexture2D renderTexture;
  public List<Action> LateActions = [];
  
  public bool debug;
  public Vector2 windowSize;
  public readonly float fullscreeenSpace = 24f;

  public EditorWindow()
  {
    #if DEBUG
    debug = true;
    #endif
  }
  
  public void Run()
  {
    if (Global == null)
      throw new Exception("Global event is null. Consider adding it.");
    if (MainLoopEvents == null)
      throw new Exception("MainLoopEvents is null. Consider adding it.");
    
    Raylib.SetConfigFlags(ConfigFlags.ResizableWindow | ConfigFlags.AlwaysRunWindow);
    Raylib.InitWindow(1360, 1024, "Zephyrion Level Editor - ...");
    Raylib.InitAudioDevice();
    rlImGui.Setup(enableDocking: true);
    renderTexture = Raylib.LoadRenderTexture(1920, 1080);
    ChangeScene(EditorSceneNames.Menu);
    
    ImGui.CreateContext();
    var io = ImGui.GetIO();

    io.ConfigFlags |= ImGuiConfigFlags.DockingEnable;
    io.ConfigFlags |= ImGuiConfigFlags.ViewportsEnable;
    
    ImGui.SetCurrentContext(io.Ctx);
    
    Rlgl.DrawRenderBatchActive();

    while (!Raylib.WindowShouldClose())
    {
      windowSize = new Vector2(Raylib.GetRenderWidth(), Raylib.GetRenderHeight());
      #if DEBUG
      if (Raylib.IsKeyPressed(KeyboardKey.F3)) debug = !debug;
      if (Raylib.IsKeyPressed(KeyboardKey.F2))
      {
        var length = Enum.GetNames<EditorSceneNames>().Length;
        var index = ((int)currentScene + 1) % length;
        ChangeScene((EditorSceneNames)index);
      }
      if (Raylib.IsKeyPressed(KeyboardKey.F1))
      {
        var length = Enum.GetNames<EditorSceneNames>().Length;
        var index = ((int)currentScene - 1 + length) % length;
        ChangeScene((EditorSceneNames)index);
      }
      #endif
      
      Raylib.BeginDrawing();
      Raylib.ClearBackground(new Color(0, 0, 0, 123));
      ViewportUpdate();
      rlImGui.Begin();
      
      MainLoopEvents[currentScene].Invoke(this);
      Global.Invoke(this);

      rlImGui.End();
      
      if (debug)
      {
        Raylib.DrawFPS(10, 10);
        Raylib.DrawText($"Current: {currentScene.ToString()}", 10, 30, 14, Color.LightGray);
      }

      Raylib.EndDrawing();

      foreach (Action lateAction in LateActions)
        lateAction();
      LateActions.Clear();
    }
    
    if (Raylib.IsWindowReady()) Close();
  }

  public static void Close()
  {
    rlImGui.Shutdown();
    Raylib.CloseAudioDevice();
    Raylib.CloseWindow();
  }

  public void ResizeRenderTexture(Vector2 newResolution)
  {
    Raylib.UnloadRenderTexture(renderTexture);
    renderTexture = Raylib.LoadRenderTexture((int)newResolution.X, (int)newResolution.Y);
  }

  public void ChangeScene(EditorSceneNames sceneName)
  {
    currentScene = sceneName;
    Raylib.SetWindowTitle("Zephyrion Level Editor - " + sceneName);
  }

  private void ViewportUpdate()
  {
    Raylib.BeginTextureMode(renderTexture);
    
    Raylib.ClearBackground(Color.Yellow);
    Raylib.DrawText("Hello, world!", 10, 50, 60, Color.White);
    
    Raylib.EndTextureMode();
  }
}