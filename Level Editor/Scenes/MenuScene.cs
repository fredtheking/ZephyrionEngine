using System.Numerics;
using ImGuiNET;
using Level_Editor.Utils;

namespace Level_Editor.Scenes;

public static class MenuScene
{
  public static void Render(EditorWindow editor)
  {
    ImGui.Begin("Menu", ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoResize);
    ImGui.SetWindowPos(Vector2.Zero);
    ImGui.SetWindowSize(editor.windowSize);
    
    ImGui.Text("Menu");
    
    ImGui.End();
  }
}