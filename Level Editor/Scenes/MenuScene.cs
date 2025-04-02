using System.Numerics;
using ImGuiNET;
using Level_Editor.Utils;

namespace Level_Editor.Scenes;

public static class MenuScene
{
  public static void Render(EditorWindow editor)
  {
    ImGui.Begin("Menu", ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoResize);
    
    ImGui.SetWindowPos(Vector2.One * editor.fullscreeenSpace);
    ImGui.SetWindowSize(editor.windowSize - Vector2.One * editor.fullscreeenSpace * 2f);
    
    ImGui.Text("Menu");
    
    ImGui.End();
  }
}