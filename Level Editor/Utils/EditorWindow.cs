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
    Raylib.InitWindow(1360, 1024, "Level Editor - ...");
    Raylib.InitAudioDevice();
    rlImGui.Setup(enableDocking: true);
    ChangeScene(EditorSceneNames.Menu);

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
      Raylib.ClearBackground(Color.DarkGray);
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
    }
    
    rlImGui.Shutdown();
    Raylib.CloseAudioDevice();
    Raylib.CloseWindow();
  }

  public void ChangeScene(EditorSceneNames sceneName)
  {
    currentScene = sceneName;
    Raylib.SetWindowTitle("Level Editor - " + sceneName);
  }
}